using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnGameOver;
    public UnityEvent OnAllSpheresDestroyed;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject highScoreMetaData;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void OnEnable()
    {
        OnGameOver.AddListener(ShowGameOverPanel);
        OnAllSpheresDestroyed.AddListener(ShowGameOverPanel);
    }

    private void OnDisable()
    {
        OnGameOver.RemoveListener(ShowGameOverPanel);
        OnAllSpheresDestroyed.RemoveListener(ShowGameOverPanel);
    }

    private void ShowGameOverPanel()
    {
        gameOverScreen.SetActive(true);
        highScoreMetaData.SetActive(true);
        Time.timeScale = 0f;
    }
}
