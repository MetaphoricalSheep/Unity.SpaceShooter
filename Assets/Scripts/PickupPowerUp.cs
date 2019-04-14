using UnityEngine;

namespace Assets.Scripts
{
    public class PickupPowerUp : MonoBehaviour
    {
        public static System.Action<int> AddShieldEvent;


        private AudioSource audioSource;
        private bool isPickedUp;

        protected void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        protected void OnTriggerEnter(Collider other)
        {
            Pickup(other);
        }

        private void Pickup(Collider other)
        {
            if (!other.CompareTag(Tags.Player) || isPickedUp)
            {
                return;
            }

            isPickedUp = true;
            audioSource.Play();
            AddPowerup();
            Destroy(gameObject);
        }

        private void AddPowerup()
        {
            switch (gameObject.tag)
            {
                case Tags.HealthPowerUp:
                    AddShieldEvent?.Invoke(1);
                    break;
            }
        }
    }
}
