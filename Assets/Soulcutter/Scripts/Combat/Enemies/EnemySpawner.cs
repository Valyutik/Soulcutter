using System;
using System.Collections.Generic;
using UnityEngine;

namespace Soulcutter.Scripts.Combat.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        private readonly List<Enemy> _enemies = new();
        private Transform _characterTransform;
        private Character.Character _character;

        public void Initialize(Character.Character character)
        {
            _character = character;
            
            _enemies.Add(Instantiate(enemyPrefab, new Vector3(-15, 0), Quaternion.identity, transform));
            _characterTransform = character.transform;

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

        public void UpdatePass()
        {
            foreach (var enemy in _enemies)
            {
                enemy.UpdatePass(_characterTransform.position);
            }
        }
    }
}