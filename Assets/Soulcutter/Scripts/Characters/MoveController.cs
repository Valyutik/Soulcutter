using Soulcutter.Scripts.Bootstrap;
using Soulcutter.Scripts.UI.Joysticks;

namespace Soulcutter.Scripts.Characters
{
    public class MoveController : IGameStateListener
    {
        private readonly IMovable _movable;
        private readonly IMoveInput _moveInput;

        public MoveController(IMoveInput moveInput, IMovable movable)
        {
            _movable = movable;
            _moveInput = moveInput;
        }
        
        public void OnStartGame()
        {
            _moveInput.OnDragEvent += _movable.Move;
        }

        public void OnFinishGame()
        {
            _moveInput.OnDragEvent -= _movable.Move;
        }
    }
}