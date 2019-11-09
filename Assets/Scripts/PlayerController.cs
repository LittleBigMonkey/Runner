using System;
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

    Vector2 bottomCheck, roofCheck, lowCheck, highCheck, pitCheck;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        jumpVelocity = Mathf.Sqrt(-2.0f * Physics2D.gravity.y * jumpHeight);

        bottomCheck = new Vector2(collider.offset.x, collider.offset.y - collider.size.y * 0.5f); //middle bottom
        roofCheck = new Vector2(collider.offset.x - collider.size.x * 0.5f, collider.offset.y); //left center
        lowCheck = new Vector2(collider.offset.x + collider.size.x * 0.5f, collider.offset.y - collider.size.y * 0.25f); //right 25% low
        highCheck = new Vector2(collider.offset.x + collider.size.x * 0.5f, collider.offset.y + collider.size.y * 0.25f); //right 25% high
        pitCheck = new Vector2(collider.offset.x + collider.size.x * 0.5f, collider.offset.y - collider.size.y * 0.5f); //right bottom
    }

    void FixedUpdate()
    {
        var flag = PhysicCheck();

        velocity = rigidbody.velocity; //get current velocity
        velocity.x = speed; //set speed


        if (flag.HasFlag(DetectionFlags.Ground))
        {
            if (flag.HasFlag(DetectionFlags.LowObstacle) || flag.HasFlag(DetectionFlags.Pit))
                Jump();

            if (flag.HasFlag(DetectionFlags.HighObstacle))
                Crouch();
            else if (!flag.HasFlag(DetectionFlags.Roof))
                StandUp();
        }

        rigidbody.velocity = velocity;
    }

    DetectionFlags PhysicCheck()
    {
        var flag = DetectionFlags.None;

        if (Raycast(bottomCheck, Vector2.down, detectionDistance * 0.1f, groundMask)) flag |= DetectionFlags.Ground;
        if (Raycast(lowCheck, Vector2.right, detectionDistance, groundMask)) flag |= DetectionFlags.LowObstacle;
        if (Raycast(highCheck, Vector2.right, detectionDistance, groundMask)) flag |= DetectionFlags.HighObstacle;
        if (Raycast(roofCheck, Vector2.up, detectionDistance, groundMask)) flag |= DetectionFlags.Roof;
        if (!Raycast(pitCheck, Vector2.down, detectionDistance, groundMask)) flag |= DetectionFlags.Pit;

        return flag;
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
        transform.localScale = new Vector3(1.0f, 0.45f, 1.0f); //animation
    }

    void StandUp()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);  //animation
    }

    [Flags]
    public enum DetectionFlags
    {
        None = 0,
        Ground = 1,
        LowObstacle = 2,
        HighObstacle = 4,
        Roof = 8,
        Pit = 16
    }
}
