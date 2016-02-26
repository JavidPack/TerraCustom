using Microsoft.Xna.Framework;
using System;
using Terraria.TerraCustom;

namespace Terraria
{
	public class Setting
	{
		public float PreSmashAltar { get; internal set; }

		public bool PreSmashAltarOreAlternates { get; internal set; } = false;

		private float percSnow = 0.2f;
		private float percJungle = 0.2f;
		private float multiGemCave = 0.05f;
		private int[] selectTreeStyle = new int[]
		{
			6,
			6,
			6,
			6
		};
		private int[] selectMossType = new int[]
		{
			5,
			5,
			5
		};
		private int selectDungeon = 3;
		private int shrineType;

		public int IsCopper { get; internal set; } = 2;

		public int IsIron { get; internal set; } = 2;

		public int IsSilver { get; internal set; } = 2;

		public int IsGold { get; internal set; } = 2;

		public int IsCobalt { get; internal set; } = 2;

		public int IsMythril { get; internal set; } = 2;

		public int IsAdaman { get; internal set; } = 2;

		public int IsCorruption { get; internal set; } = 0;

		public int IsPyramid { get; internal set; } = 2;

		public int IsGiantTree { get; internal set; } = 2;

		public int MoonStyle { get; internal set; } = 3;

		public int DungeonStyle { get; internal set; } = 2;

		public int ForestStyle { get; internal set; } = 14;

		public int CorruptStyle { get; internal set; } = 2;

		public int JungleStyle { get; internal set; } = 2;

		public int SnowStyle { get; internal set; } = 11;

		public int HallowStyle { get; internal set; } = 2;

		public int CrimsonStyle { get; internal set; } = 3;

		public int DesertStyle { get; internal set; } = 2;

		public int OceanStyle { get; internal set; } = 3;

		public bool NoTree { get; internal set; }

		public bool NoDungeon { get; internal set; }

		public bool NoTemple { get; internal set; }

		public bool NoSnow { get; internal set; }

		public bool NoJungle { get; internal set; }

		public int MossColor1 { get; internal set; } = 5;

		public int MossColor2 { get; internal set; } = 5;

		public int MossColor3 { get; internal set; } = 5;

		public float PercCopp { get; internal set; } = 1f;

		public float PercIron { get; internal set; } = 1f;

		public float PercSilv { get; internal set; } = 1f;

		public float PercGold { get; internal set; } = 1f;

		public float PercDemonite { get; internal set; } = 1f;

		public float PercHellstone { get; internal set; } = 1f;

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

		public bool NoSpiderCave { get; internal set; }

		public bool NoHive { get; internal set; }

		public bool NoPot { get; internal set; }

		public bool NoChest { get; internal set; }

		public bool NoAltar { get; internal set; }

		public bool NoOrbHeart { get; internal set; }

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

		public float EnchantedSwordBiomeMultiplier { get; internal set; } = 1f;

		public float MiningExplosiveMultiplier { get; internal set; } = 1f;

		public float TrapMultiplier { get; internal set; } = 1f;

		public bool NoUnderworld { get; internal set; } = false;

		public float SkyIslandMultiplier { get; internal set; } = 1f;

		public int DungeonSide { get; internal set; } = 0;

		public bool CrimsonCorruptionAvoidJungle { get; internal set; } = false;

		public bool NoAnthill { get; internal set; }

		public bool NoBeach { get; internal set; }
		//public bool NoAnthill { get; internal set; }
		public bool downedSlimeKing { get; internal set; }

		public bool downedQueenBee { get; internal set; }

		public bool downedEyeOfCthulu { get; internal set; }

		public bool downedEaterBrain { get; internal set; }

		public bool downedSkeletron { get; internal set; }

		public bool downedTwins { get; internal set; }

		public bool downedDestroyer { get; internal set; }

		public bool downedSkeletronPrime { get; internal set; }

		public bool downedPlantera { get; internal set; }

		public bool downedGolem { get; internal set; }

		public bool downedFishron { get; internal set; }

		public bool downedAncientCultist { get; internal set; }

		public bool downedMoonlord { get; internal set; }

		public bool savedStylist { get; internal set; }

		public bool savedGoblin { get; internal set; }

		public bool savedWizard { get; internal set; }

		public bool savedMechanic { get; internal set; }

