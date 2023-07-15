using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoSingleton<MapManager>
{
    [SerializeField] private Transform playerTrans;

    [Space(10), Header("Line")]
    [SerializeField] private Transform[] posLine;
}
