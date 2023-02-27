using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 30;
    public float angularVelocity = 12;
    public Transform mainCamera;
    public Rigidbody rb;
    private Vector3 movement;

    [Header("Jump")]
    [SerializeField] public float groundDistance = 0.54f;//0.54f
    public LayerMask groundMask;
    public float jumpForce = 10;
    bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.maxAngularVelocity = angularVelocity;
    }

    private void Update()
    {
        //Ground check
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        //Jump call
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        //Player move + forward based on camera
        Vector3 cameraForward = mainCamera.forward;
        cameraForward.y = 0f;

        movement = Input.GetAxis("Horizontal") * cameraForward.normalized * -1 +
                   Input.GetAxis("Vertical") * mainCamera.right;

      //movement = movement.normalized * speed * Time.deltaTime;
      //transform.position += movement;
        Move();
    }

    private void Move()
    {
        rb.AddTorque(movement * speed);
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, .54f);
    }*/
}
