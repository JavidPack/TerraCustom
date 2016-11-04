using Microsoft.Xna.Framework;
using System;
using System.Xml.Serialization;
using Terraria.TerraCustom;
using System.Runtime.Serialization;
using System.ComponentModel;
using Newtonsoft.Json;
using Terraria.ModLoader;

namespace Terraria.TerraCustom
{
	//[DataContract]
	//[JsonObject(MemberSerialization = MemberSerialization.OptOut)]
	public class Setting
	{
		public static void initializeAll()
		{
			initializeTerrain();
			initializeOres();
			initializeOreAmount();
			initializeGraphic();
			initializeBGs();
			initializeUGBGs();
			initializeMiscellaneous();
			initializeChallenge();
			//initializeBiomeAmount();
			initializeVariousSpawnsAmount();
			initializeMicroBiomesAmount();
			initializeTrapsAmount();
			initializeDowned();
			initializeFound();
			initializeChests();
			initializeDebug();
		}

		public static void initializeTerrain()
		{
			Main.setting.SurfaceTerrainHeightMultiplier = 1f;
			Main.setting.SurfaceTerrainHeightMax = .17f;
			Main.setting.SurfaceTerrainHeightMin = .3f;
			Main.setting.BypassSpawnAreaFlatness = false;
			Main.setting.BeachSizeMultiplier = 1f;
			Main.setting.DungeonSizeMultiplier = 1f;
			Main.setting.TempleSizeMultiplier = 1f;
			Main.setting.SurfaceHorizontalTunnelsMultiplier = 1f;
			Main.setting.LakeMultiplier = 1f;
			// Reset tile width/height
			if (WorldGen.worldSize == 0)
			{
				Main.maxTilesX = 4200;
				Main.maxTilesY = 1200;
			}
			else if (WorldGen.worldSize == 1)
			{
				Main.maxTilesX = 6400;
				Main.maxTilesY = 1800;
			}
			else if (WorldGen.worldSize == 2)
			{
				Main.maxTilesX = 8400;
				Main.maxTilesY = 2400;
			}
		}

		public static void initializeOres()
		{
			Main.setting.IsCopper = 2;
			Main.setting.IsIron = 2;
			Main.setting.IsSilver = 2;
			Main.setting.IsGold = 2;
			Main.setting.IsCobalt = 2;
			Main.setting.IsMythril = 2;
			Main.setting.IsAdaman = 2;
		}

		public static void initializeOreAmount()
		{
			Main.setting.PercIron = 1f;
			Main.setting.PercCopp = 1f;
			Main.setting.PercSilv = 1f;
			Main.setting.PercGold = 1f;
			Main.setting.PercDemonite = 1f;
			Main.setting.PercHellstone = 1f;
			Main.setting.PreSmashAltar = 0f;
			Main.setting.PreSmashAltarOreAlternates = false;
			Main.setting.PreSmashAltarPreventPatches = true;
		}

		public static void initializeMicroBiomesAmount()
		{
			Main.setting.EnchantedSwordBiomeMultiplier = 1f;
			Main.setting.ThinIceBiomeMultiplier = 1f;
			Main.setting.CampsiteBiomeMultiplier = 1f;
			Main.setting.SkyIslandMultiplier = 1f;
			Main.setting.MineCartMultiplier = 1f;
			Main.setting.GemMultiplier = 1f;
			Main.setting.GemCaveMultiplier = 1f;
			Main.setting.GemCaveSizeMultiplier = 1f;
			Main.setting.HiveMultiplier = 1f;
			Main.setting.SpiderCaveMultiplier = 1f;
			Main.setting.GraniteCaveMultiplier = 1f;
			Main.setting.MarbleCaveMultiplier = 1f;
			Main.setting.UndergroundCabinMultiplier = 1f;
		}

