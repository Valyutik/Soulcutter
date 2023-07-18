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

        }

        public void SubscribeActionButton()
        {
            _actionButton.OnPressEvent += ChopWood;
        }

        public void UnsubscribeActionButton()
        {
            _actionButton.OnPressEvent -= ChopWood;
        }

        private void OnDisable()
        {
            UnsubscribeActionButton();
        }

        private void ChopWood()
        {
            _detector.GetCurrentWood().TakeDamage(impactForce);
        }
    }
}