using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUI : MonoBehaviour
{
    private GameObject InGamePanel;
    private GameObject GameOverPanel, LevelCompletedPanel;
    private TextMeshProUGUI sEnemyCountTMPro, bEnemyCountTMPro,lvlTMpro;
    private Button Btn;
    private void Awake()
    {
        InGamePanel = transform.GetChild(0).gameObject;
        GameOverPanel = transform.GetChild(1).gameObject;
        LevelCompletedPanel = transform.GetChild(2).gameObject;
        sEnemyCountTMPro = InGamePanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        bEnemyCountTMPro = InGamePanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        lvlTMpro = InGamePanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        lvlTMpro.text = "level :" +GameManager.Instance.level;
    }

    private void OnSimpleEnemyCountChanged(int count)
    {
        sEnemyCountTMPro.text = "Kalan düþman sayýsý :" + count;
    }
    private void OnBigEnemyCountChanged(int count)
    {
        bEnemyCountTMPro.text = "Kalan büyük düþman sayýsý :" + count;

    }
    private void OnLevelCompleted()
    {
        GameManager.Instance.IncreaseLevel();
        LevelCompletedPanel.gameObject.SetActive(true);
    }
    private void OnGameOver()
    {
        GameOverPanel.SetActive(true);
    }


    private void OnEnable()
    {
        EventManager.OnGameOver += OnGameOver;
        EventManager.OnSimpleEnemyCountChanged += OnSimpleEnemyCountChanged;
        EventManager.OnBigEnemyCountChanged += OnBigEnemyCountChanged;
        EventManager.OnLevelCompleted += OnLevelCompleted;

    }
    private void OnDisable()
    {
        EventManager.OnGameOver -= OnGameOver;
        EventManager.OnSimpleEnemyCountChanged -= OnSimpleEnemyCountChanged;
        EventManager.OnBigEnemyCountChanged -= OnBigEnemyCountChanged;
        EventManager.OnLevelCompleted += OnLevelCompleted;




    }


}
