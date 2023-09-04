using UnityEngine;

namespace Soulcutter.Scripts.Characters.Animators
{
    public class CharacterMovementAnimator
    {
        private static readonly int IsRun = Animator.StringToHash("IsRun");
        private static readonly int VelocityX = Animator.StringToHash("Velocity X");
        private static readonly int VelocityY = Animator.StringToHash("Velocity Y");
        
        private readonly Animator _animator;
        
        public CharacterMovementAnimator(Animator animator)
        {
            _animator = animator;
        }
        
        public void SetRunAnimation()
        {
            _animator.SetBool(IsRun, true);
        }
        
        public void SetIdleAnimation()
        {
            _animator.SetBool(IsRun, false);
        }
        
        public void SetDirectionAnimation(Vector2 direction)
        {
            if (direction == Vector2.zero) return;
            _animator.SetFloat(VelocityX, direction.x);
            _animator.SetFloat(VelocityY, direction.y);
        }
    }
}