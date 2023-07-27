using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace tankDefend
{
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
            StartCoroutine(ShowGameOverCoroutine());
        }

        private IEnumerator ShowGameOverCoroutine()
        {
            yield return new WaitForSeconds(1f);
            gameOverScreen.SetActive(true);
            highScoreMetaData.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}