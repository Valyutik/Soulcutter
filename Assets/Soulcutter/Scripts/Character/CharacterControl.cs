using Soulcutter.Scripts.Character.Animators;
using Soulcutter.Scripts.UI.ActionButton;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;

namespace Soulcutter.Scripts.Character
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class CharacterControl : MonoBehaviour
    {
        [Range(0,100)]
        [SerializeField] private float speed;
        
        private Rigidbody2D _rigidbody2D;
        private CharacterMovement _characterMovement;
        private CharacterMovementAnimator _characterMovementAnimator;
        private CharacterActionAnimator _characterActionAnimator;
        private CharacterMovementDisable _characterMovementDisable;
        private Joystick _joystick;
        private ActionButton _actionButton;

        public void Initialize(Joystick joystick, ActionButton actionButton)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _characterMovement = new CharacterMovement(_rigidbody2D, speed);
            
            _joystick = joystick;
            joystick.OnDragEvent += _characterMovement.Move;
            
            var animator = GetComponent<Animator>();
            
            _characterMovementAnimator = new CharacterMovementAnimator(animator);
            _characterMovementDisable = animator.GetBehaviour<CharacterMovementDisable>();
            
            _characterMovementDisable.OnStateEnterEvent += _characterMovement.DisableMovement;
            _characterMovementDisable.OnStateExitEvent += _characterMovement.EnableMovement;

            _characterMovement.OnPlayerMoveEvent += _characterMovementAnimator.SetDirectionAnimation;
            _joystick.OnBeginDragEvent += _characterMovementAnimator.SetRunAnimation;
            _joystick.OnEndDragEvent += _characterMovementAnimator.SetIdleAnimation;

            _characterActionAnimator = new CharacterActionAnimator(animator);
            _actionButton = actionButton;
            _actionButton.OnPressAttackEvent += _characterActionAnimator.SetAttackAnimation;
            _actionButton.OnPressChopEvent += _characterActionAnimator.SetChopAnimation;
        }

        private void OnDisable()
        {
            _joystick.OnDragEvent -= _characterMovement.Move;
            
            _characterMovementDisable.OnStateEnterEvent -= _characterMovement.DisableMovement;
            _characterMovementDisable.OnStateExitEvent -= _characterMovement.EnableMovement;
            
            _characterMovement.OnPlayerMoveEvent -= _characterMovementAnimator.SetDirectionAnimation;
            _joystick.OnBeginDragEvent -= _characterMovementAnimator.SetRunAnimation;
            _joystick.OnEndDragEvent -= _characterMovementAnimator.SetIdleAnimation;
            
            _actionButton.OnPressAttackEvent -= _characterActionAnimator.SetAttackAnimation;
            _actionButton.OnPressChopEvent -= _characterActionAnimator.SetChopAnimation;
        }
    }
}