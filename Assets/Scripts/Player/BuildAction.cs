using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Build")]
public class BuildAction : PlayerAction
{
    public Platform platform;

    public override void Execute(object data)
    {
        if (data is Vector2 point) CreatePlatform(point);
    }
    
    void CreatePlatform(Vector2 position)
    {
        position.x = Mathf.Floor(position.x) + 0.5f; //align to grid
        position.y = Mathf.Floor(position.y) + 0.5f;

        Instantiate(platform, position, Quaternion.identity).Activate();
    }
}
