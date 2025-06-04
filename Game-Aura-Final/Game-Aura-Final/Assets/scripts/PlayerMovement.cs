using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 7f;
    [SerializeField] private float jumpHoldTime = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    private bool isJumping;
    private float jumpTimeCounter;

    // Input dari UI
    [HideInInspector] public float uiHorizontalInput = 0f;
    [HideInInspector] public bool uiJumpPressed = false;
    [HideInInspector] public bool uiJumpHeld = false;
    [HideInInspector] public bool uiJumpReleased = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Ambil input keyboard
        float inputX = Input.GetAxis("Horizontal");

        // Gunakan input UI jika tidak ada input keyboard
        if (Mathf.Abs(uiHorizontalInput) > Mathf.Abs(inputX))
            horizontalInput = uiHorizontalInput;
        else
            horizontalInput = inputX;

        // Flip sprite sesuai arah
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Animasi
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            // Saat menempel di dinding
            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 7;
            }

            // Trigger lompat
            if (Input.GetKeyDown(KeyCode.Space) || uiJumpPressed)
                Jump();

            // Tahan loncat
            if ((Input.GetKey(KeyCode.Space) || uiJumpHeld) && isJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                    jumpTimeCounter -= Time.deltaTime;
                }
            }

            // Lepas tombol loncat
            if (Input.GetKeyUp(KeyCode.Space) || uiJumpReleased)
            {
                isJumping = false;
                uiJumpReleased = false; // reset agar tidak loncat terus
            }
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }

        // Reset jumpPressed agar tidak loncat terus
        uiJumpPressed = false;
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            jumpTimeCounter = jumpHoldTime;
            isJumping = true;
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }

            wallJumpCooldown = 0;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,
                                                     boxCollider.bounds.size, 0,
                                                     Vector2.down, 0.1f,
                                                     groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,
                                                     boxCollider.bounds.size, 0,
                                                     new Vector2(transform.localScale.x, 0), 0.1f,
                                                     wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return isGrounded() && !onWall();
    }

    // ========= Fungsi untuk tombol UI =========
    public void MoveLeftButtonDown() => uiHorizontalInput = -1f;
    public void MoveRightButtonDown() => uiHorizontalInput = 1f;
    public void MoveButtonUp() => uiHorizontalInput = 0f;

    public void JumpButtonDown()
    {
        uiJumpPressed = true;
        uiJumpHeld = true;
    }

    public void JumpButtonUp()
    {
        uiJumpReleased = true;
        uiJumpHeld = false;
    }
}
