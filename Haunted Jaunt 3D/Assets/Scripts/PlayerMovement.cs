using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public float TurnSpeed = 20f;

        private Vector3 m_Movement;
        private Quaternion m_Rotation = Quaternion.identity;
        private Animator m_Animator;
        private Rigidbody m_RigidBody;
        private AudioSource m_AudioSource;

        private void Start()
        {
            m_Animator = GetComponent<Animator>();
            m_RigidBody = GetComponent<Rigidbody>();
            m_AudioSource = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            m_Movement.Set(horizontal, 0f, vertical);
            m_Movement.Normalize();

            var hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            var hasVerticalInput = !Mathf.Approximately(vertical, 0f);
            var isWalking = hasHorizontalInput || hasVerticalInput;
            m_Animator.SetBool("IsWalking", isWalking);

            if (isWalking)
            {
                if (!m_AudioSource.isPlaying)
                {
                    m_AudioSource.Play();
                }
            }
            else
            {
                m_AudioSource.Stop();
            }

            Vector3 desiredForward =
                Vector3.RotateTowards(transform.forward, m_Movement, TurnSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(desiredForward);
        }

        private void OnAnimatorMove()
        {
            m_RigidBody.MovePosition(m_RigidBody.position + m_Movement * m_Animator.deltaPosition.magnitude);
            m_RigidBody.MoveRotation(m_Rotation);
        }
    }
}