		public static void initializeTrapsAmount()
		{
			Main.setting.MiningExplosiveMultiplier = 1f;
			Main.setting.TrapMultiplier = 1f;
			Main.setting.AdditionalDartTrapMultiplier = 0f;
			Main.setting.AdditionalBoulderTrapMultiplier = 0f;
			Main.setting.AdditionalExplosiveTrapMultiplier = 0f;
			Main.setting.AdditionalGeyserTrapMultiplier = 0f;
			Main.setting.TempleTrapMultiplier = 1f;
		}

		public static void initializeVariousSpawnsAmount()
		{
			Main.setting.CrystalHeartMultiplier = 1f;
			Main.setting.StatueMultiplier = 1f;
			//Main.setting.AltarMultiplier = 1f;
			Main.setting.PreDropMeteor = 0;
			Main.setting.TreeLowerBound = 5;
			Main.setting.TreeUpperBound = 16;
			Main.setting.MushroomBiomeMultiplier = 1f;
		}

		public static void initializeChallenge()
		{
			Main.setting.NoTree = false;
			Main.setting.NoDungeon = false;
			Main.setting.NoTemple = false;
			Main.setting.NoSpiderCave = false;
			Main.setting.NoHive = false;
			Main.setting.NoSnow = false;
			Main.setting.NoJungle = false;
			Main.setting.NoAnthill = false;
			Main.setting.NoBeach = false;
			Main.setting.NoChest = false;
			Main.setting.NoPot = false;
			Main.setting.NoAltar = false;
			Main.setting.NoOrbHeart = false;
		}

		public static void initializeGraphic()
		{
			Main.setting.MoonStyle = 3;
			Main.setting.SelectDungeon = 3;
			Main.setting.SelectMossType = new int[]
			{
				5,
				5,
				5
			};
			Main.setting.SelectTreeStyle = new int[]
			{
				6,
				6,
				6,
				6
			};
			Main.setting.ShrineType = 0;
		}

		public static void initializeMiscellaneous()
		{
			Main.setting.IsCorruption = 0;
			Main.setting.CrimsonCorruptionAvoidJungle = false;
			Main.setting.CrimsonCorruptionAvoidEachOther = false;
			Main.setting.CrimsonMultiplier = 1f;
			Main.setting.CorruptionMultiplier = 1f;
			Main.setting.DungeonSide = 0;
			Main.setting.IsPyramid = 2;
			Main.setting.IsGiantTree = 2;
			Main.hardMode = false;
			Main.setting.HardmodeStripes = true;
			Main.setting.ForceEnchantedSwordShrineReal = false; // Useful Regular Expression for Search: WorldGen.PlaceTile\([^,]+,[^,]+,\s187
		}

		public static void initializeBGs()
		{
			Main.setting.ForestStyle = 14;
			Main.setting.CorruptStyle = 2;
			Main.setting.JungleStyle = 2;
			Main.setting.SnowStyle = 11;
			Main.setting.HallowStyle = 2;
			Main.setting.CrimsonStyle = 3;
			Main.setting.DesertStyle = 2;
			Main.setting.OceanStyle = 3;
		}

		public static void initializeChests()
		{
			Main.setting.BiomeChestSets = 1;
			Main.setting.PotsMultiplier = 1f;
			Main.setting.JungleShrineMultiplier = 1f;
			Main.setting.MahoganyTreeMultiplier = 1f;
			Main.setting.WaterChestMultiplier = 1f;
			Main.setting.SurfaceChestMultiplier = 1f;
			Main.setting.TempleChestMultiplier = 1f;
			Main.setting.ShadowChestMultiplier = 1f;
		}

		public static void initializeUGBGs()
		{
			Main.setting.IceBackStyle = 0;
			Main.setting.HellBackStyle = 0;
			Main.setting.JungleBackStyle = 0;
			Main.setting.CaveBackStyle1 = 0;
			Main.setting.CaveBackStyle2 = 0;
			Main.setting.CaveBackStyle3 = 0;
			Main.setting.CaveBackStyle4 = 0;
		}

