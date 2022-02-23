using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private Vector3 enemySpawnPos;
    private int _simpleEnemyCount = 0;
    private int _bigEnemyCount = 0;

    public int simpleEnemyCount
    {
        get {return _simpleEnemyCount; }
       
    }
    public int bigEnemyCount
    {
        get { return _bigEnemyCount; }

    }
    
    public void DecreaseSimpleEnemyCount()
    {
        _simpleEnemyCount --;
        CheckEnemyCount();

        EventManager.Fire_OnSimpleEnemyCountChanged(_simpleEnemyCount);

    }
    public void DecreaseBigEnemyCount()
    {
        _bigEnemyCount--;
        EventManager.Fire_OnBigEnemyCountChanged(_bigEnemyCount);
        CheckEnemyCount();

    }
    private void CheckEnemyCount()
    {
        if (simpleEnemyCount <= 0 && bigEnemyCount <= 0 && GameManager.Instance.isGameActive)
        {
            EventManager.Fire_OnLevelCompleted();
            Debug.Log(simpleEnemyCount+""+bigEnemyCount);
        }
    }

    private void Start()
    {
      // SpawnEnemy(10);
        // Test Function
         
    }
    private void Update()
    {
      //  Debug.Log("k" + _simpleEnemyCount + "b" + _bigEnemyCount);
    }
    public void SpawnEnemy(int level)
    {
       

        Vector3 addPos = new Vector3(0,0,5);
        float addXPos = 0f;
        float addZPos = 0f;
        for (int i = 0; i < level+3; i++)
        {
            addPos.x = 1.5f * (i % 3)-3/2;

            if (i % 3 == 0&& i!=0)
            {
                
                addZPos+=1.9f;
                addPos.z = addZPos;
                addPos.y = .75f;
                Instantiate(enemies[1], enemySpawnPos + addPos, enemies[1].transform.rotation);
                _bigEnemyCount++;
                EventManager.Fire_OnBigEnemyCountChanged(_bigEnemyCount);


            }

            else
            {
               
                addPos.z = addZPos;
                addPos.y = .5f;
                Instantiate(enemies[0], enemySpawnPos + addPos, enemies[0].transform.rotation);
                _simpleEnemyCount++;
                EventManager.Fire_OnSimpleEnemyCountChanged(_simpleEnemyCount);


            }
        }
    }

}
