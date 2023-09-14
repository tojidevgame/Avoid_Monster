using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerDataSO;
    [SerializeField] private EnemyMoveConfig enemyMoveConfig;
    [SerializeField] private float minDistanceToReach = 0.5f;

    public int Index { get => index; }

    private Vector2 target;
    private int index = 0;

    public void InitEnemy(int index)
    {
        this.index = index;
        target = playerDataSO.PosAtIndex(ref index);
    }

    private void FixedUpdate()
    {
        bool isReachTarget = Vector2.Distance(target, transform.position) <= minDistanceToReach;

        if(isReachTarget)
        {
            target = playerDataSO.PosAtIndex(ref index);
        }

        transform.position = Vector2.MoveTowards(transform.position, target, enemyMoveConfig.Speed * Time.fixedDeltaTime);
    }
}
