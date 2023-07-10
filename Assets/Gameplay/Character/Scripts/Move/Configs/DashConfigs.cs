using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DashConfig", menuName = "CharacterController/Dash", order = 1)]
public class DashConfigs : ScriptableObject
{
    [HideInInspector] public Action onStartDash;
    [HideInInspector] public Action onEndDash;

    [SerializeField] private float dashSpeed;
    [Tooltip("Amount of time (in seconds) the player will be in the dashing speed")]
    [SerializeField] private float startDashTime;
    [Tooltip("Time (in seconds) between dashes")]
    [SerializeField] private float dashCooldown;

    private bool isDashing = false;
    public bool IsDashing { get { return isDashing; } set { isDashing = value; } }

    public float DashSpeed { get { return dashSpeed; } }
    public float DashTimeRemain { get { return startDashTime; } }
    public float DashCooldown { get { return dashCooldown; } }
}
