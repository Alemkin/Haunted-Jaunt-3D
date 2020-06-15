using UnityEngine;

namespace Assets.Scripts
{
    public class Observer : MonoBehaviour
    {
        public Transform Player;
        public GameEnding GameEnding;

        private bool m_IsPlayerInRange;
        private void Start()
        {
        
        }

        private void Update()
        {
            CheckRayCast();
        }

        private void CheckRayCast()
        {
            if (!m_IsPlayerInRange) return;
            var direction = Player.position - transform.position + Vector3.up;
            var ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (!Physics.Raycast(ray, out raycastHit)) return;
            if (raycastHit.collider.transform == Player)
            {
                GameEnding.CaughtPlayer();
            }


        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform == Player)
            {
                m_IsPlayerInRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform == Player)
            {
                m_IsPlayerInRange = false;
            }
        }
    }
}
