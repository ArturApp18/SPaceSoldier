using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private JoyStickInput _joyStick;

        public float horizontal;
        public float vertical;
        public bool isRunning;

        private void Update()
        {
            horizontal = _joyStick.InputDir.x != 0 ? _joyStick.InputDir.x : Input.GetAxis("Horizontal");

            vertical = _joyStick.InputDir.y != 0 ? _joyStick.InputDir.y : Input.GetAxis("Vertical");
        }
    }
}