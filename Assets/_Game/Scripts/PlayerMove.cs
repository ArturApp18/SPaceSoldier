using UnityEngine;

namespace _Game.Scripts
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _speed;

        private Vector3 _moveDirection;

        private void FixedUpdate()
        {
            _moveDirection = new Vector3(_playerInput.horizontal * _speed, 0,
                _playerInput.vertical * _speed);

            if (_playerInput.isRunning)
            {
                _rigidbody.velocity = _moveDirection;
            }
            else
            {
                _playerInput.isRunning = false;
            }

            if (_playerInput.isRotating)
            {
                Vector3 lookDirection = new Vector3(_moveDirection.x, 0,
                    _moveDirection.z);
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }
}