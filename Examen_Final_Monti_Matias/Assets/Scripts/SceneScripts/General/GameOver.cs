using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace tankDefend
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI destroyedSpheresText;
        [SerializeField] private TextMeshProUGUI highscoreText;

        [SerializeField] private HighScoreManager highScoreManager;
        [SerializeField] private DestroySphereCount destroySphereCount;

        private int destroyedSpheres;

        private void Start()
        {
            destroyedSpheres = destroySphereCount.GetSpheresDestroyed();
            destroyedSpheresText.text = "Spheres Destroyed: " + destroyedSpheres;

            highScoreManager.AddHighscore(destroyedSpheres);

            ShowHighscores();
        }

        private void ShowHighscores()
        {
            if (highScoreManager != null)
            {
                List<int> highscores = highScoreManager.GetHighscores();

                string highscoreString = "Highscores: \n";

                for (int i = 0; i < highscores.Count; i++)
                {
                    highscoreString += (i + 1) + ". " + highscores[i] + "\n";
                }

                highscoreText.text = highscoreString;
            }
        }
    }
}