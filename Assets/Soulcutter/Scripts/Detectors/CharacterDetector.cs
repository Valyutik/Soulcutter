using System;
using Soulcutter.Scripts.Characters;
using UnityEngine;
using UnityEngine.AI;

namespace Soulcutter.Scripts.Detectors
{
    public class CharacterDetector : Detector
    {
        public event Action OnTriggerWithCharacter;
        private NavMeshAgent _agent;
        public Character Character { get; private set; }

        public override void Initialize(Character character)
        {
            Character = character;
            
            var boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = true;
            _agent = GetComponentInParent<NavMeshAgent>();
            
            DetectorRotator = new DetectorRotator(transform);
            DetectorRangeChanger = new DetectorRangeChanger(boxCollider2D);
            
            DetectorRangeChanger.SetRangeDetector(1f);
        }

        public override void Update()
        {
            Vector2 direction = Character.transform.position - transform.position; 
            DetectorRotator.SetDirectionDetector(direction);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
        }

        protected void OnTriggerStay2D(Collider2D other)
        {
            if (!other.TryGetComponent<Character>(out _)) return;
            OnTriggerWithCharacter?.Invoke();
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
        }
    }
}