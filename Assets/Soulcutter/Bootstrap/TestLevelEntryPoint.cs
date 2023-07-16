using Soulcutter.Scripts.Character;
using Soulcutter.Scripts.InteractionObjectDetector;
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
            characterControl.Initialize(uiSystem.Joystick);
            woodChopper.Initialize(detector, uiSystem.ActionButton);

            uiSystem.ActionButtonChanger.OnSetChopButtonType += woodChopper.SubscribeActionButton;
            uiSystem.ActionButtonChanger.OnSetAttackButtonType += woodChopper.UnsubscribeActionButton;
            
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private void OnDisable()
        {
            uiSystem.ActionButtonChanger.OnSetChopButtonType -= woodChopper.SubscribeActionButton;
            uiSystem.ActionButtonChanger.OnSetAttackButtonType -= woodChopper.UnsubscribeActionButton;
        }

        private void FixedUpdate()
        {
            uiSystem.FixedUpdatePass();
        }
    }
}
