using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class DestroyByContact : MonoBehaviour
    {
        public GameObject Explosion;
        public GameObject PlayerExplosion;
        public int scoreValue;

        public static System.Action ShieldHitEvent;
        public static System.Action EnemyDestroyedByPlayerEvent;

        private GameController GameController;

        public void Start()
        {
            Setup();
        }

        public void OnTriggerEnter(Collider other)
        {
            Hit(other);
        }

        private void Setup()
        {
            GameObject gameControllerObject = GameObject.FindWithTag("GameController");

            if (!gameControllerObject)
            {
                return;
            }

            GameController = gameControllerObject.GetComponent<GameController>();
        }

        private void Hit(Collider other)
        {
            if (IgnoreCollision(other))
            {
                return;
            }

            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, transform.rotation);
            }

            if (other.CompareTag(Tags.Player))
            {
                Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
                GameController.GameOver();
            }

            if (other.CompareTag(Tags.PlayerShield))
            {
                ShieldHitEvent.Invoke();
                Destroy(gameObject);

                return;
            }

            if (gameObject.CompareTag(Tags.Enemy) && !Tags.PlayerParts.Contains(other.tag))
            {
                EnemyDestroyedByPlayerEvent?.Invoke();
            }

            GameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        private bool IgnoreCollision(Collider other)
        {
            List<string> ignore = new List<string> { Tags.Boundary, Tags.Enemy, Tags.Asteroid, Tags.HealthPowerUp, Tags.EnemyBolt };

            return ignore.Contains(other.tag);
        }
    }
}
