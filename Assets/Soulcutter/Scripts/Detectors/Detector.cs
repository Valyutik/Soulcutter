using Soulcutter.Scripts.Characters;
using UnityEngine;
using Zenject;

namespace Soulcutter.Scripts.Detectors
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Detector : MonoBehaviour
    {
        protected DetectorRotator DetectorRotator;
        protected DetectorRangeChanger DetectorRangeChanger;
        private Character _character;
        
        [Inject]
        public virtual void Initialize(Character character)
        {
            _character = character;
            
            var boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = true;
            
            DetectorRotator = new DetectorRotator(transform);
            DetectorRangeChanger = new DetectorRangeChanger(boxCollider2D);
            
            DetectorRangeChanger.SetRangeDetector(1f);
        }

        public virtual void Update()
        {
            DetectorRotator.SetDirectionDetector(_character.Velocity);
        }

        protected abstract void OnTriggerEnter2D(Collider2D other);

        protected abstract void OnTriggerExit2D(Collider2D other);
    }
}