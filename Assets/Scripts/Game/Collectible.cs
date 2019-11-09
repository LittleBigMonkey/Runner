using UnityEngine;

public class Collectible : MonoBehaviour, IActivable
{
    public int value = 5;

    public void Activate()
    {
        PlayerData.Score += value;
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Activate();
    }
}
