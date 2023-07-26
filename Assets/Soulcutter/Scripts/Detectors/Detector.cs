using UnityEngine;

namespace Soulcutter.Scripts.Detectors
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Detector : MonoBehaviour
    {
        private DetectorRotator _detectorRotator;
        
        public void Initialize()
        {
            var boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = true;
            _detectorRotator = new DetectorRotator(GetComponentInParent<Rigidbody2D>(),
                boxCollider2D);
        }

        public void UpdatePass()
        {
            _detectorRotator.SetDirectionDetector();
        }

        protected abstract void OnTriggerEnter2D(Collider2D other);

        protected abstract void OnTriggerExit2D(Collider2D other);
    }
}