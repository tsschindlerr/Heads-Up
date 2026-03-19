using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //player movement
    private Rigidbody2D playerRb;
    private bool isGrounded;
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private float playerJumpForce;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public int extraJumpsAmount;
    private int extraJumps;

    //animation
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        extraJumps = extraJumpsAmount;
    }

    void Update()
    {
        MovePlayer();
    }
    private void FixedUpdate()
    {
        //overlap circle checking if player touches the ground layer
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    void MovePlayer()
    {
        float moveInput = Input.GetAxis("Horizontal");
        playerRb.linearVelocity = new Vector2(moveInput * playerMoveSpeed, playerRb.linearVelocity.y);

        if (isGrounded)
        {
            extraJumps = extraJumpsAmount;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, playerJumpForce);
            }
            else if (extraJumps > 0)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, playerJumpForce);
                extraJumps--;
            }
        }

        SetAnimation(moveInput);
        FlipPlayerSprite();
    }

    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if (moveInput == 0)
            {
                animator.Play("player_idle");
            }
            else
            {
                animator.Play("player_walk");
            }
        }
        else
        {
            if (playerRb.linearVelocityY > 0)
            {
                animator.Play("player_jump");
            }
        }
    }
    private void FlipPlayerSprite()
    {
        if (playerRb.linearVelocityX != 0)
        {
            if (playerRb.linearVelocityX > 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}