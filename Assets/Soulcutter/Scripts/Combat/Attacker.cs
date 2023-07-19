using Soulcutter.Scripts.Character.Animators;
using Soulcutter.Scripts.InteractionObjectDetectors;
using Soulcutter.Scripts.UI.ActionButton;
using UnityEngine;

namespace Soulcutter.Scripts.Combat
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private float attackTime = 1;
        private CharacterActionAnimator _characterActionAnimator;
        private ActionButton _actionButton;
        private ListenerAttackAndChopAnimationState _listenerAttackAndChopAnimationState;
        private bool _isAttacking;

        public void Initialize(InteractionObjectDetector detector,
            CharacterActionAnimator characterActionAnimator, ActionButton actionButton)
        {
            _isAttacking = true;
            _characterActionAnimator = characterActionAnimator;
            _actionButton = actionButton;
            _listenerAttackAndChopAnimationState = _characterActionAnimator.ListenerAttackAndChopAnimationState;
            
            _actionButton.OnPressAttackEvent += Attack;
            _listenerAttackAndChopAnimationState.OnStateExitEvent += ActivateAttack;
        }

        private void OnDisable()
        {
            _actionButton.OnPressAttackEvent -= Attack;
            _listenerAttackAndChopAnimationState.OnStateExitEvent -= ActivateAttack;
        }

        private void Attack()
        {
            if (!_isAttacking) return;
            _characterActionAnimator.SetAttackAnimation(attackTime);
            _isAttacking = false;
        }

        private void ActivateAttack()
        {
            _isAttacking = true;
        }
    }
}