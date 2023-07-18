using System;
using Soulcutter.Scripts.TreeChopping;
using UnityEngine;

namespace Soulcutter.Scripts.InteractionObjectDetector
{
    public class InteractionObjectDetector : MonoBehaviour
    {
        public event Action OnTriggerWithWoodEvent;
        public event Action OnTriggerExitEvent;

        public Wood CurrentWood { get; private set; }

        public void Initialize()
        {
            
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