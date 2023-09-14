using SuperMaxim.Messaging;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDectectCollision : MonoBehaviour
{
    private Dictionary<string ,ItemBase> holdingItems = new Dictionary<string, ItemBase>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Item"))
            {
                var item = collision.GetComponent<ItemBase>();

                if (item.ItemConfig.TypeActiveItem == TypeActiveItem.REMAIN)
                {
                    if (holdingItems.TryGetValue(item.ItemConfig.ItemKey, out var activedItem))
                    {
                        if(activedItem.IsTrigger)
                            activedItem.DestroyItem(false);
                        holdingItems.Remove(item.ItemConfig.ItemKey);
                    }
                    holdingItems.Add(item.ItemConfig.ItemKey, item);
                }

                item.TriggerItem();
            }
        }
    }
}
