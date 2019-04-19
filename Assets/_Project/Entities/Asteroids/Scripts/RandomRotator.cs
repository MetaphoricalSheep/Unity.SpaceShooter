using UnityEngine;

namespace Assets.Scripts
{
    public class RandomRotator : MonoBehaviour
    {
        public float Tumble;

        private Rigidbody rigidBody;

        public void Start()
        {
            Setup();

        }

        private void Setup()
        {
            rigidBody = GetComponent<Rigidbody>();
            rigidBody.angularVelocity = Random.insideUnitSphere * Tumble;
        }
    }
}
