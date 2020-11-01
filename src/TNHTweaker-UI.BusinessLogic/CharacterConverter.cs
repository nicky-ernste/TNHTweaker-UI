using System.Collections.Generic;
using System.Linq;
using TNHTweaker_UI.BusinessLogic.Interfaces;
using TNHTweaker_UI.Models;
using TNHTweaker_UI.Models.Enums;
using OldFormat = TNHTweaker_UI.Models.OldFormat;

namespace TNHTweaker_UI.BusinessLogic
{
    public class CharacterConverter : ICharacterConverter
    {
        public CharacterInformation ConvertCharacterToNewFormat(OldFormat.CharacterInfo oldCharacter)
        {
            if (oldCharacter == null)
                return null;

            var newCharacter = new CharacterInformation
            {
                CharacterGroup = oldCharacter.Group,
                Description = oldCharacter.Description,
                DisplayName = oldCharacter.DisplayName,
                ForceAllAgentWeapons = oldCharacter.ForceAllAgentWeapons,
                HasPrimaryItem = oldCharacter.HasItemPrimary,
                HasPrimaryWeapon = oldCharacter.HasWeaponPrimary,
                HasSecondaryItem = oldCharacter.HasItemSecondary,
                HasSecondaryWeapon = oldCharacter.HasWeaponSecondary,
                HasTertiaryItem = oldCharacter.HasItemTertiary,
                HasTertiaryWeapon = oldCharacter.HasWeaponTertiary,
                HasShield = oldCharacter.HasItemShield,
                StartingTokens = oldCharacter.StartingTokens,
                UsesPurchasePriceIncrement = oldCharacter.UsesPurchasePriceIncrement,
                PrimaryWeapon = ConvertWeaponDefinition(oldCharacter.WeaponPrimary),
                PrimaryItem = ConvertWeaponDefinition(oldCharacter.ItemPrimary),
                SecondaryWeapon = ConvertWeaponDefinition(oldCharacter.WeaponSecondary),
                SecondaryItem = ConvertWeaponDefinition(oldCharacter.ItemSecondary),
                TertiaryWeapon = ConvertWeaponDefinition(oldCharacter.WeaponTertiary),
                TertiaryItem = ConvertWeaponDefinition(oldCharacter.ItemTertiary),
                Shield = ConvertWeaponDefinition(oldCharacter.ItemShield),
                EquipmentPools = ConvertEquipmentPoolDefinitions(oldCharacter.EquipmentPool.Entries),
                Levels = ConvertLevelEntries(oldCharacter.Progressions.First().Levels),
                LevelsEndless = ConvertLevelEntries(oldCharacter.Progressions.First().Levels), //Converting the same levels because a level definition for endless did not exist in the old format.
                CharacterIconName = "no",
                TableId = oldCharacter.DisplayName.Replace(" ", string.Empty).Trim(),
                ValidAmmoEras = EraType.None,
                ValidAmmoSets = SetType.None,
                CharacterId = 0,
                RequireSightTable = new ObjectTableDefinition
                {
                    IconName = "Not Used",
                    Category = ItemCategory.Attachment
                }
            };

            return newCharacter;
        }

        /// <summary>
        /// Converts a <see cref="OldFormat.WeaponDefinition"/> into its newer <see cref="WeaponDefinition"/> counterpart.
        /// </summary>
        /// <param name="oldWeaponDefinition">The old instance of <see cref="OldFormat.WeaponDefinition"/> to convert.</param>
        /// <returns>An instance of the newer <see cref="WeaponDefinition"/>.</returns>
        private static WeaponDefinition ConvertWeaponDefinition(OldFormat.WeaponDefinition oldWeaponDefinition)
        {
            if (oldWeaponDefinition == null)
                return null;

            var newWeaponDefinition = new WeaponDefinition
            {
                ListOverride = oldWeaponDefinition.ListOverride,
                NumMags = oldWeaponDefinition.NumMagsSlClips,
                NumRounds = oldWeaponDefinition.NumRounds,
                Tables = ConvertObjectTableDefinitions(oldWeaponDefinition.TableDefs),
                AmmoOverride = null
            };

            return newWeaponDefinition;
        }

