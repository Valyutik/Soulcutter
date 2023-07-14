using UnityEngine;

namespace Soulcutter.Scripts.CharacterControl
{
    public class CharacterMovement
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;
        private readonly float _speed;

        public CharacterMovement(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _transform = rigidbody.transform;
            _speed = speed;
        }
        
        public void Move(Vector2 direction)
        {
            _rigidbody.velocity = (_transform.up * direction.y +_transform.right * direction.x) * _speed;
        }
    }
}