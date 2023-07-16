using Soulcutter.Scripts.UI.ActionButton;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;

namespace Soulcutter.Scripts.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Camera uiCamera;
        [SerializeField] private ActionButton.ActionButton actionButton;
        private ActionButtonChanger _actionButtonChanger;
        private InteractionObjectDetector.InteractionObjectDetector _detector;

        public Joystick Joystick => joystick;
        public ActionButton.ActionButton ActionButton => actionButton;
        public ActionButtonChanger ActionButtonChanger => _actionButtonChanger;

        public void Initialize(InteractionObjectDetector.InteractionObjectDetector detector)
        {
            joystick.Initialize(uiCamera);
            actionButton.Initialize();
            _actionButtonChanger = new ActionButtonChanger(actionButton);
            _detector = detector;
            
            _detector.OnTriggerWithWood += _actionButtonChanger.SetChopButtonType;
            _detector.OnTriggerExit += _actionButtonChanger.SetAttackButtonType;
        }

        private void OnDisable()
        {
            _detector.OnTriggerWithWood -= _actionButtonChanger.SetChopButtonType;
            _detector.OnTriggerExit -= _actionButtonChanger.SetAttackButtonType;
        }

        public void FixedUpdatePass()
        {
            joystick.FixedUpdatePass();
        }
    }
}