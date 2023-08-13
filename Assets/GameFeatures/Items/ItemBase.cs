using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public abstract void TriggerItem();
    protected abstract void DestroyItem();
    protected abstract void ResetData();
}
