using UnityEngine;

[CreateAssetMenu(fileName = "BombConfig", menuName = "Avoid_Monster/Item/Config Item/ShieldConfig")]
public class ShieldConfig : ScriptableObject
{
    [SerializeField] private float timeRemain = 5f;

    public float TimeRemain
    {
        get { return timeRemain; } 
    }
}
