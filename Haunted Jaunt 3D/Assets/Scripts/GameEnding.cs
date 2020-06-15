using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameEnding : MonoBehaviour
    {
        private bool m_IsPlayerAtExit;
        private float m_Timer;
        private bool m_IsPlayerCaught;
        private bool m_HasAudioPlayed;

        public float FadeDuration = 1f;
        public float DisplayImageDuration = 5f;
        public CanvasGroup ExitBackgroundImageCanvasGroup;
        public GameObject Player;
        public CanvasGroup CaughtBackgroundImageCanvasGroup;

        public AudioSource ExitAudio;
        public AudioSource CaughtAudio;

        private void Start()
        {
        
        }

        private void Update()
        {
            if (m_IsPlayerAtExit)
            {
                EndLevel(ExitBackgroundImageCanvasGroup, false, ExitAudio);
            } else if (m_IsPlayerCaught)
            {
                EndLevel(CaughtBackgroundImageCanvasGroup, true, CaughtAudio);
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == Player)
            {
                m_IsPlayerAtExit = true;
            }
        }

        private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
        {
            if (!m_HasAudioPlayed)
            {
                audioSource.Play();
                m_HasAudioPlayed = true;
            }
            m_Timer += Time.deltaTime;
            imageCanvasGroup.alpha = m_Timer / FadeDuration;

            if (!(m_Timer > FadeDuration + DisplayImageDuration)) return;

            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }

        public void CaughtPlayer()
        {
            m_IsPlayerCaught = true;
        }
    }
}
