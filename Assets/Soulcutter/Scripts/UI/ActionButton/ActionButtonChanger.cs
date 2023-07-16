using System;

namespace Soulcutter.Scripts.UI.ActionButton
{
    public class ActionButtonChanger
    {
        public event Action OnSetChopButtonType, OnSetAttackButtonType;
        
        private readonly ActionButton _actionButton;
        
        public ActionButtonChanger(ActionButton button)
        {
            _actionButton = button;
        }

        public void SetAttackButtonType()
        {
            _actionButton.ChangeButtonType(ActionButtonType.AttackButton);
            OnSetAttackButtonType?.Invoke();
        }
        
        public void SetChopButtonType()
        {
            _actionButton.ChangeButtonType(ActionButtonType.ChoppingButton);
            OnSetChopButtonType?.Invoke();
        }
    }
}