using HarmonyLib;
using UnityEngine;

namespace TopMining
{
    /// <summary>
    /// Whenever damage is dealt to a MineRock5 instance, make sure the damage is dealt to the lowest area.
    /// </summary>
    [HarmonyPatch(typeof(MineRock5), nameof(MineRock5.Damage))]
    class MineRock5Patch
    {
        static void Prefix(ref MineRock5 __instance, ref HitData hit)
        {
            // if MineRock5 instance has more than 1 child colliders
            var childColliders = __instance.GetComponentsInChildren<Collider>();
            if (childColliders.Length >= 1)
            {
                // find lowest collider and make sure hit collider is child of MineRock5 instance
                var isChild = false;
                var lowest = childColliders[0];
                foreach (var c in childColliders)
                {
                    if (!isChild)
                    {
                        isChild = c == hit.m_hitCollider;
                        // dont compare with hit collider
                        if (isChild)
                            continue;
                    }
                    // find area with lowest heigth
                    if (lowest.bounds.center.y > c.bounds.center.y)
                        lowest = c;
                }
                // assign new hit collider to lowest if old hit collider were child
                // also push hit point to avoid ore getting stuck
                if (isChild)
                {
                    // push away from collider
                    hit.m_point = hit.m_point + ((hit.m_point - hit.m_hitCollider.bounds.center).normalized * 0.3f);
                    // assign new collider
                    hit.m_hitCollider = lowest;
                }
                    
            }
        }
    }
}
