using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolsManager : MonoBehaviour
{
    [Serializable]
    protected struct PoolSpawn
    {
        public BasePool pool;
        public Transform poolRoot;
    }

    [SerializeField] private List<PoolSpawn> spawnList;


    public static bool IsDoneInit = false;
    protected void Awake()
    {
        foreach (var poolSpawn in spawnList)
        {
            poolSpawn.pool.Prewarm(poolSpawn.poolRoot);
        }

        IsDoneInit = true;
    }
}
