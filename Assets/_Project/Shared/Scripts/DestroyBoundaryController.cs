using UnityEngine;

public class DestroyBoundaryController : MonoBehaviour
{
    public void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
