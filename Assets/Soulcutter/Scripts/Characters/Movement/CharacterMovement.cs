using System;
using UnityEngine;

namespace Soulcutter.Scripts.Characters.Movement
{
    public sealed class CharacterMovement
    {
        public event Action<Vector2> OnCharacterMoveEvent;
        
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;
        private readonly float _speed;
        private bool _isMoving;

        public CharacterMovement(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _transform = rigidbody.transform;
            _speed = speed;
            _isMoving = true;
        }
        
        public void Move(Vector2 direction)
        {
            if (_isMoving)
            {
                _rigidbody.velocity = (_transform.up * direction.y +
                                       _transform.right * direction.x) * _speed;
            }
            else _rigidbody.velocity = Vector2.zero;
            OnCharacterMoveEvent?.Invoke(_rigidbody.velocity);
        }

        public void DisableMovement() => _isMoving = false;
        public void EnableMovement() => _isMoving = true;
    }
}