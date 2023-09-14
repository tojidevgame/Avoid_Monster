using UnityEngine;

public class DashPerform : MonoBehaviour
{
    [SerializeField] protected RunConfigs runData;
    [SerializeField] protected DashConfigs dashData;
    [SerializeField] protected JumpConfigs jumpData;

    protected InputDataSO moveInput;
    protected Rigidbody2D rigidBody2D;
    protected RunPerform runPerform;

    private float dashTimeRemain = 0f;
    private bool hasDashedInAir = false;
    private float dashCoolDown = 0f;

    private void Awake()
    {
        runPerform = GetComponent<RunPerform>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        dashTimeRemain = dashData.DashTimeRemain;
        dashData.IsDashing = false;
    }

    private void Update()
    {
        //if (!dashData.IsDashing && !hasDashedInAir && dashCoolDown <= 0f)
        //{
        //    if (moveInput.DashInput)
        //    {
        //        dashData.IsDashing = true;

        //        // if player in air while dashing
        //        if (!jumpData.IsGrounded)
        //        {
        //            hasDashedInAir = true;
        //        }
        //    }
        //}

        //dashCoolDown -= Time.deltaTime;

        //// if has dashed in air once but now grounded
        //if (hasDashedInAir && jumpData.IsGrounded)
        //    hasDashedInAir = false;
    }

    private void FixedUpdate()
    {
        // Dashing logic
        if (dashData.IsDashing)
        {
            if (dashTimeRemain <= 0f)
            {
                dashData.IsDashing = false;
                dashCoolDown = dashData.DashCooldown;
                dashTimeRemain = dashData.DashTimeRemain;
                rigidBody2D.velocity = Vector2.zero;
            }
            else
            {
                dashTimeRemain -= Time.fixedDeltaTime;
                if (runData.IsFacingRight)
                    rigidBody2D.velocity = Vector2.right * dashData.DashSpeed * Time.fixedDeltaTime;
                else
                    rigidBody2D.velocity = Vector2.left * dashData.DashSpeed * Time.fixedDeltaTime;
            }
        }
    }
}
