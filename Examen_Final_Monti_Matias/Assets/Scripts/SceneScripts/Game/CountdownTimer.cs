using UnityEngine;
using TMPro;

namespace tankDefend
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField] private float totalTime = 60f;
        private float currentTime;
        private bool isTimerRunning = true;

        [SerializeField] private TextMeshProUGUI timerText;
        private GameManager gameManager;

        private void Start()
        {
            gameManager = GetComponent<GameManager>();
            ResetTimer();
        }

        private void Update()
        {
            if (isTimerRunning)
            {
                currentTime -= Time.deltaTime;

                if (currentTime <= 0f)
                {
                    currentTime = 0f;
                    gameManager.OnGameOver.Invoke();
                    isTimerRunning = false;
                }

                UpdateTimerText();
            }
        }

        private void ResetTimer()
        {
            currentTime = totalTime;
            UpdateTimerText();
        }

        private void UpdateTimerText()
        {
            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public float GetTime()
        {
            return currentTime;
        }
    }
}