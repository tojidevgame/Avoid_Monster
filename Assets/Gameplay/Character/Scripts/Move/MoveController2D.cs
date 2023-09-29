using UnityEngine;

public class MoveController2D : MonoBehaviour
{
    [Header("Move Data")]
    [SerializeField] protected RunConfigs runData;
    [SerializeField] protected JumpConfigs jumpData;
    [SerializeField] protected DashConfigs dashData;
    [SerializeField] protected WallJumpConfigs wallJumpData;

    [Space(10), Header("Input")]
    [SerializeField] protected InputDataSO moveInput;


    [Space(10), Header("Check")]
    [SerializeField] protected Transform groundCheck;
    protected bool canMove = true;



    protected bool isGrounded;
    protected bool isDashing = false;
    protected bool actuallyWallGrabbing = false;

    protected Rigidbody2D rigidBody2D;
    protected bool m_facingRight = true;
    protected float m_groundedRemember = 0f;
    protected int m_extraJumps;
    protected float m_extraJumpForce;
    protected float m_dashTime;
    protected bool m_hasDashedInAir = false;
    protected bool m_onWall = false;
    protected bool m_onRightWall = false;
    protected bool m_onLeftWall = false;
    protected bool m_wallGrabbing = false;
    protected readonly float m_wallStickTime = 0.25f;
    protected float m_wallStick = 0f;
    protected bool m_wallJumping = false;
    protected float m_dashCooldown;

    // 0 -> none, 1 -> right, -1 -> left
    protected int m_onWallSide = 0;
    protected int m_playerSide = 1;

    public bool IsGrounded { get { return isGrounded; } }
    public bool ActuallyWallGrabbing { get { return actuallyWallGrabbing; } }
    public bool IsDashing { get { return isDashing; } }

    public bool WallJumping
    {
        get => m_wallJumping;
        set { m_wallJumping = value; }
    }
    public bool WallGrabbing
    {
        get => m_wallGrabbing;
        set => m_wallGrabbing = value;
    }
    public float GroundedRemember => m_groundedRemember;
    public int OnWallSide => m_onWallSide;
    public int PlayerSide => m_playerSide;
    public bool IsFacingRight => m_facingRight;

    public float DashTimeRemain => m_dashTime;
    protected virtual void Start()
    {
        m_dashTime = dashData.DashTimeRemain;
        m_dashCooldown = dashData.DashCooldown;

        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        // check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, jumpData.GroundCheckSizeX, jumpData.GroundLayer);
        
        var position = transform.position;

        // check if on wall
        m_onWall = Physics2D.OverlapCircle((Vector2)position + wallJumpData.GrabRightOffset, wallJumpData.GrabCheckRadius, jumpData.GroundLayer)
                  || Physics2D.OverlapCircle((Vector2)position + wallJumpData.GrabLeftOffset, wallJumpData.GrabCheckRadius, jumpData.GroundLayer);
        m_onRightWall = Physics2D.OverlapCircle((Vector2)position + wallJumpData.GrabRightOffset, wallJumpData.GrabCheckRadius, jumpData.GroundLayer);
        m_onLeftWall = Physics2D.OverlapCircle((Vector2)position + wallJumpData.GrabLeftOffset, wallJumpData.GrabCheckRadius, jumpData.GroundLayer);

        // calculate player and wall sides as integers
        CalculateSides();

        if ((m_wallGrabbing || isGrounded) && m_wallJumping)
        {
            m_wallJumping = false;
        }

        // Flipping
        if (!m_facingRight && moveInput.HorizontalInput > 0f)
            Flip();
        else if (m_facingRight && moveInput.HorizontalInput < 0f)
            Flip();
    }

    public virtual void Flip()
    {
        m_facingRight = !m_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    protected virtual void CalculateSides()
    {
        if (m_onRightWall)
            m_onWallSide = 1;
        else if (m_onLeftWall)
            m_onWallSide = -1;
        else
            m_onWallSide = 0;

        if (m_facingRight)
            m_playerSide = 1;
        else
            m_playerSide = -1;
    }
}
