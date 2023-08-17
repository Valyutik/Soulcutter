using UnityEngine;

namespace Soulcutter.Scripts.Detectors
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Detector : MonoBehaviour
    {
        protected DetectorRotator DetectorRotator;
        protected DetectorRangeChanger DetectorRangeChanger;
        private Character.Character _character;
        
        public virtual void Initialize(float detectorRange, Character.Character character)
        {
            _character = character;
            
            var boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = true;
            
            DetectorRotator = new DetectorRotator(transform);
            DetectorRangeChanger = new DetectorRangeChanger(boxCollider2D);
            
            DetectorRangeChanger.SetRangeDetector(detectorRange);
        }

        public virtual void UpdatePass()
        {
            DetectorRotator.SetDirectionDetector(_character.joystick.Direction);
        }

        protected abstract void OnTriggerEnter2D(Collider2D other);

        protected abstract void OnTriggerExit2D(Collider2D other);
    }
}