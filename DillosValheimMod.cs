using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace DillosValheimMod {
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class DillosValheimMod : BaseUnityPlugin {
        private const string PluginGUID = "red.logsqua.dillosvalheimmod";
        public const string PluginName = "DillosValheimMod";
        private const string PluginVersion = "0.1.0";

        public static ManualLogSource Log;

        private void Awake() {
            Log = Logger;
            Log.LogInfo($"{PluginName} version {PluginVersion} is loaded!");

            Harmony.CreateAndPatchAll(typeof(DillosValheimMod).Assembly, PluginGUID);
        }
    }

    [HarmonyPatch(typeof(Player), "UpdateEnvStatusEffects")]
    public static class Player_UpdateEnvStatusEffects_Patch {
        private static FieldInfo comfortField;

        static void Postfix(Player __instance) {
            if (__instance.GetSEMan().HaveStatusEffect(SEMan.s_statusEffectResting)) {
                var comfortLevel = SE_Rested.CalculateComfortLevel(__instance);

                // Cache the reflection field lookup to avoid expensive repeated calls
                if (comfortField == null) {
                    comfortField = typeof(Player).GetField("m_comfortLevel",
                        BindingFlags.NonPublic | BindingFlags.Instance);
                }
                comfortField?.SetValue(__instance, comfortLevel);

                __instance.GetSEMan().AddStatusEffect(SEMan.s_statusEffectRested, true);
            }
        }
    }
}
