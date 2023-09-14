using UnityEngine;

public class JumpPerform : MonoBehaviour
{
    [SerializeField] protected JumpConfigs jumpData;
    [SerializeField] protected RunConfigs runData;
    [SerializeField] protected InputDataSO moveInput;

    [Space(10), Header("Check")]
    [SerializeField] protected Transform groundCheck;
    protected Rigidbody2D rigidBody2D;

    protected int extraJumps;

    protected float yGravity;

    protected bool jumpInput;

    protected void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        moveInput.JumpInput += OnJumpClick;
        yGravity = Physics2D.gravity.y;
    }

    private void OnJumpClick()
    {
        jumpInput = true;
    }

    protected void Start()
    {
        rigidBody2D.gravityScale = jumpData.GravityScale;
    }

    protected void Update()
    {
        bool previousStatus = jumpData.IsGrounded;
        // check if grounded
        jumpData.IsGrounded = Physics2D.OverlapCircle(groundCheck.position, jumpData.GroundCheckRadius, jumpData.GroundLayer);

        if(!previousStatus && jumpData.IsGrounded)
        {
            jumpData.onEndJump?.Invoke();
        }

        // Extra jump
        if (jumpInput && jumpData.IsGrounded)  // Normal jump
        {
            float velocityY = Mathf.Sqrt(-2 * jumpData.JumpHeight * yGravity * jumpData.GravityScale);
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, velocityY);
            jumpData.onStartJump?.Invoke();

            jumpInput = false;
        }

    }

    private void OnDestroy()
    {
        moveInput.JumpInput += OnJumpClick;
    }
}
