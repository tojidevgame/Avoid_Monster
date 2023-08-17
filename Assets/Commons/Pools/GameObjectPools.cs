using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct PoolData
{
    public string Key;
    public GameObject Prefab;
    public uint Prewarms;
}

[CreateAssetMenu(fileName = "GameObjectPools", menuName = "Avoid_Monster/Config/Pools/GameObjectPools")]
public class GameObjectPools : BasePool
{
    [SerializeField] private List<PoolData> poolData;

    private Dictionary<string, Queue<GameObject>> pools;

    private GameObject Prefab(string key)
    {
        foreach (var data in poolData)
        {
            if (data.Key.Equals(key))
                return data.Prefab;
        }
        return null;
    }


    public override GameObject Rent(string key)
    {
        try
        {
            pools.TryGetValue(key, out var pool);
            if (pool.Count <= 0)
            {
                return Instantiate(Prefab(key));
            }

            var obj = pool.Peek();
            pool.Dequeue();
            return obj;
        }
        catch (Exception e)
        {
            ConsoleLog.LogError($"Pool with key: {key} was not init" + e);
            return null;
        }
    }

    public override void Return(string key, object obj)
    {
        try
        {
            pools.TryGetValue(key, out var pool);
            var go = (GameObject)obj;
            go.SetActive(false);
            pool.Enqueue(go);
        }
        catch (Exception e)
        {
            ConsoleLog.LogError($"Pool with key: {key} was not init" + e);
        }
    }

    public override void Prewarm(Transform parentRoot)
    {
        if (pools == null)
            pools = new Dictionary<string, Queue<GameObject>>();

        foreach (var data in poolData)
        {
            Queue<GameObject> pool = new Queue<GameObject>();
            int index = 0;
            for (int i = 0; i < data.Prewarms; i++)
            {
                GameObject obj = Instantiate(data.Prefab, parentRoot);
                obj.SetActive(false);
                obj.name = obj.name + index++;
                pool.Enqueue(obj);
            }

            pools.Add(data.Key, pool);
        }
    }
}
