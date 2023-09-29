using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataSO", menuName = "Avoid_Monster/Runtime Data/LevelDataSO")]
public class LevelDataSO : ScriptableObject
{
    [SerializeField] private ScoreDataSO scoreDataSO;
    [SerializeField] private EnemyManagerDataSO enemyManagerDataSO;
    [SerializeField] private Difficulties diffConfigs;
    [SerializeField] private RunConfigs playerRunConfig;
    [SerializeField] private readonly int startScoreAddEnemy = 10;

    private Difficulty curDiff;
    private int mileStoneToAddEnemy;
    private int curLevel;

    public Difficulty CurrentDiff => curDiff;

    public void ResetLevel()
    {
        mileStoneToAddEnemy = startScoreAddEnemy;
        curLevel = 0;
        curDiff = diffConfigs.GetDifficulty(curLevel);
        playerRunConfig.Speed = curDiff.PlayerVelocity;
    }

    public bool CanAddEnemy()
    {
        if (scoreDataSO.Score > mileStoneToAddEnemy && enemyManagerDataSO.AmountEnemy <= curDiff.MaxAmountEnemy)
        {
            mileStoneToAddEnemy += Random.Range(curDiff.MinScoreToAddEnemy, curDiff.MaxScoreToAddEnemy);
            return true;
        }
        return false;
    }

    public void TryUpdateLevel()
    {
        if(scoreDataSO.Score > curDiff.MileStoneScore)
        {
            curLevel++;
            curDiff = diffConfigs.GetDifficulty(curLevel);
            playerRunConfig.Speed = curDiff.PlayerVelocity;
        }
    }
}
