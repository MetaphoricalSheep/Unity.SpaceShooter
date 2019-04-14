using System.Collections.Generic;

namespace Assets.Scripts
{
    public class Tags
    {
        public const string Player = "Player";
        public const string PlayerShield = "PlayerShield";
        public const string Enemy = "Enemy";
        public const string EnemyBolt = "EnemyBolt";
        public const string Asteroid = "Asteroid";
        public const string Boundary = "Boundary";
        public const string HealthPowerUp = "HealthPowerUp";

        public static List<string> Hazards => new List<string> { Enemy, Asteroid, EnemyBolt };
        public static List<string> PlayerParts => new List<string> { Player, PlayerShield };
    }
}
