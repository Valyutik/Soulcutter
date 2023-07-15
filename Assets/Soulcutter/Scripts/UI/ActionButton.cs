using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Soulcutter.Scripts.UI
{
    public class ActionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnPressEvent, OnReleaseEvent;

        public void Initialize()
        {
            
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnPressEvent?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnReleaseEvent?.Invoke();
        }
    }
}