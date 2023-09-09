using Soulcutter.Scripts.Bootstrap;
using Soulcutter.Scripts.UI.Joysticks;

namespace Soulcutter.Scripts.Characters
{
    public class MoveController : IStartGameListener,
        IFinishGameListener
    {
        private readonly IMoveable _moveable;
        private readonly IMoveInput _moveInput;

        public MoveController(IMoveInput moveInput, IMoveable moveable)
        {
            _moveable = moveable;
            _moveInput = moveInput;
        }
        
        public void OnStartGame()
        {
            _moveInput.OnDragEvent += _moveable.Move;
        }

        public void OnFinishGame()
        {
            _moveInput.OnDragEvent -= _moveable.Move;
        }
    }
}