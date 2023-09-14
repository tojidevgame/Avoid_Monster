using UnityEngine;

public class EffectReturnToPool : MonoBehaviour
{
    [SerializeField] private string effectKey;
    [SerializeField] private BasePool effectPool;
    private void OnParticleSystemStopped()
    {
        effectPool.Return(effectKey, this.gameObject);
    }
}
