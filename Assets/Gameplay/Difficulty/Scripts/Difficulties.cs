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

#if UNITY_EDITOR
    [SerializeField] private string jsonData;


    [ContextMenu("AM: Parse Data")]
    public void ParseData()
    {
        difficulties = JsonUtility.FromJson<Difficulty[]>(jsonData);
    }
#endif
}


[Serializable]
public struct Difficulty
{
    public int MileStoneScore;
    [Space(12)]
    public int MaxAmountEnemy;
    public int MinScoreToAddEnemy;
    public int MaxScoreToAddEnemy;

    [Space(12)]
    public int MaxAmountItem;
    public int MinItemInOneGen;
    public int MaxItemInOneGen;
    public float MinTimeToGenItem;
    public float MaxTimeToGenItem;

    [Space(12)]
    public int AmountHarmfulCanGen;
    public float MinTimeToPlayHarmful;
    public float MaxTimeToPlayHarmful;

    [Space(12)]
    public float PlayerVelocity;
    public float Enemyvelocity;
}