		public static void initializeDowned()
		{
			Main.setting.downedPlantera = false;
			Main.setting.downedEyeOfCthulu = false;
			Main.setting.downedEaterBrain = false;
			Main.setting.downedSkeletron = false;
			Main.setting.downedQueenBee = false;
			Main.setting.downedSlimeKing = false;
			Main.setting.downedTwins = false;
			Main.setting.downedDestroyer = false;
			Main.setting.downedSkeletronPrime = false;
			Main.setting.downedFishron = false;
			Main.setting.downedGolem = false;
			Main.setting.downedAncientCultist = false;
			Main.setting.downedMoonlord = false;
		}

		public static void initializeFound()
		{
			Main.setting.savedStylist = false;
			Main.setting.savedGoblin = false;
			Main.setting.savedWizard = false;
			Main.setting.savedMechanic = false;
			Main.setting.savedAngler = false;
			Main.setting.savedTaxCollector = false;
		}

		public static void initializeDebug()
		{
			Main.setting.GenerateWldEachStep = false;
			Main.setting.SaveInTModFolder = false;
			Main.setting.generateLeveledRPGSave = false;
			Main.setting.LeveledRPGCriticalMode = false;
		}

		// Hints
		// [JsonIgnoreAttribute] to ignore
		// [DefaultValue(2)] for default
		// [JsonProperty] on all autoproperties since json.net has problems without it. 

		// Properties for non Setting things
		public bool HardMode { get { return Main.hardMode; } set { Main.hardMode = value; } }
		[DefaultValue(4200)]
		public int WorldWidth { get { return Main.maxTilesX; } set { Main.maxTilesX = value; } }
		[DefaultValue(1200)]
		public int WorldHeight { get { return Main.maxTilesY; } set { Main.maxTilesY = value; } }
		public bool ExpertMode { get { return Main.expertMode; } set { Main.expertMode = value; } }

		[JsonProperty]
		public bool generateLeveledRPGSave { get; internal set; }

		[JsonProperty]
		public bool LeveledRPGCriticalMode { get; internal set; }

		[JsonProperty]
		public float PreSmashAltar { get; internal set; }

		[JsonProperty]
		public bool PreSmashAltarOreAlternates { get; internal set; }

		[JsonProperty]
		[DefaultValue(true)]
		public bool PreSmashAltarPreventPatches { get; internal set; } = true;

		[JsonIgnoreAttribute]
		//[DefaultValue(new int[] { 6, 6, 6, 6 })]
		public int[] SelectTreeStyle { get; internal set; } = new int[] { 6, 6, 6, 6 };
		
		[DefaultValue(6)]
		public int SelectTreeStyle0 { get { return SelectTreeStyle[0]; } set { SelectTreeStyle[0] = value; } }
		[DefaultValue(6)]
		public int SelectTreeStyle1 { get { return SelectTreeStyle[1]; } set { SelectTreeStyle[1] = value; } }
		[DefaultValue(6)]
		public int SelectTreeStyle2 { get { return SelectTreeStyle[2]; } set { SelectTreeStyle[2] = value; } }
		[DefaultValue(6)]
		public int SelectTreeStyle3 { get { return SelectTreeStyle[3]; } set { SelectTreeStyle[3] = value; } }

		[JsonIgnoreAttribute]
		//[DefaultValue(new int[] { 5, 5, 5 })]
		public int[] SelectMossType { get; internal set; } = new int[] { 5, 5, 5 };

		[DefaultValue(5)]
		public int SelectMossType0 { get { return SelectMossType[0]; } set { SelectMossType[0] = value; } }
		[DefaultValue(5)]
		public int SelectMossType1 { get { return SelectMossType[1]; } set { SelectMossType[1] = value; } }
		[DefaultValue(5)]
		public int SelectMossType2 { get { return SelectMossType[2]; } set { SelectMossType[2] = value; } }

