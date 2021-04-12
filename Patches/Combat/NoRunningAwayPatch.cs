﻿using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleMoraleModel), nameof(DefaultBattleMoraleModel.CalculateMoraleChangeToCharacter))]
    public static class NoRunningAwayPatch
    {
        [HarmonyPostfix]
        public static void CalculateMoraleChangeToCharacter(Agent agent, float moraleChange, float distance, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.NoRunningAway, out var noRunningAway)
                && noRunningAway
                && agent.Origin.TryGetParty(out var party)
                && party.IsPlayerParty())
            {
                __result = 0.0f;
            }
        }
    }
}
