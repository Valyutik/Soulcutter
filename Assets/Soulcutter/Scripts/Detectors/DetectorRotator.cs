using UnityEngine;

namespace Soulcutter.Scripts.Detectors
{
    public class DetectorRotator
    {
        private readonly Transform _transform;

        private readonly Vector3 _rightRotate = new(0, 0, 90);
        private readonly Vector3 _frontRotate = new(0, 0, 0);
        private readonly Vector3 _backRotate = new(0, 0, 180);

        public DetectorRotator(Transform transform)
        {
            _transform = transform;
        }

        public void SetDirectionDetector(Vector2 velocity)
        {
            if (velocity.y < velocity.x && -velocity.y < velocity.x)
            {
                _transform.rotation = Quaternion.Euler(_rightRotate);
            }
            else if (velocity.y < velocity.x && -velocity.y > velocity.x)
            {
                _transform.rotation = Quaternion.Euler(_frontRotate);
            }
            else if (velocity.y > velocity.x && -velocity.y > velocity.x)
            {
                _transform.rotation = Quaternion.Euler(-_rightRotate);
            }
            else if (velocity.y > velocity.x && -velocity.y < velocity.x)
            {
                _transform.rotation = Quaternion.Euler(_backRotate);
            }
        }
    }
}