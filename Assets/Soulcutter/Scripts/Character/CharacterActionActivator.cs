using System;
using Soulcutter.Scripts.Character.Animators;
using Soulcutter.Scripts.UI.ActionButton;
using UnityEngine;

namespace Soulcutter.Scripts.Character
{
    public class CharacterActionActivator
    {
        public event Action OnActivatedChopEvent, OnActivatedCombatAttackEvent;
        
        public float TimeChop => _timeChop;
        public float TimeCombatAttack => _timeCombatAttack;

        private readonly ActionButton _actionButton;
        private readonly CharacterActionAnimator _characterActionAnimator;
        private readonly ListenerAttackAndChopAnimationState _listenerAttackAndChopAnimationState;
        private readonly WaitForSeconds _waitTimeChop, _waitCombatAttack;


        private readonly float _timeChop;
        private readonly float _timeCombatAttack;
        private bool _isAction;

        public CharacterActionActivator(ActionButton actionButton, ListenerAttackAndChopAnimationState listenerAttackAndChopAnimationState,
            CharacterActionAnimator characterActionAnimator,
            float timeChop, float timeCombatAttack)
        {
            _isAction = true;
            _actionButton = actionButton;
            _characterActionAnimator = characterActionAnimator;
            _timeChop = timeChop;
            _timeCombatAttack = timeCombatAttack;
            _listenerAttackAndChopAnimationState = listenerAttackAndChopAnimationState;
            _waitTimeChop = new WaitForSeconds(timeChop/ 2f);
            _waitCombatAttack = new WaitForSeconds(timeCombatAttack / 2f);

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

        private void OnActivatedChop()
        {
            if (!_isAction) return;
            _characterActionAnimator.SetChopAnimation(_timeChop);
            OnActivatedChopEvent?.Invoke();
            _isAction = false;
        }
        private void OnActivatedCombatAttack()
        {
            if (!_isAction) return;
            _characterActionAnimator.SetAttackAnimation(_timeCombatAttack);
            OnActivatedCombatAttackEvent?.Invoke();
            _isAction = false;
        }
    }
}