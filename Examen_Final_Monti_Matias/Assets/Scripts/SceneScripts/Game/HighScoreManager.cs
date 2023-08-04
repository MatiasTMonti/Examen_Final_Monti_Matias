using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace tankDefend
{
    public class HighScoreManager : MonoBehaviour
    {
        private string highScoreFile;
        private List<ScoreData> highScores = new List<ScoreData>();

        private void OnEnable()
        {
            highScoreFile = Path.Combine(Application.persistentDataPath, "highScores.txt");
            LoadHighscores();
        }

        private void LoadHighscores()
        {
            if (File.Exists(highScoreFile))
            {
                string[] lines = File.ReadAllLines(highScoreFile);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 2 && int.TryParse(parts[0], out int score) && float.TryParse(parts[1], out float time))
                    {
                        highScores.Add(new ScoreData { score = score, time = time });
                    }
                }
            }
        }

        private void SaveHighScore()
        {
            highScores.Sort((a, b) => b.score.CompareTo(a.score));

            while (highScores.Count > 3)
            {
                highScores.RemoveAt(highScores.Count - 1);
            }

            string[] lines = highScores.ConvertAll(data => $"{data.score};{data.time}").ToArray();
            File.WriteAllLines(highScoreFile, lines);
        }

        public void AddHighscore(int score, float time)
        {
            highScores.Add(new ScoreData { score = score, time = time });
            SaveHighScore();
        }

        public List<ScoreData> GetHighscores()
        {
            return highScores;
        }
    }
}