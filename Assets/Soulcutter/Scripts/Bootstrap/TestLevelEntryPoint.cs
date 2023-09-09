using Soulcutter.Scripts.Combat.Enemies;
using Soulcutter.Scripts.Detectors;
using Soulcutter.Scripts.UI;
using UnityEngine;

namespace Soulcutter.Scripts.Bootstrap
{
    public class TestLevelEntryPoint : MonoBehaviour
    {
        [SerializeField] private WoodDetector woodDetector;
        [SerializeField] private EnemyDetector enemyDetector;
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private Characters.Character character;
        [SerializeField] private EnemyController enemyController;
        
        private void Awake()
        {
            woodDetector.Initialize(1f, character);
            uiSystem.Initialize(woodDetector);
            //character.Initialize(uiSystem.Joystick, uiSystem.ActionButton, uiSystem.DeathScreen, uiSystem.HealthBar, woodDetector, enemyDetector);
            enemyController.Initialize(character);
            enemyDetector.Initialize(1f, character);

        }

        private void Update()
        {
            woodDetector.UpdatePass();
            enemyController.UpdatePass();
            enemyDetector.UpdatePass();
        }

        private void FixedUpdate()
        {
            //uiSystem.FixedUpdatePass();
        }
    }
}
