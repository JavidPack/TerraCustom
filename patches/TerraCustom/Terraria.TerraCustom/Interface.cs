using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.TerraCustom.UI;
using static Terraria.TerraCustom.TerraCustomUtils;

namespace Terraria.TerraCustom
{
	public enum MenuModes
	{
		// Vanilla
		SelectDifficulty = 1000,
		EnterWorldName,
		EnterWorldSeed = 5000,
		// Custom
		Settings,
		ChooseWorldSize,
		ChallengeOption,
		ResetAllSettings,
		MicroBiomes1,
		MicroBiomes2,
		DownedFound,
		Downed,
		Found,
		VariousSpawns,
		Ores,
		OreAmount,
		GraphicStyles,
		Backgrounds,
		SurfaceBackgrounds,
		UndergroundBackgrounds,
		Miscellaneous,
		Terrain,
		Terrain2,
		Terrain3,
		Chests,
		Debug,
		Traps,
		//SavedSettings,
		SettingsView,
	}
	class Interface
	{
		internal static UISettingsView settingsViewMenu = new UISettingsView();
		/*
		GenericMenu(main, DownedFoundMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref num3, ref numberClickableLabels);
		
		static TerraCustomMenuItem[] FoundMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Found NPC Settings", WorldGen.initializeFound) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new OptionLabel(),
			new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};
		*/

		static PlainLabel InfoMessageLabel = new PlainLabel("");

		//static string seedlabel = "Set Seed: ";
		static TerraCustomMenuItem[] SettingsMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(TCText("ResetAll"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.ResetAllSettings; }){ labelScale = 0.53f, additionalHorizontalSpacingPre = -38 },
			//new ActionLabel(seedlabel, () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.ResetAllSettings; }){ labelScale = 0.53f, additionalHorizontalSpacingPre = -38 },
			new ActionLabel(TCText("ReloadtModLoaderMods"), () => { Main.instance.selectedMenu = -1; Main.menuMode = ModLoader.UI.Interface.reloadModsID; }){ labelScale = 0.53f, additionalHorizontalSpacingPre = -10 },
			new ActionLabel(TCText("Terrain"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Terrain; }),
			new ActionLabel(TCText("Ores"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Ores; }),
			new ActionLabel(TCText("OreAmount"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.OreAmount; }),
			new ActionLabel(TCText("GraphicStyles"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.GraphicStyles; }),
			new ActionLabel(TCText("Backgrounds"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Backgrounds; }),
			new ActionLabel(TCText("Miscellaneous"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Miscellaneous; }),
			new ActionLabel(TCText("ChallengeOptions"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.ChallengeOption; }),
			new ActionLabel(TCText("MicroBiomes"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.MicroBiomes1; }),
			new ActionLabel(TCText("Traps"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Traps; }),
			new ActionLabel(TCText("VariousSpawns"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.VariousSpawns; }),
			new ActionLabel(TCText("DownedBossesFoundNPCs"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.DownedFound; }),
			new ActionLabel(TCText("Chests"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Chests; }),
			new ActionLabel(TCText("SaveLoadSettings"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.SettingsView; }),
			new ActionLabel(TCText("Debug"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Debug; }),
			new ActionLabel(Lang.menu[5].Value, () => { Main.menuMode = (int)MenuModes.ChooseWorldSize; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 20 }, // Back 
			new ActionLabel(Lang.menu[28].Value, CreateClicked) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 }, // Generate
			InfoMessageLabel, // message
		};

		static void CreateClicked()
		{
			Main.player[Main.myPlayer] = new Player();
			InfoMessageLabel.SetLabel("");
			if (ChestEstimate() >= 1000)
			{
				InfoMessageLabel.SetLabel("Estimated chest count too high, it will crash, please fix.");
				Main.PlaySound(SoundID.MenuClose);
				return;
			}

			Main.settingSaver.saveSetting("Autosave-LastUsed");
			Main.menuMode = 10;
			//Main.worldName = Main.newWorldName;
			if (Main.setting.LeveledRPGCriticalMode) Main.expertMode = true;
			Main.ActiveWorldFileData = WorldFile.CreateMetadata(Main.worldName, false, Main.expertMode);
			WorldGen.CreateNewWorld(null);
		}

		static TerraCustomMenuItem[] DownedFoundMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(TCText("DownedBosses"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Downed; }),
			new ActionLabel(TCText("FoundNPCs"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Found; }),
			new ActionLabel(Lang.menu[5].Value, () => { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] BackgroundsMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(TCText("SurfaceBackgrounds"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.SurfaceBackgrounds; }),
			new ActionLabel(TCText("UndergroundBackgrounds"), () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.UndergroundBackgrounds; }),
			new ActionLabel(Lang.menu[5].Value, () => { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static string[] CreateFoundYesNoArray(string value)
		{
			return new string[] { $"{TCText("Found")} {value}: {Language.GetTextValue("CLI.No")}", $"{TCText("Found")} {value}: {Language.GetTextValue("CLI.Yes")}" };
		}

		static TerraCustomMenuItem[] FoundMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("FoundNPCs")), Setting.initializeFound) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new OptionLabel(CreateFoundYesNoArray(Language.GetTextValue("NPCName.Stylist")), () => Main.setting.savedStylist ? 1 : 0, x => Main.setting.savedStylist = x > 0 ? true : false),
			new OptionLabel(CreateFoundYesNoArray(Language.GetTextValue("NPCName.GoblinTinkerer")), () => Main.setting.savedGoblin? 1 : 0, x => Main.setting.savedGoblin = x > 0 ? true : false),
			new OptionLabel(CreateFoundYesNoArray(Language.GetTextValue("NPCName.Wizard")), () => Main.setting.savedWizard? 1 : 0, x => Main.setting.savedWizard = x > 0 ? true : false),
			new OptionLabel(CreateFoundYesNoArray(Language.GetTextValue("NPCName.Mechanic")), () => Main.setting.savedMechanic? 1 : 0, x => Main.setting.savedMechanic = x > 0 ? true : false),
			new OptionLabel(CreateFoundYesNoArray(Language.GetTextValue("NPCName.Angler")), () => Main.setting.savedAngler? 1 : 0, x => Main.setting.savedAngler = x > 0 ? true : false),
			new OptionLabel(CreateFoundYesNoArray(Language.GetTextValue("NPCName.DD2Bartender")), () => Main.setting.savedBartender? 1 : 0, x => Main.setting.savedBartender = x > 0 ? true : false),
			new OptionLabel(CreateFoundYesNoArray(Language.GetTextValue("NPCName.TaxCollector")), () => Main.setting.savedTaxCollector? 1 : 0, x => Main.setting.savedTaxCollector = x > 0 ? true : false),
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.DownedFound; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static string[] CreateDownedYesNoArray(string value)
		{
			return new string[] { $"{TCText("Downed")} {value}: {Language.GetTextValue("CLI.No")}", $"{TCText("Downed")} {value}: {Language.GetTextValue("CLI.Yes")}" };
		}

