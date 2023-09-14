using UnityEngine;

public class ItemBoundPosition : MonoBehaviour
{
    [SerializeField] private Transform leftBotPos;
    [SerializeField] private Transform rightTopPos;

    [Space(12)]
    [SerializeField] private MapDataSO mapDataSO;

    public Vector2 RandomPosition()
    {
        float x = Random.Range(leftBotPos.position.x, rightTopPos.position.x);
        float y = Random.Range(leftBotPos.position.y, rightTopPos.position.y);

        return new Vector2(x, y);
    }

    public void ReturnToPool()
    {
        mapDataSO.ReturnToPool(this);
    }
}
