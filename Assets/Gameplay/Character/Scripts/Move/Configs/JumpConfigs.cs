using System;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpConfig", menuName = "CharacterController/Jump", order = 1)]
public class JumpConfigs : ScriptableObject
{
    [HideInInspector] public Action onStartJump;
    [HideInInspector] public Action onEndJump;

    [SerializeField] protected float jumpHeight;
    [SerializeField] protected float extraJumpHeightMulti;
    [SerializeField] protected float gravityScale;
    [SerializeField] protected float groundCheckRadius;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected int extraJumpCount = 1;
    [SerializeField] protected bool canMoveWhenJump = true;

    private bool isGrounded = true;
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    public float JumpHeight { get => jumpHeight; }
    public float ExtraJumpHeightMulti { get => extraJumpHeightMulti; }
    public float GravityScale { get => gravityScale; }
    public float GroundCheckRadius { get { return groundCheckRadius; } }
    public LayerMask GroundLayer { get { return groundLayer; } }
    public int ExtraJumpCount { get { return extraJumpCount; } }
    public bool CanMoveWhenJump { get {  return canMoveWhenJump; } }
}
