﻿using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), "CalculateLearningRate")]
    public static class DefaultCharacterDevelopmentModelPatch
    {
        [HarmonyPostfix]
        public static void CalculateLearningRate(Hero hero, SkillObject skill, StatExplainer explainer, ref float __result)
        {
            if (hero?.IsHumanPlayerCharacter ?? false)
            {
                __result *= BannerlordCheatsSettings.Instance.LearningRateMultiplier;
            }
        }
    }
}