using UnityEngine;

namespace Soulcutter.Scripts.Detectors
{
    public class DetectorRotator
    {
        private readonly BoxCollider2D _boxCollider2D;
        private readonly Vector2 _rightPosition = new(0.72f, 0);
        private readonly Vector2 _frontPosition = new(0, -0.55f);

        public DetectorRotator( BoxCollider2D boxCollider2D)
        {
            _boxCollider2D = boxCollider2D;
        }

        public void SetDirectionDetector(Vector2 velocity)
        {
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