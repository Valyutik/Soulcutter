using Soulcutter.Scripts.Detectors;
using Soulcutter.Scripts.UI.Buttons;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;
using Zenject;

namespace Soulcutter.Scripts.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Camera uiCamera;
        [SerializeField] private DeathScreen deathScreen;
        [SerializeField] private ActionButton actionButton;
        [SerializeField] private HealthBar healthBar;
        private ActionButtonChanger _actionButtonChanger;
        private WoodDetector _detector;

        public Joystick Joystick => joystick;
        public Camera UICamera => uiCamera;
        public ActionButton ActionButton => actionButton;
        public DeathScreen DeathScreen => deathScreen;
        public HealthBar HealthBar => healthBar;
        
        [Inject]
        public void Initialize(WoodDetector detector)
        {
            actionButton.Initialize();
            deathScreen.Initialize(joystick, actionButton);
            healthBar.Initialize();
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

        public void FixedUpdate()
        {
            joystick.FixedUpdatePass();
        }
    }
}