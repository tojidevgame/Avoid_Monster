
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPU : PopupBase
{
    [SerializeField] private ScoreDataSO scoreData;

    [Space(12), Header("Normal Game Over")]
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TextMeshProUGUI txtHighScore;

    [Space(12), Header("New High Score Game Over")]
    [SerializeField] private TextMeshProUGUI txtNewHighScore;

    [Space(12)]
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnRevive;

    [Space(12), Header("Data")]
    [SerializeField] private ScoreDataSO scoreDataSO;

    [SerializeField] private int timeToShowStartGamePU;

    private void Awake()
    {
        btnRestart.onClick.AddListener(OnRestart);
        btnRevive.onClick.AddListener(OnRevive);
    }


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

    private async void OnRestart()
    {
        PopupsManager.Instance.ClosePopup(PopupType.GameOver);
        await UniTask.Delay(timeToShowStartGamePU);
        PopupsManager.Instance.ShowPopup(PopupType.StartGame).Forget();
    }

    private void OnRevive()
    {
        // Revive
        AdManager.Instance.ShowRewardedAd( async () =>
        {
            ConsoleLog.Log("Revive");
            PopupsManager.Instance.ClosePopup(PopupType.GameOver);
            await UniTask.Delay(timeToShowStartGamePU);
            PopupsManager.Instance.ShowPopup(PopupType.StartGame).Forget();
        });
    }

    private void OnDestroy()
    {
        btnRestart.onClick.RemoveAllListeners();
        btnRevive.onClick.RemoveAllListeners();
    }
}