        /// <summary>
        /// Converts a list of <see cref="OldFormat.ObjectTableDefinition"/> into its newer <see cref="ObjectTableDefinition"/> counterpart.
        /// </summary>
        /// <param name="oldObjectTableDefinitions">A list of old instances of <see cref="OldFormat.ObjectTableDefinition"/> to convert.</param>
        /// <returns>A list of the newer <see cref="ObjectTableDefinition"/>.</returns>
        private static IList<ObjectTableDefinition> ConvertObjectTableDefinitions(IList<OldFormat.ObjectTableDefinition> oldObjectTableDefinitions) =>
            oldObjectTableDefinitions?.Select(oldObjectTableDefinition => new ObjectTableDefinition
            {
                Actions = oldObjectTableDefinition.Actions,
                Category = oldObjectTableDefinition.Category,
                Eras = oldObjectTableDefinition.Eras,
                ExcludedModes = oldObjectTableDefinition.ExcludeModes,
                Features = oldObjectTableDefinition.Features,
                FeedOptions = oldObjectTableDefinition.FeedOptions,
                IconName = oldObjectTableDefinition.Icon,
                IdOverride = oldObjectTableDefinition.IdOverride,
                IsBlanked = oldObjectTableDefinition.IsBlanked,
                MaxAmmoCapacity = oldObjectTableDefinition.MaxAmmoCapacity,
                MeleeHandedness = oldObjectTableDefinition.MeleeHandedness,
                MeleeStyles = oldObjectTableDefinition.MeleeStyles,
                MinAmmoCapacity = oldObjectTableDefinition.MinAmmoCapacity,
                Modes = oldObjectTableDefinition.Modes,
                MountsAvailable = oldObjectTableDefinition.MountsAvailable,
                MountTypes = oldObjectTableDefinition.MountTypes,
                PowerupTypes = oldObjectTableDefinition.PowerupTypes,
                RequiredExactCapacity = -1,
                RoundPowers = oldObjectTableDefinition.RoundPowers,
                Sets = oldObjectTableDefinition.Sets,
                Sizes = oldObjectTableDefinition.Sizes,
                SpawnsInLargeCase = oldObjectTableDefinition.SpawnsInLargeCase,
                SpawnsInSmallCase = oldObjectTableDefinition.SpawnsInSmallCase,
                ThrownDamageTypes = oldObjectTableDefinition.ThrownDamageTypes,
                ThrownTypes = oldObjectTableDefinition.ThrownTypes,
                UseIdListOverride = oldObjectTableDefinition.UseIdListOverride
            }).ToList();

        /// <summary>
        /// Converts a <see cref="OldFormat.ObjectTableDefinition"/> into its newer <see cref="ObjectTableDefinition"/> counterpart.
        /// </summary>
        /// <param name="oldObjectTableDefinition">The old instance of <see cref="OldFormat.ObjectTableDefinition"/> to convert.</param>
        /// <returns>An instance of the newer <see cref="ObjectTableDefinition"/>.</returns>
        private static ObjectTableDefinition ConvertObjectTableDefinition(OldFormat.ObjectTableDefinition oldObjectTableDefinition)
        {
            if (oldObjectTableDefinition == null)
                return null;

            var convertedObjectTableDefinitions = ConvertObjectTableDefinitions(new List<OldFormat.ObjectTableDefinition> { oldObjectTableDefinition });
            if (convertedObjectTableDefinitions == null || !convertedObjectTableDefinitions.Any())
                return null;

            return convertedObjectTableDefinitions.First();
        }

        /// <summary>
        /// Converts a list of <see cref="OldFormat.PoolEntry"/> into its newer <see cref="EquipmentPoolDefinition"/> counterpart.
        /// </summary>
        /// <param name="oldPoolEntries">A list of old instances of <see cref="OldFormat.PoolEntry"/> to convert.</param>
        /// <returns>A list of the newer <see cref="EquipmentPoolDefinition"/>.</returns>
        private static IList<EquipmentPoolDefinition> ConvertEquipmentPoolDefinitions(IList<OldFormat.PoolEntry> oldPoolEntries) =>
            oldPoolEntries?.Select(oldPoolEntry => new EquipmentPoolDefinition
            {
                MaxLevelAppears = oldPoolEntry.MaxLevelAppears,
                MinLevelAppears = oldPoolEntry.MinLevelAppears,
                Rarity = oldPoolEntry.Rarity,
                TokenCost = oldPoolEntry.TokenCost,
                TokenCostLimited = oldPoolEntry.TokenCostLimited,
                Type = oldPoolEntry.Type,
                Table = ConvertObjectTableDefinition(oldPoolEntry.TableDef)
            }).ToList();

        /// <summary>
        /// Converts a list of <see cref="OldFormat.LevelEntry"/> into its newer <see cref="LevelEntry"/> counterpart.
        /// </summary>
        /// <param name="oldLevelEntries">A list of old instances of <see cref="OldFormat.LevelEntry"/> to convert.</param>
        /// <returns>A list of the newer <see cref="LevelEntry"/>.</returns>
        private static IList<LevelEntry> ConvertLevelEntries(IList<OldFormat.LevelEntry> oldLevelEntries) =>
            oldLevelEntries?.Select(oldLevelEntry => new LevelEntry
            {
                AdditionalSupplyPoints = oldLevelEntry.AdditionalSupplyPoints,
                BoxTokenChance = oldLevelEntry.BoxTokenChance,
                MaxBoxesSpawned = oldLevelEntry.MaxBoxesSpawned,
                MaxTokensPerSupply = oldLevelEntry.MaxTokensPerSupply,
                MinBoxesSpawned = oldLevelEntry.MinBoxesSpawned,
                MinTokensPerSupply = oldLevelEntry.MinTokensPerSupply,
                NumberOfOverrideTokensForHold = oldLevelEntry.NumberOfOverrideTokensForHold,
                SupplyChallenge = ConvertTakeSupplyChallenge(oldLevelEntry.SupplyChallenge),
                TakeChallenge = ConvertTakeSupplyChallenge(oldLevelEntry.TakeChallenge),
                HoldPhases = ConvertPhaseDefinitions(oldLevelEntry.HoldChallenge.Phases),
                Patrols = ConvertPatrolDefinitions(oldLevelEntry.PatrolChallenge.Patrols)
            }).ToList();

