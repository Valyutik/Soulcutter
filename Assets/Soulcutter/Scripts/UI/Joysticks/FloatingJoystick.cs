using UnityEngine;
using UnityEngine.EventSystems;

namespace Soulcutter.Scripts.UI.Joysticks
{
    public class FloatingJoystick : Joystick
    {
        public override void Initialize(Camera cam)
        {
            base.Initialize(cam);
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
    }
}