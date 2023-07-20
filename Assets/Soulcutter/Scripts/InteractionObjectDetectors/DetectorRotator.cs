using UnityEngine;

namespace Soulcutter.Scripts.InteractionObjectDetectors
{
    public class DetectorRotator
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly BoxCollider2D _boxCollider2D;
        private readonly Vector2 _rightPosition = new Vector2(0.72f, 0);
        private readonly Vector2 _frontPosition = new Vector2(0, -0.55f);

        public DetectorRotator(Rigidbody2D rigidbody2D, BoxCollider2D boxCollider2D)
        {
            _rigidbody2D = rigidbody2D;
            _boxCollider2D = boxCollider2D;
        }

        public void SetDirectionDetector()
        {
            var velocity = _rigidbody2D.velocity.normalized;
            if (velocity.y < velocity.x && -velocity.y < velocity.x)
            {
                _boxCollider2D.offset = _rightPosition;
            }
            else if (velocity.y < velocity.x && -velocity.y > velocity.x)
            {
                _boxCollider2D.offset = _frontPosition;
            }
            else if (velocity.y > velocity.x && -velocity.y > velocity.x)
            {
                _boxCollider2D.offset = -_rightPosition;
            }
            else if (velocity.y > velocity.x && -velocity.y < velocity.x)
            {
                _boxCollider2D.offset = -_frontPosition;
            }
        }
    }
}