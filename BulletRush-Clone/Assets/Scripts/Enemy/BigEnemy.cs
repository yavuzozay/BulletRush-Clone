using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
   [SerializeField] private Transform emptyTargetPrefb;
    private Rigidbody enemyRb;
    List<Transform> targets;
   [SerializeField] private int curTarget=0;
    Vector3 targetPos;
    private Transform playerTransform;
    private void Awake()
    {
        targets = new List<Transform>();
        playerTransform = PlayerData.Instance.transform;
        enemyRb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            AddTarget();
        }
        targets.Add(playerTransform);
        targetPos = targets[0].transform.position;
    }
    private void FixedUpdate()
    {
        Movement();
    }
    protected override void Movement()
    {
        if (targets.Count==0)
        {
            return;
        }
        float dist = Vector3.Distance(transform.position, targets[0].position);
        targetPos = Vector3.MoveTowards(transform.position,targets[0].position , Time.fixedDeltaTime / 10 * _speed);
        enemyRb.MovePosition(targetPos);

        if (curTarget < targets.Count - 1)
        {

            if (dist < .25)
            {
                Destroy(targets[0].gameObject);
                targets.RemoveAt(0);
                //targetPos = targets[curTarget].transform.position;

               // curTarget++;
                Debug.Log(curTarget);

            }

        }
      
    }

    public override void Die()
    {

        SpawnManager.Instance.DecreaseBigEnemyCount();

        Destroy(gameObject);

    }
    private void AddTarget()
    {
        float rndX = Random.Range(-2f, 2f);
        float rndz = Random.Range(-3f, -1f);
        Vector3 pos = playerTransform.position+ new Vector3(rndX, 0, rndz);
        Transform clone = Instantiate(emptyTargetPrefb, pos, emptyTargetPrefb.rotation);
        targets.Add(clone);

    }

}
