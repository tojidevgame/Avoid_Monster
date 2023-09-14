using UnityEngine;

public class RunPerform : MonoBehaviour
{
    [SerializeField] protected RunConfigs runData;
    [SerializeField] protected JumpConfigs jumpData;
    [SerializeField] protected DashConfigs dashData;
    [SerializeField] protected InputDataSO moveInput;

    protected Rigidbody2D rigidBody2D;
    protected MoveController2D moveController;

    private bool canMove = true;
    private float slowMulti = 1f;

    protected virtual void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        moveController = GetComponent<MoveController2D>();
    }

    protected virtual void FixedUpdate()
    {
        float moveAbility = (canMove ? 1 : 0) * (!jumpData.IsGrounded && !jumpData.CanMoveWhenJump?0:1);
        float velocityX = moveAbility * slowMulti * moveInput.HorizontalInput * runData.Speed;
        if((jumpData.IsGrounded || jumpData.CanMoveWhenJump) && !dashData.IsDashing)
        {
            rigidBody2D.velocity = new Vector2(velocityX, rigidBody2D.velocity.y);
        }
    }

    protected virtual void Update()
    {
        if (!runData.IsFacingRight && moveInput.HorizontalInput > 0f)
            runData.IsFacingRight = !runData.IsFacingRight;
        else if (runData.IsFacingRight && moveInput.HorizontalInput < 0f)
            runData.IsFacingRight = !runData.IsFacingRight;
    }
}
