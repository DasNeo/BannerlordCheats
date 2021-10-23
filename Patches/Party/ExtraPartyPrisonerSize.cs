﻿using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), nameof(DefaultPartySizeLimitModel.GetPartyPrisonerSizeLimit))]
    public static class ExtraPartyPrisonerSize
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPartyPrisonerSizeLimit(ref PartyBase party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if (party.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.ExtraPartyPrisonerSize > 0)
            {
                __result.Add(BannerlordCheatsSettings.Instance.ExtraPartyPrisonerSize);
            }
        }
    }
}