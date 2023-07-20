using System.Collections;
using Soulcutter.Scripts.Character.Animators;
using Soulcutter.Scripts.InteractionObjectDetectors;
using Soulcutter.Scripts.UI.ActionButton;
using UnityEngine;

namespace Soulcutter.Scripts.TreeChopping
{
    public class WoodChopper : MonoBehaviour
    {
        [SerializeField] private int impactForce = 1;
        [SerializeField] private float choppingTime = 1;
        private InteractionObjectDetector _detector;
        private CharacterActionAnimator _characterActionAnimator;
        private ActionButton _actionButton;
        private ListenerAttackAndChopAnimationState _listenerAttackAndChopAnimationState;
        private WaitForSeconds _waitForSeconds;
        private bool _isChopping;

        public void Initialize(InteractionObjectDetector detector,
            CharacterActionAnimator characterActionAnimator, ActionButton actionButton)
        {
            _isChopping = true;
            _detector = detector;
            _characterActionAnimator = characterActionAnimator;
            _actionButton = actionButton;
            _listenerAttackAndChopAnimationState = _characterActionAnimator.ListenerAttackAndChopAnimationState;
            _waitForSeconds = new WaitForSeconds(choppingTime / 2.5f);
            
            _actionButton.OnPressChopEvent += StartCoroutineChopWood;
            _listenerAttackAndChopAnimationState.OnStateExitEvent += ActivateChopping;
        }

        private void OnDisable()
        {
            _actionButton.OnPressChopEvent -= StartCoroutineChopWood;
            _listenerAttackAndChopAnimationState.OnStateExitEvent -= ActivateChopping;
        }

        private void StartCoroutineChopWood()
        {
            StartCoroutine(ChopWood());
        }

        private IEnumerator ChopWood()
        {
            if (!_isChopping) yield break;
            _characterActionAnimator.SetChopAnimation(choppingTime);
            yield return _waitForSeconds;
            _detector.CurrentWood.TakeDamage(impactForce);
            _isChopping = false;
        }

        private void ActivateChopping()
        {
            _isChopping = true;
        }
    }
}