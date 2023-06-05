using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMechanic.Input;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private PlayerInputHandler _inputHandler;

    private Vector3 _direction;

    private Rigidbody playerRb;
 
    
    public bool isFireBtnPressed=false;

    private void Awake()
    {
        _inputHandler = GetComponent<PlayerInputHandler>();
        playerRb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        _inputHandler.OnDirectionChanged += OnDirectionChanged;
    }
    private void OnDisable()
    {
        _inputHandler.OnDirectionChanged -= OnDirectionChanged;

    }

    void Update()
    {
        Bounds.Instance.CheckBounds(Bounds.Instance.GetPlayerBounds(), this.transform);
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        RotateSmoothly();
    }

    private void OnDirectionChanged(Vector3 dir)
    {
        _direction = dir;
    }

    private void ApplyMovement()
    {
        playerRb.velocity = _direction * Player.Instance.GetSpeed();
    }
    private void RotateSmoothly()
    {
        Vector3 lookAtPosition = transform.position + _direction;
        transform.LookAt(lookAtPosition);

    }

}
