using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class BasePool : ScriptableObject
{
    public abstract GameObject Rent(string key);
    public abstract void Return(string key, object obj);
    public abstract void Prewarm(Transform parentRoot = null);
}
