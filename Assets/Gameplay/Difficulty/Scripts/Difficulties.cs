
using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Difficulties", menuName = "Avoid_Monster/Config/Difficulties")]
public class Difficulties : ScriptableObject
{
    [SerializeField] private Difficulty[] difficulties;

    private int curIndexDiff = 0;

    public Difficulty GetCurDifficulty(int score)
    {
        int diffLength = difficulties.Length;
        if (score >= difficulties[diffLength - 1].MileStoneScore)
        {
            curIndexDiff = diffLength - 1;
            return difficulties[diffLength - 1];
        }


        for (int i = 0; i < diffLength - 1; i++)
        {
            if (score >= difficulties[i].MileStoneScore && score < difficulties[i + 1].MileStoneScore)
            {
                curIndexDiff = i;
                return difficulties[i];
            }
        }

        curIndexDiff = 0;
        return difficulties[0];
    }

    public int MileStoneScoreNextDiff()
    {
        if (curIndexDiff >= difficulties.Length - 1)
            return int.MaxValue;

        return difficulties[curIndexDiff + 1].MileStoneScore;
    }
}


[Serializable]
public struct Difficulty
{
    public int MileStoneScore;
    public int MaxAmountEnemy;
    public int MaxAmountItem;
}


