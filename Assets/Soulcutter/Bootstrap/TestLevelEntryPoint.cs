using Soulcutter.Scripts.Character;
using Soulcutter.Scripts.InteractionObjectDetectors;
using Soulcutter.Scripts.TreeChopping;
using Soulcutter.Scripts.UI;
using UnityEngine;

namespace Soulcutter.Bootstrap
{
    public class TestLevelEntryPoint : MonoBehaviour
    {
        [SerializeField] private InteractionObjectDetector detector;
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private CharacterControl characterControl;
        [SerializeField] private WoodChopper woodChopper;
        
        private void Awake()
        {
            detector.Initialize();
            uiSystem.Initialize(detector);
            characterControl.Initialize(uiSystem.Joystick, uiSystem.ActionButton);
            woodChopper.Initialize(detector, characterControl.CharacterActionAnimator, uiSystem.ActionButton);

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private void FixedUpdate()
        {
            uiSystem.FixedUpdatePass();
        }
    }
}
