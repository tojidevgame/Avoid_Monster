using UnityEngine;
using DG.Tweening;

public class YoyoAnim : AnimBase
{
    [SerializeField] private Vector2 distance;
    [SerializeField] private float duration;
    [SerializeField] private Ease ease;


    public override void StopAnim()
    {
        animSequence.Kill(transform);
    }

    public override void PlayAnim()
    {
        animSequence = DOTween.Sequence();
        animSequence.Append(transform.DOMove((Vector2)transform.position + distance, duration)).SetLoops(-1, LoopType.Yoyo)
            .SetEase(ease);
    }
}
