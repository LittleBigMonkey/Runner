using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    public float tolerance = 0.1f;

    public PlayerAction buildAction;
    public PlayerAction destroyAction;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var collider = Physics2D.OverlapCircle(point, tolerance);

            if (collider)
                destroyAction.Execute(collider);
            else
                buildAction.Execute(point);
        }
    }
}
