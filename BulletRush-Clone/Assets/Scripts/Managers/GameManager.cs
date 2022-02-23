using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private bool _isGameActive=true;
    private int _level=1;

    public bool isGameActive
    {
        get { return _isGameActive; }
    }
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
        Time.timeScale = 1f;
        _level = 1;

        //0 game sahnesinin idsi string olarak da eriþebilirdik.
        SceneManager.LoadScene(0);
    }
    private void OnGameOver()
    {
        _isGameActive = false;
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        EventManager.OnGameOver += OnGameOver;        
    }
    private void OnDisable()
    {
        EventManager.OnGameOver -= OnGameOver;

    }
}
