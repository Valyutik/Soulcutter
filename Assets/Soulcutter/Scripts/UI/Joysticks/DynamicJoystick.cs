using UnityEngine;
using UnityEngine.EventSystems;

namespace Soulcutter.Scripts.UI.Joysticks
{
    public class DynamicJoystick : Joystick
    {
        public float MoveThreshold {
            set => moveThreshold = Mathf.Abs(value);
        }

        [SerializeField] private float moveThreshold = 1;
    
        public override void Initialize()
        {
            MoveThreshold = moveThreshold;
            base.Initialize();
            background.gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            background.gameObject.SetActive(false);
            base.OnPointerUp(eventData);
        }

        protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
        {
            if (magnitude > moveThreshold)
            {
                var difference = normalised * (magnitude - moveThreshold) * radius;
                background.anchoredPosition += difference;
            }
            base.HandleInput(magnitude, normalised, radius, cam);
        }
    }
}