using UnityEngine;

namespace _Game.Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private JoyStickInput _joyStick;

        public bool isRunning;
        public bool isRotating;

        public float horizontal;
        public float vertical;

        private void Update()
        {
            horizontal = _joyStick.InputDir.x != 0 ? _joyStick.InputDir.x : Input.GetAxis("Horizontal");

            vertical = _joyStick.InputDir.y != 0 ? _joyStick.InputDir.y : Input.GetAxis("Vertical");

            if (horizontal > 0.6f || vertical > 0.6f || horizontal < -0.6f || vertical < -0.6f)
                isRunning = true;
            else
                isRunning = false;

            if (horizontal != 0 || vertical != 0)
                isRotating = true;
            else
                isRotating = false;
        }
    }
}