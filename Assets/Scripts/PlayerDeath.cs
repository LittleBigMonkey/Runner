using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    new Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > 1.0f && rigidbody.velocity.sqrMagnitude <= 0.01f) Die(); //death on stop
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("DeathZone")) Die(); //death on fall
    }

    void Die()
    {
        GameManager.instance.StopGame();
    }
}
