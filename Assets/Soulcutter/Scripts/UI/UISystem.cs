using System;
using UnityEngine;

namespace Soulcutter.Scripts.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;

        public Joystick Joystick => joystick;

        public void Initialize()
        {
            joystick.Initialize();
        }

        public void FixedUpdatePass()
        {
            joystick.FixedUpdatePass();
        }
    }
}