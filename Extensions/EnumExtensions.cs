﻿using System;
using BannerlordCheats.Settings;
using TaleWorlds.Core;

namespace BannerlordCheats.Extensions
{
    public static class EnumExtensions
    {
        public static bool TryGetAgentState(this KnockoutOrKilled state, out AgentState result)
        {
            switch (state)
            {
                case KnockoutOrKilled.Default:
                    result = AgentState.None;
                    return false;
                case KnockoutOrKilled.Knockout:
                    result = AgentState.Unconscious;
                    return true;
                case KnockoutOrKilled.Killed:
                    result = AgentState.Killed;
                    return true;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}