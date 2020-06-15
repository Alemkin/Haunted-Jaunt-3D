using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class WaypointPatrol : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent;
        public Transform[] Waypoints;

        private int m_CurrentWaypointIndex;

        void Start()
        {
            NavMeshAgent.SetDestination(Waypoints[0].position);
        }

        void Update()
        {
            if (NavMeshAgent.remainingDistance < NavMeshAgent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % Waypoints.Length;
                NavMeshAgent.SetDestination(Waypoints[m_CurrentWaypointIndex].position);
            }

        }
    }
}
