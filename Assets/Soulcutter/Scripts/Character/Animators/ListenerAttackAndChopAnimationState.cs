using System;
using UnityEngine;

namespace Soulcutter.Scripts.Character.Animators
{
    public class ListenerAttackAndChopAnimationState : StateMachineBehaviour
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
