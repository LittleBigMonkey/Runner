using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Destroy")]
public class DestroyAction : PlayerAction
{
    public override void Execute(object data)
    {
        if (data is Collider2D collider) collider?.GetComponent<Destroyable>()?.Activate();
    }
}
