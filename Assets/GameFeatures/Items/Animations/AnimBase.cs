using DG.Tweening;
using UnityEngine;

public abstract class AnimBase : MonoBehaviour
{
    protected Sequence animSequence;

    public virtual void StopAnim()
    {
        animSequence?.Kill();
    }

    public abstract void PlayAnim();
}
