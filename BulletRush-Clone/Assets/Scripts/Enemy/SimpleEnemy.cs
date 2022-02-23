using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    protected override void Movement()
    {
        //Simple enemy movement
    }
    private void Die()
    {
        SpawnManager.Instance.DecreaseBigEnemyCount(1);

        base.Die();
    }

}
