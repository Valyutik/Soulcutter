using System;
using Soulcutter.Scripts.UI;
using UnityEngine;

namespace Soulcutter.Scripts.CharacterControl
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterControl : MonoBehaviour
    {
        [Range(0,100)]
        [SerializeField] private float speed;
        
        private Rigidbody2D _rigidbody2D;
        private CharacterMovement _characterMovement;
        private Joystick _joystick;
        
        public void Initialize(Joystick joystick)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _characterMovement = new CharacterMovement(_rigidbody2D, speed);
            _joystick = joystick;
            joystick.OnDragEvent += _characterMovement.Move;
        }

        private void OnDisable()
        {
            _joystick.OnDragEvent -= _characterMovement.Move;
        }
    }
}