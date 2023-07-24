using Soulcutter.Scripts.Character;
using Soulcutter.Scripts.Combat;
using Soulcutter.Scripts.InteractionObjectDetectors;
using Soulcutter.Scripts.TreeChopping;
using Soulcutter.Scripts.UI;
using UnityEngine;

namespace Soulcutter.Scripts.Bootstrap
{
    public class TestLevelEntryPoint : MonoBehaviour
    {
        [SerializeField] private InteractionObjectDetector detector;
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private CharacterControl characterControl;
        [SerializeField] private WoodChopper woodChopper;
        [SerializeField] private EnemyController enemyController;
        [SerializeField] private Attacker attacker;
        
        private void Awake()
        {
            detector.Initialize();
            uiSystem.Initialize(detector);
            characterControl.Initialize(uiSystem.Joystick, uiSystem.ActionButton);
            woodChopper.Initialize(detector, characterControl.CharacterActionActivator);
            enemyController.Initialize(characterControl.transform);
            attacker.Initialize(detector, characterControl.CharacterActionActivator);

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            detector.UpdatePass();
            enemyController.UpdatePass();
        }

        private void FixedUpdate()
        {
            uiSystem.FixedUpdatePass();
        }
    }
}
