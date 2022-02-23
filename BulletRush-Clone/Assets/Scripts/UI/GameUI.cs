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
    private Button nextLevelBtn,restrartBtn;
    private void Awake()
    {
        InGamePanel = transform.GetChild(0).gameObject;
        GameOverPanel = transform.GetChild(1).gameObject;
        restrartBtn = GameOverPanel.transform.GetChild(0).gameObject.GetComponent<Button>();
        LevelCompletedPanel = transform.GetChild(2).gameObject;
        nextLevelBtn = LevelCompletedPanel.transform.GetChild(0).gameObject.GetComponent<Button>();
        sEnemyCountTMPro = InGamePanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        bEnemyCountTMPro = InGamePanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        lvlTMpro = InGamePanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        lvlTMpro.text = "level :" +GameManager.Instance.level;
        restrartBtn.onClick.AddListener(RestrartButton);
        nextLevelBtn.onClick.AddListener(LoadNextLevel);
    }


    private void RestrartButton()
    {
        GameManager.Instance.RestrartGame();
    }
    private void LoadNextLevel()
    {
        PlayerData.Instance.gameObject.SetActive(true);
        GameOverPanel.SetActive(false);
        InGamePanel.SetActive(true);

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
        InGamePanel.SetActive(false);

        GameManager.Instance.IncreaseLevel();
        LevelCompletedPanel.gameObject.SetActive(true);
    }
    private void OnGameOver()
    {
        InGamePanel.SetActive(false);
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
        EventManager.OnLevelCompleted -= OnLevelCompleted;




    }


}
