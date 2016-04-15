using Microsoft.Xna.Framework;
using System;
using System.Xml.Serialization;
using Terraria.TerraCustom;
using System.Runtime.Serialization;

namespace Terraria
{
	[DataContract]
	public class Setting
	{
		[OnDeserializing]
		public void Hi(StreamingContext context)
		{
			Main.setting = this;
			WorldGen.initializeAll();
		}

		[DataMember]
		public bool generateLeveledRPGSave { get; internal set; } = false;

		[DataMember]
		public bool LeveledRPGCriticalMode { get; internal set; } = false;

		[DataMember]
		public float PreSmashAltar { get; internal set; }

		[DataMember]
		public bool PreSmashAltarOreAlternates { get; internal set; } = false;

		[DataMember]
		public bool PreSmashAltarPreventPatches { get; internal set; } = true;

		[DataMember]
		private float percSnow = 0.2f;
		[DataMember]
		private float percJungle = 0.2f;
		[DataMember]
		private float multiGemCave = 0.05f;
		[DataMember]
		private int[] selectTreeStyle = new int[]
		{
			6,
			6,
			6,
			6
		};
		[DataMember]
		private int[] selectMossType = new int[]
		{
			5,
			5,
			5
		};
		[DataMember]
		private int selectDungeon = 3;
		[DataMember]
		private int shrineType;
		[DataMember]
		public int IsCopper { get; internal set; } = 2;
		[DataMember]
		public int IsIron { get; internal set; } = 2;
		[DataMember]
		public int IsSilver { get; internal set; } = 2;
		[DataMember]
		public int IsGold { get; internal set; } = 2;
		[DataMember]
		public int IsCobalt { get; internal set; } = 2;
		[DataMember]
		public int IsMythril { get; internal set; } = 2;
		[DataMember]
		public int IsAdaman { get; internal set; } = 2;

