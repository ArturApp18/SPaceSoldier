using UnityEngine;

namespace _Game.Scripts
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _speed;

        private Vector3 _moveDirection;

        private bool _isRotating;
        private Quaternion _startRotation;

        private void FixedUpdate()
        {
            CalculateMoveDirection();
            UpdateRotation();
            UpdatePosition();
        }

        private void CalculateMoveDirection()
        {
            _moveDirection = new Vector3(_playerInput.horizontal * _speed, 0,
                _playerInput.vertical * _speed);
        }

        private void UpdateRotation()
        {
            if (_playerInput.isRotating)
            {
                Quaternion lookDirection = transform.rotation * Quaternion.LookRotation(_moveDirection);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection, 0.05f);
            }
        }

        private void UpdatePosition()
        {
            if (_playerInput.isRunning)
                _rigidbody.velocity = transform.forward * _speed;
            else
                _rigidbody.velocity = Vector3.zero;
        }
    }
}