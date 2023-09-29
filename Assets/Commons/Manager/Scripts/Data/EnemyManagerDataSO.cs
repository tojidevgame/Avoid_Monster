using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyManagerSO", menuName = "Avoid_Monster/Runtime Data/EnemyManagerSO")]
public class EnemyManagerDataSO : ScriptableObject
{
    [SerializeField] private BasePool enemyPool;
    [SerializeField] private GlobalData globalData;
    [SerializeField] private PlayerDataSO playerDataSO;
    [SerializeField] private LevelDataSO levelDataSO;

    [Space(12)]
    [SerializeField] private int gapBetweenTwoIndex = 10;
    [SerializeField] private int gapBetweenFirstEnemyWithPlayer = 20;

    private List<EnemyFollow> enemies = new List<EnemyFollow>();

    public int AmountEnemy => enemies.Count;

    public void KillEnemy(GameObject enemy)
    {
        enemies.Remove(enemy.GetComponent<EnemyFollow>());
        enemyPool.Return(globalData.ENEMY_KEY, enemy);

        //TODO: Effect here
    }

    public void KillEnemy(EnemyFollow enemyObj)
    {
        enemies.Remove(enemyObj);
        enemyPool.Return(globalData.ENEMY_KEY, enemyObj.gameObject);

        //TODO: Effect here
    }

    public void ClearAllEnemy()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            KillEnemy(enemies[i]);
        }
    }

    public void CreateEnemy()
    {
        if (!levelDataSO.CanAddEnemy())
            return;

        var enemyObj = enemyPool.Rent(globalData.ENEMY_KEY);
        EnemyFollow enemyFollow = enemyObj.GetComponent<EnemyFollow>();


        int newEnemyIndex = 0;
        if (enemies.Count > 0)
            newEnemyIndex = enemies[enemies.Count - 1].Index - gapBetweenTwoIndex;
        else
            newEnemyIndex = playerDataSO.CurrentPlayerIndex() - gapBetweenFirstEnemyWithPlayer;
        playerDataSO.ClampEnemyIndex(ref newEnemyIndex);


        enemyFollow.InitEnemy(newEnemyIndex);
        enemyFollow.transform.position = playerDataSO.PosAtIndex(ref newEnemyIndex);


        enemyObj.SetActive(true);


        enemies.Add(enemyFollow);
    }

    public void StopAllEnemy()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetMoveAbility(false);
        }
    }
}
