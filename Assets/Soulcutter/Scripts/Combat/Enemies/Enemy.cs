using System;
using NavMeshPlus.Extensions;
using Soulcutter.Scripts.Detectors;
using UnityEngine;

namespace Soulcutter.Scripts.Combat.Enemies
{
    [RequireComponent(typeof(Animator), typeof(AgentOverride2d))]
    public class Enemy : MonoBehaviour
    {
        [Range(0,100)]
        [SerializeField] private int health;
        [Range(0,100)]
        [SerializeField] private int damage;
        [Range(0,10)]
        [SerializeField] private float attackTime;
        [Range(0,10)]
        [SerializeField] private float attackDelay;
        [Range(0,10)]
        [SerializeField] private float detectorRange;
        private EnemyMovement _enemyMovement;
        private EnemyAnimator _enemyAnimator;
        private EnemyAttacker _enemyAttacker;
        private CharacterDetector _characterDetector;

        public void Initialize()
        {
            _enemyMovement = new EnemyMovement(GetComponent<AgentOverride2d>());
            _enemyAnimator = new EnemyAnimator(GetComponent<Animator>());
            _characterDetector = GetComponentInChildren<CharacterDetector>();
            _characterDetector.Initialize(detectorRange);
            _enemyAttacker = new EnemyAttacker(attackTime, attackDelay, damage, _enemyAnimator, _enemyMovement,
                _characterDetector);
            
            _characterDetector.OnTriggerWithCharacter += _enemyAttacker.OnAttack;
        }

        private void OnDisable()
        {
            _characterDetector.OnTriggerWithCharacter -= _enemyAttacker.OnAttack;
        }

        public void UpdatePass(Vector2 point)
        {
            if (!isActiveAndEnabled) return;
            _enemyMovement.SetDirection(point);
            
            _enemyAnimator.SetDirectionAnimation(_enemyMovement.Velocity);
            if (_enemyMovement.Velocity == Vector2.zero)
            {
                _enemyAnimator.SetIdleAnimation();
            }
            else
            {
                _enemyAnimator.SetRunAnimation();
            }
            
            _characterDetector.UpdatePass();
        }

        public void TakeDamage(int damageReceived)
        {
            health -= damageReceived;
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}
