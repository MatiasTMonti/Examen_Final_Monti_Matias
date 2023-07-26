using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace tankDefend
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuUI;

        private bool isGamePause = false;
        private float savedTimeScale;

        private void Start()
        {
            pauseMenuUI.SetActive(false);
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
    }
}