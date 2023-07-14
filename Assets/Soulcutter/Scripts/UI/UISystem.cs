using System;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;

namespace Soulcutter.Scripts.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Camera UIcamera;

        public Joystick Joystick => joystick;

        public void Initialize()
        {
            joystick.Initialize(UIcamera);
        }

        public void FixedUpdatePass()
        {
            joystick.FixedUpdatePass();
        }
    }
}