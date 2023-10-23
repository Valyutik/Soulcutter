using System;
using System.Threading.Tasks;
using Soulcutter.Scripts.Characters.Animators;
using Soulcutter.Scripts.Combat;
using Soulcutter.Scripts.Detectors;
using Soulcutter.Scripts.TreeChopping;
using Soulcutter.Scripts.UI;
using Soulcutter.Scripts.UI.Buttons;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;
using Zenject;

namespace Soulcutter.Scripts.Characters
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public sealed class Character : MonoBehaviour, IMovable
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
        
        [Space]
        [Range(0,10)]
        [SerializeField] private float timeAttack;
        [Range(0,10)]
        [SerializeField] private float timeSpecialAttack;
        
        [Space]
        [Range(0, 100)]
        [SerializeField] private int damage;
        [Range(0, 100)]
        [SerializeField] private int specialDamage;
        
        [Space]
        [Range(0, 10)]
        [SerializeField] private int pointComboThreshold;
        [Range(0, 10)]
        [SerializeField] private float comboResetTime;
        
        [Range(0,10)]
        [SerializeField] private float detectorRange;
        
        public bool IsLive { get; private set; }
        public Vector2 Velocity => _joystick.Direction;

        public Transform Transform { get; private set; }

        private CharacterMovementAnimator _characterMovementAnimator;
        private CharacterActionActivator _characterActionActivator;
        private CharacterDeathAnimator _characterDeathAnimator;
        private ListenerAttackAndChopAnimationState _listenerAttackAndChopAnimationState;
        private Joystick _joystick;
        private ActionButton _actionButton;
        private WoodChopper _woodChopper;
        private CharacterAttacker _characterAttacker;
        private DeathScreen _deathScreen;
        private HealthBar _healthBar;
        
        public event Action<Vector2> OnCharacterMoveEvent;
        
        private Rigidbody2D _rigidbody;
        private readonly float _speed;
        private bool _isMoving;
        
        private CharacterActionActivator CharacterActionActivator { get; set; }

        [Inject]
        public void Initialize(Joystick joystick, ActionButton actionButton, DeathScreen deathScreen, HealthBar healthBar,
            WoodDetector woodDetector, EnemyDetector enemyDetector)
        {
            _joystick = joystick;
            _rigidbody = GetComponent<Rigidbody2D>();
            Transform = transform;
            _isMoving = true;
            
            var animator = GetComponent<Animator>();

            _deathScreen = deathScreen;
            _healthBar = healthBar;
            
            _healthBar.GetFullHealth(health);

            _characterDeathAnimator = new CharacterDeathAnimator(animator);
            
            
            _characterMovementAnimator = new CharacterMovementAnimator(animator);

            OnCharacterMoveEvent += _characterMovementAnimator.SetDirectionAnimation;
            _joystick.OnBeginDragEvent += _characterMovementAnimator.SetRunAnimation;
            _joystick.OnEndDragEvent += _characterMovementAnimator.SetIdleAnimation;

            _listenerAttackAndChopAnimationState = animator.GetBehaviour<ListenerAttackAndChopAnimationState>();
            _listenerAttackAndChopAnimationState.OnStateEnterEvent += DisableMovement;
            _listenerAttackAndChopAnimationState.OnStateExitEvent += EnableMovement;

            CharacterActionActivator = new CharacterActionActivator(actionButton,
                animator, timeChop, timeAttack, timeSpecialAttack);

            _woodChopper = new WoodChopper(woodDetector, CharacterActionActivator, impactForce);
            _characterAttacker = new CharacterAttacker(enemyDetector, CharacterActionActivator,
                damage, specialDamage, pointComboThreshold, comboResetTime);
        }

        private void OnDisable()
        {
            OnCharacterMoveEvent -= _characterMovementAnimator.SetDirectionAnimation;
            _joystick.OnBeginDragEvent -= _characterMovementAnimator.SetRunAnimation;
            _joystick.OnEndDragEvent -= _characterMovementAnimator.SetIdleAnimation;
            
            _listenerAttackAndChopAnimationState.OnStateEnterEvent += DisableMovement;
            _listenerAttackAndChopAnimationState.OnStateExitEvent += EnableMovement;
            
            CharacterActionActivator.Deconstruct();
            _woodChopper.Deconstruct();
            _characterAttacker.Deconstruct();
        }
        
        public void Move(Vector2 direction)
        {
            if (_isMoving)
            {
                _rigidbody.velocity = (Transform.up * direction.y +
                                       Transform.right * direction.x) * speed;
            }
            else _rigidbody.velocity = Vector2.zero;
            OnCharacterMoveEvent?.Invoke(_rigidbody.velocity);
        }
        
        public void DisableMovement() => _isMoving = false;
        public void EnableMovement() => _isMoving = true;
        
        public void TakeDamage(int damageReceived)
        {
            health -= damageReceived;
            _healthBar.ChangeHealthLine(health);
            if (health <= 0)
            {
                Die();
            }
        }
        
        private async void Die()
        {
            _characterDeathAnimator.SetDieAnimation();
            await Task.Delay(600);
            _deathScreen.ShowScreen();
        }
    }
}