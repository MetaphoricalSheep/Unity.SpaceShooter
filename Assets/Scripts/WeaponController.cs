using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponController : MonoBehaviour
    {
        public GameObject Projectile;
        public Transform ProjectileSpawn;
        public float FireRate;
        public float Delay;

        private AudioSource audioSource;

        public void Start()
        {
            Setup();
        }

        public void OnEnable()
        {
            GameController.PauseEvent += OnPause;
            GameController.ResumeEvent += OnResume;
        }

        public void OnDisable()
        {
            GameController.PauseEvent -= OnPause;
            GameController.ResumeEvent -= OnResume;
        }

        private void Setup()
        {
            audioSource = GetComponent<AudioSource>();
            InvokeRepeating("Fire", Delay, FireRate);
        }

        private void Fire()
        {
            if (!GameController.IsGameOver)
            {
                Instantiate(Projectile, ProjectileSpawn.position, ProjectileSpawn.rotation);
                audioSource.Play();
            }
        }

        private void OnPause()
        {
            audioSource?.Pause();
        }

        private void OnResume()
        {
            audioSource?.UnPause();
        }
    }
}
