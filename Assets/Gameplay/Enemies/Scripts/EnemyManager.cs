using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    [SerializeField] private int gapBetweenTwoIndex = 10;
    [SerializeField] private GameObjectPools enemyPool;
    [SerializeField] private GlobalData globalData;

    private List<EnemyFollow> enemies = new List<EnemyFollow>();
    

    private void CreateEnemy()
    {
        MapManager map = MapManager.Instance;
        var enemyObj = enemyPool.Rent(globalData.ENEMY_KEY);
        EnemyFollow enemyFollow = enemyObj.GetComponent<EnemyFollow>();


        int newEnemyIndex = 0;
        if (enemies.Count > 0)
            newEnemyIndex = enemies[enemies.Count - 1].Index - gapBetweenTwoIndex;
        else
            newEnemyIndex = map.CurrentPlayerIndex() - gapBetweenTwoIndex;
        map.ClampEnemyIndex(ref newEnemyIndex);


        enemyFollow.InitEnemy(newEnemyIndex);
        enemyFollow.transform.position = map.PosAtIndex(ref newEnemyIndex);


        enemyObj.SetActive(true);


        enemies.Add(enemyFollow);
    }

    public void KillEnemy(EnemyFollow enemyObj)
    {
        enemies.Remove(enemyObj); 
        enemyPool.Return(globalData.ENEMY_KEY, enemyObj.gameObject);
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CreateEnemy();
        }
    }
#endif
}
