using Soulcutter.Scripts.Combat;
using UnityEngine;

namespace Soulcutter.Scripts.Detectors
{
    public class EnemyDetector : Detector
    {
        public Enemy CurrentEnemy { get; private set; }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Enemy>(out var enemy))
            {
                CurrentEnemy = enemy;
            }
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            CurrentEnemy = null;
        }
    }
}