using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float totalTime = 60f;
    private float currentTime;
    private bool isTimerRunning = true;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
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
                GameOver();
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

    private void GameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}
