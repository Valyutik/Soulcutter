using System.Collections.Generic;
using UnityEngine;

namespace Soulcutter.Scripts.Combat.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        private readonly List<Enemy> _enemies = new();
        private Transform _characterTransform;

        public void Initialize(Transform characterTransform)
        {
            _enemies.Add(Instantiate(enemyPrefab, new Vector3(-15, 0), Quaternion.identity, transform));
            _characterTransform = characterTransform;

            foreach (var enemy in _enemies)
            {
                enemy.Initialize();
            }
        }

        public void UpdatePass()
        {
            foreach (var enemy in _enemies)
            {
                enemy.UpdatePass(_characterTransform.position);
            }
        }
    }
}