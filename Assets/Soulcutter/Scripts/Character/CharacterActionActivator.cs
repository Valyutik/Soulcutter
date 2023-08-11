using System;
using System.Threading.Tasks;
using Soulcutter.Scripts.Character.Animators;
using Soulcutter.Scripts.UI.ActionButton;
using UnityEngine;

namespace Soulcutter.Scripts.Character
{
    public class CharacterActionActivator
    {
        public event Action OnActivatedChopEvent, OnActivatedAttackEvent, OnActivatedSpecialAttackEvent;

        private float TimeChop { get; }
        private float TimeAttack { get; }
        private float TimeSpecialAttack { get; }

        private readonly ActionButton _actionButton;
        private readonly CharacterActionAnimator _characterActionAnimator;
        private readonly ListenerAttackAndChopAnimationState _listenerAttackAndChopAnimationState;
        private bool _isAction;

        public CharacterActionActivator(ActionButton actionButton, Animator animator,
            float timeChop, float timeAttack, float timeSpecialAttack)
        {
            _isAction = true;
            _actionButton = actionButton;
            _characterActionAnimator = new CharacterActionAnimator(animator);
            _listenerAttackAndChopAnimationState = _characterActionAnimator.ListenerAttackAndChopAnimationState;
            TimeChop = timeChop;
            TimeAttack = timeAttack;
            TimeSpecialAttack = timeSpecialAttack;

            _actionButton.OnPressAttackEvent += OnActivatedAttack;
            _actionButton.OnPressChopEvent += OnActivatedChop;

            _listenerAttackAndChopAnimationState.OnStateExitEvent += OnActivatedAction;
        }

        public void Deconstruct()
        {
            _actionButton.OnPressAttackEvent -= OnActivatedAttack;
            _actionButton.OnPressChopEvent -= OnActivatedChop;

            _listenerAttackAndChopAnimationState.OnStateExitEvent -= OnActivatedAction;
        }

        public async void OnActivatedSpecialAttack()
        {
            if (!_isAction) return;
            _isAction = false;
            await Task.Delay(Convert.ToInt32(TimeAttack * 1000) / 2);
            _characterActionAnimator.SetSpecialAttackAnimation(TimeSpecialAttack);
            await Task.Delay(Convert.ToInt32(TimeSpecialAttack * 1000) / 2);
            OnActivatedSpecialAttackEvent?.Invoke();
        }
        
        private void OnActivatedAction() => _isAction = true;

        private async void OnActivatedChop()
        {
            if (!_isAction) return;
            _isAction = false;
            _characterActionAnimator.SetChopAnimation(TimeChop);
            await Task.Delay(Convert.ToInt32(TimeChop * 1000) / 2);
            OnActivatedChopEvent?.Invoke();
        }
        private async void OnActivatedAttack()
        {
            if (!_isAction) return;
            _isAction = false;
            _characterActionAnimator.SetAttackAnimation(TimeAttack);
            await Task.Delay(Convert.ToInt32(TimeAttack * 1000) / 2);
            OnActivatedAttackEvent?.Invoke();
        }
    }
}