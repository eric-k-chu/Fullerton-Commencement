using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    
    private CharacterController player;
    
    private Vector3 moveVector;
    private Vector3 playerVelocity;

    private float xInput;
    private float zInput;
    private float groundCheckRadius = 0.4f;

    [SerializeField] private bool isGrounded;

    private void Awake()
    {
        player = GetComponent<CharacterController>();   
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask, QueryTriggerInteraction.Ignore);

        Gravity();
        PlayerInput();
        Move();
    }

    // Creating Gravity vector
    void Gravity()
    {
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        playerVelocity.y += gravity * Time.deltaTime;
    }

    // Creating player motion vector
    void PlayerInput()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        moveVector = transform.right * xInput + transform.forward * zInput;
    }

    void Move()
    {
        player.Move(moveVector * moveSpeed * Time.deltaTime);
        player.Move(playerVelocity * Time.deltaTime);
    }


}
