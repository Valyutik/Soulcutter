using NavMeshPlus.Extensions;
using UnityEngine;

namespace Soulcutter.Scripts.Combat.Enemies
{
    public class EnemyMovement
    {
        private readonly AgentOverride2d _navMeshAgent;
        private readonly Transform _transform;
        private bool _canMove;
        public Vector2 Velocity => _navMeshAgent.Agent.velocity;
        
        public EnemyMovement(AgentOverride2d navMeshAgent)
        {
            _navMeshAgent = navMeshAgent;
            _transform = navMeshAgent.transform;
            _navMeshAgent.Agent.updateRotation = false;
            _navMeshAgent.Agent.updateUpAxis = false;
            _canMove = true;
        }

        public void SetDirection(Vector2 point)
        {
            if (_canMove)
            {
                _navMeshAgent.Agent.SetDestination(point);
            }
        }
        
        public void DisableMovement()
        {
            _canMove = false;
            _navMeshAgent.Agent.SetDestination(_transform.position);
        }
        
        public void EnableMovement()
        {
            _canMove = true;
        }
    }
}