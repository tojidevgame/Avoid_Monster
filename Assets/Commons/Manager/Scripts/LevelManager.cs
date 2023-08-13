using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField] private Difficulties diffConfigs;


    private int nextMileScore;

    private Difficulty curDiff;

    public Difficulty CurDiff { get => curDiff;}

    private void Start()
    {
        ResetLevel();
    }

    private void ResetLevel()
    {
        curDiff = diffConfigs.GetCurDifficulty(0);
        nextMileScore = diffConfigs.MileStoneScoreNextDiff();
    }
}
