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
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, playerJumpForce);
        }
    }
}