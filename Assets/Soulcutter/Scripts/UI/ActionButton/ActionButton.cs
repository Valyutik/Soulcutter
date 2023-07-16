using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Soulcutter.Scripts.UI.ActionButton
{
    public class ActionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnPressEvent, OnReleaseEvent;

        [SerializeField] private Sprite hitIcon;
        [SerializeField] private Sprite chopIcon;
        
        private ActionButtonType _actionButtonType;
        private Image _buttonIcon;

        public void Initialize()
        {
            _buttonIcon = transform.GetChild(0).GetComponent<Image>();
            _buttonIcon.sprite = hitIcon;
            _actionButtonType = ActionButtonType.AttackButton;
        }

        public void ChangeButtonType(ActionButtonType actionButtonType)
        {
            _actionButtonType = actionButtonType;
            _buttonIcon.sprite = _actionButtonType switch
            {
                ActionButtonType.AttackButton => hitIcon,
                ActionButtonType.ChoppingButton => chopIcon,
                _ => throw new ArgumentOutOfRangeException(nameof(actionButtonType), actionButtonType, null)
            };
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