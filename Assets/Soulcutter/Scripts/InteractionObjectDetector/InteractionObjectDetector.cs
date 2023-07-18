using System;
using Soulcutter.Scripts.TreeChopping;
using UnityEngine;

namespace Soulcutter.Scripts.InteractionObjectDetector
{
    public class InteractionObjectDetector : MonoBehaviour
    {
        public event Action OnTriggerWithWoodEvent;
        public event Action OnTriggerExitEvent;
        
        private Wood _currentWood;

        public void Initialize()
        {
            
        }

        public Wood GetCurrentWood()
        {
            return _currentWood;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<Wood>(out var currentWood)) return;
            OnTriggerWithWoodEvent?.Invoke();
            _currentWood = currentWood;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerExitEvent?.Invoke();
            _currentWood = null;
        }
    }
}