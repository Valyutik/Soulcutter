using System;
using UnityEngine;

namespace Soulcutter.Scripts.Character.Movement
{
    public class CharacterMovementDisable : StateMachineBehaviour
    {
        public event Action OnStateEnterEvent, OnStateExitEvent;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            OnStateEnterEvent?.Invoke();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            OnStateExitEvent?.Invoke();
        }
    }
}
