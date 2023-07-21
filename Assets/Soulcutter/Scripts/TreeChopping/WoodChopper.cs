using System.Collections;
using Soulcutter.Scripts.Character;
using Soulcutter.Scripts.InteractionObjectDetectors;
using UnityEngine;

namespace Soulcutter.Scripts.TreeChopping
{
    public class WoodChopper : MonoBehaviour
    {
        [SerializeField] private int impactForce = 1;
        private InteractionObjectDetector _detector;
        private CharacterActionActivator _characterActionActivator;
        private WaitForSeconds _waitForSeconds;

        public void Initialize(InteractionObjectDetector detector, CharacterActionActivator characterActionActivator)
        {
            _detector = detector;
            _characterActionActivator = characterActionActivator;
            _waitForSeconds = new WaitForSeconds(_characterActionActivator.TimeChop / 3f);

            _characterActionActivator.OnActivatedChopEvent += StartCoroutineChopWood;
        }

        private void OnDisable()
        {
            _characterActionActivator.OnActivatedChopEvent -= StartCoroutineChopWood;
        }

        private void StartCoroutineChopWood()
        {
            StartCoroutine(ChopWood());
        }

        private IEnumerator ChopWood()
        {
            yield return _waitForSeconds;
            _detector.CurrentWood.TakeDamage(impactForce);
        }
    }
}