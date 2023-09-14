using System;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType
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
    public ColorType ColorKey;
    public Material Material;
}

[CreateAssetMenu(fileName = "MaterialConfigs", menuName = "Avoid_Monster/Config/Resource Render/MaterialConfigs")]
public class MaterialConfigs : ScriptableObject
{
    [SerializeField] private List<MatData> matData;
}
