using UnityEngine;

public class Destroyable : MonoBehaviour, IActivable
{
    public void Activate()
    {
        gameObject.SetActive(false); //do stuff like particles
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }
}
