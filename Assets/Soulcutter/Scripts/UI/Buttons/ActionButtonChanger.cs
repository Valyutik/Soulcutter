namespace Soulcutter.Scripts.UI.Buttons
{
    public class ActionButtonChanger
    {
        
        private readonly Buttons.ActionButton _actionButton;
        
        public ActionButtonChanger(Buttons.ActionButton button)
        {
            _actionButton = button;
        }

        public void SetAttackButtonType()
        {
            _actionButton.ChangeButtonType(ActionButtonType.AttackButton);
        }
        
        public void SetChopButtonType()
        {
            _actionButton.ChangeButtonType(ActionButtonType.ChoppingButton);
        }
    }
}