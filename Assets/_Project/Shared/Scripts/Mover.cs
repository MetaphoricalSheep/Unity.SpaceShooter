using UnityEngine;

public class Mover : MonoBehaviour
{
    public float Speed;

    private Rigidbody rigidBody;

    private void Setup()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        Setup();

        rigidBody.velocity = transform.forward * Speed;
    }
}
