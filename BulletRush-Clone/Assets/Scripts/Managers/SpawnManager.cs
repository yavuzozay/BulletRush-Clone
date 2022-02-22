using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
  [SerializeField]private List<GameObject>enemies;
    [SerializeField] private Vector3 enemySpawnPos;

    private void Start()
    {
        /*SpawnEnemy(10);
         Test Function
         */
    }
    public void SpawnEnemy(int level)
    {
        Vector3 addPos = new Vector3(0,0,5);
        float addXPos = 0f;
        float addZPos = 0f;
        for (int i = 0; i < level; i++)
        {
            addPos.x = 1.5f * (i % 3);

            if (i % 3 == 0&& i!=0)
            {
                
                addZPos+=1.9f;
                addPos.z = addZPos;
                addPos.y = .75f;
                Instantiate(enemies[1], enemySpawnPos + addPos, enemies[1].transform.rotation);
            }
           
            else
            {
               
                addPos.z = addZPos;
                addPos.y = .5f;
                Instantiate(enemies[0], enemySpawnPos + addPos, enemies[0].transform.rotation);

            }
        }
    }

}