		static TerraCustomMenuItem[] DownedMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("DownedBosses")), Setting.initializeDowned) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.KingSlime")),() => Main.setting.downedSlimeKing ? 1 : 0, x => Main.setting.downedSlimeKing = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.QueenBee")),() => Main.setting.downedQueenBee? 1 : 0,x =>  Main.setting.downedQueenBee = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.EyeofCthulhu")),() => Main.setting.downedEyeOfCthulu? 1 : 0,x => Main.setting.downedEyeOfCthulu = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.EaterofWorldsHead") + "/" + Language.GetTextValue("NPCName.BrainofCthulhu")),() => Main.setting.downedEaterBrain? 1 : 0,x =>  Main.setting.downedEaterBrain = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.SkeletronHead")),() => Main.setting.downedSkeletron? 1 : 0,x => Main.setting.downedSkeletron  = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("Enemies.TheTwins")),() => Main.setting.downedTwins? 1 : 0,x => Main.setting.downedTwins = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.TheDestroyer")),() => Main.setting.downedDestroyer? 1 : 0,x => Main.setting.downedDestroyer = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.SkeletronPrime")),() => Main.setting.downedSkeletronPrime? 1 : 0,x => Main.setting.downedSkeletronPrime = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.Plantera")),() => Main.setting.downedPlantera? 1 : 0,x => Main.setting.downedPlantera = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.Golem")),() => Main.setting.downedGolem? 1 : 0,x => Main.setting.downedGolem = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.DukeFishron")),() => Main.setting.downedFishron? 1 : 0,x => Main.setting.downedFishron = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.CultistBoss")),() => Main.setting.downedAncientCultist? 1 : 0,x => Main.setting.downedAncientCultist = x > 0 ? true : false),
			new OptionLabel(CreateDownedYesNoArray(Language.GetTextValue("NPCName.MoonLordHead")),() => Main.setting.downedMoonlord? 1 : 0,x => Main.setting.downedMoonlord = x > 0 ? true : false),
			new ActionLabel(Lang.menu[5].Value, () => { Main.menuMode = (int)MenuModes.DownedFound; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static string[] CreateDisabledEnabledArray(string value)
		{
			return new string[] { $"{value}: {Language.GetTextValue("GameUI.Disabled")}", $"{value}: {Language.GetTextValue("GameUI.Enabled")}" };
		}

		static string ResetMenu(string menu)
		{
			return $"{Language.GetTextValue("TerraCustom.Reset")} {menu} {Language.GetTextValue("LegacyMenu.14")}";
		}

		static TerraCustomMenuItem[] ChallengeOptionMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("ChallengeOptions")), Setting.initializeChallenge) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoTree")), () => Main.setting.NoTree ? 1 : 0, x => Main.setting.NoTree = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoDungeon")), () => Main.setting.NoDungeon ? 1 : 0, x => Main.setting.NoDungeon = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoTemple")), () => Main.setting.NoTemple ? 1 : 0, x => Main.setting.NoTemple= x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoSpiderCave")), () => Main.setting.NoSpiderCave ? 1 : 0, x => Main.setting.NoSpiderCave = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoHive")), () => Main.setting.NoHive ? 1 : 0, x => Main.setting.NoHive = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoSnow")), () => Main.setting.NoSnow ? 1 : 0, x => Main.setting.NoSnow = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoJungle")), () => Main.setting.NoJungle ? 1 : 0, x => Main.setting.NoJungle = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoAnthill")), () => Main.setting.NoAnthill ? 1 : 0, x => Main.setting.NoAnthill = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoBeaches")), () => Main.setting.NoBeach ? 1 : 0, x => Main.setting.NoBeach = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoPot")), () => Main.setting.NoPot ? 1 : 0, x => Main.setting.NoPot = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoChest")), () => Main.setting.NoChest ? 1 : 0, x => Main.setting.NoChest = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoAltar")), () => Main.setting.NoAltar ? 1 : 0, x => Main.setting.NoAltar = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoOrbOrHeart")), () => Main.setting.NoOrbHeart ? 1 : 0, x => Main.setting.NoOrbHeart = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoUnderworld")), () => Main.setting.NoUnderworld ? 1 : 0, x => Main.setting.NoUnderworld = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("SwapShroomJungle")), () => Main.setting.SwapShroomJungle ? 1 : 0, x => Main.setting.SwapShroomJungle = x > 0 ? true :false),
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static string[] CreateABRandomBothArray(string a, string b)
		{
			return new string[] { $"{a}/{b}: {b}", $"{a}/{b}: {a}", $"{a}/{b}: {Language.GetTextValue("CLI.Random")}", $"{a}/{b}: {TCText("Both")}" };
		}

		// Regular = 1, Alternate = 0, Random = 2, Both = 3
		static TerraCustomMenuItem[] OresMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("Ore")), Setting.initializeOres) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel(TCText("AlsoCheckOreAmountNote")) {labelScale = 0.6f},
			new OptionLabel(CreateABRandomBothArray(Lang.GetItemNameValue(ItemID.CopperOre), Lang.GetItemNameValue(ItemID.TinOre)), () => Main.setting.IsCopper, x => Main.setting.IsCopper = x),
			new OptionLabel(CreateABRandomBothArray(Lang.GetItemNameValue(ItemID.IronOre), Lang.GetItemNameValue(ItemID.LeadOre)), () => Main.setting.IsIron, x => Main.setting.IsIron = x),
			new OptionLabel(CreateABRandomBothArray(Lang.GetItemNameValue(ItemID.SilverOre), Lang.GetItemNameValue(ItemID.TungstenOre)), () => Main.setting.IsSilver, x => Main.setting.IsSilver = x),
			new OptionLabel(CreateABRandomBothArray(Lang.GetItemNameValue(ItemID.GoldOre), Lang.GetItemNameValue(ItemID.PlatinumOre)), () => Main.setting.IsGold, x => Main.setting.IsGold = x),
			new OptionLabel(CreateABRandomBothArray(Lang.GetItemNameValue(ItemID.CobaltOre), Lang.GetItemNameValue(ItemID.PalladiumOre)), () => Main.setting.IsCobalt, x => Main.setting.IsCobalt = x),
			new OptionLabel(CreateABRandomBothArray(Lang.GetItemNameValue(ItemID.MythrilOre), Lang.GetItemNameValue(ItemID.OrichalcumOre)), () => Main.setting.IsMythril, x => Main.setting.IsMythril = x),
			new OptionLabel(CreateABRandomBothArray(Lang.GetItemNameValue(ItemID.AdamantiteOre), Lang.GetItemNameValue(ItemID.TitaniumOre)), () => Main.setting.IsAdaman, x => Main.setting.IsAdaman = x),
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static string[] CreateNoYesArray(string value)
		{
			return new string[] { $"{value}: {Language.GetTextValue("CLI.No")}", $"{value}: {Language.GetTextValue("CLI.Yes")}" };
		}

		static string[] CreateNoYesRandomArray(string value)
		{
			return new string[] { $"{value}: {Language.GetTextValue("CLI.No")}", $"{value}: {Language.GetTextValue("CLI.Yes")}", $"{value}: {Language.GetTextValue("CLI.Random")}" };
		}

		static string[] ShallowNormalDeepArray(string value) {
			return new string[] { $"{value}: {TCText("Shallow")}", $"{value}: {TCText("Normal")}", $"{value}: {TCText("Deep")}" };
		}

		static TerraCustomMenuItem[] MiscellaneousMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("Miscellaneous")), Setting.initializeMiscellaneous) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new OptionLabel(new string[] { TCText("CorruptionCrimson") + ": Random",TCText("CorruptionCrimson") + ": Corruption",TCText("CorruptionCrimson") + ": Crimson",TCText("CorruptionCrimson") + ": (Both) Corruption plus Crimson chasms",TCText("CorruptionCrimson") + ": (Both) Crimson plus Corruption chasms", TCText("CorruptionCrimson") + ": None"}, () => Main.setting.IsCorruption, x => Main.setting.IsCorruption = x),
			new OptionLabel(CreateNoYesArray(TCText("ForceCorruptionCrimsonAvoidJungleSide")), () => Main.setting.CrimsonCorruptionAvoidJungle ? 1 : 0, x => Main.setting.CrimsonCorruptionAvoidJungle = x > 0 ? true : false),
			new OptionLabel(CreateNoYesArray(TCText("ForceCorruptionCrimsonSeparateSides")), () => Main.setting.CrimsonCorruptionAvoidEachOther ? 1 : 0, x => Main.setting.CrimsonCorruptionAvoidEachOther = x > 0 ? true : false),
			new SliderItem(TCTextC("CorruptionBiomes"), 5f, () => Main.setting.CorruptionMultiplier, x => Main.setting.CorruptionMultiplier = x, x => (Main.setting.IsCorruption == 0 || Main.setting.IsCorruption == 1 || Main.setting.IsCorruption == 3 || Main.setting.IsCorruption == 4 ? Math.Round(x * 100f) + "%" + " -> " + (int)Math.Ceiling(Main.maxTilesX * 0.00045 * x) : "Disabled")),
			new SliderItem(TCTextC("CrimsonBiomes"), 5f, () => Main.setting.CrimsonMultiplier, x => Main.setting.CrimsonMultiplier = x, x => (Main.setting.IsCorruption == 0 || Main.setting.IsCorruption == 2 || Main.setting.IsCorruption == 3 || Main.setting.IsCorruption == 4 ? Math.Round(x * 100f) + "%" + " -> " + (int)Math.Ceiling(Main.maxTilesX * 0.00045 * x) : "Disabled")),
			new OptionLabel(new string[] { TCText("DungeonSide") + ": Random",TCText("DungeonSide") + ": Left",TCText("DungeonSide") + ": Right"}, () => Main.setting.DungeonSide, x => Main.setting.DungeonSide = x),
			new OptionLabel(CreateNoYesArray(TCText("Hardmode")), () => Main.hardMode ? 1 : 0, x => Main.hardMode = x > 0 ? true : false),
			new OptionLabel(CreateNoYesArray(TCText("SpawnHardmodeStripesIfHardmode")), () => Main.setting.HardmodeStripes ? 1 : 0, x => Main.setting.HardmodeStripes = x > 0 ? true : false),
			new OptionLabel(CreateNoYesRandomArray(TCText("Pyramids")), () => Main.setting.IsPyramid, x => Main.setting.IsPyramid = x),
			new OptionLabel(CreateNoYesRandomArray(TCText("GiantTrees")), () => Main.setting.IsGiantTree, x => Main.setting.IsGiantTree = x),
			new OptionLabel(CreateNoYesArray(TCText("ForceEnchantedSwordShrineReal")), () => Main.setting.ForceEnchantedSwordShrineReal ? 1 : 0, x => Main.setting.ForceEnchantedSwordShrineReal = x > 0 ? true : false),
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] VariousSpawnsMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("VariousSpawns")), Setting.initializeVariousSpawnsAmount) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel(TCText("Setting100ForDefaultAmountNote")) {labelScale = 0.6f},
			new SliderItem(TCTextC("CrystalHearts"),10f,() => Main.setting.CrystalHeartMultiplier, x => Main.setting.CrystalHeartMultiplier = x,x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05 * x)),
			new SliderItem(TCTextC("PreDropMeteor"),100f,() => (float)Main.setting.PreDropMeteor,  x => Main.setting.PreDropMeteor = (int)x,x => "Drop " + (int)x + " meteors"),
			new SliderItem(TCTextC("TreeLowerBound"),150f,() => (float)Main.setting.TreeLowerBound,x => Main.setting.TreeLowerBound = ((int)x>Main.setting.TreeUpperBound? Main.setting.TreeUpperBound: (int)x),x => "Between " + (int)x ), // ratio * %
			new SliderItem(TCTextC("TreeUpperBound"),150f,() => (float)Main.setting.TreeUpperBound,x => Main.setting.TreeUpperBound = ((int)x<Main.setting.TreeLowerBound? Main.setting.TreeLowerBound: (int)x),x => " and " + (int)x + " tiles tall"),
			new SliderItem(TCTextC("MushroomBiomes"),10f,() => Main.setting.MushroomBiomeMultiplier, x => Main.setting.MushroomBiomeMultiplier = x,x => Math.Round((double)(x * 100f)) + "% -> " + (int)((Main.maxTilesX / 500) * x)),
			new SliderItem(TCTextC("MushroomSize"),40f,() => Main.setting.MushroomScale, x => Main.setting.MushroomScale = x,x => Math.Round((double)(x * 100f)) + "%"),
			new SliderItem(TCTextC("Webs"),40f,() => Main.setting.WebMult, x => Main.setting.WebMult = x,x => Math.Round((double)(x * 100f)) + "%"),
			new SliderItem(TCTextC("Statues"),10f,() => Main.setting.StatueMultiplier, x => Main.setting.StatueMultiplier = x,x => Math.Round((double)(x * 100f)) + "% -> " + (int)((WorldGen.statueList.Length * 2 * (float)Main.maxTilesX / 4200) * x)),
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] MicroBiomesMenuItems1 = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("MicroBiomes")), Setting.initializeMicroBiomesAmount) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel(TCTextC("Setting100ForDefaultAmountBiomesNote")) {labelScale = 0.6f},
			new SliderItem(TCTextC("EnchantedSword"), 5f, () => Main.setting.EnchantedSwordBiomeMultiplier, x => Main.setting.EnchantedSwordBiomeMultiplier = x,x => Math.Round(x * 100f) + "%" + " -> " + (int)Math.Ceiling((Main.maxTilesX * Main.maxTilesY / 5040000f) * x)),
			new SliderItem(TCTextC("Campsite"), 20f, () => Main.setting.CampsiteBiomeMultiplier, x => Main.setting.CampsiteBiomeMultiplier = x,x => Math.Round(x* 100f) + "% -> " + (int)((float)6 * ((float)(Main.maxTilesX* Main.maxTilesY) / 5040000) * Main.setting.CampsiteBiomeMultiplier) + "-" + (int)((float)11 * ((float)(Main.maxTilesX* Main.maxTilesY) / 5040000) * Main.setting.CampsiteBiomeMultiplier)),
			new SliderItem(TCTextC("ThinIce"), 5f, () => Main.setting.ThinIceBiomeMultiplier, x => Main.setting.ThinIceBiomeMultiplier = x,x => Math.Round(x* 100f) + "% -> " + (int)((float)3 * ((float)(Main.maxTilesX* Main.maxTilesY) / 5040000) * Main.setting.ThinIceBiomeMultiplier) + "-" + (int)((float)5 * ((float)(Main.maxTilesX* Main.maxTilesY) / 5040000) * Main.setting.ThinIceBiomeMultiplier)),
			new SliderItem(TCTextC("SkyIslands"), 10f, () => Main.setting.SkyIslandMultiplier, x => Main.setting.SkyIslandMultiplier = x, x => "~" + Math.Round(x * 100f) + "%"),
			new SliderItem(TCTextC("MinecartTracks"), 3f, () => Main.setting.MineCartMultiplier, x => Main.setting.MineCartMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(10f * (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f * x)),
			new SliderItem(TCTextC("SpiderCaves"), 5f, () => Main.setting.SpiderCaveMultiplier, x => Main.setting.SpiderCaveMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + "~"+(int)(Main.maxTilesX * 0.005 * x)),
			new SliderItem(TCTextC("GraniteCaves"), 10f, () => Main.setting.GraniteCaveMultiplier, x => Main.setting.GraniteCaveMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(8 * (Main.maxTilesX / 4200f) * x) + "-" + (int)(13 * (Main.maxTilesX / 4200f) * x)),
			new SliderItem(TCTextC("MarbleCaves"), 10f, () => Main.setting.MarbleCaveMultiplier, x => Main.setting.MarbleCaveMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(10 * ((Main.maxTilesX * Main.maxTilesY) / 5040000f) * x) + "-" + (int)(14 * ((Main.maxTilesX * Main.maxTilesY) / 5040000f) *x)),
			new SliderItem(TCTextC("UndergroundCabins"), 10f, () => Main.setting.UndergroundCabinMultiplier, x => Main.setting.UndergroundCabinMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + ((int)(Main.setting.UndergroundCabinMultiplier * 2f * (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f)+(int)((double)(Main.maxTilesX * Main.maxTilesY) * 1.6E-05 * Main.setting.UndergroundCabinMultiplier)) + " " + (((int)(Main.setting.UndergroundCabinMultiplier * 2f * (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f)+(int)((double)(Main.maxTilesX * Main.maxTilesY) * 1.6E-05 * Main.setting.UndergroundCabinMultiplier))>800?" Warning: Might Fail, too many chests.":"")),
			new ActionLabel("Next Page", ()=> { Main.menuMode = (int)MenuModes.MicroBiomes2; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] MicroBiomesMenuItems2 = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("MicroBiomes")), Setting.initializeMicroBiomesAmount) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel(TCTextC("Setting100ForDefaultAmountBiomesNote")) {labelScale = 0.6f},
			new SliderItem(TCTextC("GemstonesNonCave"), 100f, () => Main.setting.GemMultiplier, x => Main.setting.GemMultiplier = x, x => Math.Round((double)(x * 100f)) + "%"),
			new SliderItem(TCTextC("GemstoneCaves"), 10f, () => Main.setting.GemCaveMultiplier, x => Main.setting.GemCaveMultiplier = x, x => Math.Round((double)(x * 100f)) + "%"),
			new SliderItem(TCTextC("GemstoneCaveSize"), 10f, () => Main.setting.GemCaveSizeMultiplier, x => Main.setting.GemCaveSizeMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(300*x) +" tiles"),
			new SliderItem(TCTextC("Hives"), 10f, () => Main.setting.HiveMultiplier, x => Main.setting.HiveMultiplier = x, x => Math.Round((double)(x * 100f)) + "% -> " + (int)(x*(1 + (int)(5f * Main.maxTilesX / 4200f))) + "-" + (int)(x*(1 + (int)(8f * Main.maxTilesX / 4200f))) +" hives"),
			new SliderItem(TCTextC("UnderworldHouseMult"), 10f, () => Main.setting.UnderworldHouseMult, x => Main.setting.UnderworldHouseMult = x, x => Math.Round((double)(x * 100f)) + "%"),
			new SliderItem(TCText("GiantTreeMult"),9.8f,() => Main.setting.GiantTreeMult - .2f, x => Main.setting.GiantTreeMult = x + .2f, x => Math.Round((double)(Main.setting.GiantTreeMult * 100f)) + "%"),
			new ActionLabel("Next Page", ()=> { Main.menuMode = (int)MenuModes.MicroBiomes1; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] TrapsMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("Traps")), Setting.initializeTrapsAmount) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new SliderItem(TCTextC("MiningExplosiveDetonator"), 50f, () => Main.setting.MiningExplosiveMultiplier, x => Main.setting.MiningExplosiveMultiplier = x, x => "         "+Math.Round(x * 100f) + "%"),
			new SliderItem(TCTextC("TrapsDartExplosiveBoulder"), 100f, () => Main.setting.TrapMultiplier, x => Main.setting.TrapMultiplier = x, x => "         "+Math.Round(x * 100f) + "%"),
			new SliderItem(TCTextC("AdditionalDartTraps"), 10f, () => Main.setting.AdditionalDartTrapMultiplier, x => Main.setting.AdditionalDartTrapMultiplier = x, x => "     "+Math.Round(x * 100f) + "% -> " + ((int)(0.475 * Main.maxTilesX * 0.05 * Main.setting.TrapMultiplier) + (int)(Main.maxTilesX * 0.05 * Main.setting.AdditionalDartTrapMultiplier))),
			new SliderItem(TCTextC("AdditionalBoulderTraps"), 10f, () => Main.setting.AdditionalBoulderTrapMultiplier, x => Main.setting.AdditionalBoulderTrapMultiplier = x, x => "     "+Math.Round(x * 100f) + "% -> " + ((int)(0.475 * Main.maxTilesX * 0.05 * Main.setting.TrapMultiplier) + (int)(Main.maxTilesX * 0.05 * Main.setting.AdditionalBoulderTrapMultiplier))),
			new SliderItem(TCTextC("AdditionalExplosiveTraps"), 10f, () => Main.setting.AdditionalExplosiveTrapMultiplier, x => Main.setting.AdditionalExplosiveTrapMultiplier = x, x => "     "+Math.Round(x * 100f) + "% -> " + ((int)(0.05 * Main.maxTilesX * 0.05 * Main.setting.TrapMultiplier) + (int)(Main.maxTilesX * 0.05 * Main.setting.AdditionalExplosiveTrapMultiplier))),
			new SliderItem(TCTextC("AdditionalGeyserTraps"), 10f, () => Main.setting.AdditionalGeyserTrapMultiplier, x => Main.setting.AdditionalGeyserTrapMultiplier = x, x => "     "+Math.Round(x * 100f) + "% -> " + ((int)(0.25 * Main.maxTilesX * 0.05 * Main.setting.TrapMultiplier) + (int)(Main.maxTilesX * 0.05 * Main.setting.AdditionalGeyserTrapMultiplier))),
			new SliderItem(TCTextC("TempleTraps"), 10f, () => Main.setting.TempleTrapMultiplier, x => Main.setting.TempleTrapMultiplier = x, x => Math.Round((double)(x * 100f)) + "%"),
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoMultiWire")), () => Main.setting.SmartTrapsOff ? 1 : 0, x => Main.setting.SmartTrapsOff = x > 0 ? true :false),
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] TerrainMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("Terrain")), Setting.initializeTerrain) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel(TCText("Use100ForDefaultBehaviorNote")) {labelScale = 0.6f},
			new SliderItem(TCTextC("SurfaceHeightVariance"), 10f,() => Main.setting.SurfaceTerrainHeightMultiplier,x => Main.setting.SurfaceTerrainHeightMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + (x == 0 ? " Flat" : "")),
			new SliderItem(TCTextC("SurfaceUpperLimit"),.35f,() => Main.setting.SurfaceTerrainHeightMax - .1f /*.1 to .17*/, x => Main.setting.SurfaceTerrainHeightMax = x + .1f > Main.setting.SurfaceTerrainHeightMin ? Main.setting.SurfaceTerrainHeightMin : x + .1f, x => Math.Round((double)( Main.setting.SurfaceTerrainHeightMax * 100f)) + "%" + " - Low% = High Mountains" + ( Main.setting.SurfaceTerrainHeightMax <.15f?" High Chance of Failure":"")),
			new SliderItem(TCTextC("SurfaceLowerLimit"),.35f,() => Main.setting.SurfaceTerrainHeightMin - .1f /*.3 to .45?*/, x => Main.setting.SurfaceTerrainHeightMin = x+.1f < Main.setting.SurfaceTerrainHeightMax? Main.setting.SurfaceTerrainHeightMax : x+.1f, x => Math.Round((double)( Main.setting.SurfaceTerrainHeightMin * 100f)) + "%" + " - High% = Deep Valleys" + ( Main.setting.SurfaceTerrainHeightMin <.15f?" Low Chance of Sky Islands":"")),
			new OptionLabel(CreateDisabledEnabledArray(TCText("BypassSpawnAreaFlatness")), () => Main.setting.BypassSpawnAreaFlatness ? 1 : 0, x => Main.setting.BypassSpawnAreaFlatness = x > 0 ? true :false),
			new SliderItem(TCText("BeachSize"),2f,() => Main.setting.BeachSizeMultiplier -.1f, x => Main.setting.BeachSizeMultiplier = x +.1f, x => Math.Round((double)(Main.setting.BeachSizeMultiplier * 100f)) + "% -> " + (int)(175*Main.setting.BeachSizeMultiplier)  + "-" +  (int)(250*Main.setting.BeachSizeMultiplier) +" tiles wide"),
			new SliderItem(TCText("DungeonSize"),10f,() => Main.setting.DungeonSizeMultiplier- .01f, x => Main.setting.DungeonSizeMultiplier = x + .05f /*set called with 0 to 1.0f * ratio*/, x => Math.Round((double)(Main.setting.DungeonSizeMultiplier * 100f)) + "%" + " -> " + "~"+(2+(int)(x * Main.maxTilesX / 60)) + "-" + (int)(2+(int)(Main.setting.DungeonSizeMultiplier * Main.maxTilesX / 60)+(int)((Main.setting.DungeonSizeMultiplier * Main.maxTilesX / 60) / 3f)) + " rooms/hallways"),
			new SliderItem(TCText("TempleSize"),4f,() => Main.setting.TempleSizeMultiplier- .2f, x => Main.setting.TempleSizeMultiplier = x + .2f, x => Math.Round((double)(Main.setting.TempleSizeMultiplier * 100f)) + "%" + (Main.setting.TempleSizeMultiplier>3?" Warning: Might Fail":"")),
			new SliderItem(TCText("SurfaceTunnels"), 50f,() => Main.setting.SurfaceHorizontalTunnelsMultiplier, x => Main.setting.SurfaceHorizontalTunnelsMultiplier = x, x => Math.Round(Main.setting.SurfaceHorizontalTunnelsMultiplier * 100f) + "%"),
			new SliderItem(TCText("Lakes"),20f,() => Main.setting.LakeMultiplier, x => Main.setting.LakeMultiplier = x, x => Math.Round((double)(Main.setting.LakeMultiplier * 100f)) + "%" + " -> " + " between 2 and " + (int)((double)Main.maxTilesX * 0.005 * Main.setting.LakeMultiplier - 1)),
			new SliderItem(TCText("WorldWidth"), 16800f ,() => Main.maxTilesX, x => Main.maxTilesX = (int)(x/200) * 200, x => x +" tiles wide" +  (x<4200?" Warning: Might not gen, might have Vanilla issues":"") +  (x>8400?" Warning: Will not Load in Vanilla":"")),
			new SliderItem(TCText("WorldHeight"), 4800f ,() => Main.maxTilesY, x => Main.maxTilesY = (int)(x/150) *150, x => x +" tiles tall" + (x<1200?" Warning: Might not gen, might have Vanilla issues":"") +  (x>2400?" Warning: Will not Load in Vanilla":"")),
			new ActionLabel("Next Page", ()=> { Main.menuMode = (int)MenuModes.Terrain2; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] TerrainMenuItems2 = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("Terrain")), Setting.initializeTerrain) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel(TCText("Use100ForDefaultBehaviorNote")) {labelScale = 0.6f},
			new SliderItem(TCText("Sand"), 20f,() => Main.setting.SandMultiplier, x => Main.setting.SandMultiplier = x, x => Math.Round(Main.setting.SandMultiplier * 100f) + "%"),
			new SliderItem(TCText("Clay"), 20f,() => Main.setting.ClayMult, x => Main.setting.ClayMult = x, x => Math.Round(Main.setting.ClayMult * 100f) + "%"),
			new SliderItem(TCText("Silt"), 20f,() => Main.setting.SiltMultiplier, x => Main.setting.SiltMultiplier = x, x => Math.Round(Main.setting.SiltMultiplier * 100f) + "%"),
			new SliderItem(TCText("SurfaceCaves"), 10f,() => Main.setting.SurfaceCaveMult, x => Main.setting.SurfaceCaveMult = x, x => Math.Round(Main.setting.SurfaceCaveMult * 100f) + "%"),
			new SliderItem(TCText("UndergroundCaves"), 10f,() => Main.setting.DeepCaveMult, x => Main.setting.DeepCaveMult = x, x => Math.Round(Main.setting.DeepCaveMult * 100f) + "%"),
			new SliderItem(TCText("DesertScale"), 3.9f,() => Main.setting.DesertScale- .1f, x => Main.setting.DesertScale = x + .1f, x => Math.Round((double)(Main.setting.DesertScale * 100f)) + "%" + (Main.setting.DesertScale>(3.1f)?" Warning: Might Fail":"")),
			new SliderItem(TCText("IceBiomeWidth"), 9.9f,() => Main.setting.IceBiomeWidth- .1f, x => Main.setting.IceBiomeWidth = x + .1f, x => Math.Round((double)(Main.setting.IceBiomeWidth * 100f)) + "%"),
			new OptionLabel(ShallowNormalDeepArray(TCText("IceBiomeDepth")), () => Main.setting.IceBiomeDepth, x => Main.setting.IceBiomeDepth = x),
			new SliderItem(TCText("JungleScale"), 3.1f,() => Main.setting.JungleScale- .4f, x => Main.setting.JungleScale = x + .4f, x => Math.Round((double)(Main.setting.JungleScale * 100f)) + "%" + (Main.setting.JungleScale>(3f)?" Warning: Might Fail":"")),
			new SliderItem(TCText("LakeScale"),3.8f,() => Main.setting.LakeScale - .2f, x => Main.setting.LakeScale = x + .2f, x => Math.Round((double)(Main.setting.LakeScale * 100f)) + "%"),
			new OptionLabel(CreateDisabledEnabledArray(TCText("DoubleDungeon")), () => Main.setting.DoubleDungeon ? 1 : 0, x => Main.setting.DoubleDungeon = x > 0 ? true :false),
			new ActionLabel("Next Page", ()=> { Main.menuMode = (int)MenuModes.Terrain3; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] TerrainMenuItems3 = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("Terrain")), Setting.initializeTerrain) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel(TCText("Use100ForDefaultBehaviorNote")) {labelScale = 0.6f},
			new OptionLabel(CreateDisabledEnabledArray(TCText("NoGravitate")), () => Main.setting.NoGravitate ? 1 : 0, x => Main.setting.NoGravitate = x > 0 ? true :false),
			new ActionLabel("Next Page", ()=> { Main.menuMode = (int)MenuModes.Terrain; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] ChestsMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("Chests")), Setting.initializeChests) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel(TCText("Use100ForDefaultBehaviorNote")) {labelScale = 0.6f},
			new PlainLabel(ChestEstimateString),
			new SliderItem(TCTextC("BiomeChestSets"),10f,() => Main.setting.BiomeChestSets,   x => Main.setting.BiomeChestSets = (int) x,x => x + " sets"),
			new SliderItem(TCTextC("Pots"), 2.5f, () => Main.setting.PotsMultiplier, x => Main.setting.PotsMultiplier = x, x => Math.Round((double)(Main.setting.PotsMultiplier * 100f)) + "%" + " -> " + (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0008 * Main.setting.PotsMultiplier) + " pots"),
			new SliderItem(TCTextC("JungleShrines"), 5f, () => Main.setting.JungleShrineMultiplier, x => Main.setting.JungleShrineMultiplier = x, x => Math.Round((double)(Main.setting.JungleShrineMultiplier * 100f)) + "%" + " -> " + (int)Math.Ceiling(Main.setting.JungleShrineMultiplier*7*Main.maxTilesX / 4200)+ "-" + (int)Math.Ceiling(Main.setting.JungleShrineMultiplier*12*Main.maxTilesX / 4200)+" shrines"),
			new SliderItem(TCTextC("LivingMahoganyTrees"), 2f, () => Main.setting.MahoganyTreeMultiplier, x => Main.setting.MahoganyTreeMultiplier = x, x => Math.Round((double)(Main.setting.MahoganyTreeMultiplier * 100f)) + "%" + " -> ~" + (int)(6 * (Main.maxTilesX / 4200f) * Main.setting.MahoganyTreeMultiplier)+ "-" +(int)(11 * (Main.maxTilesX / 4200f) * Main.setting.MahoganyTreeMultiplier)+ " trees"),
			new SliderItem(TCTextC("WaterChests"), 5f, () => Main.setting.WaterChestMultiplier, x => Main.setting.WaterChestMultiplier = x, x => Math.Round((double)(Main.setting.WaterChestMultiplier * 100f)) + "%" + " -> " + (int)Math.Ceiling(Main.setting.WaterChestMultiplier * 2f * 9f* (Main.maxTilesX / 4200f))+ " chests"),
			new SliderItem(TCTextC("SurfaceChests"), 5f, () => Main.setting.SurfaceChestMultiplier, x => Main.setting.SurfaceChestMultiplier = x, x => Math.Round((double)(Main.setting.SurfaceChestMultiplier * 100f)) + "%" + " -> " + (int)((double)Main.maxTilesX * 0.005 * Main.setting.SurfaceChestMultiplier) + " chests"),
			new SliderItem(TCTextC("TempleChests"), 5f, () => Main.setting.TempleChestMultiplier, x => Main.setting.TempleChestMultiplier = x, x => Math.Round((double)(Main.setting.TempleChestMultiplier * 100f)) + "%" + " -> " +(int)Math.Ceiling(Main.setting.TempleChestMultiplier * 0.35f * 13f * (Main.maxTilesX / 4200f) * Main.setting.TempleSizeMultiplier *.85f) + "-" + (int)Math.Ceiling(Main.setting.TempleChestMultiplier * 0.35f * 13f * (Main.maxTilesX / 4200f) * Main.setting.TempleSizeMultiplier * 1.15f) + " chests"),
			new SliderItem(Main.setting.ShadowChestMultiplierDelegate.label /*"Shadow Chests:"*/, Main.setting.ShadowChestMultiplierDelegate.ratio/*5f*/, Main.setting.ShadowChestMultiplierDelegate.getter, Main.setting.ShadowChestMultiplierDelegate.setter, Main.setting.ShadowChestMultiplierDelegate.estimationString),
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] OreAmountMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("OreAmount")), Setting.initializeOreAmount) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 }, // -17
			new PlainLabel(TCText("Setting100ForDefaultAmountOfOresNote")) {labelScale = 0.6f},
			new SliderItem($"{Lang.GetItemNameValue(ItemID.CopperOre)}/{Lang.GetItemNameValue(ItemID.TinOre)}:",5f,() => Main.setting.PercCopp, x => Main.setting.PercCopp = x, x => Math.Round((double)(Main.setting.PercCopp * 100f)) + "%"),
			new SliderItem($"{Lang.GetItemNameValue(ItemID.IronOre)}/{Lang.GetItemNameValue(ItemID.LeadOre)}:",5f,() => Main.setting.PercIron, x => Main.setting.PercIron = x, x => Math.Round((double)(Main.setting.PercIron * 100f)) + "%"),
			new SliderItem($"{Lang.GetItemNameValue(ItemID.SilverOre)}/{Lang.GetItemNameValue(ItemID.TungstenOre)}:",5f,() => Main.setting.PercSilv, x => Main.setting.PercSilv = x, x => Math.Round((double)(Main.setting.PercSilv * 100f)) + "%"),
			new SliderItem($"{Lang.GetItemNameValue(ItemID.GoldOre)}/{Lang.GetItemNameValue(ItemID.PlatinumOre)}:",5f,() => Main.setting.PercGold, x => Main.setting.PercGold = x, x => Math.Round((double)(Main.setting.PercGold * 100f)) + "%"),
			new SliderItem($"{Lang.GetItemNameValue(ItemID.DemoniteOre)}/{Lang.GetItemNameValue(ItemID.CrimtaneOre)}:",5f,() => Main.setting.PercDemonite, x => Main.setting.PercDemonite = x, x => Math.Round((double)(Main.setting.PercDemonite * 100f)) + "%"),
			new SliderItem($"{Lang.GetItemNameValue(ItemID.Hellstone)}:",5f,() => Main.setting.PercHellstone, x => Main.setting.PercHellstone= x, x => Math.Round((double)(Main.setting.PercHellstone * 100f)) + "%"),
			new PlainLabel(TCText("OptionToGenerateAlternateHardmodeOres")) {labelScale = 0.6f, additionalHorizontalSpacingPre = 10},
			new SliderItem("",1f,() => Main.setting.PreSmashAltar, x => Main.setting.PreSmashAltar= x, x => {
				if (Main.setting.PreSmashAltar > 0f && (double)Main.setting.PreSmashAltar < 0.3)
				{
					return TCText("GenerateLittle");
				}
				else if ((double)Main.setting.PreSmashAltar >= 0.3 && (double)Main.setting.PreSmashAltar < 0.7)
				{
					return TCText("GenerateMedium");
				}
				else if ((double)Main.setting.PreSmashAltar >= 0.7)
				{
					return TCText("GenerateLot");
				}
				else
				{
					return TCText("GenerateNone");
				}
			}) { secondStringOnly = true},
			new SliderItem("",0,() => 0f, x=> { }, x => TCText("SameAmountAsSmashingXAltars", Math.Round((double)(Main.setting.PreSmashAltar * 50f)))) { secondStringOnly = true, noSlider = true},
			new OptionLabel(CreateDisabledEnabledArray(TCText("PreSmashAltarsGeneratesOpposite")), () => Main.setting.PreSmashAltarOreGenerateOpposite? 1 : 0, x => Main.setting.PreSmashAltarOreGenerateOpposite = x > 0 ? true : false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("PreSmashAltarsGeneratesBothSetsOfOres")), () => Main.setting.PreSmashAltarOreAlternates? 1 : 0, x => Main.setting.PreSmashAltarOreAlternates = x > 0 ? true : false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("PreSmashAltarsPreventRandomPatchSpawn")), () => Main.setting.PreSmashAltarPreventPatches? 1 : 0, x => Main.setting.PreSmashAltarPreventPatches = x > 0 ? true : false),
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] DebugMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel(ResetMenu(TCText("Debug")), Setting.initializeDebug) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new OptionLabel(CreateDisabledEnabledArray(TCText("SaveWorldAfterEachStep")), () => Main.setting.GenerateWldEachStep ? 1 : 0, x => Main.setting.GenerateWldEachStep = x > 0 ? true :false),
			new OptionLabel(CreateDisabledEnabledArray(TCText("SaveWorldIntModLoaderFolder")), () => Main.setting.SaveInTModFolder ? 1 : 0, x => { if (x>0) { Main.setting.SaveInTModFolder = true; Main.setting.LeveledRPGCriticalMode = false; Main.setting.generateLeveledRPGSave = false; } else { Main.setting.SaveInTModFolder = false; }}),
			new OptionLabel(new string[] { "Save World for the Terraria Leveled mod: Disabled", "Save World for the Terraria Leveled mod: Enabled"}, () => Main.setting.generateLeveledRPGSave ? 1 : 0, x => { if (x>0) { Main.setting.generateLeveledRPGSave = true; Main.setting.SaveInTModFolder = false; } else { Main.setting.generateLeveledRPGSave = false; }}),
			new OptionLabel(new string[] { "Terraria Leveled mod Critical Mode: Disabled", "Terraria Leveled mod Critical Mode: Enabled"}, () => Main.setting.LeveledRPGCriticalMode ? 1 : 0, x => Main.setting.LeveledRPGCriticalMode = (x > 0) ? true : false),
			new ActionLabel(Lang.menu[5].Value, ()=> { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static string[] CreateRandomPlusRangeArray(string value, int count)
		{
			var list = new List<string>();
			list.Add($"{value}: {Language.GetTextValue("CLI.Random")}");
			for (int i = 0; i < count; i++)
			{
				list.Add($"{value}: {count + 1}");
			}
			return list.ToArray();
		}

		internal static Color color = Color.White;
		private static KeyboardState keyState;
		private static KeyboardState oldkeystate;
		public static int keyboardSliderAdjustment = 0;

		//TerraCustom.Interface.TerraCustomMenu(this, this.selectedMenu, clickableLabelText, clickableLabelScale, array4, ref num, ref num3, ref numberClickableLabels);
		internal static void TerraCustomMenu(Main main, int selectedMenu, bool[] array, string[] clickableLabelText, float[] clickableLabelScale, int[] array4, ref int num, ref int defaultLabelSpacing, ref int numberClickableLabels)
		{
			keyboardSliderAdjustment = 0;
			oldkeystate = keyState;
			keyState = Keyboard.GetState();
			if ((keyState.IsKeyDown(Keys.Left) && oldkeystate.IsKeyUp(Keys.Left)) || (keyState.IsKeyDown(Keys.A) && oldkeystate.IsKeyUp(Keys.A)))
			{
				if (keyState.IsKeyDown(Keys.LeftShift) || keyState.IsKeyDown(Keys.RightShift))
				{
					keyboardSliderAdjustment--;
				}
				else
				{
					keyboardSliderAdjustment -= 10;
				}
			}
			if ((keyState.IsKeyDown(Keys.Right) && oldkeystate.IsKeyUp(Keys.Right)) || (keyState.IsKeyDown(Keys.D) && oldkeystate.IsKeyUp(Keys.D)))
			{
				if (keyState.IsKeyDown(Keys.LeftShift) || keyState.IsKeyDown(Keys.RightShift))
				{
					keyboardSliderAdjustment++;
				}
				else
				{
					keyboardSliderAdjustment += 10;
				}
			}

			num = 200;
			if (Main.menuMode == (int)MenuModes.DownedFound)
			{
				GenericMenu(main, DownedFoundMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Downed)
			{
				GenericMenu(main, DownedMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Found)
			{
				GenericMenu(main, FoundMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Chests)
			{
				GenericMenu(main, ChestsMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Terrain)
			{
				GenericMenu(main, TerrainMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
				// 0 to 10f : R: 10
				// .1 to .17: R: .07 +- .1
				// Each needs: Label, Ratio, property(get/set), method for string generation?
				//.07f,.15f,
				//() => Main.setting.SurfaceTerrainHeightMax - .1f,
				// .1 to .17
				//() => Main.setting.SurfaceTerrainHeightMin - .3f,  // .3 to .45?
				// % = get/ratio therfore, ratio must be range, get must return 0 to range
				//x => Main.setting.SurfaceTerrainHeightMax = x+.1f,
				//x => Main.setting.SurfaceTerrainHeightMin = x+.3f, // ration * % 
			}
			else if (Main.menuMode == (int)MenuModes.Terrain2)
			{
				GenericMenu(main, TerrainMenuItems2, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Terrain3) {
				GenericMenu(main, TerrainMenuItems3, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.VariousSpawns)
			{
				WorldGen.SetupStatueList();
				GenericMenu(main, VariousSpawnsMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
				/*	"Demon/Crimson Altars:", 95f
				//		() => (float)Main.setting.NumberGenerationPassSteps,
				//	x => Main.setting.NumberGenerationPassSteps = (int) x,
				//x => { Main.setting.TreeLowerBound = 1; Main.setting.TreeLowerBound = 2; },
				//x => Main.setting.AltarMultiplier = x,
				//	x => (int)x + " steps (Don't change this)",
				//x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05 * x),
				*/
			}
			else if (Main.menuMode == (int)MenuModes.MicroBiomes1)
			{
				GenericMenu(main, MicroBiomesMenuItems1, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.MicroBiomes2)
			{
				GenericMenu(main, MicroBiomesMenuItems2, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Traps)
			{
				GenericMenu(main, TrapsMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Backgrounds)
			{
				GenericMenu(main, BackgroundsMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Ores)
			{
				GenericMenu(main, OresMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			//else if (Main.menuMode == (int)MenuModes.SavedSettings)
			//{
			//	//	SettingSaver settingSaver = new SettingSaver();
			//	Main.settingSaver.getSettings();

			//	TerraCustomMenuItem[] SavedSettingItems = new TerraCustomMenuItem[] {
			//		new ActionLabel("Load", Main.settingSaver.loadSetting2) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			//		new ActionLabel("Save", Main.settingSaver.saveSetting2) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			//		new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
			//	};


			//	GenericMenu(main, SavedSettingItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			//}
			else if (Main.menuMode == (int)MenuModes.ChallengeOption)
			{
				GenericMenu(main, ChallengeOptionMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Debug)
			{
				GenericMenu(main, DebugMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.UndergroundBackgrounds)
			{
				{
					string[][] optionStrings = { };
					if (TerraCustomUtils.WorldSize == 0)
					{
						optionStrings = new string[][]
						{
							CreateRandomPlusRangeArray(TCText("IceBackground"), 4),
							CreateRandomPlusRangeArray(TCText("HellBackground"), 3),
							CreateRandomPlusRangeArray(TCText("JungleBackground"), 2),
							CreateRandomPlusRangeArray(TCText("CaveBackgroundLeft"), 8),
							CreateRandomPlusRangeArray(TCText("CaveBackgroundRight"), 8),
						};
					}
					if (TerraCustomUtils.WorldSize == 1)
					{
						optionStrings = new string[][]
						{
							CreateRandomPlusRangeArray(TCText("IceBackground"), 4),
							CreateRandomPlusRangeArray(TCText("HellBackground"), 3),
							CreateRandomPlusRangeArray(TCText("JungleBackground"), 2),
							CreateRandomPlusRangeArray(TCText("CaveBackgroundLeft"), 8),
							CreateRandomPlusRangeArray(TCText("CaveBackgroundMiddle"), 8),
							CreateRandomPlusRangeArray(TCText("CaveBackgroundRight"), 8),
						};
					}
					if (TerraCustomUtils.WorldSize == 2)
					{
						optionStrings = new string[][]
						{
							CreateRandomPlusRangeArray(TCText("IceBackground"), 4),
							CreateRandomPlusRangeArray(TCText("HellBackground"), 3),
							CreateRandomPlusRangeArray(TCText("JungleBackground"), 2),
							CreateRandomPlusRangeArray(TCText("CaveBackgroundFarLeft"), 8),
							CreateRandomPlusRangeArray(TCText("CaveBackgroundLeft"), 8),
							CreateRandomPlusRangeArray(TCText("CaveBackgroundRight"), 8),
							CreateRandomPlusRangeArray(TCText("CaveBackgroundFarRight"), 8),
						};
					}

					defaultLabelSpacing = 30; // virtical spacing?
					numberClickableLabels = 2 + optionStrings.GetLength(0); // = to reset + back + # options
					for (int num21 = 0; num21 < numberClickableLabels; num21++)
					{
						clickableLabelScale[num21] = 0.73f;
					}
					int buttonIndex = 0;
					clickableLabelText[buttonIndex] = ResetMenu(TCText("UndergroundBackgrounds"));
					if (main.selectedMenu == 0)
					{
						Setting.initializeUGBGs();
					}
					clickableLabelScale[0] = 0.53f;
					array4[0] = -17;


					Func<int>[] getters = {
							() => Main.setting.IceBackStyle,
							() => Main.setting.HellBackStyle,
							() => Main.setting.JungleBackStyle,
							() => Main.setting.CaveBackStyle1,
							() => Main.setting.CaveBackStyle2,
							() => Main.setting.CaveBackStyle3,
							() => Main.setting.CaveBackStyle4,
						};
					Action<int>[] setters = {
							x => Main.setting.IceBackStyle = x,
							x =>  Main.setting.HellBackStyle = x,
							x => Main.setting.JungleBackStyle = x,
							x => Main.setting.CaveBackStyle1 = x,
							x => Main.setting.CaveBackStyle2 = x,
							x => Main.setting.CaveBackStyle3 = x,
							x => Main.setting.CaveBackStyle4 = x,

						};

					for (int i = 0; i < optionStrings.GetLength(0); i++)
					{
						buttonIndex++;
						clickableLabelText[buttonIndex] = optionStrings[i][getters[i]()];
						if (main.selectedMenu == buttonIndex)
						{
							setters[i]((getters[i]() + 1) % optionStrings[i].Length);
						}
						if (main.selectedMenu2 == buttonIndex)
						{
							setters[i]((getters[i]() + optionStrings[i].Length - 1) % optionStrings[i].Length);
						}
					}

					buttonIndex++;
					array4[buttonIndex] = 30;
					clickableLabelText[buttonIndex] = Lang.menu[5].Value;
					if (main.selectedMenu == buttonIndex)
					{
						Main.menuMode = (int)MenuModes.Backgrounds;
					}



					if (main.selectedMenu != -1)
					{
						main.lastSelectedMenu = main.selectedMenu;
					}

					//IceBackStyle 
					if (main.lastSelectedMenu == 1)
					{
						int[][] backgrounds = new int[][] { new int[] { }, new int[] { 40, 33, 34, 32 }, new int[] { 160, 118, 161, 117 }, new int[] { 164, 165, 166, 167 }, new int[] { 162, 120, 163, 119 } };
						PreviewDrawAll(main, backgrounds[Main.setting.IceBackStyle]);
					}

					// Hell todo 3
					if (main.lastSelectedMenu == 2)
					{
						int[][] backgrounds = new int[][] { new int[] { }, new int[] { 125, 185 }, new int[] { 126, 186 }, new int[] { 127, 187 }, };
						PreviewDrawAll(main, backgrounds[Main.setting.HellBackStyle]);
					}

					// Jungle todo 2
					if (main.lastSelectedMenu == 3)
					{
						int[][] backgrounds = new int[][] { new int[] { },
									new int[] { 153, 147, 148, 149, 150+ (Main.setting.HellBackStyle > 0 ? Main.setting.HellBackStyle  -1:0) },
									new int[] { 146, 154, 155, 156, 157+ (Main.setting.HellBackStyle > 0 ? Main.setting.HellBackStyle  -1:0) } };
						PreviewDrawAll(main, backgrounds[Main.setting.JungleBackStyle]);
					}

					//Caves todo 8 for 4
					if (main.lastSelectedMenu >= 4 && main.lastSelectedMenu <= 5 + TerraCustomUtils.WorldSize)
					{
						int[][] backgrounds = new int[][] { new int[] { },
								 new int[] {68,67,68,69,128+ (Main.setting.HellBackStyle > 0 ? Main.setting.HellBackStyle  -1:0) },
								 new int[] {70,71,68,72,128+ (Main.setting.HellBackStyle > 0 ? Main.setting.HellBackStyle  -1:0)},
								 new int[] {73,74,75,75,131+ (Main.setting.HellBackStyle > 0 ? Main.setting.HellBackStyle  -1:0)},
								 new int[] {77,78,79,80,134 + (Main.setting.HellBackStyle > 0 ? Main.setting.HellBackStyle  -1:0)},
								 new int[] {77,81,79,82,134 + (Main.setting.HellBackStyle > 0 ? Main.setting.HellBackStyle  -1:0)},
								 new int[] { 83,84,85,86,137+ (Main.setting.HellBackStyle > 0 ? Main.setting.HellBackStyle  -1:0)},
								 new int[] { 83,87,88,89,137+ (Main.setting.HellBackStyle > 0 ? Main.setting.HellBackStyle  -1:0)},
								 new int[] {121,122,123,124,140+ (Main.setting.HellBackStyle > 0 ? Main.setting.HellBackStyle  -1:0)},
								};
						if (main.lastSelectedMenu == 4)
							PreviewDrawAll(main, backgrounds[Main.setting.CaveBackStyle1]);
						if (main.lastSelectedMenu == 5)
							PreviewDrawAll(main, backgrounds[Main.setting.CaveBackStyle2]);
						if (main.lastSelectedMenu == 6)
							PreviewDrawAll(main, backgrounds[Main.setting.CaveBackStyle3]);
						if (main.lastSelectedMenu == 7)
							PreviewDrawAll(main, backgrounds[Main.setting.CaveBackStyle4]);
					}
				}
			}
			else if (Main.menuMode == (int)MenuModes.Miscellaneous)
			{
				GenericMenu(main, MiscellaneousMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Settings)
			{
				num = 100;
				GenericMenu(main, SettingsMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
				//num3 = 35;
			}
			else if (Main.menuMode == (int)MenuModes.ResetAllSettings)
			{
				clickableLabelText[0] = TCText("AreYouSureResetAllSettings");
				array[0] = true;
				array4[1] = 20;
				array4[2] = 20;
				clickableLabelText[1] = Lang.menu[4].Value;
				clickableLabelText[2] = Lang.menu[6].Value;
				numberClickableLabels = 4;
				// click accept
				if (main.selectedMenu == 1)
				{
					Setting.initializeAll();
					Main.menuMode = (int)MenuModes.Settings;
				}
				// click cancel
				if (main.selectedMenu == 2)
				{
					Main.menuMode = (int)MenuModes.Settings;
				}
			}
			else if (Main.menuMode == (int)MenuModes.GraphicStyles)
			{
				Main.dayTime = false;
				defaultLabelSpacing = 30;
				numberClickableLabels = 12;
				for (int num47 = 0; num47 < numberClickableLabels; num47++)
				{
					clickableLabelScale[num47] = 0.73f;
				}
				int num48 = 0;
				clickableLabelText[num48] = ResetMenu(TCText("GraphicStyles"));
				if (main.selectedMenu == 0)
				{
					Setting.initializeGraphic();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -17;
				num48++;
				if (Main.setting.MoonStyle == 0)
				{
					clickableLabelText[num48] = TCText("MoonStyle") + ": 1";
				}
				else if (Main.setting.MoonStyle == 1)
				{
					clickableLabelText[num48] = TCText("MoonStyle") + ": 2";
				}
				else if (Main.setting.MoonStyle == 2)
				{
					clickableLabelText[num48] = TCText("MoonStyle") + ": 3";
				}
				else if (Main.setting.MoonStyle == 3)
				{
					clickableLabelText[num48] = TCText("MoonStyle") + ": " + Language.GetTextValue("CLI.Random");
				}
				if (main.selectedMenu == num48)
				{
					Main.setting.MoonStyle = (Main.setting.MoonStyle + 1) % 4;
				}
				num48++;
				if (Main.setting.SelectTreeStyle[0] == 6)
				{
					clickableLabelText[num48] = "Tree Style " + (TerraCustomUtils.WorldSize < 2 ? "Left" : "Far Left") + ": " + Language.GetTextValue("CLI.Random");
				}
				else
				{
					clickableLabelText[num48] = "Tree Style " + (TerraCustomUtils.WorldSize < 2 ? "Left" : "Far Left") + ": " + (Main.setting.SelectTreeStyle[0]);
				}
				if (main.selectedMenu == num48)
				{
					if (Main.setting.SelectTreeStyle[0] == 6)
					{
						Main.setting.SelectTreeStyle[0] = 0;
					}
					else
					{
						Main.setting.SelectTreeStyle[0]++;
					}
				}
				num48++;
				if (Main.setting.SelectTreeStyle[1] == 6)
				{
					clickableLabelText[num48] = "Tree Style " + (TerraCustomUtils.WorldSize == 0 ? "Right" : TerraCustomUtils.WorldSize == 1 ? "Middle" : "Left") + ": " + Language.GetTextValue("CLI.Random");
				}
				else
				{
					clickableLabelText[num48] = "Tree Style " + (TerraCustomUtils.WorldSize == 0 ? "Right" : TerraCustomUtils.WorldSize == 1 ? "Middle" : "Left") + ": " + (Main.setting.SelectTreeStyle[1]);
				}
				if (main.selectedMenu == num48)
				{
					if (Main.setting.SelectTreeStyle[1] == 6)
					{
						Main.setting.SelectTreeStyle[1] = 0;
					}
					else
					{
						Main.setting.SelectTreeStyle[1]++;
					}
				}
				num48++;
				if (TerraCustomUtils.WorldSize > 0)
				{
					if (Main.setting.SelectTreeStyle[2] == 6)
					{
						clickableLabelText[num48] = "Tree Style Right: " + Language.GetTextValue("CLI.Random");
					}
					else
					{
						clickableLabelText[num48] = "Tree Style Right: " + (Main.setting.SelectTreeStyle[2]);
					}
					if (main.selectedMenu == num48)
					{
						if (Main.setting.SelectTreeStyle[2] == 6)
						{
							Main.setting.SelectTreeStyle[2] = 0;
						}
						else
						{
							Main.setting.SelectTreeStyle[2]++;
						}
					}
					num48++;
				}
				if (TerraCustomUtils.WorldSize > 1)
				{
					if (Main.setting.SelectTreeStyle[3] == 6)
					{
						clickableLabelText[num48] = "Tree Style Far Right: " + Language.GetTextValue("CLI.Random");
					}
					else
					{
						clickableLabelText[num48] = "Tree Style Far Right: " + (Main.setting.SelectTreeStyle[3]);
					}
					if (main.selectedMenu == num48)
					{
						if (Main.setting.SelectTreeStyle[3] == 6)
						{
							Main.setting.SelectTreeStyle[3] = 0;
						}
						else
						{
							Main.setting.SelectTreeStyle[3]++;
						}
					}
					num48++;
				}
				if (Main.setting.SelectDungeon == 0)
				{
					clickableLabelText[num48] = "Dungeon Color: Blue";
				}
				else if (Main.setting.SelectDungeon == 1)
				{
					clickableLabelText[num48] = "Dungeon Color: Green";
				}
				else if (Main.setting.SelectDungeon == 2)
				{
					clickableLabelText[num48] = "Dungeon Color: Pink";
				}
				else if (Main.setting.SelectDungeon == 3)
				{
					clickableLabelText[num48] = "Dungeon Color: " + Language.GetTextValue("CLI.Random");
				}
				if (main.selectedMenu == num48)
				{
					if (Main.setting.SelectDungeon == 3)
					{
						Main.setting.SelectDungeon = 0;
					}
					else
					{
						Main.setting.SelectDungeon++;
					}
				}
				num48++;
				string[] array22 = new string[]
				{
						"Green",
						"Yellow",
						"Red",
						"Blue",
						"Purple"
				};
				if (Main.setting.SelectMossType[0] == 5)
				{
					clickableLabelText[num48] = "Moss Color Left: " + Language.GetTextValue("CLI.Random");
				}
				else
				{
					clickableLabelText[num48] = "Moss Color Left: " + array22[Main.setting.SelectMossType[0]];
				}
				if (main.selectedMenu == num48)
				{
					if (Main.setting.SelectMossType[0] == 5)
					{
						Main.setting.SelectMossType[0] = 0;
					}
					else
					{
						Main.setting.SelectMossType[0]++;
					}
				}
				num48++;
				if (Main.setting.SelectMossType[1] == 5)
				{
					clickableLabelText[num48] = "Moss Color Middle: " + Language.GetTextValue("CLI.Random");
				}
				else
				{
					clickableLabelText[num48] = "Moss Color Middle: " + array22[Main.setting.SelectMossType[1]];
				}
				if (main.selectedMenu == num48)
				{
					if (Main.setting.SelectMossType[1] == 5)
					{
						Main.setting.SelectMossType[1] = 0;
					}
					else
					{
						Main.setting.SelectMossType[1]++;
					}
				}
				num48++;
				if (Main.setting.SelectMossType[2] == 5)
				{
					clickableLabelText[num48] = "Moss Color Right: " + Language.GetTextValue("CLI.Random");
				}
				else
				{
					clickableLabelText[num48] = "Moss Color Right: " + array22[Main.setting.SelectMossType[2]];
				}
				if (main.selectedMenu == num48)
				{
					if (Main.setting.SelectMossType[2] == 5)
					{
						Main.setting.SelectMossType[2] = 0;
					}
					else
					{
						Main.setting.SelectMossType[2]++;
					}
				}
				num48++;
				string[] array23 = new string[]
				{
						"Iridescent Bricks",
						"Mudstone Blocks",
						"Rich Mahogany",
						"Tin Brick",
						"Gold Brick"
				};
				if (Main.setting.ShrineType == 0)
				{
					clickableLabelText[num48] = "Jungle Shrines: " + Language.GetTextValue("CLI.Random");
				}
				else if (Main.setting.ShrineType == 6)
				{
					clickableLabelText[num48] = "Jungle Shrines: Mix";
				}
				else
				{
					clickableLabelText[num48] = "Jungle Shrines: " + array23[Main.setting.ShrineType - 1];
				}
				if (main.selectedMenu == num48)
				{
					if (Main.setting.ShrineType == 6)
					{
						Main.setting.ShrineType = 0;
					}
					else
					{
						Main.setting.ShrineType++;
					}
				}
				num48++;
				array4[num48] = 10;
				clickableLabelText[num48] = Lang.menu[5].Value;
				if (main.selectedMenu == num48)
				{
					main.lastSelectedMenu = -1;
					Main.menuMode = (int)MenuModes.Settings;
				}

				if (main.selectedMenu != -1)
				{
					main.lastSelectedMenu = main.selectedMenu;
				}

				if (main.lastSelectedMenu == 1)
				{
					int moonToDraw = Main.setting.MoonStyle == 3 ? ((int)Main.GlobalTime / 1 % 3) : Main.setting.MoonStyle;
					Main.spriteBatch.Draw(Main.moonTexture[moonToDraw], new Vector2(0, Main.screenHeight - Main.moonTexture[moonToDraw].Height), Color.White);
				}

				if (main.lastSelectedMenu == 2 || main.lastSelectedMenu == 3 || (TerraCustomUtils.WorldSize > 0 && main.lastSelectedMenu == 4) || (TerraCustomUtils.WorldSize > 1 && main.lastSelectedMenu == 5))
				{
					Main.spriteBatch.Draw(Main.TCTreeTops, new Vector2(0, Main.screenHeight - Main.TCTreeTops.Height), Color.White);
				}
				if (TerraCustomUtils.WorldSize == 0)
				{
					if (main.lastSelectedMenu == 5 || main.lastSelectedMenu == 6 || main.lastSelectedMenu == 7)
					{
						Main.spriteBatch.Draw(Main.TCMossColors, new Vector2(0, Main.screenHeight - Main.TCMossColors.Height), Color.White);

					}
				}
				else if (TerraCustomUtils.WorldSize == 1)
				{
					if (main.lastSelectedMenu == 6 || main.lastSelectedMenu == 7 || main.lastSelectedMenu == 8)
					{
						Main.spriteBatch.Draw(Main.TCMossColors, new Vector2(0, Main.screenHeight - Main.TCMossColors.Height), Color.White);

					}
				}
				else
				{
					if (main.lastSelectedMenu == 7 || main.lastSelectedMenu == 8 || main.lastSelectedMenu == 9)
					{
						Main.spriteBatch.Draw(Main.TCMossColors, new Vector2(0, Main.screenHeight - Main.TCMossColors.Height), Color.White);

					}
				}

				if (main.lastSelectedMenu == 4 + TerraCustomUtils.WorldSize)
				{
					Main.spriteBatch.Draw(Main.TCDungeonColors, new Vector2(0, Main.screenHeight - Main.TCDungeonColors.Height), Color.White);
				}
			}
			else if (Main.menuMode == (int)MenuModes.SurfaceBackgrounds /*26*/)
			{
				{
					Main.dayTime = true;
					defaultLabelSpacing = 30;
					numberClickableLabels = 10;
					for (int num49 = 0; num49 < numberClickableLabels; num49++)
					{
						clickableLabelScale[num49] = 0.73f;
					}
					int num50 = 0;
					clickableLabelText[num50] = ResetMenu(TCText("Backgrounds"));
					if (main.selectedMenu == 0)
					{
						Setting.initializeBGs();
					}
					clickableLabelScale[0] = 0.53f;
					array4[0] = -17;
					num50++;
					if (Main.setting.ForestStyle == 14)
					{
						clickableLabelText[num50] = TCText("ForestBackground") + ": " + Language.GetTextValue("CLI.Random");
					}
					else
					{
						// 0 to 13?
						clickableLabelText[num50] = TCText("ForestBackground") + ": " + (Main.setting.ForestStyle + 1);
					}
					if (main.selectedMenu == num50)
					{
						if (Main.setting.ForestStyle == 14)
						{
							Main.setting.ForestStyle = 0;
						}
						else
						{
							Main.setting.ForestStyle++;
						}
						TerraCustomUtils.findBackgrounds(0, Main.setting.ForestStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0]);
						main.LoadBackground(Main.treeBG[1]);
						main.LoadBackground(Main.treeBG[2]);
					}
					if (main.selectedMenu2 == num50)
					{
						if (Main.setting.ForestStyle == 0)
						{
							Main.setting.ForestStyle = 14;
						}
						else
						{
							Main.setting.ForestStyle--;
						}
						TerraCustomUtils.findBackgrounds(0, Main.setting.ForestStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0]);
						main.LoadBackground(Main.treeBG[1]);
						main.LoadBackground(Main.treeBG[2]);
					}
					num50++;
					if (Main.setting.CorruptStyle == 2)
					{
						clickableLabelText[num50] = TCText("CorruptBackground") + ": " + Language.GetTextValue("CLI.Random");
					}
					else
					{
						clickableLabelText[num50] = TCText("CorruptBackground") + ": " + (Main.setting.CorruptStyle + 1);
					}
					if (main.selectedMenu == num50)
					{
						if (Main.setting.CorruptStyle == 2)
						{
							Main.setting.CorruptStyle = 0;
						}
						else
						{
							Main.setting.CorruptStyle++;
						}
						TerraCustomUtils.findBackgrounds(1, Main.setting.CorruptStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.corruptBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.corruptBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.corruptBG[2]);
					}
					if (main.selectedMenu2 == num50)
					{
						if (Main.setting.CorruptStyle == 0)
						{
							Main.setting.CorruptStyle = 2;
						}
						else
						{
							Main.setting.CorruptStyle--;
						}
						TerraCustomUtils.findBackgrounds(1, Main.setting.CorruptStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.corruptBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.corruptBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.corruptBG[2]);
					}
					num50++;
					if (Main.setting.JungleStyle == 2)
					{
						clickableLabelText[num50] = TCText("JungleBackground") + ": " + Language.GetTextValue("CLI.Random");
					}
					else
					{
						clickableLabelText[num50] = TCText("JungleBackground") + ": " + (Main.setting.JungleStyle + 1);
					}
					if (main.selectedMenu == num50)
					{
						if (Main.setting.JungleStyle == 2)
						{
							Main.setting.JungleStyle = 0;
						}
						else
						{
							Main.setting.JungleStyle++;
						}
						TerraCustomUtils.findBackgrounds(2, Main.setting.JungleStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.jungleBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.jungleBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.jungleBG[2]);
					}
					if (main.selectedMenu2 == num50)
					{
						if (Main.setting.JungleStyle == 0)
						{
							Main.setting.JungleStyle = 2;
						}
						else
						{
							Main.setting.JungleStyle--;
						}
						TerraCustomUtils.findBackgrounds(2, Main.setting.JungleStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.jungleBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.jungleBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.jungleBG[2]);
					}
					num50++;
					if (Main.setting.SnowStyle == 11)
					{
						clickableLabelText[num50] = TCText("SnowBackground") + ": " + Language.GetTextValue("CLI.Random");
					}
					else
					{
						clickableLabelText[num50] = TCText("SnowBackground") + ": " + (Main.setting.SnowStyle + 1);
					}
					if (main.selectedMenu == num50)
					{
						if (Main.setting.SnowStyle == 11)
						{
							Main.setting.SnowStyle = 0;
						}
						else
						{
							Main.setting.SnowStyle++;
						}
						TerraCustomUtils.findBackgrounds(3, Main.setting.SnowStyle);
						main.LoadBackground(Main.treeMntBG[0] = Main.snowMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1] = Main.snowMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.snowBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.snowBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.snowBG[2]);
					}
					if (main.selectedMenu2 == num50)
					{
						if (Main.setting.SnowStyle == 0)
						{
							Main.setting.SnowStyle = 11;
						}
						else
						{
							Main.setting.SnowStyle--;
						}
						TerraCustomUtils.findBackgrounds(3, Main.setting.SnowStyle);
						main.LoadBackground(Main.treeMntBG[0] = Main.snowMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1] = Main.snowMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.snowBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.snowBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.snowBG[2]);
					}
					num50++;
					if (Main.setting.HallowStyle == 2)
					{
						clickableLabelText[num50] = TCText("HallowBackground") + ": " + Language.GetTextValue("CLI.Random");
					}
					else
					{
						clickableLabelText[num50] = TCText("HallowBackground") + ": " + (Main.setting.HallowStyle + 1);
					}
					if (main.selectedMenu == num50)
					{
						if (Main.setting.HallowStyle == 2)
						{
							Main.setting.HallowStyle = 0;
						}
						else
						{
							Main.setting.HallowStyle++;
						}
						TerraCustomUtils.findBackgrounds(4, Main.setting.HallowStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.hallowBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.hallowBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.hallowBG[2]);
					}
					if (main.selectedMenu2 == num50)
					{
						if (Main.setting.HallowStyle == 0)
						{
							Main.setting.HallowStyle = 2;
						}
						else
						{
							Main.setting.HallowStyle--;
						}
						TerraCustomUtils.findBackgrounds(4, Main.setting.HallowStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.hallowBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.hallowBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.hallowBG[2]);
					}
					num50++;
					if (Main.setting.CrimsonStyle == 3)
					{
						clickableLabelText[num50] = TCText("CrimsonBackground") + ": " + Language.GetTextValue("CLI.Random");
					}
					else
					{
						clickableLabelText[num50] = TCText("CrimsonBackground") + ": " + (Main.setting.CrimsonStyle + 1);
					}
					if (main.selectedMenu == num50)
					{
						if (Main.setting.CrimsonStyle == 3)
						{
							Main.setting.CrimsonStyle = 0;
						}
						else
						{
							Main.setting.CrimsonStyle++;
						}
						TerraCustomUtils.findBackgrounds(5, Main.setting.CrimsonStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.crimsonBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.crimsonBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.crimsonBG[2]);
					}
					if (main.selectedMenu2 == num50)
					{
						if (Main.setting.CrimsonStyle == 0)
						{
							Main.setting.CrimsonStyle = 3;
						}
						else
						{
							Main.setting.CrimsonStyle--;
						}
						TerraCustomUtils.findBackgrounds(5, Main.setting.CrimsonStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.crimsonBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.crimsonBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.crimsonBG[2]);
					}
					num50++;
					if (Main.setting.DesertStyle == 2)
					{
						clickableLabelText[num50] = TCText("DesertBackground") + ": " + Language.GetTextValue("CLI.Random");
					}
					else
					{
						clickableLabelText[num50] = TCText("DesertBackground") + ": " + (Main.setting.DesertStyle + 1);
					}
					if (main.selectedMenu == num50)
					{
						if (Main.setting.DesertStyle == 2)
						{
							Main.setting.DesertStyle = 0;
						}
						else
						{
							Main.setting.DesertStyle++;
						}
						TerraCustomUtils.findBackgrounds(6, Main.setting.DesertStyle);

						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.desertBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.desertBG[1]);
						main.LoadBackground(Main.treeBG[2] = -1);
					}
					if (main.selectedMenu2 == num50)
					{
						if (Main.setting.DesertStyle == 0)
						{
							Main.setting.DesertStyle = 2;
						}
						else
						{
							Main.setting.DesertStyle--;
						}
						TerraCustomUtils.findBackgrounds(6, Main.setting.DesertStyle);

						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.desertBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.desertBG[1]);
						main.LoadBackground(Main.treeBG[2] = -1);
					}
					num50++;
					if (Main.setting.OceanStyle == 3)
					{
						clickableLabelText[num50] = TCText("OceanBackground") + ": " + Language.GetTextValue("CLI.Random");
					}
					else
					{
						clickableLabelText[num50] = TCText("OceanBackground") + ": " + (Main.setting.OceanStyle + 1);
					}
					if (main.selectedMenu == num50)
					{
						if (Main.setting.OceanStyle == 3)
						{
							Main.setting.OceanStyle = 0;
						}
						else
						{
							Main.setting.OceanStyle++;
						}
						TerraCustomUtils.findBackgrounds(7, Main.setting.OceanStyle);
						main.LoadBackground(Main.treeMntBG[0] = Main.oceanBG);
						main.LoadBackground(Main.treeMntBG[1] = -1);
						main.LoadBackground(Main.treeBG[0] = -1);
						main.LoadBackground(Main.treeBG[1] = -1);
						main.LoadBackground(Main.treeBG[2] = -1);
					}
					if (main.selectedMenu2 == num50)
					{
						if (Main.setting.OceanStyle == 0)
						{
							Main.setting.OceanStyle = 3;
						}
						else
						{
							Main.setting.OceanStyle--;
						}
						TerraCustomUtils.findBackgrounds(7, Main.setting.OceanStyle);
						main.LoadBackground(Main.treeMntBG[0] = Main.oceanBG);
						main.LoadBackground(Main.treeMntBG[1] = -1);
						main.LoadBackground(Main.treeBG[0] = -1);
						main.LoadBackground(Main.treeBG[1] = -1);
						main.LoadBackground(Main.treeBG[2] = -1);
					}
					num50++;
					array4[num50] = 10;
					clickableLabelText[num50] = Lang.menu[5].Value;
					if (main.selectedMenu == num50)
					{
						Main.menuMode = (int)MenuModes.Backgrounds;
					}
				}

				//flag2 = true;
				//num = 240;
				//num3 = 60;
				//num4 = 3;
				//array9[0] = "";
				//array9[1] = Lang.menu[65];
				//array[1] = true;
				//array4[2] = 170;
				//array4[1] = 10;
				//array9[2] = Lang.menu[5];
				//if (main.selectedMenu == 2)
				//{
				//    Main.menuMode = 11;
				//    Main.PlaySound(11, -1, -1, 1);
				//}
			}
			else if (Main.menuMode == (int)MenuModes.OreAmount)
			{
				GenericMenu(main, OreAmountMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.ChooseWorldSize)
			{
				num = 170;
				defaultLabelSpacing = 55;
				array4[1] = 20;
				array4[2] = 20;
				array4[3] = 20;
				array4[4] = 20;
				//array4[5] = 20;
				array4[5] = 20;
				array4[6] = 60;
				clickableLabelText[0] = Lang.menu[91].Value;
				array[0] = true;
				clickableLabelText[1] = Lang.menu[92].Value;
				clickableLabelText[2] = Lang.menu[93].Value;
				clickableLabelText[3] = Lang.menu[94].Value;
				//	clickableLabelText[4] = Lang.menu[5];
				clickableLabelText[4] = TCText("KeepPreviousCustomSize");
				clickableLabelText[5] = TCText("LoadAutosavedConfig");
				clickableLabelText[6] = Lang.menu[15].Value;
				numberClickableLabels = 7;
				if (main.selectedMenu == 6)
				{
					main.QuitGame();
				}
				else if (main.selectedMenu == 5)
				{
					if (Main.settingSaver.settingExists("Autosave-LastUsed"))
					{
						Main.settingSaver.loadSetting("Autosave-LastUsed");
						Main.clrInput();
						Main.menuMode = (int)MenuModes.EnterWorldName;
						WorldGen.setWorldSize();
					}
				}
				else if (main.selectedMenu > 0)
				{
					if (main.selectedMenu == 1)
					{
						Main.maxTilesX = 4200;
						Main.maxTilesY = 1200;
					}
					else if (main.selectedMenu == 2)
					{
						Main.maxTilesX = 6400;
						Main.maxTilesY = 1800;
					}
					else if (main.selectedMenu == 3)
					{
						Main.maxTilesX = 8400;
						Main.maxTilesY = 2400;
					}
					else if (main.selectedMenu == 4)
					{
						if (Main.maxTilesX == 8401)
						{
							Main.maxTilesX = 4200;
							Main.maxTilesY = 1200;
						}
					}
					Main.clrInput();
					Main.menuMode = (int)MenuModes.SelectDifficulty;
					WorldGen.setWorldSize();
				}
			}
			else if (Main.menuMode == (int)MenuModes.SettingsView)
			{
				Main.MenuUI.SetState(settingsViewMenu);
				Main.menuMode = 888;
			}
		}

		private static void GenericMenu(Main main, TerraCustomMenuItem[] foundMenuItems, bool[] array, string[] clickableLabelText, float[] clickableLabelScale, int[] array4, ref int num, ref int defaultLabelSpacing, ref int numberClickableLabels)
		{
			int yPosition = num + 40;
			//int yPosition = 240;
			defaultLabelSpacing = 30; // virtical spacing?

			int labelNumber = 0;
			for (int menuItemIndex = 0; menuItemIndex < foundMenuItems.Length; menuItemIndex++) // TODO skip sliders = 2
			{
				if (foundMenuItems[menuItemIndex].isLabel)
				{
					clickableLabelScale[labelNumber] = foundMenuItems[menuItemIndex].labelScale; //0.73f;
					labelNumber++;
				}
			}

			IngameOptions.rightHover = -1;
			if (!Main.mouseLeft)
			{
				IngameOptions.rightLock = -1;
			}

			int offset = 0;
			int buttonIndex = 0;
			for (int i = 0; i < foundMenuItems.Length; i++)
			{
				foundMenuItems[i].HandleMe(ref clickableLabelText[buttonIndex], main.selectedMenu == buttonIndex, ref yPosition, i);
				foundMenuItems[i].HandleMeAdditional(ref array[buttonIndex]);
				if (foundMenuItems[i].isLabel)
				{
					array4[buttonIndex] = offset + foundMenuItems[i].additionalHorizontalSpacingPre;
					if (foundMenuItems[i].additionalHorizontalSpacingPre > 0)
					{
						offset += foundMenuItems[i].additionalHorizontalSpacingPre; // negative?
					}
					buttonIndex++;
				}
				else
				{
					offset += foundMenuItems[i].Height /* - defaultLabelSpacing*/;
				}
			}
			numberClickableLabels = labelNumber;

			if (IngameOptions.rightHover != -1)
			{
				IngameOptions.rightLock = IngameOptions.rightHover;
			}
		}

		/*
		private static int DrawSliders(int num40, int num41, Color textColor3, string[] labels, float[] ratios, Func<float>[] getters, Action<float>[] setters, Func<float, string>[] estimationString)
		{
			for (int i = 0; i < labels.Length; i++)
			{
				int yPos = num41;
				int xPos = 390 + Main.screenWidth / 2 - 400 - 100;
				// String 1
				yPos += 0 + i * 30;
				num40 = yPos;
				Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, labels[i], (float)xPos, (float)yPos, textColor3, Color.Black, Vector2.Zero, 0.5f);

				// String 2
				xPos += 270;//180;
				Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, estimationString[i](getters[i]()), (float)xPos, (float)yPos, textColor3, Color.Black, Vector2.Zero, 0.5f);

				// Slider
				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 140), (float)(num41 - 18 + 30 + 30 * i));
				float percent = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, getters[i]() / ratios[i]);
				if (IngameOptions.inBar || IngameOptions.rightLock == 6 + i)
				{
					IngameOptions.rightHover = 6 + i;
					if (Main.mouseLeft && IngameOptions.rightLock == 6 + i)
					{
						setters[i](ratios[i] * percent);
					}
				}
			}
			return num40;
		}
		*/

		private static void PreviewDraw(Texture2D texture2D, int position)
		{
			switch (position)
			{
				case 0:
					Main.spriteBatch.Draw(texture2D, new Vector2(0, 0), Color.White);
					break;
				case 1:
					Main.spriteBatch.Draw(texture2D, new Vector2(Main.screenWidth - texture2D.Width, 0), Color.White);
					break;
				case 2:
					Main.spriteBatch.Draw(texture2D, new Vector2(0, Main.screenHeight - texture2D.Height), Color.White);
					break;
				case 3:
					Main.spriteBatch.Draw(texture2D, new Vector2(Main.screenWidth - texture2D.Width, Main.screenHeight - texture2D.Height), Color.White);
					break;
				case 4:
					Main.spriteBatch.Draw(texture2D, new Vector2(0, Main.screenHeight / 2 - texture2D.Height / 2), Color.White);
					break;
				case 5:
					Main.spriteBatch.Draw(texture2D, new Vector2(Main.screenWidth - texture2D.Width, Main.screenHeight / 2 - texture2D.Height / 2), Color.White);
					break;
				default:
					Main.spriteBatch.Draw(texture2D, new Vector2(0, Main.screenHeight - texture2D.Height), Color.White);
					break;
			}

		}
		private static void PreviewDrawAll(Main main, int[] v)
		{
			for (int i = 0; i < v.GetLength(0); i++)
			{
				main.LoadBackground(v[i]);
				PreviewDraw(Main.backgroundTexture[v[i]], i);
			}
		}

		private static string ChestEstimateString()
		{
			int chests = ChestEstimate();

			string retVal = TCText("EsimatedXChests", chests);

			if (chests > 1000)
			{
				retVal += " Failure very likely.";
			}
			else if (chests > 900)
			{
				retVal += " Failure likely.";
			}
			return retVal;
		}

		private static int ChestEstimate()
		{
			int chests = 0;

			// Lihzahrd
			chests += (int)Math.Ceiling(Main.setting.TempleChestMultiplier * 0.35f * 13f * (Main.maxTilesX / 4200f) * Main.setting.TempleSizeMultiplier);

			// Dungeon: Biome
			chests += Main.setting.BiomeChestSets * ((Main.setting.IsCorruption == 3 || Main.setting.IsCorruption == 4) ? 5 : 4);

			// Dungeon: Locked Gold
			chests += (int)(2 + Math.Ceiling((Main.setting.DungeonSizeMultiplier * Main.maxTilesX / 60) * (7f / 6f) * (1f / 5f)));

			// Sky Island Chests
			chests += (int)((double)Main.maxTilesX * 0.0008 * Main.setting.SkyIslandMultiplier);

			// Web Covered -- Spider (Buried?)
			chests += (int)((double)Main.maxTilesX * 0.005 * Main.setting.SpiderCaveMultiplier * (1 / 15f));

			// Surface Chests -- Ice, wood
			chests += (int)((double)Main.maxTilesX * 0.005 * Main.setting.SurfaceChestMultiplier);

			// Water Chests
			chests += (int)Math.Ceiling(Main.setting.WaterChestMultiplier * 2f * 9f * (Main.maxTilesX / 4200f));

			// Pyramid 1 or 2?
			// Ignore For now

			// Living Wood chest....1 maybe. Main.setting.IsGiantTree
			// Ignore for now

			// Ivy -- spawn base of underground trees , also in jungle shrines
			// Underground Trees (aka Living Mahogany Trees)  -- Half of Ivy
			chests += (int)(6f * (Main.maxTilesX / 4200f) * Main.setting.MahoganyTreeMultiplier);
			//(int)Math.Ceiling(Main.setting.JungleShrineMultiplier * 7 * Main.maxTilesX / 4200)
			//(int)Math.Ceiling(Main.setting.JungleShrineMultiplier * 12 * Main.maxTilesX / 4200)
			chests += (int)Math.Ceiling(Main.setting.JungleShrineMultiplier * 9 * Main.maxTilesX / 4200);

			// Shadow
			chests += (int)(6.5f * (Main.maxTilesX / 4200) * Main.setting.ShadowChestMultiplier);

			// Underground Cabin -- All unlocked gold, all Mahogany, Granite, Marble, Mushroom
			chests += Math.Max(0, ((int)(Main.setting.UndergroundCabinMultiplier * 2f * (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f) + (int)((double)(Main.maxTilesX * Main.maxTilesY) * 1.6E-05 * Main.setting.UndergroundCabinMultiplier)) - (int)(6.5f * (Main.maxTilesX / 4200)));

			// until I do the others
			//chests += Main.maxTilesX == 4200 ? 73 : Main.maxTilesX == 6400 ? 117 : 161;

			return chests;
		}
	}
}
