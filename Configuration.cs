using BepInEx.Configuration;

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

        private static ConfigEntry<bool> enableOrbsCollision;

        //Battle
        private static ConfigEntry<float> playerDmgMultiplierCfg;
        private static ConfigEntry<float> bombBaseDamageCfg;
        private static ConfigEntry<float> enemyDmgMultiplierCfg;
        private static ConfigEntry<float> playerStartingHealthCfg;
        private static ConfigEntry<float> enemyHealthMultiplierCfg;
        private static ConfigEntry<int> orbDiscardAmountCfg;

        //Currency
        private static ConfigEntry<int> startingGoldAmountCfg;

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

            enableOrbsCollision = config.Bind("Pachinko", "Enable_Orb_Collision", false,
                "Enable collision between orbs (when multiball is active)");

            //Battle
            playerDmgMultiplierCfg = config.Bind("Battle", "Player_Dmg_Multiplier", 1f,
                "Multiplier for damage dealt by the player");
            bombBaseDamageCfg = config.Bind("Battle", "Bomb_Base_Damage", 50f,
                "Base damage for bombs");
            enemyDmgMultiplierCfg = config.Bind("Battle", "Enemy_Dmg_Multiplier", 1f,
                "Multiplier for all damage dealt by enemies");
            playerStartingHealthCfg = config.Bind("Battle", "Player_Starting_Health", 100f,
                "The amount of health the player starts with");
            enemyHealthMultiplierCfg = config.Bind("Battle", "Enemy_Health_Multiplier", 1f,
                "Multiplier for enemies' starting health");
            orbDiscardAmountCfg = config.Bind("Battle", "Orb_Discard_Amount", 1,
                "The amount of orbs you can discard");

            //Currency
            startingGoldAmountCfg = config.Bind("Currency", "Starting_Gold_Amount", 15,
                "The amount of gold the player starts a run with");
        }

        //Relics
        public static float CookbookBombChance => cookbookBombChanceCfg.Value;
        public static int MatryoshkaMultiballLevel => matryoshkaMultiballLevel.Value;

        //Pachinko
        public static int AimerLength => aimerLengthCfg.Value;
        public static int AimerBounces => aimerBouncesCfg.Value;

        public static float Gravity => gravityCfg.Value;
        public static float FireForce => fireForceCfg.Value;

        public static bool EnableOrbsCollision => enableOrbsCollision.Value;

        //Battle
        public static float PlayerDmgMultiplier => playerDmgMultiplierCfg.Value;
        public static float BombBaseDamage => bombBaseDamageCfg.Value;
        public static float EnemyDmgMultiplier => enemyDmgMultiplierCfg.Value;
        public static float PlayerStartingHealth => playerStartingHealthCfg.Value;
        public static float EnemyHealthMultiplier => enemyHealthMultiplierCfg.Value;
        public static int OrbDiscardAmount => orbDiscardAmountCfg.Value;

        //Currency
        public static int StartingGoldAmount => startingGoldAmountCfg.Value;
    }
}