using System.Collections;
using Soulcutter.Scripts.Character;
using Soulcutter.Scripts.Detectors;
using UnityEngine;

namespace Soulcutter.Scripts.Combat
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        private CharacterActionActivator _characterActionActivator;
        private EnemyDetector _detector;
        private WaitForSeconds _waitForSeconds;

        public void Initialize(EnemyDetector detector, CharacterActionActivator characterActionActivator)
        {
            _characterActionActivator = characterActionActivator;
            _detector = detector;
            _waitForSeconds = new WaitForSeconds(_characterActionActivator.TimeCombatAttack / 3f);
            
            _characterActionActivator.OnActivatedCombatAttackEvent += StartCoroutineAttack;
        }

        private void OnDisable()
        {
            _characterActionActivator.OnActivatedCombatAttackEvent -= StartCoroutineAttack;
        }

        private void StartCoroutineAttack()
        {
            StartCoroutine(Attack());
        }
        
        private IEnumerator Attack()
        {
            yield return _waitForSeconds;
            if (_detector.CurrentEnemy != null) _detector.CurrentEnemy.TakeDamage(damage);
        }
    }
}