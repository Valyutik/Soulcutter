using System;
using System.Threading.Tasks;
using Soulcutter.Scripts.Character.Animators;
using Soulcutter.Scripts.UI.ActionButton;
using UnityEngine;

namespace Soulcutter.Scripts.Character
{
    public class CharacterActionActivator
    {
        public event Action OnActivatedChopEvent, OnActivatedCombatAttackEvent;

        private float TimeChop { get; }

        private float TimeCombatAttack { get; }

        private readonly ActionButton _actionButton;
        private readonly CharacterActionAnimator _characterActionAnimator;
        private readonly ListenerAttackAndChopAnimationState _listenerAttackAndChopAnimationState;
        private bool _isAction;

        public CharacterActionActivator(ActionButton actionButton, Animator animator,
            float timeChop, float timeCombatAttack)
        {
            _isAction = true;
            _actionButton = actionButton;
            _characterActionAnimator = new CharacterActionAnimator(animator);
            _listenerAttackAndChopAnimationState = _characterActionAnimator.ListenerAttackAndChopAnimationState;
            TimeChop = timeChop;
            TimeCombatAttack = timeCombatAttack;

            _actionButton.OnPressAttackEvent += OnActivatedCombatAttack;
            _actionButton.OnPressChopEvent += OnActivatedChop;

            _listenerAttackAndChopAnimationState.OnStateExitEvent += OnActivatedAction;
        }

        public void Deconstruct()
        {
            _actionButton.OnPressAttackEvent -= OnActivatedCombatAttack;
            _actionButton.OnPressChopEvent -= OnActivatedChop;

            _listenerAttackAndChopAnimationState.OnStateExitEvent -= OnActivatedAction;
        }

        private void OnActivatedAction() => _isAction = true;

        private async void OnActivatedChop()
        {
            if (!_isAction) return;
            _characterActionAnimator.SetChopAnimation(TimeChop);
            await Task.Delay(Convert.ToInt32(TimeChop * 1000) / 2);
            OnActivatedChopEvent?.Invoke();
            _isAction = false;
        }
        private async void OnActivatedCombatAttack()
        {
            if (!_isAction) return;
            _characterActionAnimator.SetAttackAnimation(TimeCombatAttack);
            await Task.Delay(Convert.ToInt32(TimeCombatAttack * 1000) / 2);
            OnActivatedCombatAttackEvent?.Invoke();
            _isAction = false;
        }
    }
}