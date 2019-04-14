using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float Lifetime;

    public void Start()
    {
        Destroy(gameObject, Lifetime);
    }
}
