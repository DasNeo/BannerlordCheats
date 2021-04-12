﻿using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetTotalWage))]
    public static class NoTroopWagesPatch
    {
        [HarmonyPostfix]
        public static void GetTotalWage(ref MobileParty mobileParty, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.TroopWagesPercentage, out var troopWagesPercentage)
                && mobileParty.IsPlayerParty())
            {
                __result.AddPercentage(troopWagesPercentage);
            }
        }
    }
}
