using DG.Tweening;
using UnityEngine;

public class JumpPerform : MonoBehaviour
{
    [SerializeField] protected JumpConfigs jumpData;
    [SerializeField] protected RunConfigs runData;
    [SerializeField] protected InputDataSO moveInput;

    [Space(10), Header("Check")]
    [SerializeField] protected Transform groundCheck;

    [Header("Animation")]
    [SerializeField] protected Transform render;
    [SerializeField] protected Vector3 punchScale;
    [SerializeField] protected float duration;

    protected Rigidbody2D rigidBody2D;

    protected int extraJumps;

    protected float yGravity;

    protected bool jumpInput;

    Vector2 sizeBox;

    protected void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        moveInput.JumpInput += OnJumpClick;
        yGravity = Physics2D.gravity.y;

        sizeBox = new Vector2(jumpData.GroundCheckSizeX, jumpData.GroundCheckSizeY);

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

        jumpData.IsGrounded = Physics2D.OverlapBox(groundCheck.position, sizeBox, 0, jumpData.GroundLayer);

        if (!jumpData.IsGrounded)
            jumpInput = false;

        if (!previousStatus && jumpData.IsGrounded)
        {
            jumpData.onEndJump?.Invoke();
        }

        if (jumpInput && jumpData.IsGrounded)  // Normal jump
        {
            float velocityY = Mathf.Sqrt(-2 * jumpData.JumpHeight * yGravity * jumpData.GravityScale);
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, velocityY);
            jumpData.onStartJump?.Invoke();

            PlayAnimationJump();
            jumpInput = false;
        }
    }

    private void PlayAnimationJump()
    {
        render.DOKill();
        render.DOPunchScale(punchScale, duration);
    }

    private void OnDestroy()
    {
        moveInput.JumpInput += OnJumpClick;
    }

    void DebugDrawOverlapBox(Vector3 center, Vector3 halfExtents, float angle, Color color)
    {
        //Vector3 topLeft = center + Quaternion.Euler(0, 0, angle) * new Vector3(-halfExtents.x, halfExtents.y);
        //Vector3 topRight = center + Quaternion.Euler(0, 0, angle) * new Vector3(halfExtents.x, halfExtents.y);
        //Vector3 bottomLeft = center + Quaternion.Euler(0, 0, angle) * new Vector3(-halfExtents.x, -halfExtents.y);
        //Vector3 bottomRight = center + Quaternion.Euler(0, 0, angle) * new Vector3(halfExtents.x, -halfExtents.y);

        //Debug.DrawLine(topLeft, topRight, color);
        //Debug.DrawLine(topRight, bottomRight, color);
        //Debug.DrawLine(bottomRight, bottomLeft, color);
        //Debug.DrawLine(bottomLeft, topLeft, color);
    }
}
