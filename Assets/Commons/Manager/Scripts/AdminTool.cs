using UnityEngine;
using UnityEngine.UI;

public class AdminTool : MonoBehaviour
{
    [SerializeField] private Button btnAdmin;
    [SerializeField] private GameObject adminContent;

    [Space(12), Header("Stat")]
    [SerializeField] private Text fps;
    private float timeSettext = float.MinValue;

    private void Awake()
    {
        btnAdmin.onClick.AddListener(ActiveAdminContent);
    }

    private void ActiveAdminContent()
    {
        adminContent.SetActive(!adminContent.activeSelf);
    }

    private void Update()
    {
        if(Time.time > timeSettext + 0.5)
        {
            timeSettext = Time.time;
            fps.text = $"FPS: {(1.0f / Time.deltaTime)}";
        }
    }
}
