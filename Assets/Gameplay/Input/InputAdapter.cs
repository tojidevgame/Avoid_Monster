using UnityEngine;
using UnityEngine.UI;

public class InputAdapter : MonoBehaviour
{
    [SerializeField] private InputDataSO inputDataSO;
    [SerializeField] private Joystick joyStick;
    [SerializeField] private Button btnJump;

    private void Awake()
    {
        btnJump.onClick.AddListener(TriggerJump);
    }

    private void TriggerJump()
    {
        inputDataSO.JumpInput.Invoke();
    }

    private void Update()
    {
        inputDataSO.HorizontalInput = joyStick.Horizontal;

#if UNITY_EDITOR
        inputDataSO.HorizontalInput = Input.GetAxis("Horizontal");
#endif
    }

    private void OnDestroy()
    {
        btnJump.onClick.RemoveAllListeners();
    }
}
