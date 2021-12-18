﻿using BepInEx.Configuration;

namespace PeglinTweaks
{
    class Configuration
    {
        //Relics
        private static ConfigEntry<float> cookbookBombChanceCfg;
        private static ConfigEntry<int> matryoshkaMultiballLevel;

        //Pachinko
        private static ConfigEntry<int> aimerLengthCfg;
        private static ConfigEntry<int> aimerBouncesCfg;

        private static ConfigEntry<float> gravityCfg;
        private static ConfigEntry<float> fireForceCfg;
        private static ConfigEntry<float> maxSpeedCfg;

        //Battle
        private static ConfigEntry<float> playerDmgMultiplierCfg;
        private static ConfigEntry<float> enemyDmgMultiplierCfg;
        private static ConfigEntry<float> playerStartingHealthCfg;
        private static ConfigEntry<float> enemyHealthMultiplierCfg;

        //Animation
        private static ConfigEntry<bool> enableScreenShakeCfg;

        public static void BindConfigs(ConfigFile config)
        {
            //Relics
            cookbookBombChanceCfg = config.Bind("Relics", "Cookbook_Bomb_Chance", 0.07F,
                "Alchemist's cookbook bomb conversion chance. Use a value between 0 and 1");
            matryoshkaMultiballLevel = config.Bind("Relics", "Matryoshka_Multiball_Level", 1,
                "The level of multiball provided by the matryoshka relic\n" +
                "Warning: If you set this higher than 8, your computer might explode.");

            //Pachinko
            aimerLengthCfg = config.Bind("Pachinko", "Aimer_Length", 35,
                "The length of the aiming reticle when firing");
            aimerBouncesCfg = config.Bind("Pachinko", "Aimer_Bounces", 1,
                "The amount of bounces that the aiming reticle shows");

            gravityCfg = config.Bind("Pachinko", "Gravity", 1.25f, "The strength of gravity on orbs");
            fireForceCfg = config.Bind("Pachinko", "Fire_Force", 630f, "The strength with which orbs are fired");
            maxSpeedCfg = config.Bind("Pachinko", "Max_Speed", 55f, "The maximum speed of an orb");

            //Battle
            playerDmgMultiplierCfg = config.Bind("Battle", "Player_Dmg_Multiplier", 1f,
                "Multiplier for all damage dealt by the player");
            enemyDmgMultiplierCfg = config.Bind("Battle", "Enemy_Dmg_Multiplier", 1f,
                "Multiplier for all damage dealt by enemies");
            playerStartingHealthCfg = config.Bind("Battle", "Player_Starting_Health", 100f,
                "The amount of health the player starts with");
            enemyHealthMultiplierCfg = config.Bind("Battle", "Enemy_Health_Multiplier", 1f,
                "Multiplier for enemies' starting health");

            //Animation
            enableScreenShakeCfg = config.Bind("Animation", "Enable_Screen_Shake", true,
                "Enable the screen shake animation on large damage output");
        }

        //Relics
        public static float CookbookBombChance => cookbookBombChanceCfg.Value;
        public static int MatryoshkaMultiballLevel => matryoshkaMultiballLevel.Value;

        //Pachinko
        public static int AimerLength => aimerLengthCfg.Value;
        public static int AimerBounces => aimerBouncesCfg.Value;

        public static float Gravity => gravityCfg.Value;
        public static float FireForce => fireForceCfg.Value;
        public static float MaxSpeed => maxSpeedCfg.Value;

        //Battle
        public static float PlayerDmgMultiplier => playerDmgMultiplierCfg.Value;
        public static float EnemyDmgMultiplier => enemyDmgMultiplierCfg.Value;
        public static float PlayerStartingHealth => playerStartingHealthCfg.Value;
        public static float EnemyHealthMultiplier => enemyHealthMultiplierCfg.Value;

        //Animation
        public static bool EnableScreenShake => enableScreenShakeCfg.Value;
    }
}