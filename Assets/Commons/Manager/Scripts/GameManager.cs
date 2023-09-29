using Cysharp.Threading.Tasks;
using SuperMaxim.Messaging;
using UnityEngine;

public struct GameOverPayload
{

}
public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemyManagerDataSO enemyDataSO;

    [Space(12), Header("Player")]
    [SerializeField] private Rigidbody2D playerRigid;
    [SerializeField] private ParticleSystem playerSpawnEffect;
    [SerializeField] private int timeToEnablePhysic = 500;
    [SerializeField] private Vector3 originalPosPlayer;

    [Space(12)]
    [SerializeField] private InputManager inputManager;

    [Space(12), Header("Data")]
    [SerializeField] private ScoreDataSO scoreDataSO;

    [Space(12)]
    [SerializeField] private int timeDelayShowGameOverPU = 500;


    private bool isGameOver = false;



    #region CALLBACK_FUNCTION
    private void Awake()
    {

#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        Application.targetFrameRate = 60;
#endif
        Messenger.Default.Subscribe<GameOverPayload>(OnGameOver);
        Messenger.Default.Subscribe<StartGamePayload>(OnStartGame);
        DisablePlayer();
    }

    private async void Start()
    {
        await PopupsManager.Instance.ShowPopup(PopupType.StartGame, async () =>
        {
            Messenger.Default.Publish<StartGamePayload>(new StartGamePayload());
        });
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.M))
            PopupsManager.Instance.ShowPopup(PopupType.StartGame).Forget();
#endif
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<GameOverPayload>(OnGameOver);
        Messenger.Default.Unsubscribe<StartGamePayload>(OnStartGame);
    }

    #endregion





    #region ON_GAME_OVER
    private async void OnGameOver(GameOverPayload payload)
    {
        if (isGameOver)
            return;
        ConsoleLog.LogError("On Game Over");
        isGameOver = true;


        SetActiveInput(false);
        StopAllMovement();

        await UniTask.Delay(timeDelayShowGameOverPU);
        await PopupsManager.Instance.ShowPopup(PopupType.GameOver);
    }

    private void StopAllMovement()
    {
        enemyDataSO.StopAllEnemy();
    }

    #endregion





    #region ON_START_GAME
    private void OnStartGame(StartGamePayload payload)
    {
        ConsoleLog.LogError("On Start Game");
        isGameOver = false;
        StartGameplay();
    }

    private async void ClearGame()
    {
        await PopupsManager.Instance.ShowPopup(PopupType.StartGame);
        //TODO: Wait to showed PU endgame
        enemyDataSO.ClearAllEnemy();
    }

    private void DisablePlayer()
    {
        // Setup Player
        playerRigid.bodyType = RigidbodyType2D.Kinematic;
        playerRigid.gameObject.SetActive(false);
    }

    private async UniTask EnablePlayer()
    {
        playerRigid.position = originalPosPlayer;
        //playerSpawnEffect?.Play();
        playerRigid.gameObject.SetActive(true);
        await UniTask.Delay(timeToEnablePhysic);

        playerRigid.bodyType = RigidbodyType2D.Dynamic;
    }

    private async void StartGameplay()
    {
        await EnablePlayer();
        SetActiveInput(true);
    }


    #endregion

    #region COMMON_FUNCTION
    private void SetActiveInput(bool isActive)
    {
        inputManager.gameObject.SetActive(isActive);
        inputManager.BlockInput(isActive);
    }
    #endregion

}
