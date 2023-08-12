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
        [SerializeField] private Character.Character character;
        [SerializeField] private EnemyController enemyController;
        
        private void Awake()
        {
            woodDetector.Initialize(1f);
            uiSystem.Initialize(woodDetector);
            character.Initialize(uiSystem.Joystick, uiSystem.ActionButton, uiSystem.DeathScreen, woodDetector, enemyDetector);
            enemyController.Initialize(character.transform);
            enemyDetector.Initialize(1f);

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            woodDetector.UpdatePass();
            enemyController.UpdatePass();
            enemyDetector.UpdatePass();
        }

        private void FixedUpdate()
        {
            uiSystem.FixedUpdatePass();
        }
    }
}
