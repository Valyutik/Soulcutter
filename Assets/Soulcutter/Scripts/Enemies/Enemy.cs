using System.Threading.Tasks;
using NavMeshPlus.Extensions;
using Soulcutter.Scripts.Characters;
using Soulcutter.Scripts.Combat.Enemies;
using Soulcutter.Scripts.Detectors;
using UnityEngine;

namespace Soulcutter.Scripts.Enemies
{
    [RequireComponent(typeof(Animator), typeof(AgentOverride2d))]
    public class Enemy : MonoBehaviour
    {
        public bool IsLive { get; private set; }
        
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
        private Character _character;

        public void Initialize(Character character)
        {
            _character = character;
            IsLive = true;
            
            _enemyMovement = new EnemyMovement(GetComponent<AgentOverride2d>());
            _enemyAnimator = new EnemyAnimator(GetComponent<Animator>());
            _characterDetector = GetComponentInChildren<CharacterDetector>();
            _characterDetector.Initialize(_character);
            _enemyAttacker = new EnemyAttacker(attackTime, attackDelay, damage, _enemyAnimator, _enemyMovement,
                _characterDetector);
            
            _characterDetector.OnTriggerWithCharacter += _enemyAttacker.OnAttack;
        }

        private void OnDisable()
        {
            _characterDetector.OnTriggerWithCharacter -= _enemyAttacker.OnAttack;
        }

        public void Update()
        {
            if (!isActiveAndEnabled || !IsLive) return;
            _enemyMovement.SetDirection(_character.Transform.position);
            
            _enemyAnimator.SetDirectionAnimation(_enemyMovement.Velocity);
            if (_enemyMovement.Velocity == Vector2.zero)
            {
                _enemyAnimator.SetIdleAnimation();
            }
            else
            {
                _enemyAnimator.SetRunAnimation();
            }
        }

        public void TakeDamage(int damageReceived)
        {
            health -= damageReceived;
            if (health <= 0)
            {
                Die();
            }
        }

        private async void Die()
        {
            OnDisable();
            IsLive = false;
            _enemyAnimator.SetDieAnimation();
            await Task.Delay(10000);
            gameObject.SetActive(false);
        }
    }
}
