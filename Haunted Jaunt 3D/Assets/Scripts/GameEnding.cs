using UnityEngine;

namespace Assets.Scripts
{
    public class GameEnding : MonoBehaviour
    {
        private bool m_IsPlayerAtExit;
        private float m_Timer;

        public float FadeDuration = 1f;
        public float DisplayImageDuration = 5f;
        public CanvasGroup ExitBackgroundImageCanvasGroup;
        public GameObject Player;

        // Start is called before the first frame update
        private void Start()
        {
        
        }

        // Update is called once per frame
        private void Update()
        {
            if (m_IsPlayerAtExit)
            {
                EndLevel();
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == Player)
            {
                m_IsPlayerAtExit = true;
            }
        }

        private void EndLevel()
        {
            m_Timer += Time.deltaTime;
            ExitBackgroundImageCanvasGroup.alpha = m_Timer / FadeDuration;

            if (m_Timer > FadeDuration + DisplayImageDuration)
            {
                Application.Quit();
            }
        }
    }
}