		[JsonProperty]
		[DefaultValue(2)]
		public int IsCopper { get; internal set; } = 2;

		[JsonProperty]
		[DefaultValue(2)]
		public int IsIron { get; internal set; } = 2;

		[JsonProperty]
		[DefaultValue(2)]
		public int IsSilver { get; internal set; } = 2;

		[JsonProperty]
		[DefaultValue(2)]
		public int IsGold { get; internal set; } = 2;
		
		[JsonProperty]
		[DefaultValue(2)]
		public int IsCobalt { get; internal set; } = 2;
		
		[JsonProperty]
		[DefaultValue(2)]
		public int IsMythril { get; internal set; } = 2;
		
		[JsonProperty]
		[DefaultValue(2)]
		public int IsAdaman { get; internal set; } = 2;
		
		[JsonProperty]
		public int IsCorruption { get; internal set; }
		
		[JsonProperty]
		[DefaultValue(2)]
		public int IsPyramid { get; internal set; } = 2;
		
		[JsonProperty]
		[DefaultValue(2)]
		public int IsGiantTree { get; internal set; } = 2;
		
		[JsonProperty]
		public bool ForceEnchantedSwordShrineReal { get; internal set; }
		
		[JsonProperty]
		//const int defaultMoonStyle = 3; // Should I use this approach?
		[DefaultValue(3)]
		public int MoonStyle { get; internal set; } = 3;
		
		// Not saved, is intermediary storage value
		public int DungeonStyle { get; internal set; } = 2;
		
		[JsonProperty]
		[DefaultValue(14)]
		public int ForestStyle { get; internal set; } = 14;
		
		[JsonProperty]
		[DefaultValue(2)]
		public int CorruptStyle { get; internal set; } = 2;
		
		[JsonProperty]
		[DefaultValue(2)]
		public int JungleStyle { get; internal set; } = 2;
		
		[JsonProperty]
		[DefaultValue(11)]
		public int SnowStyle { get; internal set; } = 11;
		
		[JsonProperty]
		[DefaultValue(2)]
		public int HallowStyle { get; internal set; } = 2;
		
		[JsonProperty]
		[DefaultValue(3)]
		public int CrimsonStyle { get; internal set; } = 3;
		
		[JsonProperty]
		[DefaultValue(2)]
		public int DesertStyle { get; internal set; } = 2;
		
		[JsonProperty]
		[DefaultValue(3)]
		public int OceanStyle { get; internal set; } = 3;
		
		[JsonProperty]
		public bool NoTree { get; internal set; }
		
		[JsonProperty]
		public bool NoDungeon { get; internal set; }
		
		[JsonProperty]
		public bool NoTemple { get; internal set; }
		
		[JsonProperty]
		public bool NoSnow { get; internal set; }
		
