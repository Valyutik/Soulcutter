using Soulcutter.Scripts.Detectors;
using Soulcutter.Scripts.UI.ActionButton;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;

namespace Soulcutter.Scripts.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Camera uiCamera;
        [SerializeField] private DeathScreen deathScreen;
        [SerializeField] private ActionButton.ActionButton actionButton;
        private ActionButtonChanger _actionButtonChanger;
        private WoodDetector _detector;

        public Joystick Joystick => joystick;
        public ActionButton.ActionButton ActionButton => actionButton;
        public DeathScreen DeathScreen => deathScreen;

        public void Initialize(WoodDetector detector)
        {
            joystick.Initialize(uiCamera);
            actionButton.Initialize();
            deathScreen.Inizialize(joystick, actionButton);
            _actionButtonChanger = new ActionButtonChanger(actionButton);
            _detector = detector;
            
            _detector.OnTriggerWithWoodEvent += _actionButtonChanger.SetChopButtonType;
            _detector.OnTriggerExitEvent += _actionButtonChanger.SetAttackButtonType;
        }

        private void OnDisable()
        {
            _detector.OnTriggerWithWoodEvent -= _actionButtonChanger.SetChopButtonType;
            _detector.OnTriggerExitEvent -= _actionButtonChanger.SetAttackButtonType;
        }

        public void FixedUpdatePass()
        {
            joystick.FixedUpdatePass();
        }
    }
}