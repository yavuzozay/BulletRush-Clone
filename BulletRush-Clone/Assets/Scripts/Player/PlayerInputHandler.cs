using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerMechanic.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
       
        [SerializeField] private Joystick _joystick;

        [SerializeField]
        private Button _fireButton;

        private Vector3 _direction;
        public event Action<Vector3> OnDirectionChanged;
        public event Action OnFireButtonPressed;

        private void Start()
        {
            _fireButton.onClick.AddListener(HandleFireButton);
        }
        private void Update()
        {
            HandleDirection();
        }
        private void HandleDirection()
        {
            _direction.x = _joystick.Horizontal;
            _direction.z = _joystick.Vertical;
            OnDirectionChanged?.Invoke(_direction);
        }
        private void HandleFireButton()
        {
            OnFireButtonPressed?.Invoke();
            Debug.Log("fire button clicked");
        }
    }
}

