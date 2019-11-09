using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float tolerance = 0.1f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var collider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), tolerance);

            if (collider?.GetComponent<Destroyable>())
                collider?.GetComponent<Destroyable>().Activate();
        }
    }
}
