using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;

        [SerializeField] private float _speed;

        private Vector3 moveDirection;

        private static readonly int IsRunnig = Animator.StringToHash("isRunnig");

        private void FixedUpdate()
        {
            moveDirection = new Vector3(_playerInput.horizontal * _speed, 0,
                _playerInput.vertical * _speed);
            if (MoveCheck())
            {
                _playerInput.isRunning = true;
                _rigidbody.velocity = moveDirection;
            }
            else
            {
                _playerInput.isRunning = false;
            }

            if (RotationCheck())
            {
                Vector3 lookDirection = new Vector3(moveDirection.x, 0,
                    moveDirection.z);
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
            else
            {
            }
        }

        private bool MoveCheck() =>
            _playerInput.horizontal > 0.6f || _playerInput.vertical > 0.6f ||
            _playerInput.horizontal < -0.6f || _playerInput.vertical < -0.6f;

        private bool RotationCheck() =>
            _playerInput.horizontal != 0 || _playerInput.vertical != 0;
    }
}