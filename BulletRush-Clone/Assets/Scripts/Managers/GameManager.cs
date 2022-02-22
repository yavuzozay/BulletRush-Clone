using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private bool isGameActive;
    private int _level=1;
    public int level
    {
        get {return _level; }
    }
    private void Start()
    {
        LoadLevel();
    }
    public void IncreaseLevel()
    {
        _level++;
    }
    public void LoadLevel()
    {
        SpawnManager.Instance.SpawnEnemy(_level);
    }
  public void RestrartGame()
    {
        //0 game sahnesinin idsi string olarak da eriþebilirdik.
        SceneManager.LoadScene(0);
    }
}
