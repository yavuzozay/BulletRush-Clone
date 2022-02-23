using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    private Rigidbody enemyRb;
    private Vector3 target;
    private Transform playerTransform;
    

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerTransform = PlayerData.Instance.transform;
    }
    private void FixedUpdate()
    {
        Movement();
    }
    protected override void Movement()
    {
        target = Vector3.Lerp(transform.position, playerTransform.position, Time.fixedDeltaTime*_speed/10);
        enemyRb.MovePosition(target);
    }

    public override void Die()
    {
        SpawnManager.Instance.DecreaseSimpleEnemyCount();
        Destroy(gameObject);
    }
}
