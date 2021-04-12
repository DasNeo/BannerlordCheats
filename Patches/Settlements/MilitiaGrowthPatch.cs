﻿using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.MilitiaChange), MethodType.Getter)]
    public static class MilitiaGrowthTownPatch
    {
        [HarmonyPostfix]
        public static void MilitiaChange(ref Town __instance, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.DailyMilitiaBonus, out var dailyMilitiaBonus)
                && __instance.IsPlayerTown())
            {
                __result += dailyMilitiaBonus;
            }
        }
    }

    [HarmonyPatch(typeof(Village), nameof(Village.MilitiaChange), MethodType.Getter)]
    public static class MilitiaGrowthVillagePatch
    {
        [HarmonyPostfix]
        public static void MilitiaChange(ref Village __instance, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.DailyMilitiaBonus, out var dailyMilitiaBonus)
                && __instance.IsPlayerVillage())
            {
                __result += dailyMilitiaBonus;
            }
        }
    }
}
