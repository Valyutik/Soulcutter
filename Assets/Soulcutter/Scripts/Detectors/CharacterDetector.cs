using System;
using UnityEngine;
using UnityEngine.AI;

namespace Soulcutter.Scripts.Detectors
{
    public class CharacterDetector : Detector
    {
        public event Action OnTriggerWithCharacter;
        private NavMeshAgent _agent;
        public Characters.Character Character { get; private set; }

        public override void Initialize(float detectorRange, Characters.Character character)
        {
            Character = character;
            
            var boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = true;
            _agent = GetComponentInParent<NavMeshAgent>();
            
            DetectorRotator = new DetectorRotator(transform);
            DetectorRangeChanger = new DetectorRangeChanger(boxCollider2D);
            
            DetectorRangeChanger.SetRangeDetector(detectorRange);
        }

        public override void UpdatePass()
        {

            Vector2 direction = Character.transform.position - transform.position; 
            
            DetectorRotator.SetDirectionDetector(direction);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
        }

        protected void OnTriggerStay2D(Collider2D other)
        {
            if (!other.TryGetComponent<Characters.Character>(out var character)) return;
            OnTriggerWithCharacter?.Invoke();
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
        }
    }
}