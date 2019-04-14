using UnityEngine;

namespace Assets.Scripts
{
    public class DropPowerup : MonoBehaviour
    {
        public GameObject[] PowerUps;
        public float DropChance = 1;

        private bool destroyedByPlayer;

        protected void Start()
        {
            DestroyByContact.EnemyDestroyedByPlayerEvent += DestroyedByPlayer;
        }

        protected void OnDestroy()
        {
            if (destroyedByPlayer)
            {
                GameObject powerUp = PowerUps[Random.Range(0, PowerUps.Length)];
                Instantiate(powerUp, gameObject.transform.position, gameObject.transform.rotation);
            }
        }

        protected void DestroyedByPlayer()
        {
            destroyedByPlayer = true;
        }
    }
}
