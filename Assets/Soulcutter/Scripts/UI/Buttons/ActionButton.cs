using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Soulcutter.Scripts.UI.Buttons
{
    public class ActionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnPressAttackEvent, OnReleaseAttackEvent;
        public event Action OnPressChopEvent, OnReleaseChopEvent;

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
            switch (_actionButtonType)
            {
                case ActionButtonType.AttackButton:
                    OnPressAttackEvent?.Invoke();
                    break;
                case ActionButtonType.ChoppingButton:
                    OnPressChopEvent?.Invoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            switch (_actionButtonType)
            {
                case ActionButtonType.AttackButton:
                    OnReleaseAttackEvent?.Invoke();
                    break;
                case ActionButtonType.ChoppingButton:
                    OnReleaseChopEvent?.Invoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Inable() => gameObject.SetActive(true);

        public void Disable() => gameObject.SetActive(false);
    }
}