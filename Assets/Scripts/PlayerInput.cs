using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float tolerance = 0.1f;
    public Platform platform;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var collider = Physics2D.OverlapCircle(point, tolerance);

            if (collider)
                collider?.GetComponent<Destroyable>()?.Activate();
            else
                CreatePlatform(point);
        }
    }

    void CreatePlatform(Vector2 position)
    {
        position.x = Mathf.Floor(position.x) + 0.5f; //align to grid
        position.y = Mathf.Floor(position.y) + 0.5f;

        Instantiate(platform, position, Quaternion.identity).Activate();
    }
}
