using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{

    [SerializeField]private bool canAttack = true;
    [SerializeField]private GameObject bullet;
    private Transform attackTransform;
   
    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        attackTransform = transform.GetChild(0);
        
    }


    private void Start()
    {

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
    private void FireAttack()
    {

        if (canAttack&&playerController.isFireBtnPressed)
        {
             canAttack = false;
             Instantiate(bullet, attackTransform.position, transform.rotation);
             StartCoroutine(AttackTimer());
        }

    }
    IEnumerator AttackTimer()
    {

        //.25 saniye sonra tekrar atak yapabilir...
        
            yield return new WaitForSeconds(.25f);
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
