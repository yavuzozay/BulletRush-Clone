using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private float _speed;
    public float GetSpeed() { return _speed; }
    public Vector3 _startPos { get; private set; }
    private void Awake()
    {
        _startPos = gameObject.transform.position;
    }
    private void OnLevelCompleted()
    {
        transform.position = _startPos;
        gameObject.SetActive(false);

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