		public bool savedAngler { get; internal set; }

		public bool savedTaxCollector { get; internal set; }

		public float MineCartMultiplier { get; internal set; } = 1f;

		public float GemCaveMultiplier { get; internal set; } = 1f;

		public float GemCaveSizeMultiplier { get; internal set; } = 1f;

		public float SpiderCaveMultiplier { get; internal set; } = 1f;

		public float GraniteCaveMultiplier { get; internal set; } = 1f;

		public float MarbleCaveMultiplier { get; internal set; } = 1f;

		public float CrystalHeartMultiplier { get; internal set; } = 1f;

		public float SurfaceTerrainHeightMultiplier { get; internal set; } = 1f;

		public float SurfaceTerrainHeightMax { get; internal set; } = .17f;

		public float SurfaceTerrainHeightMin { get; internal set; } = .3f;

		public float DungeonSizeMultiplier { get; internal set; } = 1f;

		public int PreDropMeteor { get; internal set; } = 0;

		public float UndergroundCabinMultiplier { get; internal set; } = 1f;

		public float TempleTrapMultiplier { get; internal set; } = 1f;

		public float TempleSizeMultiplier { get; internal set; } = 1f;

		public int IceBackStyle { get; internal set; } = 0;

		public int HellBackStyle { get; internal set; } = 0;

		public int JungleBackStyle { get; internal set; } = 0;

		public int CaveBackStyle1 { get; internal set; } = 0;

		public int CaveBackStyle2 { get; internal set; } = 0;

		public int CaveBackStyle3 { get; internal set; } = 0;

		public int CaveBackStyle4 { get; internal set; } = 0;

		public int TreeLowerBound { get; internal set; } = 5;

		public int TreeUpperBound { get; internal set; } = 5;

		public float SurfaceHorizontalTunnelsMultiplier { get; internal set; } = 1f;

		public float LakeMultiplier { get; internal set; } = 1f;
		// Chests
		public int BiomeChestSets { get; internal set; } = 1;

		public float JungleShrineMultiplier { get; internal set; } = 1f;

		public float PotsMultiplier { get; internal set; } = 1f;

		public bool HardmodeStripes { get; internal set; } = true;

		public float MahoganyTreeMultiplier { get; internal set; } = 1f;

		public float WaterChestMultiplier { get; internal set; } = 1f;

		public float SurfaceChestMultiplier { get; internal set; } = 1f;

		public float TempleChestMultiplier { get; internal set; } = 1f;

		public float ShadowChestMultiplier { get; internal set; } = 1f;

		public SettingDelegate ShadowChestMultiplierDelegate = new SettingDelegate(
			                                                       "Shadow Chests:", 
			                                                       5f, 
			                                                       () => Main.setting.ShadowChestMultiplier, 
			                                                       x => Main.setting.ShadowChestMultiplier = x, 
			                                                       x => Math.Round((double)(Main.setting.ShadowChestMultiplier * 100f)) + "%" + " -> " + (int)(5f * (Main.maxTilesX / 4200) * Main.setting.ShadowChestMultiplier) + "-" + (int)(8f * (Main.maxTilesX / 4200) * Main.setting.ShadowChestMultiplier) + " chests"
		                                                       );
		//public int NumberGenerationPassSteps { get; internal set; } = 95;
		public bool GenerateWldEachStep { get; internal set; }
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
		internal int additionalHorizontalSpacingPost = 0;

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
			yPosition += Height;
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
			int yPos = yPosition - 15;
			base.HandleMe(ref label, clicked, ref yPosition, index);

			int xPos = 390 + Main.screenWidth / 2 - 400 - 100;
			// String 1
			Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, this.label, (float)xPos, (float)yPos, Interface.color, Color.Black, Vector2.Zero, 0.5f);

			// String 2
			xPos += 270;//180;
			Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, estimationString(getter()), (float)xPos, (float)yPos, Interface.color, Color.Black, Vector2.Zero, 0.5f);

			// Slider
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
		}
	}

	public class PlainLabel : TerraCustomMenuItem
	{
		string label;
		public PlainLabel(string label)
		{
			this.label = label;
		}
		public override void HandleMe(ref string label, bool clicked, ref int yPosition, int index)
		{
			base.HandleMe(ref label, clicked, ref yPosition, index);
			label = this.label;
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
