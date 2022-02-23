using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Singleton<PlayerData>
{
    [SerializeField] private float speed;
    public float GetSpeed() { return speed; }
    public Vector3 startPos { get; private set; }
    private void Awake()
    {
        startPos = gameObject.transform.position;
    }
    private void OnLevelCompleted()
    {
        transform.position = startPos;
        PlayerData.Instance.gameObject.SetActive(false);

    }
    private void OnEnable()
    {
        EventManager.OnLevelCompleted += OnLevelCompleted;
    }
    private void OnDisable()
    {
        EventManager.OnLevelCompleted -= OnLevelCompleted;

    }
}
