using Soulcutter.Scripts.CharacterControl;
using Soulcutter.Scripts.UI;
using UnityEngine;

namespace Soulcutter.Bootstrap
{
    public class TestLevelEntryPoint : MonoBehaviour
    {
        [SerializeField] private CharacterControl characterControl;
        [SerializeField] private UISystem uiSystem;
        
        private void Awake()
        {
            uiSystem.Initialize();
            characterControl.Initialize(uiSystem.Joystick);
        }

        private void FixedUpdate()
        {
            uiSystem.FixedUpdatePass();
        }
    }
}
