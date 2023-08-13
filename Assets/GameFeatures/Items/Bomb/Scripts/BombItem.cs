using Cysharp.Threading.Tasks;
using UnityEngine;

public class BombItem : ItemBase
{
    [SerializeField] private BombConfig bombConfig;
    [SerializeField] private GlobalData globalData;

    private bool isTrigger = false;
    private float countDownTime;

    public override void TriggerItem()
    {
        isTrigger = true;
        countDownTime = bombConfig.TimeToExpode;
    }


    private void Update()
    {
        if (!isTrigger)
            return;

        countDownTime -= Time.deltaTime;
        if(countDownTime <= 0)
        {
            // Get position of the first enemy 
            Explode();

            DestroyItem();
        }
    }

    private void Explode()
    {
        // Find what enemy will be kill
        Physics2D.OverlapCircle(transform.position, bombConfig.RangeExplode, bombConfig.LayerImpact);

        // Trigger effect explode
        ConsoleLog.Log("Bomb Explore");
    }

    protected override void DestroyItem()
    {
        ResetData();

    }

    protected override void ResetData()
    {
        isTrigger = false;
    }
}
