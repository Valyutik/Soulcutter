using NavMeshPlus.Extensions;
using UnityEngine;

namespace Soulcutter.Scripts.Combat
{
    public class EnemyMovement
    {
        private AgentOverride2d _navMeshAgent;
        private Vector2 _point;

        public EnemyMovement(AgentOverride2d navMeshAgent)
        {
            _navMeshAgent = navMeshAgent;
            _navMeshAgent.Agent.updateRotation = false;
            _navMeshAgent.Agent.updateUpAxis = false;
        }

        public void SetDirection(Vector2 point)
        {
            _navMeshAgent.Agent.SetDestination(point);
        }
    }
}