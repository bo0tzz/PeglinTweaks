using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Battle;
using Battle.Attacks;
using Battle.Enemies;
using HarmonyLib;

namespace PeglinTweaks.Battle
{
    [HarmonyPatch(typeof(Attack), nameof(Attack.Initialize))]
    class PlayerDmgMultiplierPatch
    {
        public static void Prefix(ref float ___DamagePerPeg, ref float ___CritDamagePerPeg)
        {
            ___DamagePerPeg *= Configuration.PlayerDmgMultiplier;
            ___CritDamagePerPeg *= Configuration.PlayerDmgMultiplier;
        }
    }

    [HarmonyPatch(typeof(BattleController), nameof(BattleController.Awake))]
    class BombDmgMultiplierPatch
    {
        public static void Postfix(BattleController __instance)
        {
            __instance._baseBombDamage = Configuration.BombBaseDamage;
        }
    }

    [HarmonyPatch(typeof(PlayerHealthController), nameof(PlayerHealthController.Damage))]
    class EnemyDmgMultiplierPatch
    {
        public static void Prefix(ref float damage) => damage *= Configuration.EnemyDmgMultiplier;
    }

    [HarmonyPatch(typeof(GameInit), nameof(GameInit.Start))]
    class PlayerStartHealthPatch
    {
        public static void Prefix(FloatVariable ___maxPlayerHealth, FloatVariable ___playerHealth)
        {
            ___maxPlayerHealth._initialValue = Configuration.PlayerStartingHealth;
            ___playerHealth._initialValue = Configuration.PlayerStartingHealth;
        }
    }

    [HarmonyPatch(typeof(Enemy), nameof(Enemy.Initialize))]
    class EnemyHealthMultiplierPatch
    {
        public static void Prefix(ref float ___StartingHealth)
        {
            ___StartingHealth = (float)Math.Round(___StartingHealth * Configuration.EnemyHealthMultiplier);
        }
    }

    [HarmonyPatch(typeof(BattleController), nameof(BattleController.MaxDiscardedShots), MethodType.Getter)]
    class OrbDiscardCountPatch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var patched = false;
            foreach (var instruction in instructions)
            {
                if (!patched && instruction.opcode == OpCodes.Ldc_I4_1)
                {
                    patched = true;
                    yield return new CodeInstruction(OpCodes.Ldc_I4, Configuration.OrbDiscardAmount);
                }
                else
                {
                    yield return instruction;
                }
            }
        }
    }
}