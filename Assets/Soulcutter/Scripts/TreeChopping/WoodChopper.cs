using Soulcutter.Scripts.UI.ActionButton;
using UnityEngine;

namespace Soulcutter.Scripts.TreeChopping
{
    public class WoodChopper : MonoBehaviour
    {
        [SerializeField] private int impactForce;
        private InteractionObjectDetector.InteractionObjectDetector _detector;
        private ActionButton _actionButton;

        public void Initialize(InteractionObjectDetector.InteractionObjectDetector detector, ActionButton actionButton)
        {
            _detector = detector;
            _actionButton = actionButton;

            _actionButton.OnPressChopEvent += ChopWood;
        }

        private void OnDisable()
        {
            _actionButton.OnPressChopEvent -= ChopWood;
        }

        private void ChopWood()
        {
            _detector.GetCurrentWood().TakeDamage(impactForce);
        }
    }
}