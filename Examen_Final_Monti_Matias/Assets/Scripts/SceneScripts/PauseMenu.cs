using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Toggle muteToggle;

    private bool isGamePause = false;
    private bool isMuted = false;
    private float savedTimeScale;

    private void Start()
    {
        pauseMenuUI.SetActive(false);

        isMuted = audioSource.mute;
        muteToggle.isOn = isMuted;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePause)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        isGamePause = false;
        Time.timeScale = savedTimeScale;

        pauseMenuUI.SetActive(false);
    }

    public void PauseGame()
    {
        isGamePause = true;
        savedTimeScale = Time.timeScale;
        Time.timeScale = 0f;

        pauseMenuUI.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;

        muteToggle.isOn = isMuted;
    }

    public void ToggleMuteFromOptions(bool isMutedFromOptions)
    {
        isMuted = isMutedFromOptions;
        audioSource.mute = isMuted;

        muteToggle.isOn = isMuted;
    }
}
