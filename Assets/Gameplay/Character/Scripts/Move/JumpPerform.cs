using UnityEngine;

public class JumpPerform : MonoBehaviour
{
    [SerializeField] protected JumpConfigs jumpData;
    [SerializeField] protected RunConfigs runData;

    [Space(10), Header("Check")]
    [SerializeField] protected Transform groundCheck;

    protected MoveInput moveInput;
    protected Rigidbody2D rigidBody2D;

    protected int extraJumps;
    protected float extraJumpHeight;

    protected float velocity = 0;

    protected virtual void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        moveInput = GetComponent<MoveInput>();
    }

    protected virtual void Start()
    {
        extraJumpHeight = jumpData.JumpHeight * jumpData.ExtraJumpHeightMulti;
        rigidBody2D.gravityScale = jumpData.GravityScale;
    }

    protected virtual void Update()
    {
        bool previousStatus = jumpData.IsGrounded;
        // check if grounded
        jumpData.IsGrounded = Physics2D.OverlapCircle(groundCheck.position, jumpData.GroundCheckRadius, jumpData.GroundLayer);

        if (jumpData.IsGrounded)
        {
            extraJumps = jumpData.ExtraJumpCount;
        }

        if(!previousStatus && jumpData.IsGrounded)
        {
            jumpData.onEndJump?.Invoke();
        }

        // Extra jump
        if (moveInput.JumpInput && extraJumps > 0 && !jumpData.IsGrounded)
        {
            float velocity = runData.Speed_X_WhenJump * Mathf.Sqrt(jumpData.GravityScale);
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, velocity);
            extraJumps--;
        }
        else if (moveInput.JumpInput && jumpData.IsGrounded)  // Normal jump
        {
            float velocity = runData.Speed_X_WhenJump * Mathf.Sqrt(jumpData.GravityScale);
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, velocity);
            jumpData.onStartJump?.Invoke();
        }

    }
}
