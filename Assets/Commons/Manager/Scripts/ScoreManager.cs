
using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    private int score;
    private int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
