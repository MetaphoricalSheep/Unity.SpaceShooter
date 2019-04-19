using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EvasiveManeuvers : MonoBehaviour
    {
        public float Dodge;
        public float Smoothing;
        public float Tilt;
        public MinMaxRange ManeuverTime;
        public Boundary Boundary;

        private float targetManeuver;
        private Rigidbody rigidBody;
        private Transform playerTransform;

        public void Start()
        {
            Setup();
            StartCoroutine(Evade());
        }

        public void FixedUpdate()
        {
            Maneuver();
        }

        private void Setup()
        {
            rigidBody = GetComponent<Rigidbody>();
            playerTransform = GameObject.FindWithTag("Player")?.transform;
        }

        private void Maneuver()
        {
            float newManeuver = Mathf.MoveTowards(rigidBody.velocity.x, targetManeuver, Time.deltaTime * Smoothing);
            rigidBody.velocity = new Vector3(newManeuver, 0.0f, rigidBody.velocity.z);
            rigidBody.position = new Vector3(
                Mathf.Clamp(rigidBody.position.x, Boundary.XMin, Boundary.XMax),
                0.0f,
                Mathf.Clamp(rigidBody.position.z, Boundary.ZMin, Boundary.ZMax)
            );

            rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -Tilt);
        }


        private IEnumerator Evade()
        {
            while (true)
            {
                if (playerTransform != null)
                {
                    targetManeuver = playerTransform.position.x;
                }

                yield return new WaitForSeconds(Random.Range(ManeuverTime.Min, ManeuverTime.Max));

                targetManeuver = 0;
            }
        }
    }
}
