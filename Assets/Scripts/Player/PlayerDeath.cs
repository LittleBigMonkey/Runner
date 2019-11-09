using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    new Rigidbody2D rigidbody;

    public float timeout = 0.5f;
    float hitTime = 0.0f;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rigidbody.velocity.sqrMagnitude <= 0.001f)
        {
            hitTime += Time.deltaTime;

            if (hitTime > timeout) Die(); //death on stop
        }
        else
            hitTime = 0.0f;
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
