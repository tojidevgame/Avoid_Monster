using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreDataSO scoreDataSO;

    private void Start()
    {
        scoreDataSO.ResetScore();
        scoreDataSO.HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
