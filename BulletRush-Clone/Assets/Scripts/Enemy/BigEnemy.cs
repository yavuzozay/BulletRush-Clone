using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
   
    protected override void Movement()
    {
        //Big Enemy Movement
        
    }

    private void OnDestroy()
    {
        SpawnManager.Instance.DecreaseBigEnemyCount(1);
        base.OnDestroy();
    }
}
