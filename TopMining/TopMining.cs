using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace TopMining
{
    [BepInPlugin(TopMiningInfo.MOD_ID, TopMiningInfo.MOD_NAME, TopMiningInfo.MOD_VERSION)]
    [BepInProcess("valheim.exe")]
    [BepInProcess("valheim_server.exe")]
    public class TopMining : BaseUnityPlugin
    {
        private static ConfigEntry<UnityEngine.KeyCode> configTopMiningKey;
        private static ConfigEntry<bool> configTopMiningHold;

        public static readonly Harmony Harmony = new Harmony(TopMiningInfo.MOD_ID);

        void Awake()
        {
            configTopMiningKey = Config.Bind(new ConfigDefinition("General", "TopMineKey"), UnityEngine.KeyCode.LeftShift, new ConfigDescription("Hold to disable top mining mode"));
            configTopMiningHold = Config.Bind(new ConfigDefinition("General", "TopMineHold"), false, new ConfigDescription("Hold Top Mine Key to activate top mining mode"));

            Harmony.PatchAll();
        }

        private static bool isTopMiningActive()
        {
            return configTopMiningHold.Value ? UnityEngine.Input.GetKey(configTopMiningKey.Value) : !UnityEngine.Input.GetKey(configTopMiningKey.Value);
        }

        public static bool TopMiningActive { get => isTopMiningActive(); }
    }
}
