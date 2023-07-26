using Soulcutter.Scripts.Combat;
using Soulcutter.Scripts.Detectors;
using Soulcutter.Scripts.TreeChopping;
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
        [SerializeField] private WoodChopper woodChopper;
        [SerializeField] private EnemyController enemyController;
        [SerializeField] private Attacker attacker;
        
        private void Awake()
        {
            woodDetector.Initialize();
            uiSystem.Initialize(woodDetector);
            character.Initialize(uiSystem.Joystick, uiSystem.ActionButton);
            woodChopper.Initialize(woodDetector, character.CharacterActionActivator);
            enemyController.Initialize(character.transform);
            enemyDetector.Initialize();
            attacker.Initialize(enemyDetector, character.CharacterActionActivator);

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
