using UnityEngine;

namespace Soulcutter.Scripts.Character.Animators
{
    public class CharacterActionAnimator
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Chop = Animator.StringToHash("Chop");
        
        private readonly Animator _animator;
        private Vector2 _direction;

        public CharacterActionAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void SetAttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }

        public void SetChopAnimation()
        {
            _animator.SetTrigger(Chop);
        }
    }
}