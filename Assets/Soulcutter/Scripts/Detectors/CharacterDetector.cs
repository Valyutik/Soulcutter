using System;
using UnityEngine;
using UnityEngine.AI;

namespace Soulcutter.Scripts.Detectors
{
    public class CharacterDetector : Detector
    {
        public event Action OnTriggerWithCharacter;
        private NavMeshAgent _agent;
        public Character.Character Character { get; private set; }

        public override void Initialize(float detectorRange)
        {
            var boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = true;
            _agent = GetComponentInParent<NavMeshAgent>();
            
            DetectorRotator = new DetectorRotator(transform);
            DetectorRangeChanger = new DetectorRangeChanger(boxCollider2D);
            
            DetectorRangeChanger.SetRangeDetector(detectorRange);
        }

        public override void UpdatePass()
        {
            DetectorRotator.SetDirectionDetector(_agent.velocity.normalized);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
        }

        protected void OnTriggerStay2D(Collider2D other)
        {
            if (!other.TryGetComponent<Character.Character>(out var character)) return;
            OnTriggerWithCharacter?.Invoke();
            Character = character;
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            Character = null;
        }
    }
}