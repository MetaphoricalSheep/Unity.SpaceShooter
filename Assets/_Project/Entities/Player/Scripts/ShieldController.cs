using SpaceShooter.Entities.Scripts.Controller;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShieldController : MonoBehaviour
    {
        public static System.Action DestroyShieldEvent;

        private Renderer shieldRenderer;
        private GameObject playerShield;

        public void Start()
        {
            Setup();
        }

        private void DamageShield()
        {
            GameController.PlayerStats.Shields -= 1;

            if (GameController.PlayerStats.Shields < 1)
            {
                playerShield.SetActive(false);
            }

            UpdateShieldDisplay();
        }

        private void AddShield(int health)
        {
            playerShield.SetActive(true);
            GameController.PlayerStats.Shields += health;
            UpdateShieldDisplay();
        }

        private void UpdateShieldDisplay()
        {
            int shields = GameController.PlayerStats.Shields;

            if (shields > 4)
            {
                shieldRenderer.material.SetColor("_Color", ShieldHealthColors.Nominal);
            }
            else if (shields > 2)
            {
                shieldRenderer.material.SetColor("_Color", ShieldHealthColors.Partial);
            }
            else
            {
                shieldRenderer.material.SetColor("_Color", ShieldHealthColors.Critical);
            }
        }

        private void Setup()
        {
            playerShield = gameObject.transform.Find("Player Shield").gameObject;
            shieldRenderer = playerShield.GetComponent<Renderer>();
            DestroyByContact.ShieldHitEvent += DamageShield;
            PickupPowerUp.AddShieldEvent += AddShield;
        }
    }
}
