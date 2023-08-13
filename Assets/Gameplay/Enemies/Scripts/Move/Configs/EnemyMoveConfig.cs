using UnityEngine;

[CreateAssetMenu(fileName = "EnemyMoveConfig", menuName = "Avoid_Monster/Config/Enemy/MoveConfig")]
public class EnemyMoveConfig : ScriptableObject
{
    [SerializeField] private float speed;

    public float Speed { get => speed; set => speed = value; }
}
