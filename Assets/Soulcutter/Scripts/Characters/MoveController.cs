using Soulcutter.Scripts.Bootstrap;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;
using Zenject;

namespace Soulcutter.Scripts.Characters
{
    public class MoveController : MonoBehaviour, IStartGameListener,
        IFinishGameListener
    {
        private IMoveable _moveable;
        private IMoveInput _moveInput;

        [Inject]
        public void Initialize(IMoveInput moveInput, IMoveable moveable)
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