        /// <summary>
        /// Converts a <see cref="OldFormat.TakeSupplyChallenge"/> into its newer <see cref="TakeSupplyChallenge"/> counterpart.
        /// </summary>
        /// <param name="oldTakeSupplyChallenge">The old instance of <see cref="OldFormat.TakeSupplyChallenge"/> to convert.</param>
        /// <returns>An instance of the newer <see cref="TakeSupplyChallenge"/>.</returns>
        private static TakeSupplyChallenge ConvertTakeSupplyChallenge(OldFormat.TakeSupplyChallenge oldTakeSupplyChallenge)
        {
            if (oldTakeSupplyChallenge == null)
                return null;

            var newTakeSupplyChallenge = new TakeSupplyChallenge
            {
                EnemyType = oldTakeSupplyChallenge.EnemyId,
                IffUsed = oldTakeSupplyChallenge.IffUsed,
                NumGuards = oldTakeSupplyChallenge.NumGuards,
                NumTurrets = oldTakeSupplyChallenge.NumTurrets,
                TurretType = oldTakeSupplyChallenge.TurretType
            };

            return newTakeSupplyChallenge;
        }

        /// <summary>
        /// Converts a list of <see cref="OldFormat.PhaseDefinition"/> into its newer <see cref="PhaseDefinition"/> counterpart.
        /// </summary>
        /// <param name="oldPhaseDefinitions">A list of old instances of <see cref="OldFormat.PhaseDefinition"/> to convert.</param>
        /// <returns>A list of the newer <see cref="PhaseDefinition"/>.</returns>
        private static IList<PhaseDefinition> ConvertPhaseDefinitions(IList<OldFormat.PhaseDefinition> oldPhaseDefinitions) =>
            oldPhaseDefinitions?.Select(oldPhaseDefinition => new PhaseDefinition
            {
                Encryption = oldPhaseDefinition.Encryption,
                EnemyType = oldPhaseDefinition.EType,
                LeaderType = oldPhaseDefinition.LType,
                GrenadeChance = oldPhaseDefinition.GrenadeChance,
                GrenadeType = oldPhaseDefinition.GrenadeType,
                IffUsed = oldPhaseDefinition.IffUsed,
                MaxDirections = oldPhaseDefinition.MaxDirections,
                MaxEnemies = oldPhaseDefinition.MaxEnemies,
                MaxEnemiesAlive = oldPhaseDefinition.MaxEnemiesAlive,
                MaxTargets = oldPhaseDefinition.MaxTargets,
                MinEnemies = oldPhaseDefinition.MinEnemies,
                MinTargets = oldPhaseDefinition.MinTargets,
                ScanTime = oldPhaseDefinition.ScanTime,
                SpawnCadence = oldPhaseDefinition.SpawnCadence,
                SwarmPlayer = false,
                WarmUpTime = oldPhaseDefinition.WarmUp
            }).ToList();

        /// <summary>
        /// Converts a list of <see cref="OldFormat.PatrolDefinition"/> into its newer <see cref="PatrolDefinition"/> counterpart.
        /// </summary>
        /// <param name="oldPatrolDefinitions">A list of old instances of <see cref="OldFormat.PatrolDefinition"/> to convert.</param>
        /// <returns>A list of the newer <see cref="PatrolDefinition"/>.</returns>
        private static IList<PatrolDefinition> ConvertPatrolDefinitions(IList<OldFormat.PatrolDefinition> oldPatrolDefinitions) =>
            oldPatrolDefinitions?.Select(oldPatrolDefinition => new PatrolDefinition
            {
                AssaultSpeed = "Walking",
                DropChance = 0.2,
                DropsHealth = true,
                DropsMagazine = false,
                EnemyType = oldPatrolDefinition.EType,
                LeaderType = oldPatrolDefinition.LType,
                IffUsed = oldPatrolDefinition.IffUsed,
                MaxPatrols = oldPatrolDefinition.MaxPatrols,
                MaxPatrolsLimited = oldPatrolDefinition.MaxPatrolsLimitedAmmo,
                PatrolCadence = 10,
                PatrolCadenceLimited = 10,
                PatrolSize = oldPatrolDefinition.PatrolSize,
                SwarmPlayer = false
            }).ToList();
    }
}