		[JsonProperty]
		public bool NoJungle { get; internal set; }
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float PercCopp { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float PercIron { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float PercSilv { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float PercGold { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float PercDemonite { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float PercHellstone { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(3)]
		public int SelectDungeon { get; internal set; } = 3;
		
		[JsonProperty]
		public bool NoSpiderCave { get; internal set; }
		
		[JsonProperty]
		public bool NoHive { get; internal set; }
		
		[JsonProperty]
		public bool NoPot { get; internal set; }
		
		[JsonProperty]
		public bool NoChest { get; internal set; }
		
		[JsonProperty]
		public bool NoAltar { get; internal set; }
		
		[JsonProperty]
		public bool NoOrbHeart { get; internal set; }
		
		[JsonProperty]
		public int ShrineType { get; internal set; }
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float EnchantedSwordBiomeMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float ThinIceBiomeMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float CampsiteBiomeMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float MushroomBiomeMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float MiningExplosiveMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float TrapMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		public float AdditionalDartTrapMultiplier { get; internal set; }

		//[JsonProperty(EmitDefaultValue = false)]
		[JsonProperty]
		public float AdditionalBoulderTrapMultiplier { get; internal set; }
		
		[JsonProperty]
		public float AdditionalExplosiveTrapMultiplier { get; internal set; }
		
		[JsonProperty]
		public float AdditionalGeyserTrapMultiplier { get; internal set; }
		
		[JsonProperty]
		public bool NoUnderworld { get; internal set; } = false;

		[DefaultValue(1f)]
		public float SkyIslandMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		public int DungeonSide { get; internal set; } = 0;
		
		[JsonProperty]
		public bool CrimsonCorruptionAvoidJungle { get; internal set; } = false;
		
		[JsonProperty]
		public bool CrimsonCorruptionAvoidEachOther { get; internal set; } = false;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float CrimsonMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float CorruptionMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		public bool NoAnthill { get; internal set; }
		
		[JsonProperty]
		public bool NoBeach { get; internal set; }
		
		[JsonProperty]
		public bool downedSlimeKing { get; internal set; }
		
		[JsonProperty]
		public bool downedQueenBee { get; internal set; }
		
		[JsonProperty]
		public bool downedEyeOfCthulu { get; internal set; }
		
		[JsonProperty]
		public bool downedEaterBrain { get; internal set; }
		
		[JsonProperty]
		public bool downedSkeletron { get; internal set; }
		
		[JsonProperty]
		public bool downedTwins { get; internal set; }
		
		[JsonProperty]
		public bool downedDestroyer { get; internal set; }
		
		[JsonProperty]
		public bool downedSkeletronPrime { get; internal set; }
		
		[JsonProperty]
		public bool downedPlantera { get; internal set; }
		
		[JsonProperty]
		public bool downedGolem { get; internal set; }
		
		[JsonProperty]
		public bool downedFishron { get; internal set; }
		
		[JsonProperty]
		public bool downedAncientCultist { get; internal set; }
		
		[JsonProperty]
		public bool downedMoonlord { get; internal set; }
		
		[JsonProperty]
		public bool savedStylist { get; internal set; }
		
		[JsonProperty]
		public bool savedGoblin { get; internal set; }
		
		[JsonProperty]
		public bool savedWizard { get; internal set; }
		
		[JsonProperty]
		public bool savedMechanic { get; internal set; }
		
		[JsonProperty]
		public bool savedAngler { get; internal set; }
		
		[JsonProperty]
		public bool savedTaxCollector { get; internal set; }
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float MineCartMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float GemMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float GemCaveMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float GemCaveSizeMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float HiveMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float SpiderCaveMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float GraniteCaveMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float MarbleCaveMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float CrystalHeartMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float StatueMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float SurfaceTerrainHeightMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(.17f)]
		public float SurfaceTerrainHeightMax { get; internal set; } = .17f;
		
		[JsonProperty]
		[DefaultValue(.3f)]
		public float SurfaceTerrainHeightMin { get; internal set; } = .3f;
		
		[JsonProperty]
		public bool BypassSpawnAreaFlatness { get; internal set; }
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float DungeonSizeMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float BeachSizeMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		public int PreDropMeteor { get; internal set; } = 0;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float UndergroundCabinMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float TempleTrapMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float TempleSizeMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		public int IceBackStyle { get; internal set; } = 0;
		
		[JsonProperty]
		public int HellBackStyle { get; internal set; } = 0;
		
		[JsonProperty]
		public int JungleBackStyle { get; internal set; } = 0;
		
		[JsonProperty]
		public int CaveBackStyle1 { get; internal set; } = 0;
		
		[JsonProperty]
		public int CaveBackStyle2 { get; internal set; } = 0;
		
		[JsonProperty]
		public int CaveBackStyle3 { get; internal set; } = 0;
		
		[JsonProperty]
		public int CaveBackStyle4 { get; internal set; } = 0;
		
		[JsonProperty]
		[DefaultValue(5)]
		public int TreeLowerBound { get; internal set; } = 5;

		[JsonProperty]
		[DefaultValue(16)]
		public int TreeUpperBound { get; internal set; } = 16;

		[JsonProperty]
		[DefaultValue(1f)]
		public float SurfaceHorizontalTunnelsMultiplier { get; internal set; } = 1f;

		[JsonProperty]
		[DefaultValue(1f)]
		public float LakeMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1)]
		public int BiomeChestSets { get; internal set; } = 1;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float JungleShrineMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float PotsMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(true)]
		public bool HardmodeStripes { get; internal set; } = true;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float MahoganyTreeMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float WaterChestMultiplier { get; internal set; } = 1f;
		
		[JsonProperty]
		[DefaultValue(1f)]
		public float SurfaceChestMultiplier { get; internal set; } = 1f;

		[JsonProperty]
		[DefaultValue(1f)]
		public float TempleChestMultiplier { get; internal set; } = 1f;

		[JsonProperty]
		[DefaultValue(1f)]
		public float ShadowChestMultiplier { get; internal set; } = 1f;

		[JsonIgnoreAttribute]
		public SettingDelegate ShadowChestMultiplierDelegate = new SettingDelegate(
																   "Shadow Chests:",
																   5f,
																   () => Main.setting.ShadowChestMultiplier,
																   x => Main.setting.ShadowChestMultiplier = x,
																   x => Math.Round((double)(Main.setting.ShadowChestMultiplier * 100f)) + "%" + " -> " + (int)(5f * (Main.maxTilesX / 4200) * Main.setting.ShadowChestMultiplier) + "-" + (int)(8f * (Main.maxTilesX / 4200) * Main.setting.ShadowChestMultiplier) + " chests"
															   );

		//public int NumberGenerationPassSteps { get; internal set; } = 95;

		[JsonProperty]
		public bool GenerateWldEachStep { get; internal set; } = false;

		[JsonProperty]
		public bool SaveInTModFolder { get; internal set; } = false;

		//public float AltarMultiplier { get; internal set; } = 1f;
	}

