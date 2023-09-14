using System;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpConfig", menuName = "Avoid_Monster/Config/CharacterController/Jump", order = 1)]
public class JumpConfigs : ScriptableObject
{
    [HideInInspector] public Action onStartJump;
    [HideInInspector] public Action onEndJump;

    [SerializeField] protected float jumpHeight = 12;
    [SerializeField] protected float gravityScale = 12;
    [SerializeField] protected float groundCheckRadius = 0.1f;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected bool canMoveWhenJump = false;

    private void OnEnable()
    {
        groundLayer = 1 << LayerMask.NameToLayer("Ground");
    }

    private bool isGrounded = true;
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    public float JumpHeight { get => jumpHeight; }
    public float GravityScale { get => gravityScale; }
    public float GroundCheckRadius { get { return groundCheckRadius; } }
    public LayerMask GroundLayer { get { return groundLayer; } }
    public bool CanMoveWhenJump { get {  return canMoveWhenJump; } }

    public void ClearAllAction()
    {
        onStartJump = null;
        onEndJump = null;
    }
}
