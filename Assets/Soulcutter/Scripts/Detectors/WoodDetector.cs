using System;
using Soulcutter.Scripts.TreeChopping;
using UnityEngine;

namespace Soulcutter.Scripts.Detectors
{
    public class WoodDetector : Detector
    {
        public event Action OnTriggerWithWoodEvent;
        public event Action OnTriggerExitEvent;

        public Wood CurrentWood { get; private set; }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<Wood>(out var wood)) return;
            if (wood.IsFallen)
            {
                OnTriggerExitEvent?.Invoke();
                return;
            }
            OnTriggerWithWoodEvent?.Invoke();
            CurrentWood = wood;
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerExitEvent?.Invoke();
            CurrentWood = null;
        }
    }
}