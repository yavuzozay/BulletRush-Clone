using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{

    [SerializeField]private bool canAttack = true;
    [SerializeField]private GameObject bullet;
    private Transform attackTransform;
   
    PlayerController playerController;


    //Player States
    private Animator animator;
    private bool isIdle = true;
    private bool isAttacking = false;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        attackTransform = transform.GetChild(0);
        animator = GetComponent<Animator>();
    }


  

    private void Update()
    {
        UpdateAnims();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EventManager.Fire_OnGameOver();
        }
    }
    private void FixedUpdate()
    {
        FireAttack();
    }

   
    private void UpdateAnims()
    {
        animator.SetBool("isIdle", isIdle);
        animator.SetBool("isAttacking", isAttacking);
    }
    private void FireAttack()
    {

        if (canAttack&&playerController.isFireBtnPressed)
        {

            isAttacking = true;
            isIdle = false;
             canAttack = false;
            //pool sistemi eklenecek..
             Instantiate(bullet, attackTransform.position, transform.rotation);
             StartCoroutine(AttackTimer());
        }
        else if (!playerController.isFireBtnPressed)
        {
            isIdle = true;
            isAttacking = false;
        }

    }
    IEnumerator AttackTimer()
    {
            yield return new WaitForSeconds(.15f);
            canAttack = true;

    }
    void OnLevelCompleted()
    {
        canAttack = true;
    }

    private void OnEnable()
    {
        EventManager.OnLevelCompleted += OnLevelCompleted;
    }
    private void OnDisable()
    {
        EventManager.OnLevelCompleted -= OnLevelCompleted;

    }


}
