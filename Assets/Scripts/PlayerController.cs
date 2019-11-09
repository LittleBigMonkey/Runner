using UnityEngine;

public class PlayerController : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    new BoxCollider2D collider;

    public float speed = 5.0f;
    public float jumpHeight = 2.0f;
    float jumpVelocity;
    Vector2 velocity;

    public float detectionDistance = 0.75f;
    public LayerMask groundMask;

    bool isGrounded = false;

    Vector2 bottomCheck, topCheck, lowCheck, highCheck;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        jumpVelocity = Mathf.Sqrt(-2.0f * Physics2D.gravity.y * jumpHeight);

        bottomCheck = new Vector2(collider.offset.x, collider.offset.y - collider.size.y * 0.5f); //middle bottom
        topCheck = new Vector2(collider.offset.x - collider.size.x * 0.5f, collider.offset.y); //left center
        lowCheck = new Vector2(collider.offset.x + collider.size.x * 0.5f, collider.offset.y - collider.size.y * 0.5f + collider.size.y * 0.25f); //right 25% high
        highCheck = new Vector2(collider.offset.x + collider.size.x * 0.5f, collider.offset.y - collider.size.y * 0.5f + collider.size.y * 0.75f); //right 75% high
    }

    void FixedUpdate()
    {
        velocity = rigidbody.velocity; //get current velocity
        velocity.x = speed; //set speed

        isGrounded = Raycast(bottomCheck, Vector2.down, detectionDistance * 0.1f, groundMask);

        if (isGrounded)
        {
            if (Raycast(lowCheck, Vector2.right, detectionDistance, groundMask))
                Jump();

            if (Raycast(highCheck, Vector2.right, detectionDistance, groundMask))
                Crouch();
            else if (!Raycast(topCheck, Vector2.up, detectionDistance, groundMask))
                StandUp();
        }

        rigidbody.velocity = velocity;
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 direction, float length, LayerMask mask)
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + offset, direction, length, mask);
        Debug.DrawRay((Vector2)transform.position + offset, direction * length, hit ? Color.red : Color.green);

        return hit;
    }

    void Jump()
    {
        velocity.y = jumpVelocity;
    }

    void Crouch()
    {
        transform.localScale = new Vector3(1.0f, 0.45f, 1.0f);
    }

    void StandUp()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}
