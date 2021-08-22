#if DEBUG

using HarmonyLib;

namespace TopMining
{
    /// <summary>
    /// Make sure we do enough damage to destroy an ore in one hit
    /// </summary>
    [HarmonyPatch(typeof(MineRock5), nameof(MineRock5.Damage))]
    class MineRock5InstantMineCheat
    {
        static void Prefix(ref MineRock5 __instance, ref HitData hit)
        {
            hit.m_damage.m_pickaxe += 1000f;
        }
    }

    /// <summary>
    /// Set players max carry, stamina regen, stamina drain, jog speed, run speed to cheat values.
    /// </summary>
    [HarmonyPatch(typeof(Player), nameof(Player.OnSpawned))]
    class PlayerCheats
    {
        static void Postfix(ref Player __instance)
        {
            // carry weight
            __instance.m_maxCarryWeight = 999;

            // stamina
            __instance.m_runSpeed = 20;
            __instance.m_speed = 6;
            __instance.m_swimSpeed = 20;
            __instance.m_staminaRegen = 60;
            __instance.m_staminaRegenDelay = 0;
            __instance.m_runStaminaDrain = 0;
            __instance.m_swimStaminaDrainMaxSkill = 0;
            __instance.m_swimStaminaDrainMinSkill = 0;
        }
    }

    /// <summary>
    /// Players recieve zero damage, other characters recieve alot.
    /// </summary>
    [HarmonyPatch(typeof(Character), nameof(Character.Damage))]
    class CharacterCheats
    {
        static void Prefix(ref Character __instance, ref HitData hit)
        {
            if (__instance is Player)
            {
                hit.m_damage.m_spirit = 0;
                hit.m_damage.m_slash = 0;
                hit.m_damage.m_poison = 0;
                hit.m_damage.m_pierce = 0;
                hit.m_damage.m_pickaxe = 0;
                hit.m_damage.m_lightning = 0;
                hit.m_damage.m_frost = 0;
                hit.m_damage.m_fire = 0;
                hit.m_damage.m_damage = 0;
                hit.m_damage.m_chop = 0;
                hit.m_damage.m_blunt = 0;
            }
            else
            {
                hit.m_damage.m_damage += 1000;
            }
        }
    }
}
#endif