using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    protected override void Movement()
    {
        //Simple enemy movement
    }
    private void OnDestroy()
    {
        SpawnManager.Instance.DecreaseSimpleEnemyCount(1);
        base.OnDestroy();
    }

}
