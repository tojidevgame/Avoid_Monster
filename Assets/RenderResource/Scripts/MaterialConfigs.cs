using System;
using System.Collections.Generic;
using UnityEngine;

public enum Color
{
    BLUE,
    GREEN,
    PINK,
    RED,
    STRONG_BLUE,
    YELLOW
}

[Serializable]
public struct MatData
{
    public Color ColorKey;
    public Material Material;
}

[CreateAssetMenu(fileName = "MaterialConfigs", menuName = "Avoid_Monster/Config/Resource Render/MaterialConfigs")]
public class MaterialConfigs : ScriptableObject
{
    [SerializeField] private List<MatData> matData;
}
