using UnityEngine;

public class BombItem : ItemBase
{
    private float countDownTimeExplode;

    public override void TriggerItem()
    {
        isTrigger = true;
        countDownTimeExplode = ((BombConfig)itemConfig).TimeToExpode;
    }


    private void Update()
    {
        if (!isTrigger)
            return;

        countDownTimeExplode -= Time.deltaTime;
        if(countDownTimeExplode <= 0)
        {
            Explode();

            DestroyItem();
        }
    }

    private void Explode()
    {
        // Find what enemy will be kill
        Physics2D.OverlapCircle(transform.position, ((BombConfig)itemConfig).RangeExplode, ((BombConfig)itemConfig).LayerImpact);

        // Trigger effect explode
        ConsoleLog.Log("Bomb Explore");
    }

    public override void DestroyItem(bool playDestroyEffect = true)
    {
        ResetData();
    }

    protected override void ResetData()
    {
        isTrigger = false;
    }
}
