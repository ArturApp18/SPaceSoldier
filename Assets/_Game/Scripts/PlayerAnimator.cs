using UnityEngine;

namespace _Game.Scripts
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Animator _animator;
        
        private static readonly int IsRunnig = Animator.StringToHash("isRunnig");

        private void Update()
        {
            if (_playerInput.isRunning)
            {
                _animator.SetBool(IsRunnig, true);
            }
            else
            {
                _animator.SetBool(IsRunnig, false);
            }
        }
    }
}