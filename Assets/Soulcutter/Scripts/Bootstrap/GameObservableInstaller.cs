using Soulcutter.Scripts.Characters;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;

namespace Soulcutter.Scripts.Bootstrap
{
    public sealed class GameObservableInstaller : MonoBehaviour
    {
        [SerializeField] private GameMachine gameMachine;
        [SerializeField] private Joystick joystick;
        [SerializeField] private MoveController moveController;

        private void Awake()
        {
            gameMachine.AddListener(joystick);
            gameMachine.AddListener(moveController);
        }
    }
}