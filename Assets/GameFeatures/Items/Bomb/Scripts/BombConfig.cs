using UnityEngine;

[CreateAssetMenu(fileName = "BombConfig", menuName = "Avoid_Monster/Config/Item/BombConfig")]
public class BombConfig : ScriptableObject
{
    [SerializeField] private float timeToExpode = 1f;
    [SerializeField] private float rangeExplode = 1f;
    [SerializeField] private LayerMask layerImpact;

    public float TimeToExpode { get => timeToExpode;}
    public float RangeExplode { get => rangeExplode;}
    public LayerMask LayerImpact { get => layerImpact;}
}
