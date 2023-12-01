using Soulcutter.Scripts.Characters;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Soulcutter.Scripts.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private int enemyCount = 5;
        private readonly List<Enemy> _enemies = new();
        private Character _character;

        [Inject]
        public void Initialize(Character character)
        {
            _character = character;
        }

        private void Start()
        {
            for (var i = 0; i < enemyCount; i++)
            {
                _enemies.Add(Instantiate(enemyPrefab,
                    new Vector2(Random.Range(-15,15), Random.Range(-10,10)), Quaternion.identity, transform));
            }

            foreach (var enemy in _enemies)
            {
                enemy.Initialize(_character);
            }
        }

        private void OnDisable()
        {
            foreach (var enemy in _enemies)
            {
                enemy.gameObject.SetActive(false);
            }
        }
    }
}