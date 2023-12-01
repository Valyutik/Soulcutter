using Soulcutter.Scripts.Characters;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Soulcutter.Scripts.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        private readonly List<Enemy> _enemies = new();
        private Character _character;

        [Inject]
        public void Initialize(Character character)
        {
            _character = character;
        }

        private void Start()
        {
            _enemies.Add(Instantiate(enemyPrefab,
                new Vector3(-15, 0), Quaternion.identity, transform));

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