using NavMeshPlus.Extensions;
using UnityEngine;

namespace Soulcutter.Scripts.Combat
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int health;
        private EnemyMovement _enemyMovement;
        
        public void Initialize()
        {
            _enemyMovement = new EnemyMovement(GetComponent<AgentOverride2d>());
        }

        public void UpdatePass(Vector2 point)
        {
            _enemyMovement.SetDirection(point);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
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
