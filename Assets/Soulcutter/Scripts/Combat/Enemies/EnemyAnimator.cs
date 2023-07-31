using UnityEngine;

namespace Soulcutter.Scripts.Combat.Enemies
{
    public class EnemyAnimator
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int AttackSpeed = Animator.StringToHash("AttackSpeed");
        private static readonly int IsRun = Animator.StringToHash("IsRun");
        private static readonly int VelocityX = Animator.StringToHash("Velocity X");
        private static readonly int VelocityY = Animator.StringToHash("Velocity Y");

        private Vector2 _direction;
        private readonly Animator _animator;

        public EnemyAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void SetAttackAnimation(float time)
        {
            var multiplier = 1 / time;
            var speedAnimation = 1 * multiplier;
            _animator.SetFloat(AttackSpeed, speedAnimation);
            _animator.SetTrigger(Attack);
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