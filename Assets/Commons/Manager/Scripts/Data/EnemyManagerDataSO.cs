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

    private List<EnemyFollow> enemiesActive = new List<EnemyFollow>();

    public int AmountEnemy => enemiesActive.Count;

    public void KillEnemy(EnemyFollow enemyObj)
    {
        int index = enemiesActive.IndexOf(enemyObj);
        enemiesActive.Remove(enemyObj);
        enemyPool.Return(globalData.ENEMY_KEY, enemyObj.gameObject);

        //TODO: Effect here
    }

    public void ClearAllEnemy()
    {
        while(enemiesActive.Count > 0)
        {
            KillEnemy(enemiesActive[^1]);

        }
    }

    public void CreateEnemy()
    {
        if (!levelDataSO.CanAddEnemy())
            return;

        var enemyObj = enemyPool.Rent(globalData.ENEMY_KEY);
        EnemyFollow enemyFollow = enemyObj.GetComponent<EnemyFollow>();


        int newEnemyIndex = 0;
        if (enemiesActive.Count > 0)
            newEnemyIndex = enemiesActive[enemiesActive.Count - 1].Index - gapBetweenTwoIndex;
        else
            newEnemyIndex = playerDataSO.CurrentPlayerIndex() - gapBetweenFirstEnemyWithPlayer;
        playerDataSO.ClampEnemyIndex(ref newEnemyIndex);


        enemyFollow.InitEnemy(newEnemyIndex);
        enemyFollow.transform.position = playerDataSO.PosAtIndex(ref newEnemyIndex);


        enemyObj.SetActive(true);


        enemiesActive.Add(enemyFollow);
    }

    public void StopAllEnemy()
    {
        for (int i = 0; i < enemiesActive.Count; i++)
        {
            enemiesActive[i].SetMoveAbility(false);
        }
    }
}
