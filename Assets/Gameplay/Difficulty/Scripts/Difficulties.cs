using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Difficulties", menuName = "Avoid_Monster/Config/Difficulties")]
public class Difficulties : ScriptableObject
{
    [SerializeField] private Difficulty[] difficulties;


    public Difficulty GetDifficulty(int level)
    {
        try
        {
            level = Mathf.Clamp(level, 0, difficulties.Length - 1);
            return difficulties[level];
        }
        catch
        {
            return difficulties[^1];
        }
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
}


