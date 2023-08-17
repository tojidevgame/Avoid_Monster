using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField] private Difficulties diffConfigs;
    [SerializeField] private readonly int startScoreAddEnemy = 10;


    private int mileStoneToAddEnemy;

    private Difficulty curDiff;

    public Difficulty CurDiff { get => curDiff;}

    private void Start()
    {
        ResetLevel();
    }

    private void ResetLevel()
    {
        mileStoneToAddEnemy = startScoreAddEnemy;
        curDiff = diffConfigs.GetCurDifficulty(0);
    }

    public bool CanAddEnemy(int score)
    {
        if(score > mileStoneToAddEnemy)
        {
            mileStoneToAddEnemy += Random.Range(curDiff.MinScoreToAddEnemy, curDiff.MaxScoreToAddEnemy);
            return true;
        }
        return false;
    }

}
