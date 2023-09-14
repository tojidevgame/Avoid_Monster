using UnityEngine;

[CreateAssetMenu(fileName = "GlobalData", menuName = "Avoid_Monster/Config/GlobalData")]
public class GlobalData : ScriptableObject
{
    [Header("Key Object")]
    [SerializeField] public string ENEMY_KEY = "pool_enemy_key";

    [Space(12), Header("Effect")]
    [SerializeField] public string EFFECT_SHIELD_DESTROY = "effect_shield_destroy";

    [SerializeField] public string NORMAL_REWARD_KEY = "pool_coin_item_key";
    [SerializeField] public string SPECIAL_REWARD_KEY = "pool_special_item_key";

    //[SerializeField] public string BOMB_ITEM_KEY = "pool_bomb_item_key";
    //[SerializeField] public string SHIELD_ITEM_KEY = "pool_shield_item_key";
}
