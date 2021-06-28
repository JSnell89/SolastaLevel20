﻿using System;
using System.Collections.Generic;
using HarmonyLib;
using static SolastaLevel20.Settings;
using static SolastaLevel20.Models.MultiClass;

namespace SolastaLevel20.Patches
{
    class CharactersPanelPatcher
    {
        [HarmonyPatch(typeof(CharactersPanel), "Refresh")]
        internal static class CharactersPanel_Refresh_Patch
        {
            internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                code.Find(x => x.opcode.Name == "ldc.i4.s" && Convert.ToInt32(x.operand) == GAME_MAX_LEVEL).operand = MOD_MAX_LEVEL;
                return code;
            }
        }

        [HarmonyPatch(typeof(CharactersPanel), "OnNewCharacterCb")]
        internal static class CharactersPanel_OnNewCharacterCb_Patch
        {
            internal static void Postfix()
            {
                IsHeroesPoolDirty = true;
            }
        }

        [HarmonyPatch(typeof(CharactersPanel), "OnLevelUpCb")]
        internal static class CharactersPanel_OnLevelUpCb_Patch
        {
            internal static void Postfix()
            {
                IsHeroesPoolDirty = true;
            }
        }
    }
}