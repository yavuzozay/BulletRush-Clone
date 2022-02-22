using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

  private bool isGameActive;
  public void RestrartGame()
    {
        //0 game sahnesinin idsi string olarak da eriþebilirdik.
        SceneManager.LoadScene(0);
    }
}
