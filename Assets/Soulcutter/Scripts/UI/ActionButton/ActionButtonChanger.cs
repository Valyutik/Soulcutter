namespace Soulcutter.Scripts.UI.ActionButton
{
    public class ActionButtonChanger
    {
        private readonly ActionButton _actionButton;
        
        public ActionButtonChanger(ActionButton button)
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