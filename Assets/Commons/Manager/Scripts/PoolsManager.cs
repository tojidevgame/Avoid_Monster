using UnityEngine;

public class PoolsManager : MonoSingleton<PoolsManager>
{
    [Header("Game Object Pools")]
    [SerializeField] private GameObjectPools goPools;
    [SerializeField] private Transform goPoolRoot;

    public static bool IsDoneInit = false;
    protected override void Awake()
    {
        base.Awake();
        goPools.Prewarm(goPoolRoot);

        IsDoneInit = true;
    }
}
