using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;

namespace Soulcutter.Scripts.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Camera uiCamera;
        [SerializeField] private ActionButton actionButton;

        public Joystick Joystick => joystick;

        public void Initialize()
        {
            joystick.Initialize(uiCamera);
            actionButton.Initialize();
        }

        public void FixedUpdatePass()
        {
            joystick.FixedUpdatePass();
        }
    }
}