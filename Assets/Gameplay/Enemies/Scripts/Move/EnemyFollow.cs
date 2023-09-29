using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerDataSO;

    private bool canMove = true;

    public int Index { get => index; }

    private int index = 0;

    public void InitEnemy(int index)
    {
        this.index = index;
    }

    public void SetMoveAbility(bool canMove = true)
    {
        this.canMove = canMove;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.position = playerDataSO.PosAtIndex(ref index);
        }
    }   
}
