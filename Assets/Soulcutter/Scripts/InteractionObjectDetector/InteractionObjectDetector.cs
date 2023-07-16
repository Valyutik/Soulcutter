using System;
using Soulcutter.Scripts.TreeChopping;
using UnityEngine;

namespace Soulcutter.Scripts.InteractionObjectDetector
{
    public class InteractionObjectDetector : MonoBehaviour
    {
        public event Action OnTriggerWithWood;
        public event Action OnTriggerExit;
        
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
            OnTriggerWithWood?.Invoke();
            _currentWood = currentWood;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerExit?.Invoke();
            _currentWood = null;
        }
    }
}