using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField] private float maxDistanceToReach = 0.2f;
    [SerializeField] private EnemyDataManagement dataManagement;

    private uint curIndex;
    private Vector2 targetPos = Vector2.zero;

    private bool isDoneSetup = false;

    private EnemyInput enemyInput;

    private void Start()
    {
        Setup(0);
    }

    public async void Setup(uint index)
    {
        isDoneSetup = false;
        dataManagement = GetComponent<EnemyDataManagement>();


        await UniTask.WaitUntil(() => dataManagement.IsDoneInit);

        enemyInput = GetComponent<EnemyInput>();
        curIndex = index;
        targetPos = HistoryPlayer.Instance.CurPos(curIndex);
        enemyInput.HorizontalInput = CalculateDirect(targetPos);

        dataManagement.RegisterOnStartJump(() =>
        {
            enemyInput.JumpInput = false;
        });

        isDoneSetup = true;
    }

    private void Update()
    {
        if (!isDoneSetup)
            return;

        // Is enemy reach to player
        if(Vector2.Distance(targetPos, transform.position) <= maxDistanceToReach)
        {
            enemyInput.JumpInput = true;

            Vector2 nextPos = HistoryPlayer.Instance.NextPosIncreaseIndex(ref curIndex);

            enemyInput.HorizontalInput = CalculateDirect(nextPos);

            targetPos = nextPos;
        }
    }

    private int CalculateDirect(Vector2 target)
    {
        if (target.x - transform.position.x > 0)
            return 1;
        else
            return -1;
    }
}
