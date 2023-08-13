using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameController : MonoBehaviour
{
    [SerializeField] private float minTimeToChangeScene = 1f;


    private async void Start()
    {
        await UniTask.WaitUntil(() => PoolsManager.IsAlive);

        await UniTask.WaitUntil(() => PoolsManager.IsDoneInit);

        await UniTask.Delay(TimeSpan.FromSeconds(minTimeToChangeScene));

        SceneManager.LoadScene("Gameplay");
    }
}
