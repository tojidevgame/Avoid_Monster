using Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private PlayerDataSO playerData; 
    [SerializeField] private JumpConfigs jumpConfigs;
    [SerializeField] private float yDamingWhenJump;
    [SerializeField] private float yDamingWhenRun;
    [SerializeField] private float minDistanceToSetRunDaming;

    private bool isJumping = false;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        jumpConfigs.onStartJump += SetJumpDaming;
        jumpConfigs.onEndJump += EndJump;
    }

    private void Update()
    {
        if(isJumping) return;

        if(Mathf.Abs(playerData.PlayerTransform.position.y - virtualCamera.transform.position.y) <= minDistanceToSetRunDaming)
        {
            SetupYDaming(yDamingWhenRun);
        }
    }

    private void OnDestroy()
    {
        jumpConfigs.onStartJump -= SetJumpDaming;
        jumpConfigs.onEndJump -= EndJump;
    }

    private void SetJumpDaming()
    {
        isJumping = true;
        SetupYDaming(yDamingWhenJump);
    }


    private void EndJump()
    {
        isJumping = false;
    }

    private void SetupYDaming(float yDaming)
    {
        var follow = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        follow.m_YDamping = yDaming;
    }

}
