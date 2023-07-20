using System;
using Soulcutter.Scripts.TreeChopping;
using UnityEngine;

namespace Soulcutter.Scripts.InteractionObjectDetectors
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class InteractionObjectDetector : MonoBehaviour
    {
        public event Action OnTriggerWithWoodEvent;
        public event Action OnTriggerExitEvent;

        public Wood CurrentWood { get; private set; }

        private DetectorRotator _detectorRotator;

        public void Initialize()
        {
            _detectorRotator = new DetectorRotator(GetComponentInParent<Rigidbody2D>(),
                GetComponent<BoxCollider2D>());
        }

        public void UpdatePass()
        {
            _detectorRotator.SetDirectionDetector();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<Wood>(out var currentWood)) return;
            OnTriggerWithWoodEvent?.Invoke();
            CurrentWood = currentWood;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerExitEvent?.Invoke();
            CurrentWood = null;
        }
    }
}