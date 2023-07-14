using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private LineInfo playerLineInfo;
    
    
    public Transform PlayerTransform { get { return playerTransform; } }
    public LineInfo PlayerInfor { get {  return playerLineInfo; } }

}
