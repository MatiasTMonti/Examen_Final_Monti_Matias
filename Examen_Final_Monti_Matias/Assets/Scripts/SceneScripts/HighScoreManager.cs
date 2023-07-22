using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class HighScoreManager : MonoBehaviour
{
    private string highScoreFile;
    private List<int> highScores = new List<int>();

    private void Awake()
    {
        highScoreFile = Path.Combine(Application.persistentDataPath, "highScores.txt");
    }

    private void Start()
    {
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
        highScores.Sort((a, b) => a.CompareTo(b));

        while (highScores.Count > 3)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }

        File.WriteAllLines(highScoreFile, highScores.ConvertAll(x => x.ToString()).ToArray());
    }

    private void AddHighscore(int score)
    {
        highScores.Add(score);
        SaveHighScore();
    }

    public List<int> GetHighscores()
    {
        return highScores;
    }
}
