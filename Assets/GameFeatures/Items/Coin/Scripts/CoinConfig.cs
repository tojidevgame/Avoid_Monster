using UnityEngine;

[CreateAssetMenu(fileName = "CoinConfig", menuName = "Avoid_Monster/Item/Config Item/CoinConfig")]
public class CoinConfig : ItemConfigBase
{
    [Space(12)]
    [SerializeField] private int score;
    [SerializeField] private string effectCoinDestroyKey;
    [SerializeField] private int rateAppear;

    public string EffectCoinDestroyKey => effectCoinDestroyKey;
    public int Score => score;
    public int RateAppear => rateAppear;
}
