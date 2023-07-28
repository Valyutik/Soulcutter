using Soulcutter.Scripts.Character.Animators;
using Soulcutter.Scripts.Character.Movement;
using Soulcutter.Scripts.Combat;
using Soulcutter.Scripts.Detectors;
using Soulcutter.Scripts.TreeChopping;
using Soulcutter.Scripts.UI.ActionButton;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;

namespace Soulcutter.Scripts.Character
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class Character : MonoBehaviour
    {
        [Header("Movement")]
        [Range(0,100)]
        [SerializeField] private float speed;
        
        [Header("Chopping")]
        [Range(0,10)]
        [SerializeField] private float timeChop;
        [Range(0,100)]
        [SerializeField] private int impactForce = 1;

        [Header("Combat")]
        [Range(0, 100)]
        [SerializeField] private int health;
        [Range(0,10)]
        [SerializeField] private float timeCombatAttack;
        [Range(0,100)]
        [SerializeField] private int damage = 1;
        
        public bool IsLive { get; private set; }
        
        private Rigidbody2D _rigidbody2D;
        private CharacterMovement _characterMovement;
        private CharacterMovementAnimator _characterMovementAnimator;
        private CharacterActionActivator _characterActionActivator;
        private ListenerAttackAndChopAnimationState _listenerAttackAndChopAnimationState;
        private Joystick _joystick;
        private ActionButton _actionButton;
        private WoodChopper _woodChopper;
        private CharacterAttacker _characterAttacker;

        private CharacterActionActivator CharacterActionActivator { get; set; }

        public void Initialize(Joystick joystick, ActionButton actionButton,
            WoodDetector woodDetector, EnemyDetector enemyDetector)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            var animator = GetComponent<Animator>();
            
            _characterMovement = new CharacterMovement(_rigidbody2D, speed);
            _joystick = joystick;
            joystick.OnDragEvent += _characterMovement.Move;
            
            _characterMovementAnimator = new CharacterMovementAnimator(animator);

            _characterMovement.OnPlayerMoveEvent += _characterMovementAnimator.SetDirectionAnimation;
            _joystick.OnBeginDragEvent += _characterMovementAnimator.SetRunAnimation;
            _joystick.OnEndDragEvent += _characterMovementAnimator.SetIdleAnimation;

            _listenerAttackAndChopAnimationState = animator.GetBehaviour<ListenerAttackAndChopAnimationState>();
            _listenerAttackAndChopAnimationState.OnStateEnterEvent += _characterMovement.DisableMovement;
            _listenerAttackAndChopAnimationState.OnStateExitEvent += _characterMovement.EnableMovement;

            CharacterActionActivator = new CharacterActionActivator(actionButton,
                animator,timeChop, timeCombatAttack);

            _woodChopper = new WoodChopper(woodDetector, CharacterActionActivator, impactForce);
            _characterAttacker = new CharacterAttacker(enemyDetector, CharacterActionActivator, damage);
        }

        private void OnDisable()
        {
            _joystick.OnDragEvent -= _characterMovement.Move;
            
            _characterMovement.OnPlayerMoveEvent -= _characterMovementAnimator.SetDirectionAnimation;
            _joystick.OnBeginDragEvent -= _characterMovementAnimator.SetRunAnimation;
            _joystick.OnEndDragEvent -= _characterMovementAnimator.SetIdleAnimation;
            
            _listenerAttackAndChopAnimationState.OnStateEnterEvent += _characterMovement.DisableMovement;
            _listenerAttackAndChopAnimationState.OnStateExitEvent += _characterMovement.EnableMovement;
            
            CharacterActionActivator.Deconstruct();
            _woodChopper.Deconstruct();
            _characterAttacker.Deconstruct();
        }
        
        public void TakeDamage(int damageReceived)
        {
            health -= damageReceived;
            if (health <= 0)
            {
                Die();
            }
        }
        
        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}