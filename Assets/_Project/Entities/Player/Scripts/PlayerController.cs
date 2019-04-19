using TwoBirds.GameEngine.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public float Speed;
        public float Tilt;
        public float FireRate;

        public Boundary Boundary;
        public GameObject Projectile;
        public Transform ProjectileSpawn;
        public AudioVolume gameSoundsVolume;

        private float nextFire;

        private Rigidbody rigidBody;
        private AudioSource audioSource;


        private void Setup()
        {
            rigidBody = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = gameSoundsVolume.Volume;
        }

        public void Start()
        {
            Setup();
        }

        public void Update()
        {
            Fire();
        }

        public void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rigidBody.velocity = movement * Speed;

            rigidBody.position = new Vector3(
                Mathf.Clamp(rigidBody.position.x, Boundary.XMin, Boundary.XMax),
                0.0f,
                Mathf.Clamp(rigidBody.position.z, Boundary.ZMin, Boundary.ZMax)
            );

            rigidBody.rotation = Quaternion.Euler(0.0F, 0.0F, rigidBody.velocity.x * (-Tilt));
        }

        private void Fire()
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire && !GameController.isPaused)
            {
                nextFire = Time.time + FireRate;
                Instantiate(Projectile, ProjectileSpawn.position, ProjectileSpawn.rotation);
                audioSource.Play();
            }
        }
    }
}
