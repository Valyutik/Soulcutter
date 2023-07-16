using System;
using Soulcutter.Scripts.TreeChopping;
using UnityEngine;

namespace Soulcutter.Scripts.Character
{
    public class InteractionObjectDetector : MonoBehaviour
    {
        public event Action<Wood> OnTriggerWithWood;
        public event Action OnTriggerExit;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Wood>(out var tree))
            {
                OnTriggerWithWood?.Invoke(tree);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerExit?.Invoke();
        }
    }
}