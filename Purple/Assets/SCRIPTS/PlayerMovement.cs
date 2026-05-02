using Mono.Cecil;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; set; }

    [Header("References")]
    public Purple_Guy_Movement_Stats moveStats;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask groundLayer;


    private float playerHalfHeight;

    public Rigidbody2D rb;

    //movement vars
    public Vector2 moveVelocity;
    public bool isFacingRight;

    //Wall Slide
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    //WallJump
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 8f);

    //Collision vars
    public bool isGrounded;

    //jump var
    public float verticalVelocity;
    public bool isJumping;
    public bool jumpStart;
    public bool isDescending;
    public bool isFalling;
    public int jumpsUsed;
    public float walljumpDistance = 5;

    //Coyote time vars
    public float coyoteTimer;

    //Finish condition
    public bool finished;

    public bool wallJumpLeft;
    public bool wallJumpRight;

    private void Awake()
    {

        finished = false;
        isFacingRight = true;
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHalfHeight = spriteRenderer.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        JumpChecks();
        WallSlide();
        if (!isWallJumping) 
        {
            Flip();
        }
        
        WallJump();
        
    }

    private void FixedUpdate()
    {
        Jump();
        if (isGrounded)
        {
            Move(moveStats.groundAcceleration, moveStats.groundDeceleration, Purple_Guy_Input_Manager.movement);
        }
        else
        {
            Move(moveStats.airAcceleration, moveStats.airDeceleration, Purple_Guy_Input_Manager.movement);
        }
    }
    #region Movement
    private void Move(float acceleration, float deceleration, Vector2 moveInput)
    {
        if (moveInput != Vector2.zero)
        {
            //TurnCheck(moveInput);

            Vector2 targetVelocity = Vector2.zero;
            targetVelocity = new Vector2(moveInput.x, 05) * moveStats.maxWalkSpeed;
            moveVelocity = Vector2.Lerp(moveVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
            rb.linearVelocity = new Vector2(moveVelocity.x, rb.linearVelocity.y);
        }
        else if (moveInput == Vector2.zero)
        {
            moveVelocity = Vector2.Lerp(moveVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
            rb.linearVelocity = new Vector2(moveVelocity.x, rb.linearVelocity.y);
        }
    }
    //void TurnCheck(Vector2 moveInput)
    //{
    //    if (isFacingRight && moveInput.x < 0)
    //    {
    //        Turn(false);
    //    }
    //    else if (!isFacingRight && moveInput.x > 0)
    //    {
    //        Turn(true);
    //    }
    //}
    //void Turn(bool turnRight)
    //{
    //    if (turnRight)
    //    {
    //        isFacingRight = true;
    //        transform.Rotate(0f, 180f, 0f);
    //    }
    //    else
    //    {
    //        isFacingRight = false;
    //        transform.Rotate(0f, -180f, 0f);
    //    }
    //}
    private void Flip()
    {
        if (isFacingRight && rb.linearVelocityX < 0f || !isFacingRight && rb.linearVelocityX > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }

    #endregion

    #region Jump

    private void JumpChecks()
    {
        //When we press the jump button
        if (Purple_Guy_Input_Manager.jumpWasPressed)
        {
            StartCoroutine(JumpLimit());
        }
        //When we release the jump button
        if (Purple_Guy_Input_Manager.jumpIsReleased)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y*0.3f);
            isDescending = true;
        }


        //Initiate jump with coyote time
        if (jumpStart && GetIsGrounded() && jumpsUsed < moveStats.numberOfJumpsAllowed)
        {
            InitiateJump(1);
        }
        //Double jump
        else if (isDescending && jumpsUsed < moveStats.numberOfJumpsAllowed)
        {
            InitiateJump(1);
        }
        ////Air jump after coyote time lapsed
        //else if (coyoteTimer <= 0f && isFalling && jumpsUsed < moveStats.numberOfJumpsAllowed - 1)
        //{
        //    InitiateJump(2);
        //}
        //Landed
        if ((isDescending || isFalling) && GetIsGrounded())
        {
            isJumping = false;
            isFalling = false;
            jumpStart = false;
            isDescending = false;
            jumpsUsed = 0;
        }
    }

    private void InitiateJump(int numberOfJumpsUsed)
    {
        if (!jumpStart)
        {
            jumpStart = true;
        }

        
        verticalVelocity = moveStats.jumpHeight;
        coyoteTimer = 0f;
        
    }
    private void Jump()
    {
        if (isJumping==true && !isDescending)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveStats.jumpHeight);
            if (jumpsUsed == 0)
            {
                jumpsUsed = 1;
            }
        }
        

    }
    //Wall Jump

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, LayerMask.GetMask("Wall"));
    }

    private void WallSlide()
    {
        if (IsWalled() && !isGrounded && moveVelocity.x != 0f)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.fixedDeltaTime;
        }

        if (wallJumpingCounter >0f && Purple_Guy_Input_Manager.jumpWasPressed)
        {
            isWallJumping = true;
            rb.linearVelocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if(transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }
    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    
    #endregion

    #region Collison Checks
    //Collision checks


    private bool GetIsGrounded()
    {
        
        return Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight+0.1f, groundLayer);
        
    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = true;
    //        verticalVelocity = 0;
    //        isFalling = false;
    //        //CountTimers();
    //    }
    //}
    //public void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = false;
    //        if (!isJumping)
    //        {
    //            isFalling = true;
    //            CountTimers();
    //        }
    //    }
    //}
    
    #endregion

    #region Timers
    private void CountTimers()
    {

        if (!isGrounded && isFalling)
        {
            coyoteTimer -= Time.deltaTime;
        }
        else
        {
            coyoteTimer = moveStats.jumpCoyoteTime;
        }
    }
    #endregion

    IEnumerator JumpLimit()
    {
        jumpStart = true;
        isJumping = true;
        yield return new WaitForSeconds(0.05f);
        jumpStart = false;
        isDescending = true;
        isJumping = false;
    }
    IEnumerator WallJumpLimitLeft()
    {

        yield return new WaitForSeconds(0.1f);
        wallJumpLeft = false;
    }
    IEnumerator WallJumpLimitRight()
    {

        yield return new WaitForSeconds(0.1f);
        wallJumpRight = false;
    }
}

