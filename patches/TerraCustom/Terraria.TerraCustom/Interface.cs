using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using Terraria;
using Terraria.IO;

namespace Terraria.TerraCustom
{
	class Interface
	{
		/*
		GenericMenu(main, DownedFoundMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref num3, ref numberClickableLabels);
		
		static TerraCustomMenuItem[] FoundMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Found NPC Settings", WorldGen.initializeFound) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new OptionLabel(),
			new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};
		*/

		static TerraCustomMenuItem[] SettingsMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset All", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.ResetAllSettings; }){ labelScale = 0.53f, additionalHorizontalSpacingPre = -18 },
			new ActionLabel("Terrain", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Terrain; }),
			new ActionLabel("Ores", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Ores; }),
			new ActionLabel("Ore Amount", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.OreAmount; }),
			new ActionLabel("Graphic Styles", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.GraphicStyles; }),
			new ActionLabel("Backgrounds", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Backgrounds; }),
			new ActionLabel("Miscellaneous", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Miscellaneous; }),
			new ActionLabel("Challenge options", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.ChallengeOption; }),
			new ActionLabel("Micro Biomes", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.MicroBiomes; }),
			new ActionLabel("Various Spawns", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.VariousSpawns; }),
			new ActionLabel("Downed Bosses/Found NPCs", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.DownedFound; }),
			new ActionLabel("Chests", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Chests; }),
			new ActionLabel(Lang.menu[5], () => { Main.menuMode = (int)MenuModes.ChooseWorldSize; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 20 }, // Back 
			new ActionLabel(Lang.menu[28], () => {
				Main.menuMode = 10;
				Main.worldName = Main.newWorldName;
				Main.ActiveWorldFileData = WorldFile.CreateMetadata(Main.worldName, false, Main.expertMode);
				WorldGen.CreateNewWorld(null);
			}) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 }, // Generate
		};

		static TerraCustomMenuItem[] DownedFoundMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Downed Bosses", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Downed; }),
			new ActionLabel("Found NPCs", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.Found; }),
			new ActionLabel(Lang.menu[5], () => { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] BackgroundsMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Surface Backgrounds", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.SurfaceBackgrounds; }),
			new ActionLabel("Underground Backgrounds", () => { Main.instance.selectedMenu = -1; Main.menuMode = (int)MenuModes.UndergroundBackgrounds; }),
			new ActionLabel(Lang.menu[5], () => { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] FoundMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Found NPC Settings", WorldGen.initializeFound) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new OptionLabel(new string[] { "Found Stylist: No", "Found Stylist: Yes" }, () => Main.setting.savedStylist ? 1 : 0, x => Main.setting.savedStylist = x > 0 ? true : false),
			new OptionLabel(new string[] { "Found Goblin : No", "Found Goblin : Yes" }, () => Main.setting.savedGoblin? 1 : 0, x => Main.setting.savedGoblin = x > 0 ? true : false),
			new OptionLabel(new string[] { "Found Wizard : No", "Found Wizard : Yes" }, () => Main.setting.savedWizard? 1 : 0, x => Main.setting.savedWizard = x > 0 ? true : false),
			new OptionLabel(new string[] { "Found Mechanic: No", "Found Mechanic: Yes" }, () => Main.setting.savedMechanic? 1 : 0, x => Main.setting.savedMechanic = x > 0 ? true : false),
			new OptionLabel(new string[] { "Found Angler : No", "Found Angler : Yes" }, () => Main.setting.savedAngler? 1 : 0, x => Main.setting.savedAngler = x > 0 ? true : false),
			new OptionLabel(new string[] { "Found Tax Collector: No", "Found Tax Collector: Yes" }, () => Main.setting.savedTaxCollector? 1 : 0, x => Main.setting.savedTaxCollector = x > 0 ? true : false),
			new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.DownedFound; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] DownedMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Found NPC Settings", WorldGen.initializeDowned) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new OptionLabel(new string[] {"Downed Slime King: No", "Downed Slime King: Yes"},() => Main.setting.downedSlimeKing ? 1 : 0, x => Main.setting.downedSlimeKing = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Queen Bee : No", "Downed Queen Bee : Yes"},() => Main.setting.downedQueenBee? 1 : 0,x =>  Main.setting.downedQueenBee = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Eye of Cthulu : No", "Downed Eye of Cthulu : Yes"},() => Main.setting.downedEyeOfCthulu? 1 : 0,x => Main.setting.downedEyeOfCthulu = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Eater of Worlds / Brain of Cthulu: No", "Downed Eater of Worlds / Brain of Cthulu: Yes"},() => Main.setting.downedEaterBrain? 1 : 0,x =>  Main.setting.downedEaterBrain = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Skeletron : No", "Downed Skeletron : Yes"},() => Main.setting.downedSkeletron? 1 : 0,x => Main.setting.downedSkeletron  = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Twins: No", "Downed Twins: Yes"},() => Main.setting.downedTwins? 1 : 0,x => Main.setting.downedTwins = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Destroyer: No", "Downed Destroyer: Yes"},() => Main.setting.downedDestroyer? 1 : 0,x => Main.setting.downedDestroyer = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Skeletron Prime: No", "Downed Skeletron Prime: Yes"},() => Main.setting.downedSkeletronPrime? 1 : 0,x => Main.setting.downedSkeletronPrime = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Plantera: No", "Downed Plantera: Yes"},() => Main.setting.downedPlantera? 1 : 0,x => Main.setting.downedPlantera = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Golem: No", "Downed Golem: Yes"},() => Main.setting.downedGolem? 1 : 0,x => Main.setting.downedGolem = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Fishron : No", "Downed Fishron : Yes"},() => Main.setting.downedFishron? 1 : 0,x => Main.setting.downedFishron = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Lunatic Cultist: No", "Downed Lunatic Cultist: Yes"},() => Main.setting.downedAncientCultist? 1 : 0,x => Main.setting.downedAncientCultist = x > 0 ? true : false),
			new OptionLabel(new string[] {"Downed Moonlord: No", "Downed Moonlord: Yes"},() => Main.setting.downedMoonlord? 1 : 0,x => Main.setting.downedMoonlord = x > 0 ? true : false),
			new ActionLabel(Lang.menu[5], () => { Main.menuMode = (int)MenuModes.DownedFound; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};


		static TerraCustomMenuItem[] ChallengeOptionMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Challenge Settings", WorldGen.initializeChallenge) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new OptionLabel(new string[] {"No tree: Disabled","No tree: Enabled"}, () => Main.setting.NoTree ? 1 : 0, x => Main.setting.NoTree = x > 0 ? true :false),
			new OptionLabel(new string[] {"No dungeon: Disabled","No dungeon: Enabled"}, () => Main.setting.NoDungeon ? 1 : 0, x => Main.setting.NoDungeon = x > 0 ? true :false),
			new OptionLabel(new string[] {"No temple: Disabled","No temple: Enabled"}, () => Main.setting.NoTemple ? 1 : 0, x => Main.setting.NoTemple= x > 0 ? true :false),
			new OptionLabel(new string[] {"No spider cave: Disabled","No spider cave: Enabled"}, () => Main.setting.NoSpiderCave ? 1 : 0, x => Main.setting.NoSpiderCave = x > 0 ? true :false),
			new OptionLabel(new string[] {"No hive: Disabled","No hive: Enabled"}, () => Main.setting.NoHive ? 1 : 0, x => Main.setting.NoHive = x > 0 ? true :false),
			new OptionLabel(new string[] {"No snow: Disabled","No snow: Enabled"}, () => Main.setting.NoSnow ? 1 : 0, x => Main.setting.NoSnow = x > 0 ? true :false),
			new OptionLabel(new string[] {"No jungle: Disabled","No jungle: Enabled"}, () => Main.setting.NoJungle ? 1 : 0, x => Main.setting.NoJungle = x > 0 ? true :false),
			new OptionLabel(new string[] {"No anthill: Disabled","No anthill: Enabled"}, () => Main.setting.NoAnthill ? 1 : 0, x => Main.setting.NoAnthill = x > 0 ? true :false),
			new OptionLabel(new string[] {"No beaches: Disabled","No beaches: Enabled"}, () => Main.setting.NoBeach ? 1 : 0, x => Main.setting.NoBeach = x > 0 ? true :false),
			new OptionLabel(new string[] {"No pot: Disabled","No pot: Enabled"}, () => Main.setting.NoPot ? 1 : 0, x => Main.setting.NoPot = x > 0 ? true :false),
			new OptionLabel(new string[] {"No chest: Disabled","No chest: Enabled"}, () => Main.setting.NoChest ? 1 : 0, x => Main.setting.NoChest = x > 0 ? true :false),
			new OptionLabel(new string[] {"No altar: Disabled","No altar: Enabled"}, () => Main.setting.NoAltar ? 1 : 0, x => Main.setting.NoAltar = x > 0 ? true :false),
			new OptionLabel(new string[] {"No orb/heart: Disabled","No orb/heart: Enabled"}, () => Main.setting.NoOrbHeart ? 1 : 0, x => Main.setting.NoOrbHeart = x > 0 ? true :false),
			new OptionLabel(new string[] {"No underworld: Disabled","No underworld: Enabled"}, () => Main.setting.NoUnderworld ? 1 : 0, x => Main.setting.NoUnderworld = x > 0 ? true :false),
			new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] OresMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Ore Settings", WorldGen.initializeOres) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel("Also check 'Ore Amount' option to get both hardmode ores") {labelScale = 0.6f},
			new OptionLabel(new string[] { "Copper/Tin: Tin", "Copper/Tin: Copper", "Copper/Tin: Random", "Copper/Tin: Both"}, () => Main.setting.IsCopper, x => Main.setting.IsCopper = x),
			new OptionLabel(new string[] { "Iron/Lead: Lead", "Iron/Lead: Iron", "Iron/Lead: Random", "Iron/Lead: Both"}, () => Main.setting.IsIron, x => Main.setting.IsIron = x),
			new OptionLabel(new string[] { "Silver/Tungsten: Tungsten","Silver/Tungsten: Silver","Silver/Tungsten: Random","Silver/Tungsten: Both"}, () => Main.setting.IsSilver, x => Main.setting.IsSilver = x),
			new OptionLabel(new string[] { "Gold/Platinum: Platinum", "Gold/Platinum: Gold","Gold/Platinum: Random","Gold/Platinum: Both"}, () => Main.setting.IsGold, x => Main.setting.IsGold = x),
			new OptionLabel(new string[] { "Cobalt/Palladium: Palladium","Cobalt/Palladium: Cobalt", "Cobalt/Palladium: Random"}, () => Main.setting.IsCobalt, x => Main.setting.IsCobalt = x),
			new OptionLabel(new string[] { "Mythril/Orichalcum: Orichalcum","Mythril/Orichalcum: Mythril","Mythril/Orichalcum: Random"}, () => Main.setting.IsMythril, x => Main.setting.IsMythril = x),
			new OptionLabel(new string[] { "Adamantite/Titanium: Titanium","Adamantite/Titanium: Adamantite","Adamantite/Titanium: Random"}, () => Main.setting.IsAdaman, x => Main.setting.IsAdaman = x),
			new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] MiscellaneousMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Miscellaneous Settings", WorldGen.initializeMiscellaneous) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new OptionLabel(new string[] { "Corruption/Crimson: Random","Corruption/Crimson: Corruption","Corruption/Crimson: Crimson","Corruption/Crimson: Corruption with Crimson chasms","Corruption/Crimson: Crimson with Corruption chasms", "Corruption/Crimson: None"}, () => Main.setting.IsCorruption, x => Main.setting.IsCorruption = x),
			new OptionLabel(new string[] { "Force Corruption/Crimson Avoid Jungle Side: No","Force Corruption/Crimson Avoid Jungle Side: Yes"}, () => Main.setting.CrimsonCorruptionAvoidJungle ? 1 : 0, x => Main.setting.CrimsonCorruptionAvoidJungle = x > 0 ? true : false),
			new OptionLabel(new string[] { "Dungeon Side: Random","Dungeon Side: Left","Dungeon Side: Right"}, () => Main.setting.DungeonSide, x => Main.setting.DungeonSide = x),
			new OptionLabel(new string[] { "Hardmode: No","Hardmode: Yes"}, () => Main.hardMode ? 1 : 0, x => Main.hardMode = x > 0 ? true : false),
			new OptionLabel(new string[] { "Spawn Hardmode stripes (if Hardmode is Yes): No","Spawn Hardmode stripes (if Hardmode is Yes): Yes"}, () => Main.setting.HardmodeStripes ? 1 : 0, x => Main.setting.HardmodeStripes = x > 0 ? true : false),
			new OptionLabel(new string[] { "Pyramids: No","Pyramids: Yes","Pyramids: Random"}, () => Main.setting.IsPyramid, x => Main.setting.IsPyramid = x),
			new OptionLabel(new string[] { "Giant Trees: No","Giant Trees: Yes","Giant Trees: Random" }, () => Main.setting.IsGiantTree, x => Main.setting.IsGiantTree = x),
			new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] VariousSpawnsMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Various Spawns Amounts", WorldGen.initializeVariousSpawnsAmount) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel("setting 100% will generate default amount") {labelScale = 0.6f},
			new SliderItem("Crystal Hearts:",10f,() => Main.setting.CrystalHeartMultiplier, x => Main.setting.CrystalHeartMultiplier = x,x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05 * x)),
			new SliderItem("Pre-Drop Meteor",100f,() => (float)Main.setting.PreDropMeteor,  x => Main.setting.PreDropMeteor = (int)x,x => "Drop " + (int)x + " meteors"),
			new SliderItem("Tree Lower Bound",150f,() => (float)Main.setting.TreeLowerBound,x => Main.setting.TreeLowerBound = ((int)x>Main.setting.TreeUpperBound? Main.setting.TreeUpperBound: (int)x),x => "Between " + (int)x ), // ratio * %
			new SliderItem("Tree Upper Bound",150f,() => (float)Main.setting.TreeUpperBound,x => Main.setting.TreeUpperBound = ((int)x<Main.setting.TreeLowerBound? Main.setting.TreeLowerBound: (int)x),x => " and " + (int)x + " tiles tall"),
			new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.Settings; }) { labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] MicroBiomesMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Micro Biomes Amounts", WorldGen.initializeMicroBiomesAmount) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel("setting 100% will generate default amount of biomes") {labelScale = 0.6f},
			new SliderItem("Enchanted Sword:", 5f, () => Main.setting.EnchantedSwordBiomeMultiplier, x => Main.setting.EnchantedSwordBiomeMultiplier = x,x => Math.Round(x * 100f) + "%" + " -> " + (int)Math.Ceiling((Main.maxTilesX * Main.maxTilesY / 5040000f) * x)),
			new SliderItem("Campsite:", 20f, () => Main.setting.CampsiteBiomeMultiplier, x => Main.setting.CampsiteBiomeMultiplier = x,x => Math.Round(x* 100f) + "% -> " + (int)((float)6 * ((float)(Main.maxTilesX* Main.maxTilesY) / 5040000) * Main.setting.CampsiteBiomeMultiplier) + "-" + (int)((float)11 * ((float)(Main.maxTilesX* Main.maxTilesY) / 5040000) * Main.setting.CampsiteBiomeMultiplier)),
			new SliderItem("ThinIce:", 5f, () => Main.setting.ThinIceBiomeMultiplier, x => Main.setting.ThinIceBiomeMultiplier = x,x => Math.Round(x* 100f) + "% -> " + (int)((float)3 * ((float)(Main.maxTilesX* Main.maxTilesY) / 5040000) * Main.setting.ThinIceBiomeMultiplier) + "-" + (int)((float)5 * ((float)(Main.maxTilesX* Main.maxTilesY) / 5040000) * Main.setting.ThinIceBiomeMultiplier)),
			new SliderItem("Mining Explosive (Detonator):", 50f, () => Main.setting.MiningExplosiveMultiplier, x => Main.setting.MiningExplosiveMultiplier = x, x => "         "+Math.Round(x * 100f) + "%"),
			new SliderItem("Traps (Dart, Explosive, Boulder):", 100f, () => Main.setting.TrapMultiplier, x => Main.setting.TrapMultiplier = x, x => "         "+Math.Round(x * 100f) + "%"),
			new SliderItem("Additional Dart Traps:", 10f, () => Main.setting.AdditionalDartTrapMultiplier, x => Main.setting.AdditionalDartTrapMultiplier = x, x => "     "+Math.Round(x * 100f) + "% -> " + ((int)(0.475 * Main.maxTilesX * 0.05 * Main.setting.TrapMultiplier) + (int)(Main.maxTilesX * 0.05 * Main.setting.AdditionalDartTrapMultiplier))),
			new SliderItem("Additional Boulder Traps:", 10f, () => Main.setting.AdditionalBoulderTrapMultiplier, x => Main.setting.AdditionalBoulderTrapMultiplier = x, x => "     "+Math.Round(x * 100f) + "% -> " + ((int)(0.475 * Main.maxTilesX * 0.05 * Main.setting.TrapMultiplier) + (int)(Main.maxTilesX * 0.05 * Main.setting.AdditionalBoulderTrapMultiplier))),
			new SliderItem("Additional Explosive Traps:", 10f, () => Main.setting.AdditionalExplosiveTrapMultiplier, x => Main.setting.AdditionalExplosiveTrapMultiplier = x, x => "     "+Math.Round(x * 100f) + "% -> " + ((int)(0.05 * Main.maxTilesX * 0.05 * Main.setting.TrapMultiplier) + (int)(Main.maxTilesX * 0.05 * Main.setting.AdditionalExplosiveTrapMultiplier))),
			new SliderItem("Sky Islands:", 10f, () => Main.setting.SkyIslandMultiplier, x => Main.setting.SkyIslandMultiplier = x, x => "~" + Math.Round(x * 100f) + "%"),
			new SliderItem("Minecart Tracks:", 3f, () => Main.setting.MineCartMultiplier, x => Main.setting.MineCartMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(10f * (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f * x)),
			new SliderItem("Gemstones (non-cave):", 100f, () => Main.setting.GemMultiplier, x => Main.setting.GemMultiplier = x, x => Math.Round((double)(x * 100f)) + "%"),
			new SliderItem("Gemstone Caves:", 10f, () => Main.setting.GemCaveMultiplier, x => Main.setting.GemCaveMultiplier = x, x => Math.Round((double)(x * 100f)) + "%"),
			new SliderItem("Gemstone Cave Size:", 10f, () => Main.setting.GemCaveSizeMultiplier, x => Main.setting.GemCaveSizeMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(300*x) +" tiles"),
			new SliderItem("Spider Caves:", 5f, () => Main.setting.SpiderCaveMultiplier, x => Main.setting.SpiderCaveMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + "~"+(int)(Main.maxTilesX * 0.005 * x)),
			new SliderItem("Granite Caves:", 10f, () => Main.setting.GraniteCaveMultiplier, x => Main.setting.GraniteCaveMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(8 * (Main.maxTilesX / 4200f) * x) + "-" + (int)(13 * (Main.maxTilesX / 4200f) * x)),
			new SliderItem("Marble Caves:", 10f, () => Main.setting.MarbleCaveMultiplier, x => Main.setting.MarbleCaveMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(10 * ((Main.maxTilesX * Main.maxTilesY) / 5040000f) * x) + "-" + (int)(14 * ((Main.maxTilesX * Main.maxTilesY) / 5040000f) *x)),
			new SliderItem("Underground Cabins:", 10f, () => Main.setting.UndergroundCabinMultiplier, x => Main.setting.UndergroundCabinMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + " -> " + ((int)(Main.setting.UndergroundCabinMultiplier * 2f * (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f)+(int)((double)(Main.maxTilesX * Main.maxTilesY) * 1.6E-05 * Main.setting.UndergroundCabinMultiplier)) + " " + (((int)(Main.setting.UndergroundCabinMultiplier * 2f * (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f)+(int)((double)(Main.maxTilesX * Main.maxTilesY) * 1.6E-05 * Main.setting.UndergroundCabinMultiplier))>800?" Warning: Might Fail, too many chests.":"")),
			new SliderItem("Temple Traps:", 10f, () => Main.setting.TempleTrapMultiplier, x => Main.setting.TempleTrapMultiplier = x, x => Math.Round((double)(x * 100f)) + "%"),
			new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] TerrainMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Terrain", WorldGen.initializeTerrain) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel("set to 100% for default behavior") {labelScale = 0.6f},
			new SliderItem("Surface Height Variance:", 10f,() => Main.setting.SurfaceTerrainHeightMultiplier,x => Main.setting.SurfaceTerrainHeightMultiplier = x, x => Math.Round((double)(x * 100f)) + "%" + (x == 0 ? " Flat" : "")),
			new SliderItem("Surface Upper Limit:",.35f,() => Main.setting.SurfaceTerrainHeightMax - .1f /*.1 to .17*/, x => Main.setting.SurfaceTerrainHeightMax = x + .1f > Main.setting.SurfaceTerrainHeightMin ? Main.setting.SurfaceTerrainHeightMin : x + .1f, x => Math.Round((double)( Main.setting.SurfaceTerrainHeightMax * 100f)) + "%" + " - Low% = High Mountains" + ( Main.setting.SurfaceTerrainHeightMax <.15f?" High Chance of Failure":"")),
			new SliderItem("Surface Lower Limit:",.35f,() => Main.setting.SurfaceTerrainHeightMin - .1f /*.3 to .45?*/, x => Main.setting.SurfaceTerrainHeightMin = x+.1f < Main.setting.SurfaceTerrainHeightMax? Main.setting.SurfaceTerrainHeightMax : x+.1f, x => Math.Round((double)( Main.setting.SurfaceTerrainHeightMin * 100f)) + "%" + " - High% = Deep Valleys" + ( Main.setting.SurfaceTerrainHeightMin <.15f?" Low Chance of Sky Islands":"")),
			new SliderItem("Dungeon Size",10f,() => Main.setting.DungeonSizeMultiplier- .01f, x => Main.setting.DungeonSizeMultiplier = x + .05f /*set called with 0 to 1.0f * ratio*/, x => Math.Round((double)(Main.setting.DungeonSizeMultiplier * 100f)) + "%" + " -> " + "~"+(2+(int)(x * Main.maxTilesX / 60)) + "-" + (int)(2+(int)(Main.setting.DungeonSizeMultiplier * Main.maxTilesX / 60)+(int)((Main.setting.DungeonSizeMultiplier * Main.maxTilesX / 60) / 3f)) + " rooms/hallways"),
			new SliderItem("Temple Size",4f,() => Main.setting.TempleSizeMultiplier- .2f, x => Main.setting.TempleSizeMultiplier = x + .2f, x => Math.Round((double)(Main.setting.TempleSizeMultiplier * 100f)) + "%" + (Main.setting.TempleSizeMultiplier>3?" Warning: Might Fail":"")),
			new SliderItem("Surface Tunnels", 50f,() => Main.setting.SurfaceHorizontalTunnelsMultiplier, x => Main.setting.SurfaceHorizontalTunnelsMultiplier = x, x => Math.Round(Main.setting.SurfaceHorizontalTunnelsMultiplier * 100f) + "%"),
			new SliderItem("Lakes",20f,() => Main.setting.LakeMultiplier, x => Main.setting.LakeMultiplier = x, x => Math.Round((double)(Main.setting.LakeMultiplier * 100f)) + "%" + " -> " + " between 2 and " + (int)((double)Main.maxTilesX * 0.005 * Main.setting.LakeMultiplier - 1)),
			new SliderItem("World Width", 16800f ,() => Main.maxTilesX, x => Main.maxTilesX = (int)x, x => x +" tiles wide"),
			new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] ChestsMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Chests", WorldGen.initializeChests) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 },
			new PlainLabel("set to 100% for default behavior") {labelScale = 0.6f},
			new SliderItem("Biome Chest Sets:",10f,() => Main.setting.BiomeChestSets,   x => Main.setting.BiomeChestSets = (int) x,x => x + " sets"),
			new SliderItem("Pots:", 2.5f, () => Main.setting.PotsMultiplier, x => Main.setting.PotsMultiplier = x, x => Math.Round((double)(Main.setting.PotsMultiplier * 100f)) + "%" + " -> " + (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0008 * Main.setting.PotsMultiplier) + " pots"),
			new SliderItem("Jungle Shrines:", 5f, () => Main.setting.JungleShrineMultiplier, x => Main.setting.JungleShrineMultiplier = x, x => Math.Round((double)(Main.setting.JungleShrineMultiplier * 100f)) + "%" + " -> " + (int)Math.Ceiling(Main.setting.JungleShrineMultiplier*7*Main.maxTilesX / 4200)+ "-" + (int)Math.Ceiling(Main.setting.JungleShrineMultiplier*12*Main.maxTilesX / 4200)+" shrines"),
			new SliderItem("Living Mahogany Trees:", 2f, () => Main.setting.MahoganyTreeMultiplier, x => Main.setting.MahoganyTreeMultiplier = x, x => Math.Round((double)(Main.setting.MahoganyTreeMultiplier * 100f)) + "%" + " -> ~" + (int)(6 * (Main.maxTilesX / 4200f) * Main.setting.MahoganyTreeMultiplier)+ "-" +(int)(11 * (Main.maxTilesX / 4200f) * Main.setting.MahoganyTreeMultiplier)+ " trees"),
			new SliderItem("Water Chests:", 5f, () => Main.setting.WaterChestMultiplier, x => Main.setting.WaterChestMultiplier = x, x => Math.Round((double)(Main.setting.WaterChestMultiplier * 100f)) + "%" + " -> " + (int)Math.Ceiling(Main.setting.WaterChestMultiplier * 2f * 9f* (Main.maxTilesX / 4200f))+ " chests"),
			new SliderItem("Surface Chests:", 5f, () => Main.setting.SurfaceChestMultiplier, x => Main.setting.SurfaceChestMultiplier = x, x => Math.Round((double)(Main.setting.SurfaceChestMultiplier * 100f)) + "%" + " -> " + (int)((double)Main.maxTilesX * 0.005 * Main.setting.SurfaceChestMultiplier) + " chests"),
			new SliderItem("Temple Chests:", 5f, () => Main.setting.TempleChestMultiplier, x => Main.setting.TempleChestMultiplier = x, x => Math.Round((double)(Main.setting.TempleChestMultiplier * 100f)) + "%" + " -> " +(int)Math.Ceiling(Main.setting.TempleChestMultiplier * 0.35f * 13f * (Main.maxTilesX / 4200f) * Main.setting.TempleSizeMultiplier *.85f) + "-" + (int)Math.Ceiling(Main.setting.TempleChestMultiplier * 0.35f * 13f * (Main.maxTilesX / 4200f) * Main.setting.TempleSizeMultiplier * 1.15f) + " chests"),
			new SliderItem(Main.setting.ShadowChestMultiplierDelegate.label /*"Shadow Chests:"*/, Main.setting.ShadowChestMultiplierDelegate.ratio/*5f*/, Main.setting.ShadowChestMultiplierDelegate.getter, Main.setting.ShadowChestMultiplierDelegate.setter, Main.setting.ShadowChestMultiplierDelegate.estimationString),
			new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

		static TerraCustomMenuItem[] OreAmountMenuItems = new TerraCustomMenuItem[] {
			new ActionLabel("Reset Ore Amount", WorldGen.initializeOreAmount) { labelScale = 0.53f, additionalHorizontalSpacingPre = -5 }, // -17
			new PlainLabel("setting 100% will generate default amount of ores") {labelScale = 0.6f},
			new SliderItem("Copper/Tin:",5f,() => Main.setting.PercCopp, x => Main.setting.PercCopp = x, x => Math.Round((double)(Main.setting.PercCopp * 100f)) + "%"),
			new SliderItem("Iron/Lead:",5f,() => Main.setting.PercIron, x => Main.setting.PercIron = x, x => Math.Round((double)(Main.setting.PercIron * 100f)) + "%"),
			new SliderItem("Silver/Tungsten:",5f,() => Main.setting.PercSilv, x => Main.setting.PercSilv = x, x => Math.Round((double)(Main.setting.PercSilv * 100f)) + "%"),
			new SliderItem("Gold/Platinum:",5f,() => Main.setting.PercGold, x => Main.setting.PercGold = x, x => Math.Round((double)(Main.setting.PercGold * 100f)) + "%"),
			new SliderItem("Demonite/Crimtane:",5f,() => Main.setting.PercDemonite, x => Main.setting.PercDemonite = x, x => Math.Round((double)(Main.setting.PercDemonite * 100f)) + "%"),
			new SliderItem("Hellstone:",5f,() => Main.setting.PercHellstone, x => Main.setting.PercHellstone= x, x => Math.Round((double)(Main.setting.PercHellstone * 100f)) + "%"),
			new PlainLabel("Option to generate alternate hardmode ores in the beginning") {labelScale = 0.6f, additionalHorizontalSpacingPre = 10},
			new SliderItem("",1f,() => Main.setting.PreSmashAltar, x => Main.setting.PreSmashAltar= x, x => {
				if (Main.setting.PreSmashAltar > 0f && (double)Main.setting.PreSmashAltar < 0.3)
				{
					return "Generate a little";
				}
				else if ((double)Main.setting.PreSmashAltar >= 0.3 && (double)Main.setting.PreSmashAltar < 0.7)
				{
					return "Generate medium amount";
				}
				else if ((double)Main.setting.PreSmashAltar >= 0.7)
				{
					return "Generate a lot";
				}
				else
				{
					return "Generate none";
				}
			}) { secondStringOnly = true},
			new SliderItem("",0,() => 0f, x=> { }, x => "(Same amount as smashing " + Math.Round((double)(Main.setting.PreSmashAltar * 50f)) + " altars)") { secondStringOnly = true, noSlider = true},
			new OptionLabel(new string[] { "PreSmash Altars generates both sets of ores : Disabled", "PreSmash Altars generates both sets of ores : Enabled" }, () => Main.setting.PreSmashAltarOreAlternates? 1 : 0, x => Main.setting.PreSmashAltarOreAlternates = x > 0 ? true : false),
			new OptionLabel(new string[] { "PreSmash Altars prevent random Corruption/Crimson/Hallow patch spawn : Disabled",  "PreSmash Altars prevent random Corruption/Crimson/Hallow patch spawn : Enabled"}, () => Main.setting.PreSmashAltarPreventPatches? 1 : 0, x => Main.setting.PreSmashAltarPreventPatches = x > 0 ? true : false),
			new ActionLabel(Lang.menu[5], ()=> { Main.menuMode = (int)MenuModes.Settings; }){ labelScale = 0.93f, additionalHorizontalSpacingPre = 10 },
		};

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
			else if (Main.menuMode == (int)MenuModes.VariousSpawns)
			{
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
			else if (Main.menuMode == (int)MenuModes.MicroBiomes)
			{
				GenericMenu(main, MicroBiomesMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Backgrounds)
			{
				GenericMenu(main, BackgroundsMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.Ores)
			{
				GenericMenu(main, OresMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.ChallengeOption)
			{
				GenericMenu(main, ChallengeOptionMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
			}
			else if (Main.menuMode == (int)MenuModes.UndergroundBackgrounds)
			{
				{
					string[][] optionStrings = { };
					if (WorldGen.worldSize == 0)
					{
						optionStrings = new string[][]
						{
							new string[] { "Ice Background: Random", "Ice Background: 1", "Ice Background: 2", "Ice Background: 3", "Ice Background: 4"},
							new string[] { "Hell Background: Random", "Hell Background: 1", "Hell Background: 2", "Hell Background: 3"},
							new string[] { "Jungle Background: Random", "Jungle Background: 1", "Jungle Background: 2"},
							new string[] { "Cave Background Left: Random", "Cave Background Left: 1", "Cave Background Left: 2", "Cave Background Left: 3", "Cave Background Left: 4", "Cave Background Left: 5", "Cave Background Left: 6", "Cave Background Left: 7", "Cave Background Left: 8"},
							new string[] { "Cave Background Right: Random", "Cave Background Right: 1", "Cave Background Right: 2", "Cave Background Right: 3", "Cave Background Right: 4", "Cave Background Right: 5", "Cave Background Right: 6", "Cave Background Right: 7", "Cave Background Right: 8"},
						};
					}
					if (WorldGen.worldSize == 1)
					{
						optionStrings = new string[][]
						{
							new string[] { "Ice Background: Random", "Ice Background: 1", "Ice Background: 2", "Ice Background: 3", "Ice Background: 4"},
							new string[] { "Hell Background: Random", "Hell Background: 1", "Hell Background: 2", "Hell Background: 3"},
							new string[] { "Jungle Background: Random", "Jungle Background: 1", "Jungle Background: 2"},
							new string[] { "Cave Background Left: Random", "Cave Background Left: 1", "Cave Background Left: 2", "Cave Background Left: 3", "Cave Background Left: 4", "Cave Background Left: 5", "Cave Background Left: 6", "Cave Background Left: 7", "Cave Background Left: 8"},
							new string[] { "Cave Background Middle: Random", "Cave Background Middle: 1", "Cave Background Middle: 2", "Cave Background Middle: 3", "Cave Background Middle: 4", "Cave Background Middle: 5", "Cave Background Middle: 6", "Cave Background Middle: 7", "Cave Background Middle: 8" },
							new string[] { "Cave Background Right: Random", "Cave Background Right: 1", "Cave Background Right: 2", "Cave Background Right: 3", "Cave Background Right: 4", "Cave Background Right: 5", "Cave Background Right: 6", "Cave Background Right: 7", "Cave Background Right: 8"},
						};
					}
					if (WorldGen.worldSize == 2)
					{
						optionStrings = new string[][]
						{
							new string[] { "Ice Background: Random", "Ice Background: 1", "Ice Background: 2", "Ice Background: 3", "Ice Background: 4"},
							new string[] { "Hell Background: Random", "Hell Background: 1", "Hell Background: 2", "Hell Background: 3"},
							new string[] { "Jungle Background: Random", "Jungle Background: 1", "Jungle Background: 2"},
							new string[] { "Cave Background Far Left: Random", "Cave Background Far Left: 1", "Cave Background Far Left: 2", "Cave Background Far Left: 3", "Cave Background Far Left: 4", "Cave Background Far Left: 5", "Cave Background Far Left: 6", "Cave Background Far Left: 7", "Cave Background Far Left: 8"},
							new string[] { "Cave Background Left: Random", "Cave Background Left: 1", "Cave Background Left: 2", "Cave Background Left: 3", "Cave Background Left: 4", "Cave Background Left: 5", "Cave Background Left: 6", "Cave Background Left: 7", "Cave Background Left: 8"},
							new string[] { "Cave Background Right: Random", "Cave Background Right: 1", "Cave Background Right: 2", "Cave Background Right: 3", "Cave Background Right: 4", "Cave Background Right: 5", "Cave Background Right: 6", "Cave Background Right: 7", "Cave Background Right: 8"},
							new string[] { "Cave Background Far Right: Random", "Cave Background Far Right: 1", "Cave Background Far Right: 2", "Cave Background Far Right: 3", "Cave Background Far Right: 4", "Cave Background Far Right: 5", "Cave Background Far Right: 6", "Cave Background Far Right: 7", "Cave Background Far Right: 8"},
						};
					}

					defaultLabelSpacing = 30; // virtical spacing?
					numberClickableLabels = 2 + optionStrings.GetLength(0); // = to reset + back + # options
					for (int num21 = 0; num21 < numberClickableLabels; num21++)
					{
						clickableLabelScale[num21] = 0.73f;
					}
					int buttonIndex = 0;
					clickableLabelText[buttonIndex] = "Reset Underground Background Settings";
					if (main.selectedMenu == 0)
					{
						WorldGen.initializeUGBGs();
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
					clickableLabelText[buttonIndex] = Lang.menu[5];
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
					if (main.lastSelectedMenu >= 4 && main.lastSelectedMenu <= 5 + WorldGen.worldSize)
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
				GenericMenu(main, SettingsMenuItems, array, clickableLabelText, clickableLabelScale, array4, ref num, ref defaultLabelSpacing, ref numberClickableLabels);
				//num3 = 35;
			}
			else if (Main.menuMode == (int)MenuModes.ResetAllSettings)
			{
				clickableLabelText[0] = "Are you sure you will reset all the settings?";
				array[0] = true;
				array4[1] = 20;
				array4[2] = 20;
				clickableLabelText[1] = Lang.menu[4];
				clickableLabelText[2] = Lang.menu[6];
				numberClickableLabels = 4;
				// click accept
				if (main.selectedMenu == 1)
				{
					WorldGen.initializeAll();
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
				clickableLabelText[num48] = "Reset Graphic Styles";
				if (main.selectedMenu == 0)
				{
					WorldGen.initializeGraphic();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -17;
				num48++;
				if (Main.setting.MoonStyle == 0)
				{
					clickableLabelText[num48] = "Moon Style: 1";
				}
				else if (Main.setting.MoonStyle == 1)
				{
					clickableLabelText[num48] = "Moon Style: 2";
				}
				else if (Main.setting.MoonStyle == 2)
				{
					clickableLabelText[num48] = "Moon Style: 3";
				}
				else if (Main.setting.MoonStyle == 3)
				{
					clickableLabelText[num48] = "Moon Style: Random";
				}
				if (main.selectedMenu == num48)
				{
					if (Main.setting.MoonStyle == 0)
					{
						Main.setting.MoonStyle = 1;
						Main.moonType = Main.setting.MoonStyle;
					}
					else if (Main.setting.MoonStyle == 1)
					{
						Main.setting.MoonStyle = 2;
						Main.moonType = Main.setting.MoonStyle;
					}
					else if (Main.setting.MoonStyle == 2)
					{
						Main.setting.MoonStyle = 3;
					}
					else if (Main.setting.MoonStyle == 3)
					{
						Main.setting.MoonStyle = 0;
						Main.moonType = Main.setting.MoonStyle;
					}
				}
				num48++;
				if (Main.setting.SelectTreeStyle[0] == 6)
				{
					clickableLabelText[num48] = "Tree Style " + (WorldGen.worldSize < 2 ? "Left" : "Far Left") + ":  Random";
				}
				else
				{
					clickableLabelText[num48] = "Tree Style " + (WorldGen.worldSize < 2 ? "Left" : "Far Left") + ": " + (Main.setting.SelectTreeStyle[0]);
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
					clickableLabelText[num48] = "Tree Style " + (WorldGen.worldSize == 0 ? "Right" : WorldGen.worldSize == 1 ? "Middle" : "Left") + ":  Random";
				}
				else
				{
					clickableLabelText[num48] = "Tree Style " + (WorldGen.worldSize == 0 ? "Right" : WorldGen.worldSize == 1 ? "Middle" : "Left") + ": " + (Main.setting.SelectTreeStyle[1]);
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
				if (WorldGen.worldSize > 0)
				{
					if (Main.setting.SelectTreeStyle[2] == 6)
					{
						clickableLabelText[num48] = "Tree Style Right:  Random";
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
				if (WorldGen.worldSize > 1)
				{
					if (Main.setting.SelectTreeStyle[3] == 6)
					{
						clickableLabelText[num48] = "Tree Style Far Right:  Random";
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
					clickableLabelText[num48] = "Dungeon Color: Random";
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
					clickableLabelText[num48] = "Moss Color Left: Random";
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
					clickableLabelText[num48] = "Moss Color Middle: Random";
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
					clickableLabelText[num48] = "Moss Color Right: Random";
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
					clickableLabelText[num48] = "Jungle Shrines: Random";
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
				clickableLabelText[num48] = Lang.menu[5];
				if (main.selectedMenu == num48)
				{
					main.lastSelectedMenu = -1;
					Main.menuMode = (int)MenuModes.Settings /*11*/;
				}

				if (main.selectedMenu != -1)
				{
					main.lastSelectedMenu = main.selectedMenu;
				}

				if (main.lastSelectedMenu == 1)
				{
					Main.spriteBatch.Draw(Main.moonTexture[Main.moonType], new Vector2(0, Main.screenHeight - Main.moonTexture[Main.moonType].Height), Color.White);
				}

				if (main.lastSelectedMenu == 2 || main.lastSelectedMenu == 3 || (WorldGen.worldSize > 0 && main.lastSelectedMenu == 4) || (WorldGen.worldSize > 1 && main.lastSelectedMenu == 5))
				{
					Main.spriteBatch.Draw(Main.TCTreeTops, new Vector2(0, Main.screenHeight - Main.TCTreeTops.Height), Color.White);
				}
				if (WorldGen.worldSize == 0)
				{
					if (main.lastSelectedMenu == 5 || main.lastSelectedMenu == 6 || main.lastSelectedMenu == 7)
					{
						Main.spriteBatch.Draw(Main.TCMossColors, new Vector2(0, Main.screenHeight - Main.TCMossColors.Height), Color.White);

					}
				}
				else if (WorldGen.worldSize == 1)
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

				if (main.lastSelectedMenu == 4 + WorldGen.worldSize)
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
					clickableLabelText[num50] = "Reset Background Settings";
					if (main.selectedMenu == 0)
					{
						WorldGen.initializeBGs();
					}
					clickableLabelScale[0] = 0.53f;
					array4[0] = -17;
					num50++;
					if (Main.setting.ForestStyle == 14)
					{
						clickableLabelText[num50] = "Forest Background: Random";
					}
					else
					{
						// 0 to 13?
						clickableLabelText[num50] = "Forest Background: " + (Main.setting.ForestStyle + 1);
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
						WorldGen.findBackgrounds(0, Main.setting.ForestStyle);
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
						WorldGen.findBackgrounds(0, Main.setting.ForestStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0]);
						main.LoadBackground(Main.treeBG[1]);
						main.LoadBackground(Main.treeBG[2]);
					}
					num50++;
					if (Main.setting.CorruptStyle == 2)
					{
						clickableLabelText[num50] = "Corrupt Background: Random";
					}
					else
					{
						clickableLabelText[num50] = "Corrupt Background: " + (Main.setting.CorruptStyle + 1);
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
						WorldGen.findBackgrounds(1, Main.setting.CorruptStyle);
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
						WorldGen.findBackgrounds(1, Main.setting.CorruptStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.corruptBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.corruptBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.corruptBG[2]);
					}
					num50++;
					if (Main.setting.JungleStyle == 2)
					{
						clickableLabelText[num50] = "Jungle Background: Random";
					}
					else
					{
						clickableLabelText[num50] = "Jungle Background: " + (Main.setting.JungleStyle + 1);
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
						WorldGen.findBackgrounds(2, Main.setting.JungleStyle);
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
						WorldGen.findBackgrounds(2, Main.setting.JungleStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.jungleBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.jungleBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.jungleBG[2]);
					}
					num50++;
					if (Main.setting.SnowStyle == 11)
					{
						clickableLabelText[num50] = "Snow Background: Random";
					}
					else
					{
						clickableLabelText[num50] = "Snow Background: " + (Main.setting.SnowStyle + 1);
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
						WorldGen.findBackgrounds(3, Main.setting.SnowStyle);
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
						WorldGen.findBackgrounds(3, Main.setting.SnowStyle);
						main.LoadBackground(Main.treeMntBG[0] = Main.snowMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1] = Main.snowMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.snowBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.snowBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.snowBG[2]);
					}
					num50++;
					if (Main.setting.HallowStyle == 2)
					{
						clickableLabelText[num50] = "Hallow Background: Random";
					}
					else
					{
						clickableLabelText[num50] = "Hallow Background: " + (Main.setting.HallowStyle + 1);
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
						WorldGen.findBackgrounds(4, Main.setting.HallowStyle);
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
						WorldGen.findBackgrounds(4, Main.setting.HallowStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.hallowBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.hallowBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.hallowBG[2]);
					}
					num50++;
					if (Main.setting.CrimsonStyle == 3)
					{
						clickableLabelText[num50] = "Crimson Background: Random";
					}
					else
					{
						clickableLabelText[num50] = "Crimson Background: " + (Main.setting.CrimsonStyle + 1);
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
						WorldGen.findBackgrounds(5, Main.setting.CrimsonStyle);
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
						WorldGen.findBackgrounds(5, Main.setting.CrimsonStyle);
						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.crimsonBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.crimsonBG[1]);
						main.LoadBackground(Main.treeBG[2] = Main.crimsonBG[2]);
					}
					num50++;
					if (Main.setting.DesertStyle == 2)
					{
						clickableLabelText[num50] = "Desert Background: Random";
					}
					else
					{
						clickableLabelText[num50] = "Desert Background: " + (Main.setting.DesertStyle + 1);
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
						WorldGen.findBackgrounds(6, Main.setting.DesertStyle);

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
						WorldGen.findBackgrounds(6, Main.setting.DesertStyle);

						main.LoadBackground(Main.treeMntBG[0]);
						main.LoadBackground(Main.treeMntBG[1]);
						main.LoadBackground(Main.treeBG[0] = Main.desertBG[0]);
						main.LoadBackground(Main.treeBG[1] = Main.desertBG[1]);
						main.LoadBackground(Main.treeBG[2] = -1);
					}
					num50++;
					if (Main.setting.OceanStyle == 3)
					{
						clickableLabelText[num50] = "Ocean Background: Random";
					}
					else
					{
						clickableLabelText[num50] = "Ocean Background: " + (Main.setting.OceanStyle + 1);
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
						WorldGen.findBackgrounds(7, Main.setting.OceanStyle);
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
						WorldGen.findBackgrounds(7, Main.setting.OceanStyle);
						main.LoadBackground(Main.treeMntBG[0] = Main.oceanBG);
						main.LoadBackground(Main.treeMntBG[1] = -1);
						main.LoadBackground(Main.treeBG[0] = -1);
						main.LoadBackground(Main.treeBG[1] = -1);
						main.LoadBackground(Main.treeBG[2] = -1);
					}
					num50++;
					array4[num50] = 10;
					clickableLabelText[num50] = Lang.menu[5];
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
		}

		private static void GenericMenu(Main main, TerraCustomMenuItem[] foundMenuItems, bool[] array, string[] clickableLabelText, float[] clickableLabelScale, int[] array4, ref int num, ref int defaultLabelSpacing, ref int numberClickableLabels)
		{
			int yPosition = 240;
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

			string retVal = "Estimated " + chests + " chests.";

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
	}
}
