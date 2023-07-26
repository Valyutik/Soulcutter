using NavMeshPlus.NavMeshComponents.Scripts;
using UnityEngine;

namespace Soulcutter.Scripts.Combat
{
    [RequireComponent(typeof(Animator), typeof(AgentOverride2d))]
    public class Enemy : MonoBehaviour
    {
        [Range(0,100)]
        [SerializeField] private float health;
        [Range(0,100)]
        [SerializeField] private int damage;
        private EnemyMovement _enemyMovement;
        private EnemyAnimator _enemyAnimator;

        public void Initialize()
        {
            _enemyMovement = new EnemyMovement(GetComponent<AgentOverride2d>());
            _enemyAnimator = new EnemyAnimator(GetComponent<Animator>());
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
