using UnityEngine;

[CreateAssetMenu(fileName = "ScoreDataSO", menuName = "Avoid_Monster/Runtime Data/ScoreData")]
public class ScoreDataSO : ScriptableObject
{
    private int score;
    private int highScore;

    public int Score
    {
        get { return score; }
    }

    public int HighScore
    {
        get { return highScore; }
        set
        {
            highScore = value;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void AddScore(int value)
    {
        if (score + value < 0)
            return;
        score += value;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public bool CheckHighScore()
    {
        bool result = score > highScore;
        if (result)
        {
            HighScore = score;
        }
        return result;
    }
}
