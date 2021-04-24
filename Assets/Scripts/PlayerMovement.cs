using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpHeight = 2f;

    Rigidbody rb;
    Animator anim;

    float horizontalInput;
    Vector3 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        // actual movement
        rb.MovePosition(rb.position + moveDir * Time.fixedDeltaTime * movementSpeed);
    }

    void Move()
    {
        // get input and calculate direction
        horizontalInput = Input.GetAxisRaw("Horizontal");
        moveDir = new Vector3(horizontalInput, 0, 0);

        // animation
        if (horizontalInput == 0) anim.SetBool("walking", false);
        else anim.SetBool("walking", true);
    }

    void Jump()
    {
        // check for input
        if (!Input.GetButtonDown("Jump")) return;

        // check if grounded
        if (!isGrounded()) return;

        // jump
        rb.AddForce(Vector3.up * jumpHeight * 1000);

        // animation
        anim.SetTrigger("jump");
    }

    bool isGrounded()
    {
        // use collider height to calculate raycast origin
        Vector3 _origin = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        // raycast down a little to check if ground is hit
        bool _hit = Physics.Raycast(_origin, Vector3.down, 0.5f);

        return _hit;     
    }

}