	public class SettingDelegate
	{
		public string label;
		public float ratio;
		public Func<float> getter;
		public Action<float> setter;
		public Func<float, string> estimationString;

		public SettingDelegate(string label, float ratio, Func<float> getter, Action<float> setter, Func<float, string> estimationString)
		{
			this.label = label;
			this.ratio = ratio;
			this.getter = getter;
			this.setter = setter;
			this.estimationString = estimationString;
		}
	}

	public class TerraCustomMenuItem
	{
		public float labelScale = 1f;
		public bool isLabel = true;
		private int height = 30;
		internal int additionalHorizontalSpacingPre = 0;
		//internal int additionalHorizontalSpacingPost = 0;
		public int Height
		{
			get
			{
				if (isLabel)
				{
					Vector2 origin = Main.fontDeathText.MeasureString("Test");
					origin.X *= 0.5f;
					origin.Y *= 0.5f;
					return (int)(origin.Y * labelScale);
				}
				return this.height;
			}
			set
			{
				this.height = value;
			}
		}

		public virtual void HandleMe(ref string label, bool clicked, ref int yPosition, int index)
		{
			yPosition += Height + (additionalHorizontalSpacingPre > 0 ? additionalHorizontalSpacingPre : 0);
		}

		public virtual void HandleMeAdditional(ref bool isPlainWhiteLabel)
		{
		}

	}
	// Slider Item
	public class SliderItem : TerraCustomMenuItem
	{
		public string label;
		public float ratio;
		public Func<float> getter;
		public Action<float> setter;
		public Func<float, string> estimationString;
		internal bool secondStringOnly = false;
		internal bool noSlider = false;

