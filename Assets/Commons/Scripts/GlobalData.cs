using UnityEngine;

[CreateAssetMenu(fileName = "GlobalData", menuName = "Avoid_Monster/Config/GlobalData")]
public class GlobalData : ScriptableObject
{
    [Header("Key Object")]
    [SerializeField] public string ENEMY_KEY = "pool_enemy_key";
    [SerializeField] public string NORMAL_REWARD_KEY = "pool_normal_reward_key";
    [SerializeField] public string SPECIAL_REWARD_KEY = "pool_special_reward_key";
    [SerializeField] public string BOMB_ITEM_KEY = "pool_bomb_item_key";
}
