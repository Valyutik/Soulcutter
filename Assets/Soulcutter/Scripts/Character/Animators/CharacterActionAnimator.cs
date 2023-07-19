using UnityEngine;

namespace Soulcutter.Scripts.Character.Animators
{
    public class CharacterActionAnimator
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Chop = Animator.StringToHash("Chop");
        private static readonly int ChoppingSpeed = Animator.StringToHash("ChoppingSpeed");
        private static readonly int AttackSpeed = Animator.StringToHash("AttackSpeed");

        private Vector2 _direction;
        private readonly Animator _animator;

        public ListenerAttackAndChopAnimationState ListenerAttackAndChopAnimationState =>
            _animator.GetBehaviour<ListenerAttackAndChopAnimationState>();

        public CharacterActionAnimator(Animator animator)
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

        public void SetChopAnimation(float time)
        {
            var multiplier = 1 / time;
            var speedAnimation = 1 * multiplier;
            _animator.SetFloat(ChoppingSpeed, speedAnimation);
            _animator.SetTrigger(Chop);
        }
    }
}