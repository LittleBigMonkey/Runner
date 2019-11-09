using UnityEngine;

public class Activator : MonoBehaviour
{
    IActivable[] activables;

    void Awake()
    {
        activables = GetComponentsInChildren<IActivable>();
    }

    void OnEnable()
    {
        foreach (var item in activables)
            item.Reset();
    }
}
