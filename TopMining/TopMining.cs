using BepInEx;
using HarmonyLib;

namespace TopMining
{
    [BepInPlugin(TopMiningInfo.MOD_ID, TopMiningInfo.MOD_NAME, TopMiningInfo.MOD_VERSION)]
    [BepInProcess("valheim.exe")]
    [BepInProcess("valheim_server.exe")]
    public class TopMining : BaseUnityPlugin
    {
        public static readonly Harmony Harmony = new Harmony(TopMiningInfo.MOD_ID);

        void Awake()
        {
            Harmony.PatchAll();
        }
    }
}
