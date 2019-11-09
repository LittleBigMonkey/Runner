using UnityEngine;

public class Platform : MonoBehaviour, IActivable
{
    public float lifetime = 5.0f;

    public void Activate()
    {
        Destroy(gameObject, lifetime); //do stuff like particles
    }

    public void Reset()
    {
        Destroy(gameObject);
    }
}
