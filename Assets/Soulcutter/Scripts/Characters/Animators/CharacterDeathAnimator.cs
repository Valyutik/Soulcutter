using UnityEngine;

namespace Soulcutter.Scripts.Characters.Animators
{
    public class CharacterDeathAnimator
    {
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        
        private readonly Animator _animator;    
        
        public CharacterDeathAnimator(Animator animator)
        {
            _animator = animator;
        }
        
        public void SetDieAnimation()
        {
            _animator.SetTrigger(IsDead);
        }
    }
}