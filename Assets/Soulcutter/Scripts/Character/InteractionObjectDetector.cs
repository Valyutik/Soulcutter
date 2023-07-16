using UnityEngine;

namespace Soulcutter.Scripts.Character
{
    public class InteractionObjectDetector : MonoBehaviour
    {
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log(other);
        }
    }
}