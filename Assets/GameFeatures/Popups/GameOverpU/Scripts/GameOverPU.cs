
using TMPro;
using UnityEngine;

public class GameOverPU : PopupBase
{
    [SerializeField] private ScoreDataSO scoreData;

    [Space(12), Header("Normal Game Over")]
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TextMeshProUGUI txtHighScore;

    [Space(12), Header("New High Score Game Over")]
    [SerializeField] private TextMeshProUGUI txtNewHighScore;

    [Space(12), Header("Data")]
    [SerializeField] private ScoreDataSO scoreDataSO;
    public override void PreSetupAction()
    {
        base.PreSetupAction();
        ConsoleLog.LogError("Presetup");

        bool isNewHighScore = scoreDataSO.CheckHighScore();

        if(isNewHighScore && false)
        {
            //TODO: Show Content highScore
        }
        else
        {
            //TODO: Show Content GameOver
            txtScore.SetText(scoreData.Score.ToString());
            txtHighScore.SetText(scoreData.HighScore.ToString());
        }
    }
}
