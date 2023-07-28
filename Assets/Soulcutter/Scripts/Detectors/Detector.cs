using UnityEngine;

namespace Soulcutter.Scripts.Detectors
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Detector : MonoBehaviour
    {
        protected DetectorRotator DetectorRotator;
        private Rigidbody2D _rigidbody2D;
        
        public virtual void Initialize()
        {
            var boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = true;
            _rigidbody2D = GetComponentInParent<Rigidbody2D>();
            DetectorRotator = new DetectorRotator(boxCollider2D);
        }

        public virtual void UpdatePass()
        {
            DetectorRotator.SetDirectionDetector(_rigidbody2D.velocity.normalized);
        }

        protected abstract void OnTriggerEnter2D(Collider2D other);

        protected abstract void OnTriggerExit2D(Collider2D other);
    }
}