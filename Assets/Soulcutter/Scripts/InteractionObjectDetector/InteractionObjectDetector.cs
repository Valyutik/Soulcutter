using System;
using Soulcutter.Scripts.TreeChopping;
using UnityEngine;

namespace Soulcutter.Scripts.InteractionObjectDetector
{
    public class InteractionObjectDetector : MonoBehaviour
    {
        public event Action OnTriggerWithWood;
        public event Action OnTriggerExit;

        public void Initialize()
        {
            
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Wood>(out var tree))
            {
                OnTriggerWithWood?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerExit?.Invoke();
        }
    }
}