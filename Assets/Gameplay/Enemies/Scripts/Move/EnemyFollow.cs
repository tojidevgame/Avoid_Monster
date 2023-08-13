using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private EnemyInfo enemyInfo;
    [SerializeField] private Rigidbody2D rigid2D;
    [SerializeField] private EnemyMoveConfig enemyMoveConfig;
    [SerializeField] private float minDistanceToReach = 0.5f;

    public int Index { get => index; }

    private Vector2 target;
    private Vector2 velocity = Vector2.zero;
    private int index = 0;

    private MapManager instanceMap;

    public void InitEnemy(int index)
    {
        this.index = index;
        instanceMap = MapManager.Instance;
        target = instanceMap.PosAtIndex(ref index);
    }

    private void FixedUpdate()
    {
        bool isReachTarget = Vector2.Distance(target, transform.position) <= minDistanceToReach;

        if(isReachTarget)
        {
            target = instanceMap.PosAtIndex(ref index);
        }

        transform.position = Vector2.MoveTowards(transform.position, target, enemyMoveConfig.Speed * Time.fixedDeltaTime);
    }
}
