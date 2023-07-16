using UnityEngine;

namespace Soulcutter.Scripts.Character
{
    public class CharacterAnimator
    {
        private static readonly int IsRun = Animator.StringToHash("isRun");
        private static readonly int VelocityX = Animator.StringToHash("Velocity X");
        private static readonly int VelocityY = Animator.StringToHash("Velocity Y");
        private static readonly int OldVelocityX = Animator.StringToHash("OldVelocity X");
        private static readonly int OldVelocityY = Animator.StringToHash("OldVelocity Y");
        
        private readonly Animator _animator;
        private Vector2 _direction;

        public CharacterAnimator(Animator animator)
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
            _animator.SetFloat(OldVelocityX, _direction.x);
            _animator.SetFloat(OldVelocityY, _direction.y);
        }

        public void SetDirectionAnimation(Vector2 direction)
        {
            _direction = direction;
            _animator.SetFloat(VelocityX, direction.x);
            _animator.SetFloat(VelocityY, direction.y);
        }
    }
}