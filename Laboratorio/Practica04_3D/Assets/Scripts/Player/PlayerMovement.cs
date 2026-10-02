using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float runSpeed = 10f;
    public float gravity = -9.8f;
    public float jumpForce = 5f;
    CharacterController controller;
    Vector3 velocity;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb == null || rb.isKinematic)
            return;
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0,
        hit.moveDirection.z);
        rb.velocity = pushDir * 4f;
    }
    void Update()
    {
        bool isGrounded = controller.isGrounded;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isRunning ? runSpeed : speed;

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}