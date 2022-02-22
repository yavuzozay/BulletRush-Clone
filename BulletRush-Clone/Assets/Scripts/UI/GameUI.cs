using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUI : MonoBehaviour
{
    private GameObject InGamePanel;
    private GameObject GameOverPanel;
    private TextMeshProUGUI sEnemyCountTMPro, bEnemyCountTMPro;
    //private Button g
    private void Awake()
    {
        InGamePanel = transform.GetChild(0).gameObject;
        GameOverPanel = transform.GetChild(1).gameObject;
        sEnemyCountTMPro = InGamePanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        bEnemyCountTMPro = InGamePanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnSimpleEnemyCountChanged(int count)
    {
        sEnemyCountTMPro.text = "Kalan düþman sayýsý :" + count;
    }
    private void OnBigEnemyCountChanged(int count)
    {
        bEnemyCountTMPro.text = "Kalan büyük düþman sayýsý :" + count;

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

    }
    private void OnDisable()
    {
        EventManager.OnGameOver -= OnGameOver;
        EventManager.OnSimpleEnemyCountChanged -= OnSimpleEnemyCountChanged;
        EventManager.OnBigEnemyCountChanged -= OnBigEnemyCountChanged;



    }


}
