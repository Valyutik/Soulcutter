using Soulcutter.Scripts.UI;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;

namespace Soulcutter.Scripts.CharacterControl
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class CharacterControl : MonoBehaviour
    {
        [Range(0,100)]
        [SerializeField] private float speed;
        
        private Rigidbody2D _rigidbody2D;
        private CharacterMovement _characterMovement;
        private Joystick _joystick;
        private CharacterAnimator _animator;
        
        public void Initialize(Joystick joystick)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _characterMovement = new CharacterMovement(_rigidbody2D, speed);
            _joystick = joystick;
            joystick.OnDragEvent += _characterMovement.Move;

            var animator = GetComponent<Animator>();
            _animator = new CharacterAnimator(animator);
            _joystick.OnBeginDragEvent += _animator.SetRunAnimation;
            _joystick.OnEndDragEvent += _animator.SetIdleAnimation;
            _joystick.OnDragEvent += _animator.SetDirectionAnimation;
        }

        private void OnDisable()
        {
            _joystick.OnDragEvent -= _characterMovement.Move;
            
            _joystick.OnBeginDragEvent -= _animator.SetRunAnimation;
            _joystick.OnEndDragEvent -= _animator.SetIdleAnimation;
            _joystick.OnDragEvent -= _animator.SetDirectionAnimation;
        }
    }
}