		public SliderItem(string label, float ratio, Func<float> getter, Action<float> setter, Func<float, string> estimationString)
		{
			isLabel = false;
			this.label = label;
			this.ratio = ratio;
			this.getter = getter;
			this.setter = setter;
			this.estimationString = estimationString;
		}

		public override void HandleMe(ref string label, bool clicked, ref int yPosition, int index)
		{
			int yPos = yPosition;
			base.HandleMe(ref label, clicked, ref yPosition, index);
			int xPos = 390 + Main.screenWidth / 2 - 400 - 100;
			// String 1
			Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, this.label, (float)xPos, (float)yPos, Interface.color, Color.Black, Vector2.Zero, 0.5f);
			// String 2
			xPos += 270;//180;
			if (secondStringOnly)
			{
				xPos -= 270;
			}
			Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, estimationString(getter()), (float)xPos, (float)yPos, Interface.color, Color.Black, Vector2.Zero, 0.5f);
			// Slider
			if (!noSlider)
			{
				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 140), (float)(yPos + 12)); // line up correctly
				float percent = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, getter() / ratio);
				if (IngameOptions.inBar || IngameOptions.rightLock == index)
				{
					IngameOptions.rightHover = index;
					if (Main.mouseLeft && IngameOptions.rightLock == index)
					{
						setter(ratio * percent);
					}
				}
				if (IngameOptions.inBar && Interface.keyboardSliderAdjustment != 0)
				{
					float newPercent = (getter() / ratio + (.001f * Interface.keyboardSliderAdjustment));
					newPercent = Math.Min(Math.Max(0f, newPercent), 1f);
					setter(ratio * newPercent);
				}
			}
		}
	}

	public class PlainLabel : TerraCustomMenuItem
	{
		private Func<string> stringFunction;
		string label;

		public PlainLabel(Func<string> stringFunction)
		{
			this.stringFunction = stringFunction;
		}

		public PlainLabel(string label)
		{
			this.label = label;
		}

		public override void HandleMe(ref string label, bool clicked, ref int yPosition, int index)
		{
			base.HandleMe(ref label, clicked, ref yPosition, index);
			if (stringFunction == null)
			{
				label = this.label;
			}
			else
			{
				label = stringFunction();
			}
		}

		public override void HandleMeAdditional(ref bool isPlainWhiteLabel)
		{
			isPlainWhiteLabel = true;
		}
	}
	// Button Item
	public class ActionLabel : TerraCustomMenuItem
	{
		private Action action;
		private string label;

		public ActionLabel(string label, Action action)
		{
			this.label = label;
			this.action = action;
			labelScale = 0.73f;
		}

		public override void HandleMe(ref string label, bool clicked, ref int yPosition, int index)
		{
			base.HandleMe(ref label, clicked, ref yPosition, index);
			label = this.label;
			if (clicked)
			{
				action();
			}
		}
	}
	// Label Item
	public class OptionLabel : TerraCustomMenuItem
	{
		private Func<int> getter;
		private Action<int> setter;
		private string[] optionStrings;

		public OptionLabel(string[] v, Func<int> getter, Action<int> setter)
		{
			this.optionStrings = v;
			this.getter = getter;
			this.setter = setter;
			labelScale = 0.73f;
		}

		public override void HandleMe(ref string label, bool clicked, ref int yPosition, int index)
		{
			base.HandleMe(ref label, clicked, ref yPosition, index);
			label = optionStrings[getter()];
			if (clicked)
			{
				setter((getter() + 1) % optionStrings.Length);
			}
		}
	}
}


// Gets the attributes for the property.
// AttributeCollection attributes = 
//    TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;

/* Prints the default value by retrieving the DefaultValueAttribute 
 * from the AttributeCollection. */
//DefaultValueAttribute myAttribute = 
//    (DefaultValueAttribute)attributes[typeof(DefaultValueAttribute)];
// Console.WriteLine("The default value is: " + myAttribute.Value.ToString());
