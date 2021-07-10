﻿using System.Collections.Generic;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionPointPools;

namespace SolastaLevel20.Models.Classes
{
    public static class SorcererBuilder
    {
        public static void Load()
        {
            // add missing progression
            Sorcerer.FeatureUnlocks.AddRange(new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                new FeatureUnlockByLevel(PointPoolSorcererAdditionalMetamagic, 17),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19),
                // TODO: Sorcerous Restoration
            });
        }
    }
}