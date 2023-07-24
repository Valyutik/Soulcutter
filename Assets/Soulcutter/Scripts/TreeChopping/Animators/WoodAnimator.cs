using UnityEngine;

namespace Soulcutter.Scripts.TreeChopping.Animators
{
    public class WoodAnimator
    {
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int IsFalling = Animator.StringToHash("IsFalling");
        
        private readonly Animator _animator;

        public WoodAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void SetHitAnimation()
        {
            _animator.SetTrigger(Hit);
        }

        public void SetFallingAnimation()
        {
            _animator.SetBool(IsFalling, true);
        }
    }
}