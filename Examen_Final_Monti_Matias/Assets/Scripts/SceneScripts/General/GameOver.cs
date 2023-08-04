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
        [SerializeField] private CountdownTimer countdown;

        private int destroyedSpheres;

        private void Start()
        {
            destroyedSpheres = destroySphereCount.GetSpheresDestroyed();
            destroyedSpheresText.text = "Spheres Destroyed: " + destroyedSpheres;

            highScoreManager.AddHighscore(destroyedSpheres, countdown.GetTime());

            ShowHighscores();
        }

        private void ShowHighscores()
        {
            if (highScoreManager != null)
            {
                List<ScoreData> highscores = highScoreManager.GetHighscores();

                string highscoreString = "Highscores: \n";

                for (int i = 0; i < highscores.Count; i++)
                {
                    highscoreString += (i + 1) + ". " + highscores[i].score + " - Time: " + highscores[i].time.ToString("F2") + "s\n";
                }

                highscoreText.text = highscoreString;
            }
        }
    }
}