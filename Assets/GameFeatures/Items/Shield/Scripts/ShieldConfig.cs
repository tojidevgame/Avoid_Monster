using UnityEngine;

[CreateAssetMenu(fileName = "ShieldConfig", menuName = "Avoid_Monster/Item/Config Item/ShieldConfig")]
public class ShieldConfig : ItemConfigBase
{
    [SerializeField] private string effectShieldDestroyKey;

    public string EffectShieldDestroyKey => effectShieldDestroyKey;
}
