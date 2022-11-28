using HarmonyLib;
using Relics;

namespace PeglinTweaks.Pachinko
{
    [HarmonyPatch(typeof(PredictionManager), nameof(PredictionManager.Initialize))]
    class PredictionManagerPatch
    {
        public static void Prefix(ref int ____baseMaxIterations)
        {
            ____baseMaxIterations = Configuration.AimerLength;
        }

        public static void Postfix(ref int ____bounceCount, RelicManager relicManager)
        {
            var bouncesBase = relicManager.RelicEffectActive(RelicEffect.LONGER_AIMER) ? 1 : 0;
            ____bounceCount = bouncesBase + Configuration.AimerBounces;
        }
    }

    [HarmonyPatch(typeof(PachinkoBall), nameof(PachinkoBall.Start))]
    class PhysicsPatch
    {
        public static void Prefix(ref float ___GravityScale, ref float ___FireForce)
        {
            ___GravityScale = Configuration.Gravity;
            ___FireForce = Configuration.FireForce;
        }
    }
}