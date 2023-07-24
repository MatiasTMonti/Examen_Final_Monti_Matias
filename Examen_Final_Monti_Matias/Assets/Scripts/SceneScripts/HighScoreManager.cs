using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class HighScoreManager : MonoBehaviour
{
    private string highScoreFile;
    private List<int> highScores = new List<int>();

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

            foreach(string line in lines)
            {
                if (int.TryParse(line, out int score))
                {
                    highScores.Add(score);
                }
            }
        }
    }

    private void SaveHighScore()
    {
        highScores.Sort((a, b) => b.CompareTo(a));

        while (highScores.Count > 3)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }

        File.WriteAllLines(highScoreFile, highScores.ConvertAll(x => x.ToString()).ToArray());
    }

    public void AddHighscore(int score)
    {
        highScores.Add(score);
        SaveHighScore();
    }

    public List<int> GetHighscores()
    {
        return highScores;
    }
}