		[DataMember]
		public int IsCorruption { get; internal set; } = 0;
		[DataMember]
		public int IsPyramid { get; internal set; } = 2;
		[DataMember]
		public int IsGiantTree { get; internal set; } = 2;
		[DataMember]
		public int MoonStyle { get; internal set; } = 3;
		[DataMember]
		public int DungeonStyle { get; internal set; } = 2;
		[DataMember]
		public int ForestStyle { get; internal set; } = 14;
		[DataMember]
		public int CorruptStyle { get; internal set; } = 2;
		[DataMember]
		public int JungleStyle { get; internal set; } = 2;
		[DataMember]
		public int SnowStyle { get; internal set; } = 11;
		[DataMember]
		public int HallowStyle { get; internal set; } = 2;
		[DataMember]
		public int CrimsonStyle { get; internal set; } = 3;
		[DataMember]
		public int DesertStyle { get; internal set; } = 2;
		[DataMember]
		public int OceanStyle { get; internal set; } = 3;
		[DataMember]
		public bool NoTree { get; internal set; }
		[DataMember]
		public bool NoDungeon { get; internal set; }
		[DataMember]
		public bool NoTemple { get; internal set; }
		[DataMember]
		public bool NoSnow { get; internal set; }
		[DataMember]
		public bool NoJungle { get; internal set; }
		[DataMember]
		public int MossColor1 { get; internal set; } = 5;
		[DataMember]
		public int MossColor2 { get; internal set; } = 5;
		[DataMember]
		public int MossColor3 { get; internal set; } = 5;
		[DataMember]
		public float PercCopp { get; internal set; } = 1f;
		[DataMember]
		public float PercIron { get; internal set; } = 1f;
		[DataMember]
		public float PercSilv { get; internal set; } = 1f;
		[DataMember]
		public float PercGold { get; internal set; } = 1f;
		[DataMember]
		public float PercDemonite { get; internal set; } = 1f;
		[DataMember]
		public float PercHellstone { get; internal set; } = 1f;
		[DataMember]
		public float PercSnow
		{
			get
			{
				return this.percSnow;
			}
			set
			{
				this.percSnow = value;
			}
		}
		[DataMember]
		public float PercJungle
		{
			get
			{
				return this.percJungle;
			}
			set
			{
				this.percJungle = value;
			}
		}
		[DataMember]
		public float MultiGemCave
		{
			get
			{
				return this.multiGemCave;
			}
			set
			{
				this.multiGemCave = value;
			}
		}
		[DataMember]
		public int[] SelectTreeStyle
		{
			get
			{
				return this.selectTreeStyle;
			}
			set
			{
				this.selectTreeStyle = value;
			}
		}
		[DataMember]
		public int[] SelectMossType
		{
			get
			{
				return this.selectMossType;
			}
			set
			{
				this.selectMossType = value;
			}
		}
		[DataMember]
		public int SelectDungeon
		{
			get
			{
				return this.selectDungeon;
			}
			set
			{
				this.selectDungeon = value;
			}
		}
		[DataMember]
		public bool NoSpiderCave { get; internal set; }
		[DataMember]
		public bool NoHive { get; internal set; }
		[DataMember]
		public bool NoPot { get; internal set; }
		[DataMember]
		public bool NoChest { get; internal set; }
		[DataMember]
		public bool NoAltar { get; internal set; }
		[DataMember]
		public bool NoOrbHeart { get; internal set; }
		[DataMember]
		public int ShrineType
		{
			get
			{
				return this.shrineType;
			}
			set
			{
				this.shrineType = value;
			}
		}
		[DataMember]
		public float EnchantedSwordBiomeMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float ThinIceBiomeMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float CampsiteBiomeMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float MushroomBiomeMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float MiningExplosiveMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float TrapMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float AdditionalDartTrapMultiplier { get; internal set; } = 0f;
		//[DataMember(EmitDefaultValue = false)]
		[DataMember]
		public float AdditionalBoulderTrapMultiplier { get; internal set; } = 0f;
		[DataMember]
		public float AdditionalExplosiveTrapMultiplier { get; internal set; } = 0f;
		[DataMember]
		public bool NoUnderworld { get; internal set; } = false;
		[DataMember]
		public float SkyIslandMultiplier { get; internal set; } = 1f;
		[DataMember]
		public int DungeonSide { get; internal set; } = 0;
		[DataMember]
		public bool CrimsonCorruptionAvoidJungle { get; internal set; } = false;
		[DataMember]
		public bool NoAnthill { get; internal set; }
		[DataMember]
		public bool NoBeach { get; internal set; }
		[DataMember]
		public bool downedSlimeKing { get; internal set; }
		[DataMember]
		public bool downedQueenBee { get; internal set; }
		[DataMember]
		public bool downedEyeOfCthulu { get; internal set; }
		[DataMember]
		public bool downedEaterBrain { get; internal set; }
		[DataMember]
		public bool downedSkeletron { get; internal set; }
		[DataMember]
		public bool downedTwins { get; internal set; }
		[DataMember]
		public bool downedDestroyer { get; internal set; }
		[DataMember]
		public bool downedSkeletronPrime { get; internal set; }
		[DataMember]
		public bool downedPlantera { get; internal set; }
		[DataMember]
		public bool downedGolem { get; internal set; }
		[DataMember]
		public bool downedFishron { get; internal set; }
		[DataMember]
		public bool downedAncientCultist { get; internal set; }
		[DataMember]
		public bool downedMoonlord { get; internal set; }
		[DataMember]
		public bool savedStylist { get; internal set; }
		[DataMember]
		public bool savedGoblin { get; internal set; }
		[DataMember]
		public bool savedWizard { get; internal set; }
		[DataMember]
		public bool savedMechanic { get; internal set; }
		[DataMember]
		public bool savedAngler { get; internal set; }
		[DataMember]
		public bool savedTaxCollector { get; internal set; }
		[DataMember]
		public float MineCartMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float GemMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float GemCaveMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float GemCaveSizeMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float HiveMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float SpiderCaveMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float GraniteCaveMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float MarbleCaveMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float CrystalHeartMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float StatueMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float SurfaceTerrainHeightMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float SurfaceTerrainHeightMax { get; internal set; } = .17f;
		[DataMember]
		public float SurfaceTerrainHeightMin { get; internal set; } = .3f;
		[DataMember]
		public float DungeonSizeMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float BeachSizeMultiplier { get; internal set; } = 1f;
		[DataMember]
		public int PreDropMeteor { get; internal set; } = 0;
		[DataMember]
		public float UndergroundCabinMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float TempleTrapMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float TempleSizeMultiplier { get; internal set; } = 1f;
		[DataMember]
		public int IceBackStyle { get; internal set; } = 0;
		[DataMember]
		public int HellBackStyle { get; internal set; } = 0;
		[DataMember]
		public int JungleBackStyle { get; internal set; } = 0;
		[DataMember]
		public int CaveBackStyle1 { get; internal set; } = 0;
		[DataMember]
		public int CaveBackStyle2 { get; internal set; } = 0;
		[DataMember]
		public int CaveBackStyle3 { get; internal set; } = 0;
		[DataMember]
		public int CaveBackStyle4 { get; internal set; } = 0;
		[DataMember]
		public int TreeLowerBound { get; internal set; } = 5;
		[DataMember]
		public int TreeUpperBound { get; internal set; } = 5;
		[DataMember]
		public float SurfaceHorizontalTunnelsMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float LakeMultiplier { get; internal set; } = 1f;
		[DataMember]
		public int BiomeChestSets { get; internal set; } = 1;
		[DataMember]
		public float JungleShrineMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float PotsMultiplier { get; internal set; } = 1f;
		[DataMember]
		public bool HardmodeStripes { get; internal set; } = true;
		[DataMember]
		public float MahoganyTreeMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float WaterChestMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float SurfaceChestMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float TempleChestMultiplier { get; internal set; } = 1f;
		[DataMember]
		public float ShadowChestMultiplier { get; internal set; } = 1f;

		[NonSerialized]
		public SettingDelegate ShadowChestMultiplierDelegate = new SettingDelegate(
			                                                       "Shadow Chests:", 
			                                                       5f, 
			                                                       () => Main.setting.ShadowChestMultiplier, 
			                                                       x => Main.setting.ShadowChestMultiplier = x, 
			                                                       x => Math.Round((double)(Main.setting.ShadowChestMultiplier * 100f)) + "%" + " -> " + (int)(5f * (Main.maxTilesX / 4200) * Main.setting.ShadowChestMultiplier) + "-" + (int)(8f * (Main.maxTilesX / 4200) * Main.setting.ShadowChestMultiplier) + " chests"
		                                                       );
		//public int NumberGenerationPassSteps { get; internal set; } = 95;
		[DataMember]
		public bool GenerateWldEachStep { get; internal set; } = false;
		[DataMember]
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
			yPosition += Height + (additionalHorizontalSpacingPre >0 ? additionalHorizontalSpacingPre : 0);
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
				if(IngameOptions.inBar && Interface.keyboardSliderAdjustment != 0)
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
			if(stringFunction == null)
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
