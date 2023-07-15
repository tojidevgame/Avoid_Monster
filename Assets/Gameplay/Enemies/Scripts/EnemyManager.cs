using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    [SerializeField] private Transform playerTransform;
    
    public Transform PlayerTransform { get { return playerTransform; } }

}
