using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float ScrollSpeed;

    private Vector3 startPosition;

    public void Start()
    {
        startPosition = transform.position;
    }

    public void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * ScrollSpeed, transform.localScale.y);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
