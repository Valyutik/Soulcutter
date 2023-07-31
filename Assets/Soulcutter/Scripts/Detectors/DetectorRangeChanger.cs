using UnityEngine;

namespace Soulcutter.Scripts.Detectors
{
    public class DetectorRangeChanger
    {
        private readonly BoxCollider2D _boxCollider2D;

        public DetectorRangeChanger(BoxCollider2D boxCollider2D)
        {
            _boxCollider2D = boxCollider2D;
        }

        public void SetRangeDetector(float detectorRange)
        {
            var offsetY = (detectorRange / -2);
            
            _boxCollider2D.size = new Vector2(1f, detectorRange);
            _boxCollider2D.offset = new Vector2(0f, offsetY);
        }
    }
}