using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.IO;

namespace Terraria.TerraCustom
{
	class Interface
	{

		static Color color = Color.White;
		//TerraCustom.Interface.TerraCustomMenu(this, this.selectedMenu, clickableLabelText, clickableLabelScale, array4, ref num, ref num3, ref numberClickableLabels);
		internal static void TerraCustomMenu(Main main, int selectedMenu, bool[] array, string[] clickableLabelText, float[] clickableLabelScale, int[] array4, ref int num, ref int num3, ref int numberClickableLabels)
		{
			if (Main.menuMode == (int)MenuModes.DownedFound)
			{
				num = 200;
				num3 = 35;
				numberClickableLabels = 3;  // increment this.
				array4[numberClickableLabels - 1] = 9;
				for (int num23 = 0; num23 < numberClickableLabels; num23++)
				{
					clickableLabelScale[num23] = 0.73f;
				}
				clickableLabelScale[numberClickableLabels - 1] = 0.93f;
				int buttonIndex = 0;


				clickableLabelText[buttonIndex] = "Downed Bosses";
				if (main.selectedMenu == buttonIndex)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.Downed;
				}
				buttonIndex++;

				clickableLabelText[buttonIndex] = "Found NPCs";
				if (main.selectedMenu == buttonIndex)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.Found;
				}
				buttonIndex++;


				array4[buttonIndex] = 30;
				clickableLabelText[buttonIndex] = Lang.menu[5];
				if (main.selectedMenu == buttonIndex)
				{
					Main.menuMode = (int)MenuModes.Settings;
				}
			}
			else if (Main.menuMode == (int)MenuModes.Downed)
			{
				string[][] optionStrings =
				{
							new string[] { "Downed Slime King: No", "Downed Slime King: Yes"},
							new string[] { "Downed Queen Bee : No", "Downed Queen Bee : Yes"},
							new string[] { "Downed Eye of Cthulu : No", "Downed Eye of Cthulu : Yes"},
							new string[] { "Downed Eater of Worlds / Brain of Cthulu: No", "Downed Eater of Worlds / Brain of Cthulu: Yes"},
							new string[] { "Downed Skeletron : No", "Downed Skeletron : Yes"},
							new string[] { "Downed Twins: No", "Downed Twins: Yes"},
							new string[] { "Downed Destroyer: No", "Downed Destroyer: Yes"},
							new string[] { "Downed Skeletron Prime: No", "Downed Skeletron Prime: Yes"},
							new string[] { "Downed Plantera: No", "Downed Plantera: Yes"},
							new string[] { "Downed Golem: No", "Downed Golem: Yes"},
							new string[] { "Downed Fishron : No", "Downed Fishron : Yes"},
							new string[] { "Downed Lunatic Cultist: No", "Downed Lunatic Cultist: Yes"},
							new string[] { "Downed Moonlord: No", "Downed Moonlord: Yes"},
						};

				num = 200;
				num3 = 30; // virtical spacing?
				numberClickableLabels = 2 + optionStrings.GetLength(0); // = to reset + back + # options
				for (int num21 = 0; num21 < numberClickableLabels; num21++)
				{
					clickableLabelScale[num21] = 0.73f;
				}
				int buttonIndex = 0;
				clickableLabelText[buttonIndex] = "Reset Downed Boss Settings";
				if (main.selectedMenu == 0)
				{
					WorldGen.initializeDowned();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -17;


				Func<int>[] getters = {
							() => Main.setting.downedSlimeKing ? 1 : 0,
							() => Main.setting.downedQueenBee ? 1 : 0,
							() => Main.setting.downedEyeOfCthulu ? 1 : 0,
							() => Main.setting.downedEaterBrain ? 1 : 0,
							() => Main.setting.downedSkeletron ? 1 : 0,
							() => Main.setting.downedTwins ? 1 : 0,
							() => Main.setting.downedDestroyer ? 1 : 0,
							() => Main.setting.downedSkeletronPrime ? 1 : 0,
							() => Main.setting.downedPlantera ? 1 : 0,
							() => Main.setting.downedGolem ? 1 : 0,
							() => Main.setting.downedFishron ? 1 : 0,
							() => Main.setting.downedAncientCultist ? 1 : 0,
							() => Main.setting.downedMoonlord ? 1 : 0
						};
				Action<int>[] setters = {
					x => Main.setting.downedSlimeKing = x > 0 ? true : false,
					x =>  Main.setting.downedQueenBee = x > 0 ? true : false,
					x => Main.setting.downedEyeOfCthulu = x > 0 ? true : false,
					x =>  Main.setting.downedEaterBrain = x > 0 ? true : false,
					x => Main.setting.downedSkeletron  = x > 0 ? true : false,
					x => Main.setting.downedTwins = x > 0 ? true : false,
					x => Main.setting.downedDestroyer = x > 0 ? true : false,
					x => Main.setting.downedSkeletronPrime = x > 0 ? true : false,
					x => Main.setting.downedPlantera = x > 0 ? true : false,
					x => Main.setting.downedGolem = x > 0 ? true : false,
					x => Main.setting.downedFishron = x > 0 ? true : false,
					x => Main.setting.downedAncientCultist = x > 0 ? true : false,
					x => Main.setting.downedMoonlord = x > 0 ? true : false
				};

				for (int i = 0; i < getters.Length; i++)
				{
					buttonIndex++;
					clickableLabelText[buttonIndex] = optionStrings[i][getters[i]()];
					if (main.selectedMenu == buttonIndex)
					{
						setters[i]((getters[i]() + 1) % optionStrings[i].Length);
					}
				}

				buttonIndex++;
				array4[buttonIndex] = 30;
				clickableLabelText[buttonIndex] = Lang.menu[5];
				if (main.selectedMenu == buttonIndex)
				{
					Main.menuMode = (int)MenuModes.DownedFound;
				}
			}
			else if (Main.menuMode == (int)MenuModes.Found)
			{
				string[][] optionStrings =
				{
					new string[] { "Found Stylist: No", "Found Stylist: Yes"},
					new string[] { "Found Goblin : No", "Found Goblin : Yes"},
					new string[] { "Found Wizard : No", "Found Wizard : Yes"},
					new string[] { "Found Mechanic: No", "Found Mechanic: Yes"},
					new string[] { "Found Angler : No", "Found Angler : Yes"},
					new string[] { "Found Tax Collector: No", "Found Tax Collector: Yes"},
				};

				num = 200;
				num3 = 30; // virtical spacing?
				numberClickableLabels = 2 + optionStrings.GetLength(0); // = to reset + back + # options
				for (int num21 = 0; num21 < numberClickableLabels; num21++)
				{
					clickableLabelScale[num21] = 0.73f;
				}
				int buttonIndex = 0;
				clickableLabelText[buttonIndex] = "Reset Found NPC Settings";
				if (main.selectedMenu == 0)
				{
					WorldGen.initializeFound();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -17;


				Func<int>[] getters = {
					() => Main.setting.savedStylist ? 1 : 0,
					() => Main.setting.savedGoblin ? 1 : 0,
					() => Main.setting.savedWizard ? 1 : 0,
					() => Main.setting.savedMechanic ? 1 : 0,
					() => Main.setting.savedAngler ? 1 : 0,
					() => Main.setting.savedTaxCollector ? 1 : 0,
				};
				Action<int>[] setters = {
					x => Main.setting.savedStylist = x > 0 ? true : false,
					x =>  Main.setting.savedGoblin = x > 0 ? true : false,
					x => Main.setting.savedWizard = x > 0 ? true : false,
					x =>  Main.setting.savedMechanic = x > 0 ? true : false,
					x => Main.setting.savedAngler  = x > 0 ? true : false,
					x => Main.setting.savedTaxCollector = x > 0 ? true : false,
				};

				for (int i = 0; i < getters.Length; i++)
				{
					buttonIndex++;
					clickableLabelText[buttonIndex] = optionStrings[i][getters[i]()];
					if (main.selectedMenu == buttonIndex)
					{
						setters[i]((getters[i]() + 1) % optionStrings[i].Length);
					}
				}

				buttonIndex++;
				array4[buttonIndex] = 30;
				clickableLabelText[buttonIndex] = Lang.menu[5];
				if (main.selectedMenu == buttonIndex)
				{
					Main.menuMode = (int)MenuModes.DownedFound;
				}
			}
			else if (Main.menuMode == (int)MenuModes.Chests)
			{
				num = 200;
				num3 = 30;
				numberClickableLabels = 2;
				for (int num38 = 0; num38 < numberClickableLabels; num38++)
				{
					clickableLabelScale[num38] = 0.73f;
				}
				clickableLabelText[0] = "Reset Chests";
				if (main.selectedMenu == 0)
				{
					WorldGen.initializeChests();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -17;
				string text4 = "set to 100% for default behavior";
				int num39 = Main.screenWidth / 2 - 220;
				int num40 = 240;
				Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, text4, (float)num39, (float)num40, Microsoft.Xna.Framework.Color.White, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);
				num40 += 30;
				Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, ChestEstimateString(), (float)num39, (float)num40, Microsoft.Xna.Framework.Color.White, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);
				clickableLabelText[1] = Lang.menu[5];
				if (main.selectedMenu == 1)
				{
					Main.menuMode = (int)MenuModes.Settings;
				}
				int num41 = num40 + 30;
				IngameOptions.rightHover = -1;
				if (!Main.mouseLeft)
				{
					IngameOptions.rightLock = -1;
				}

				Microsoft.Xna.Framework.Color textColor3 = color;
				textColor3.R = (byte)((255 + textColor3.R) / 2);
				textColor3.G = (byte)((255 + textColor3.R) / 2);
				textColor3.B = (byte)((255 + textColor3.R) / 2);
				int numval = (int)textColor3.R;
				if (numval < 0)
				{
					numval = 0;
				}
				textColor3 = new Microsoft.Xna.Framework.Color((int)((byte)numval), (int)((byte)numval), (int)((byte)numval), (int)((byte)255));

				// Each needs: Label, Ratio, property(get/set), method for string generation?
				string[] labels = { "Biome Chest Sets:", "Pots:", "Jungle Shrines:", "Living Mahogany Trees:", "Water Chests:", "Surface Chests:", "Temple Chests:", Main.setting.ShadowChestMultiplierDelegate.label /*"Shadow Chests:"*/ };
				float[] ratios = { 10f, 2.5f, 5f, 2f, 5f, 5f, 5f, Main.setting.ShadowChestMultiplierDelegate.ratio/*5f*/};
				Func<float>[] getters = {
							() => Main.setting.BiomeChestSets,
							() => Main.setting.PotsMultiplier,
							() => Main.setting.JungleShrineMultiplier,
							() => Main.setting.MahoganyTreeMultiplier,
							() => Main.setting.WaterChestMultiplier,
							() => Main.setting.SurfaceChestMultiplier,
							() => Main.setting.TempleChestMultiplier,
							Main.setting.ShadowChestMultiplierDelegate.getter,
                            //() => Main.setting.ShadowChestMultiplier,
						};
				// 
				// % = get/ratio therfore, ratio must be range, get must return 0 to range
				Action<float>[] setters = {
							x => Main.setting.BiomeChestSets = (int) x,
							x => Main.setting.PotsMultiplier = x,
							x => Main.setting.JungleShrineMultiplier = x,
							x => Main.setting.MahoganyTreeMultiplier = x,
							x => Main.setting.WaterChestMultiplier = x,
							x => Main.setting.SurfaceChestMultiplier = x,
							x => Main.setting.TempleChestMultiplier = x,
							Main.setting.ShadowChestMultiplierDelegate.setter,
							//x => Main.setting.ShadowChestMultiplier = x,
						};
				Func<float, string>[] estimationString = {
							x => x + " sets",
							x => Math.Round((double)(Main.setting.PotsMultiplier * 100f)) + "%" + " -> " + (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0008 * Main.setting.PotsMultiplier) + " pots",
							x => Math.Round((double)(Main.setting.JungleShrineMultiplier * 100f)) + "%" + " -> " + (int)Math.Ceiling(Main.setting.JungleShrineMultiplier*7*Main.maxTilesX / 4200)+ "-" + (int)Math.Ceiling(Main.setting.JungleShrineMultiplier*12*Main.maxTilesX / 4200)+" shrines",
							x => Math.Round((double)(Main.setting.MahoganyTreeMultiplier * 100f)) + "%" + " -> ~" + (int)(6 * (Main.maxTilesX / 4200f) * Main.setting.MahoganyTreeMultiplier)+ "-" +(int)(11 * (Main.maxTilesX / 4200f) * Main.setting.MahoganyTreeMultiplier)+ " trees",
							x => Math.Round((double)(Main.setting.WaterChestMultiplier * 100f)) + "%" + " -> " + (int)Math.Ceiling(Main.setting.WaterChestMultiplier * 2f * 9f* (Main.maxTilesX / 4200f))+ " chests",
							x => Math.Round((double)(Main.setting.SurfaceChestMultiplier * 100f)) + "%" + " -> " + (int)((double)Main.maxTilesX * 0.005 * Main.setting.SurfaceChestMultiplier) + " chests",
							x => Math.Round((double)(Main.setting.TempleChestMultiplier * 100f)) + "%" + " -> " +(int)Math.Ceiling(Main.setting.TempleChestMultiplier * 0.35f * 13f * (Main.maxTilesX / 4200f) * Main.setting.TempleSizeMultiplier *.85f) + "-" + (int)Math.Ceiling(Main.setting.TempleChestMultiplier * 0.35f * 13f * (Main.maxTilesX / 4200f) * Main.setting.TempleSizeMultiplier * 1.15f) + " chests",
							//x => Math.Round((double)(Main.setting.ShadowChestMultiplier * 100f)) + "%" + " -> " + (int)(5f * (Main.maxTilesX / 4200) * Main.setting.ShadowChestMultiplier) + "-" + (int)(8f * (Main.maxTilesX / 4200) * Main.setting.ShadowChestMultiplier) + " chests",
							Main.setting.ShadowChestMultiplierDelegate.estimationString,
						};

				// TODO Sliders.
				for (int i = 0; i < labels.Length; i++)
				{
					int yPos = num41;
					int xPos = 390 + Main.screenWidth / 2 - 400 - 100;
					// String 1
					yPos += 0 + i * 30;
					num40 = yPos;
					Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, labels[i], (float)xPos, (float)yPos, textColor3, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);

					// String 2
					xPos += 270;//180;
					Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, estimationString[i](getters[i]()), (float)xPos, (float)yPos, textColor3, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);

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

				if (IngameOptions.rightHover != -1)
				{
					IngameOptions.rightLock = IngameOptions.rightHover;
				}
				array4[1] = labels.Length * 30 + 30 + 30;
			}
			else if (Main.menuMode == (int)MenuModes.Terrain)
			{
				num = 200;
				num3 = 30;
				numberClickableLabels = 2;
				for (int num38 = 0; num38 < numberClickableLabels; num38++)
				{
					clickableLabelScale[num38] = 0.73f;
				}
				clickableLabelText[0] = "Reset Terrain";
				if (main.selectedMenu == 0)
				{
					WorldGen.initializeTerrain();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = 0;// -17;
				string text4 = "set to 100% for default behavior";
				int num39 = Main.screenWidth / 2 - 220;
				int num40 = 240;
				Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, text4, (float)num39, (float)num40, Microsoft.Xna.Framework.Color.White, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);
				clickableLabelText[1] = Lang.menu[5];
				if (main.selectedMenu == 1)
				{
					Main.menuMode = (int)MenuModes.Settings;
				}
				int num41 = num40 + 30;
				IngameOptions.rightHover = -1;
				if (!Main.mouseLeft)
				{
					IngameOptions.rightLock = -1;
				}

				Microsoft.Xna.Framework.Color textColor3 = color;
				textColor3.R = (byte)((255 + textColor3.R) / 2);
				textColor3.G = (byte)((255 + textColor3.R) / 2);
				textColor3.B = (byte)((255 + textColor3.R) / 2);
				int numval = (int)textColor3.R;
				if (numval < 0)
				{
					numval = 0;
				}
				textColor3 = new Microsoft.Xna.Framework.Color((int)((byte)numval), (int)((byte)numval), (int)((byte)numval), (int)((byte)255));


				// 0 to 10f : R: 10
				// .1 to .17: R: .07 +- .1

				// Each needs: Label, Ratio, property(get/set), method for string generation?
				string[] labels = { "Surface Height Variance:", "Surface Upper Limit:", "Surface Lower Limit:", "Dungeon Size", "Temple Size", "Surface Tunnels", "Lakes", "World Width" };
				float[] ratios = { 10f, .35f, .35f,/*.07f, .15f, */10f, 4f, 50f, 20f, 16800f };
				Func<float>[] getters = {
							() => Main.setting.SurfaceTerrainHeightMultiplier,
							//() => Main.setting.SurfaceTerrainHeightMax - .1f,  // .1 to .17
							//() => Main.setting.SurfaceTerrainHeightMin - .3f,  // .3 to .45?
							() => Main.setting.SurfaceTerrainHeightMax - .1f,  // .1 to .17
							() => Main.setting.SurfaceTerrainHeightMin - .1f,  // .3 to .45?
							() => Main.setting.DungeonSizeMultiplier- .01f, // 
							() => Main.setting.TempleSizeMultiplier- .2f, // 
							() => Main.setting.SurfaceHorizontalTunnelsMultiplier,
							() => Main.setting.LakeMultiplier,
							() => Main.maxTilesX
						};
				// 
				// % = get/ratio therfore, ratio must be range, get must return 0 to range
				Action<float>[] setters = {
							x => Main.setting.SurfaceTerrainHeightMultiplier = x,
							//x => Main.setting.SurfaceTerrainHeightMax = x+.1f,
							//x => Main.setting.SurfaceTerrainHeightMin = x+.3f, // ration * % 
							x => Main.setting.SurfaceTerrainHeightMax = x+.1f > Main.setting.SurfaceTerrainHeightMin? Main.setting.SurfaceTerrainHeightMin : x+.1f,
							x => Main.setting.SurfaceTerrainHeightMin = x+.1f < Main.setting.SurfaceTerrainHeightMax? Main.setting.SurfaceTerrainHeightMax : x+.1f,
							x => Main.setting.DungeonSizeMultiplier = x + .05f,   // set called with 0 to 1.0f * ratio
							x => Main.setting.TempleSizeMultiplier = x + .2f,
							x => Main.setting.SurfaceHorizontalTunnelsMultiplier = x,
							x => Main.setting.LakeMultiplier = x,
							x => Main.maxTilesX = (int)x,
						};
				Func<float, string>[] estimationString = {
							x => Math.Round((double)(x * 100f)) + "%" + (x==0?" Flat":""),
							x => Math.Round((double)( Main.setting.SurfaceTerrainHeightMax * 100f)) + "%" + " - Low% = High Mountains" + ( Main.setting.SurfaceTerrainHeightMax <.15f?" High Chance of Failure":""),
							x => Math.Round((double)( Main.setting.SurfaceTerrainHeightMin * 100f)) + "%" + " - High% = Deep Valleys" + ( Main.setting.SurfaceTerrainHeightMin <.15f?" Low Chance of Sky Islands":""),
							x => Math.Round((double)(Main.setting.DungeonSizeMultiplier * 100f)) + "%" + " -> " + "~"+(2+(int)(x * Main.maxTilesX / 60)) + "-" + (int)(2+(int)(Main.setting.DungeonSizeMultiplier * Main.maxTilesX / 60)+(int)((Main.setting.DungeonSizeMultiplier * Main.maxTilesX / 60) / 3f)) + " rooms/hallways",
							x => Math.Round((double)(Main.setting.TempleSizeMultiplier * 100f)) + "%" + (Main.setting.TempleSizeMultiplier>3?" Warning: Might Fail":""),
							x => Math.Round(Main.setting.SurfaceHorizontalTunnelsMultiplier * 100f) + "%",
							x => Math.Round((double)(Main.setting.LakeMultiplier * 100f)) + "%" + " -> " + " between 2 and " + (int)((double)Main.maxTilesX * 0.005 * Main.setting.LakeMultiplier - 1),
							x => x +" tiles wide",
						};

				// TODO Sliders.
				for (int i = 0; i < labels.Length; i++)
				{
					int yPos = num41;
					int xPos = 390 + Main.screenWidth / 2 - 400 - 100;
					// String 1
					yPos += 0 + i * 30;
					num40 = yPos;
					Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, labels[i], (float)xPos, (float)yPos, textColor3, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);

					// String 2
					xPos += 270;//180;
					Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, estimationString[i](getters[i]()), (float)xPos, (float)yPos, textColor3, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);

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

				if (IngameOptions.rightHover != -1)
				{
					IngameOptions.rightLock = IngameOptions.rightHover;
				}
				array4[1] = labels.Length * 30 + 30;
				array4[1] = 0;//+ Main.rand.Next(0, 30)
			}
			else if (Main.menuMode == (int)MenuModes.VariousSpawns)
			{
				num = 200;
				num3 = 30;
				numberClickableLabels = 2;
				for (int num38 = 0; num38 < numberClickableLabels; num38++)
				{
					clickableLabelScale[num38] = 0.73f;
				}
				clickableLabelText[0] = "Reset Various Spawns Amounts";
				if (main.selectedMenu == 0)
				{
					WorldGen.initializeVariousSpawnsAmount();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -17;
				string text4 = "setting 100% will generate default amount";
				int num39 = Main.screenWidth / 2 - 220;
				int num40 = 240;
				Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, text4, (float)num39, (float)num40, Microsoft.Xna.Framework.Color.White, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);
				clickableLabelText[1] = Lang.menu[5];
				if (main.selectedMenu == 1)
				{
					Main.menuMode = (int)MenuModes.Settings;
				}
				int num41 = num40 + 30;
				//num39 = Main.screenWidth / 2 - 300;
				//	num40 += 70;
				IngameOptions.rightHover = -1;
				if (!Main.mouseLeft)
				{
					IngameOptions.rightLock = -1;
				}

				Microsoft.Xna.Framework.Color textColor3 = color;
				textColor3.R = (byte)((255 + textColor3.R) / 2);
				textColor3.G = (byte)((255 + textColor3.R) / 2);
				textColor3.B = (byte)((255 + textColor3.R) / 2);
				int numval = (int)textColor3.R;
				if (numval < 0)
				{
					numval = 0;
				}
				textColor3 = new Microsoft.Xna.Framework.Color((int)((byte)numval), (int)((byte)numval), (int)((byte)numval), (int)((byte)255));

				// Each needs: Label, Ratio, property(get/set), method for string generation?
				string[] labels = { "Crystal Hearts:", /*"Demon/Crimson Altars:"*/ "Pre-Drop Meteor", "Tree Lower Bound", "Tree Upper Bound"/*, "Debug: #Generation Pass Steps"*/ };
				float[] ratios = { 10f, 100f, 150f, 150f/*, 95f*/};
				Func<float>[] getters = {
							() => Main.setting.CrystalHeartMultiplier,
							//() => Main.setting.AltarMultiplier,
							() => (float)Main.setting.PreDropMeteor,
							() => (float)Main.setting.TreeLowerBound,
							() => (float)Main.setting.TreeUpperBound,
					//		() => (float)Main.setting.NumberGenerationPassSteps,
						};
				Action<float>[] setters = {
							x => Main.setting.CrystalHeartMultiplier = x,
							x => Main.setting.PreDropMeteor = (int)x,
							x => Main.setting.TreeLowerBound = ((int)x>Main.setting.TreeUpperBound? Main.setting.TreeUpperBound: (int)x), // ratio * %
							x => Main.setting.TreeUpperBound = ((int)x<Main.setting.TreeLowerBound? Main.setting.TreeLowerBound: (int)x), // ratio * %
						//	x => Main.setting.NumberGenerationPassSteps = (int) x,

							//x => { Main.setting.TreeLowerBound = 1; Main.setting.TreeLowerBound = 2; },
							//x => Main.setting.AltarMultiplier = x,
						};
				Func<float, string>[] estimationString = {
							x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05 * x),
							x => "Drop " + (int)x + " meteors",
							x => "Between " + (int)x ,
							x => " and " + (int)x + " tiles tall",
						//	x => (int)x + " steps (Don't change this)",

							//x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05 * x),
						};

				// TODO Sliders.
				DrawSliders(num40, num41, textColor3, labels, ratios, getters, setters, estimationString);

				if (IngameOptions.rightHover != -1)
				{
					IngameOptions.rightLock = IngameOptions.rightHover;
				}
				array4[1] = labels.Length * 30 + 30;
			}
			else if (Main.menuMode == (int)MenuModes.MicroBiomes)
			{
				//TODO micro biomes drawmenu


				num = 200;
				num3 = 30;
				numberClickableLabels = 2;
				for (int num38 = 0; num38 < numberClickableLabels; num38++)
				{
					clickableLabelScale[num38] = 0.73f;
				}
				clickableLabelText[0] = "Reset Micro Biomes Amounts";
				if (main.selectedMenu == 0)
				{
					WorldGen.initializeMicroBiomesAmount();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -17;
				string text4 = "setting 100% will generate default amount of biomes";
				int num39 = Main.screenWidth / 2 - 220;
				int num40 = 240;
				Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, text4, (float)num39, (float)num40, Microsoft.Xna.Framework.Color.White, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);
				clickableLabelText[1] = Lang.menu[5];
				if (main.selectedMenu == 1)
				{
					Main.menuMode = (int)MenuModes.Settings;
				}
				int num41 = num40 + 30;
				string text5 = "";
				for (int num42 = 0; num42 < 8; num42++)
				{
					int num43 = num41;
					int num44 = 390 + Main.screenWidth / 2 - 400 - 100;
					switch (num42)
					{
						case 0:
							text5 = "Enchanted Sword:";
							break;
						case 1:
							text5 = "Mining Explosive (Detonator):";
							num43 += 30;
							break;
						case 2:
							text5 = "Traps (Dart, Explosive, Boulder):";
							num43 += 60;
							break;
						case 3:
							text5 = "Sky Islands:";
							num43 += 90;
							break;
						case 4:
							int numberEnchantedSwordBiomes = (int)Math.Ceiling((Main.maxTilesX * Main.maxTilesY / 5040000f) * Main.setting.EnchantedSwordBiomeMultiplier);
							text5 = Math.Round((double)(Main.setting.EnchantedSwordBiomeMultiplier * 100f)) + "%" + " -> " + numberEnchantedSwordBiomes;  // .2 orignially, *500 = 100 
							num44 += 270;
							break;
						case 5:
							text5 = Math.Round((double)(Main.setting.MiningExplosiveMultiplier * 100f)) + "%";  // .2 orignially, *500 = 100 
							num44 += 360;
							num43 += 30;
							break;
						case 6:
							text5 = Math.Round((double)(Main.setting.TrapMultiplier * 100f)) + "%";  // .2 orignially, *500 = 100 
							num44 += 360;
							num43 += 60;
							break;
						case 7:
							//  int numberEnchantedSwordBiomes = (int)Math.Ceiling((Main.maxTilesX * Main.maxTilesY / 5040000f) * Main.setting.EnchantedSwordBiomeMultiplier);
							text5 = "~" + Math.Round((double)(Main.setting.SkyIslandMultiplier * 100f)) + "%";// + " -> " + numberEnchantedSwordBiomes;  // .2 orignially, *500 = 100 
							num44 += 270;
							num43 += 90;
							break;

					}
					num40 = num43;
					Microsoft.Xna.Framework.Color textColor2 = color;
					textColor2.R = (byte)((255 + textColor2.R) / 2);
					textColor2.G = (byte)((255 + textColor2.R) / 2);
					textColor2.B = (byte)((255 + textColor2.R) / 2);
					int num45 = 255;
					int num46 = (int)textColor2.R - (255 - num45);
					if (num46 < 0)
					{
						num46 = 0;
					}
					textColor2 = new Microsoft.Xna.Framework.Color((int)((byte)num46), (int)((byte)num46), (int)((byte)num46), (int)((byte)num45));
					Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, text5, (float)num44, (float)num43, textColor2, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);
				}
				// text4 = "Option to generate alternate hardmode ores in the beginning";
				num39 = Main.screenWidth / 2 - 300;
				num40 += 70;
				//Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, text4, (float)num39, (float)num40, Microsoft.Xna.Framework.Color.White, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);
				IngameOptions.rightHover = -1;
				if (!Main.mouseLeft)
				{
					IngameOptions.rightLock = -1;
				}

				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 140), (float)(num41 - 18 + 30));
				float percEnchantedSwordBiomeMultiplier = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, Main.setting.EnchantedSwordBiomeMultiplier / 5f);
				if (IngameOptions.inBar || IngameOptions.rightLock == 2)
				{
					IngameOptions.rightHover = 2;
					if (Main.mouseLeft && IngameOptions.rightLock == 2)
					{
						Main.setting.EnchantedSwordBiomeMultiplier = 5f * percEnchantedSwordBiomeMultiplier;
					}
				}

				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 140), (float)(num41 - 18 + 60));
				float percMiningExplosiveMultiplier = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, Main.setting.MiningExplosiveMultiplier / 50f);
				if (IngameOptions.inBar || IngameOptions.rightLock == 3)
				{
					IngameOptions.rightHover = 3;
					if (Main.mouseLeft && IngameOptions.rightLock == 3)
					{
						Main.setting.MiningExplosiveMultiplier = 50f * percMiningExplosiveMultiplier;
					}
				}

				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 140), (float)(num41 - 18 + 90));
				float percTrapMultiplier = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, Main.setting.TrapMultiplier / 100f);
				if (IngameOptions.inBar || IngameOptions.rightLock == 4)
				{
					IngameOptions.rightHover = 4;
					if (Main.mouseLeft && IngameOptions.rightLock == 4)
					{
						Main.setting.TrapMultiplier = 100f * percTrapMultiplier;
					}
				}

				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 140), (float)(num41 - 18 + 120));
				float percSkyIslandMultiplier = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, Main.setting.SkyIslandMultiplier / 10f);
				if (IngameOptions.inBar || IngameOptions.rightLock == 5)
				{
					IngameOptions.rightHover = 5;
					if (Main.mouseLeft && IngameOptions.rightLock == 5)
					{
						Main.setting.SkyIslandMultiplier = 10f * percSkyIslandMultiplier;
					}
				}

				Microsoft.Xna.Framework.Color textColor3 = color;
				textColor3.R = (byte)((255 + textColor3.R) / 2);
				textColor3.G = (byte)((255 + textColor3.R) / 2);
				textColor3.B = (byte)((255 + textColor3.R) / 2);
				int numval = (int)textColor3.R;
				if (numval < 0)
				{
					numval = 0;
				}
				textColor3 = new Microsoft.Xna.Framework.Color((int)((byte)numval), (int)((byte)numval), (int)((byte)numval), (int)((byte)255));

				// Each needs: Label, Ratio, property(get/set), method for string generation?
				string[] labels = { "Minecart Tracks:", "Gemstone Caves:", "Gemstone Cave Size:", "Spider Caves:", "Granite Caves:", "Marble Caves:", "Underground Cabins:", "Temple Traps:" };
				float[] ratios = { 3f, 10f, 10f, 5f, 10f, 10f, 10f, 10f };
				Func<float>[] getters = {
							() => Main.setting.MineCartMultiplier,
							() => Main.setting.GemCaveMultiplier,
							() => Main.setting.GemCaveSizeMultiplier,
							() => Main.setting.SpiderCaveMultiplier,
							() => Main.setting.GraniteCaveMultiplier,
							() => Main.setting.MarbleCaveMultiplier,
							() => Main.setting.UndergroundCabinMultiplier,
							() => Main.setting.TempleTrapMultiplier,
						};
				Action<float>[] setters = {
							x => Main.setting.MineCartMultiplier = x,
							x => Main.setting.GemCaveMultiplier = x,
							x => Main.setting.GemCaveSizeMultiplier = x,
							x => Main.setting.SpiderCaveMultiplier = x,
							x => Main.setting.GraniteCaveMultiplier = x,
							x => Main.setting.MarbleCaveMultiplier = x,
							x => Main.setting.UndergroundCabinMultiplier = x,
							x => Main.setting.TempleTrapMultiplier = x,
						};
				Func<float, string>[] estimationString = {
							x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(10f * (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f * x),
							x => Math.Round((double)(x * 100f)) + "%",
							x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(300*x) +" tiles",
							x => Math.Round((double)(x * 100f)) + "%" + " -> " + "~"+(int)(Main.maxTilesX * 0.005 * x),
							x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(8 * (Main.maxTilesX / 4200f) * x) + "-" + (int)(13 * (Main.maxTilesX / 4200f) * x),
							x => Math.Round((double)(x * 100f)) + "%" + " -> " + (int)(10 * ((Main.maxTilesX * Main.maxTilesY) / 5040000f) * x) + "-" + (int)(14 * ((Main.maxTilesX * Main.maxTilesY) / 5040000f) *x),
							x => Math.Round((double)(x * 100f)) + "%" + " -> " + ((int)(Main.setting.UndergroundCabinMultiplier * 2f * (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f)+(int)((double)(Main.maxTilesX * Main.maxTilesY) * 1.6E-05 * Main.setting.UndergroundCabinMultiplier)) + " " + (((int)(Main.setting.UndergroundCabinMultiplier * 2f * (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f)+(int)((double)(Main.maxTilesX * Main.maxTilesY) * 1.6E-05 * Main.setting.UndergroundCabinMultiplier))>800?" Warning: Might Fail, too many chests.":""),
							x => Math.Round((double)(x * 100f)) + "%",
						};

				// TODO Sliders.
				DrawSliders(num40, num41, textColor3, labels, ratios, getters, setters, estimationString);
				//for (int i = 0; i < labels.Length; i++)
				//{
				//	int yPos = num41;
				//	int xPos = 390 + Main.screenWidth / 2 - 400 - 100;
				//	// String 1
				//	yPos += 120 + i * 30;
				//	num40 = yPos;
				//	Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, labels[i], (float)xPos, (float)yPos, textColor3, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);

				//	// String 2
				//	xPos += 270;//180;
				//	Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, estimationString[i](getters[i]()), (float)xPos, (float)yPos, textColor3, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);

				//	// Slider
				//	IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 140), (float)(num41 - 18 + 150 + 30 * i));
				//	float percent = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, getters[i]() / ratios[i]);
				//	if (IngameOptions.inBar || IngameOptions.rightLock == 6 + i)
				//	{
				//		IngameOptions.rightHover = 6 + i;
				//		if (Main.mouseLeft && IngameOptions.rightLock == 6 + i)
				//		{
				//			setters[i](ratios[i] * percent);
				//		}
				//	}
				//}


				if (IngameOptions.rightHover != -1)
				{
					IngameOptions.rightLock = IngameOptions.rightHover;
				}
				array4[1] = labels.Length * 30 + (30 * 4) + 30;
			}
			else if (Main.menuMode == (int)MenuModes.Backgrounds)
			{
				num = 200;
				num3 = 35;
				numberClickableLabels = 3;  // increment this.
				array4[numberClickableLabels - 1] = 9;
				for (int num23 = 0; num23 < numberClickableLabels; num23++)
				{
					clickableLabelScale[num23] = 0.73f;
				}
				clickableLabelScale[numberClickableLabels - 1] = 0.93f;
				int buttonIndex = 0;


				clickableLabelText[buttonIndex] = "Surface Backgrounds";
				if (main.selectedMenu == buttonIndex)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.SurfaceBackgrounds;
				}
				buttonIndex++;

				clickableLabelText[buttonIndex] = "Underground Backgrounds";
				if (main.selectedMenu == buttonIndex)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.UndergroundBackgrounds;
				}
				buttonIndex++;


				array4[buttonIndex] = 30;
				clickableLabelText[buttonIndex] = Lang.menu[5];
				if (main.selectedMenu == buttonIndex)
				{
					Main.menuMode = (int)MenuModes.Settings;
				}
			}

			else if (Main.menuMode == (int)MenuModes.ResetAllSettings /*114*/)
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
			else if (Main.menuMode == (int)MenuModes.Ores)
			{
				num = 200;
				num3 = 35;
				numberClickableLabels = 10;
				array4[numberClickableLabels - 1] = 18;
				for (int num25 = 0; num25 < numberClickableLabels; num25++)
				{
					clickableLabelScale[num25] = 0.73f;
				}
				int num26 = 0;
				clickableLabelText[num26] = "Reset Ore Settings";
				if (main.selectedMenu == num26)
				{
					WorldGen.initializeOres();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -18;
				num26++;
				clickableLabelText[num26] = "Also check 'Ore Amount' option to get both hardmode ores";
				clickableLabelScale[num26] = 0.6f;
				array[num26] = true;
				num26++;
				if (Main.setting.IsIron == 1)
				{
					clickableLabelText[num26] = "Iron/Lead: Iron";
				}
				else if (Main.setting.IsIron == 0)
				{
					clickableLabelText[num26] = "Iron/Lead: Lead";
				}
				else if (Main.setting.IsIron == 2)
				{
					clickableLabelText[num26] = "Iron/Lead: Random";
				}
				else if (Main.setting.IsIron == 3)
				{
					clickableLabelText[num26] = "Iron/Lead: Both";
				}
				if (main.selectedMenu == num26)
				{
					if (Main.setting.IsIron == 1)
					{
						Main.setting.IsIron = 0;
					}
					else if (Main.setting.IsIron == 2)
					{
						Main.setting.IsIron = 1;
					}
					else if (Main.setting.IsIron == 0)
					{
						Main.setting.IsIron = 3;
					}
					else if (Main.setting.IsIron == 3)
					{
						Main.setting.IsIron = 2;
					}
				}
				num26++;
				if (Main.setting.IsCopper == 1)
				{
					clickableLabelText[num26] = "Copper/Tin: Copper";
				}
				else if (Main.setting.IsCopper == 0)
				{
					clickableLabelText[num26] = "Copper/Tin: Tin";
				}
				else if (Main.setting.IsCopper == 2)
				{
					clickableLabelText[num26] = "Copper/Tin: Random";
				}
				else if (Main.setting.IsCopper == 3)
				{
					clickableLabelText[num26] = "Copper/Tin: Both";
				}
				if (main.selectedMenu == num26)
				{
					if (Main.setting.IsCopper == 1)
					{
						Main.setting.IsCopper = 0;
					}
					else if (Main.setting.IsCopper == 2)
					{
						Main.setting.IsCopper = 1;
					}
					else if (Main.setting.IsCopper == 0)
					{
						Main.setting.IsCopper = 3;
					}
					else if (Main.setting.IsCopper == 3)
					{
						Main.setting.IsCopper = 2;
					}
				}
				num26++;
				if (Main.setting.IsSilver == 1)
				{
					clickableLabelText[num26] = "Silver/Tungsten: Silver";
				}
				else if (Main.setting.IsSilver == 0)
				{
					clickableLabelText[num26] = "Silver/Tungsten: Tungsten";
				}
				else if (Main.setting.IsSilver == 2)
				{
					clickableLabelText[num26] = "Silver/Tungsten: Random";
				}
				else if (Main.setting.IsSilver == 3)
				{
					clickableLabelText[num26] = "Silver/Tungsten: Both";
				}
				if (main.selectedMenu == num26)
				{
					if (Main.setting.IsSilver == 1)
					{
						Main.setting.IsSilver = 0;
					}
					else if (Main.setting.IsSilver == 2)
					{
						Main.setting.IsSilver = 1;
					}
					else if (Main.setting.IsSilver == 0)
					{
						Main.setting.IsSilver = 3;
					}
					else if (Main.setting.IsSilver == 3)
					{
						Main.setting.IsSilver = 2;
					}
				}
				num26++;
				if (Main.setting.IsGold == 1)
				{
					clickableLabelText[num26] = "Gold/Platinum: Gold";
				}
				else if (Main.setting.IsGold == 0)
				{
					clickableLabelText[num26] = "Gold/Platinum: Platinum";
				}
				else if (Main.setting.IsGold == 2)
				{
					clickableLabelText[num26] = "Gold/Platinum: Random";
				}
				else if (Main.setting.IsGold == 3)
				{
					clickableLabelText[num26] = "Gold/Platinum: Both";
				}
				if (main.selectedMenu == num26)
				{
					if (Main.setting.IsGold == 1)
					{
						Main.setting.IsGold = 0;
					}
					else if (Main.setting.IsGold == 2)
					{
						Main.setting.IsGold = 1;
					}
					else if (Main.setting.IsGold == 0)
					{
						Main.setting.IsGold = 3;
					}
					else if (Main.setting.IsGold == 3)
					{
						Main.setting.IsGold = 2;
					}
				}
				num26++;
				if (Main.setting.IsCobalt == 1)
				{
					clickableLabelText[num26] = "Cobalt/Palladium: Cobalt";
					WorldGen.oreTier1 = 107; //Terraria.ID.TileID.Cobalt
				}
				else if (Main.setting.IsCobalt == 0)
				{
					clickableLabelText[num26] = "Cobalt/Palladium: Palladium";
					WorldGen.oreTier1 = 221;
				}
				else if (Main.setting.IsCobalt == 2)
				{
					clickableLabelText[num26] = "Cobalt/Palladium: Random";
					WorldGen.oreTier1 = -1;
				}
				if (main.selectedMenu == num26)
				{
					if (Main.setting.IsCobalt == 1)
					{
						Main.setting.IsCobalt = 0;
					}
					else if (Main.setting.IsCobalt == 2)
					{
						Main.setting.IsCobalt = 1;
					}
					else if (Main.setting.IsCobalt == 0)
					{
						Main.setting.IsCobalt = 2;
					}
				}
				num26++;
				if (Main.setting.IsMythril == 1)
				{
					clickableLabelText[num26] = "Mythril/Orichalcum: Mythril";
					WorldGen.oreTier2 = 108;
				}
				else if (Main.setting.IsMythril == 0)
				{
					clickableLabelText[num26] = "Mythril/Orichalcum: Orichalcum";
					WorldGen.oreTier2 = 222;
				}
				else if (Main.setting.IsMythril == 2)
				{
					clickableLabelText[num26] = "Mythril/Orichalcum: Random";
					WorldGen.oreTier2 = -1;
				}
				if (main.selectedMenu == num26)
				{
					if (Main.setting.IsMythril == 1)
					{
						Main.setting.IsMythril = 0;
					}
					else if (Main.setting.IsMythril == 2)
					{
						Main.setting.IsMythril = 1;
					}
					else if (Main.setting.IsMythril == 0)
					{
						Main.setting.IsMythril = 2;
					}
				}
				num26++;
				if (Main.setting.IsAdaman == 1)
				{
					clickableLabelText[num26] = "Adamantite/Titanium: Adamantite";
					WorldGen.oreTier3 = 111;
				}
				else if (Main.setting.IsAdaman == 0)
				{
					clickableLabelText[num26] = "Adamantite/Titanium: Titanium";
					WorldGen.oreTier3 = 223;
				}
				else if (Main.setting.IsAdaman == 2)
				{
					clickableLabelText[num26] = "Adamantite/Titanium: Random";
					WorldGen.oreTier3 = -1;
				}
				if (main.selectedMenu == num26)
				{
					if (Main.setting.IsAdaman == 1)
					{
						Main.setting.IsAdaman = 0;
					}
					else if (Main.setting.IsAdaman == 2)
					{
						Main.setting.IsAdaman = 1;
					}
					else if (Main.setting.IsAdaman == 0)
					{
						Main.setting.IsAdaman = 2;
					}
				}
				num26++;
				clickableLabelText[num26] = Lang.menu[5];
				if (main.selectedMenu == num26)
				{
					Main.menuMode = (int)MenuModes.Settings;
				}
			}
			else if (Main.menuMode == (int)MenuModes.ChallengeOption  /*113*/)
			{
				num = 200;
				num3 = 30;
				numberClickableLabels = 16; // change this!
				array4[numberClickableLabels - 1] = 27;
				for (int num27 = 0; num27 < numberClickableLabels; num27++)
				{
					clickableLabelScale[num27] = 0.73f;
				}
				int num28 = 0;
				clickableLabelText[num28] = "Reset Challenge Settings";
				if (main.selectedMenu == num28)
				{
					WorldGen.initializeChallenge();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -18;
				num28++;
				if (!Main.setting.NoTree)
				{
					clickableLabelText[num28] = "No tree: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No tree: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoTree = !Main.setting.NoTree;
				}
				num28++;
				if (!Main.setting.NoDungeon)
				{
					clickableLabelText[num28] = "No dungeon: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No dungeon: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoDungeon = !Main.setting.NoDungeon;
				}
				num28++;
				if (!Main.setting.NoTemple)
				{
					clickableLabelText[num28] = "No temple: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No temple: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoTemple = !Main.setting.NoTemple;
				}
				num28++;
				if (!Main.setting.NoSpiderCave)
				{
					clickableLabelText[num28] = "No spider cave: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No spider cave: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoSpiderCave = !Main.setting.NoSpiderCave;
				}
				num28++;
				if (!Main.setting.NoHive)
				{
					clickableLabelText[num28] = "No hive: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No hive: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoHive = !Main.setting.NoHive;
				}
				num28++;
				if (!Main.setting.NoSnow)
				{
					clickableLabelText[num28] = "No snow: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No snow: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoSnow = !Main.setting.NoSnow;
				}
				num28++;
				if (!Main.setting.NoJungle)
				{
					clickableLabelText[num28] = "No jungle: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No jungle: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoJungle = !Main.setting.NoJungle;
				}
				num28++;
				if (!Main.setting.NoAnthill)
				{
					clickableLabelText[num28] = "No anthill: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No anthill: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoAnthill = !Main.setting.NoAnthill;
				}
				num28++;
				if (!Main.setting.NoBeach)
				{
					clickableLabelText[num28] = "No beaches: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No beaches: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoBeach = !Main.setting.NoBeach;
				}
				num28++;
				//if (!Main.setting.NoAnthill)
				//{
				//	array9[num28] = "No anthill: Disabled";
				//}
				//else
				//{
				//	array9[num28] = "No anthill: Enabled";
				//}
				//if (this.selectedMenu == num28)
				//{
				//	Main.setting.NoAnthill = !Main.setting.NoAnthill;
				//}
				//num28++;
				if (!Main.setting.NoPot)
				{
					clickableLabelText[num28] = "No pot: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No pot: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoPot = !Main.setting.NoPot;
				}
				num28++;
				if (!Main.setting.NoChest)
				{
					clickableLabelText[num28] = "No chest: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No chest: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoChest = !Main.setting.NoChest;
				}
				num28++;
				if (!Main.setting.NoAltar)
				{
					clickableLabelText[num28] = "No altar: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No altar: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoAltar = !Main.setting.NoAltar;
				}
				num28++;
				if (!Main.setting.NoOrbHeart)
				{
					clickableLabelText[num28] = "No orb/heart: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No orb/heart: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoOrbHeart = !Main.setting.NoOrbHeart;
				}
				num28++;
				if (!Main.setting.NoUnderworld)
				{
					clickableLabelText[num28] = "No underworld: Disabled";
				}
				else
				{
					clickableLabelText[num28] = "No underworld: Enabled";
				}
				if (main.selectedMenu == num28)
				{
					Main.setting.NoUnderworld = !Main.setting.NoUnderworld;
				}
				num28++;
				array4[num28] = 20;
				clickableLabelText[num28] = Lang.menu[5];
				if (main.selectedMenu == num28)
				{
					Main.menuMode = (int)MenuModes.Settings;
				}
			}
			else if (Main.menuMode == (int)MenuModes.UndergroundBackgrounds /*26*/)
			{
				{
					//	TCDrawUnderground = true;

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
						/*string[][]*/
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

					num = 200;
					num3 = 30; // virtical spacing?
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
						Main.TCDrawUnderground = false;
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
			else if (Main.menuMode == (int)MenuModes.Miscellaneous /*1111*/)
			{
				num = 200;
				num3 = 44;
				numberClickableLabels = 9;  // change here
				for (int num21 = 0; num21 < numberClickableLabels; num21++)
				{
					clickableLabelScale[num21] = 0.73f;
				}
				int num22 = 0;
				clickableLabelText[num22] = "Reset Miscellaneous Settings";
				if (main.selectedMenu == 0)
				{
					WorldGen.initializeMiscellaneous();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -17;

				num22++;
				if (Main.setting.IsCorruption == 0)
				{
					clickableLabelText[num22] = "Corruption/Crimson: Random";
				}
				else if (Main.setting.IsCorruption == 1)
				{
					clickableLabelText[num22] = "Corruption/Crimson: Corruption";
				}
				else if (Main.setting.IsCorruption == 2)
				{
					clickableLabelText[num22] = "Corruption/Crimson: Crimson";
				}
				else if (Main.setting.IsCorruption == 3)
				{
					clickableLabelText[num22] = "Corruption/Crimson: Corruption with Crimson chasms";
				}
				else if (Main.setting.IsCorruption == 4)
				{
					clickableLabelText[num22] = "Corruption/Crimson: Crimson with Corruption chasms";
				}
				else if (Main.setting.IsCorruption == 5)
				{
					clickableLabelText[num22] = "Corruption/Crimson: None";
				}
				if (main.selectedMenu == num22)
				{
					Main.setting.IsCorruption = (Main.setting.IsCorruption + 1) % 6;
				}

				num22++;
				if (Main.setting.CrimsonCorruptionAvoidJungle)
				{
					clickableLabelText[num22] = "Force Corruption/Crimson Avoid Jungle Side: Yes";
				}
				else
				{
					clickableLabelText[num22] = "Force Corruption/Crimson Avoid Jungle Side: No";
				}
				if (main.selectedMenu == num22)
				{
					Main.setting.CrimsonCorruptionAvoidJungle = !Main.setting.CrimsonCorruptionAvoidJungle;
				}

				num22++;
				if (Main.setting.DungeonSide == 0)
				{
					clickableLabelText[num22] = "Dungeon Side: Random";
				}
				else if (Main.setting.DungeonSide == 1)
				{
					clickableLabelText[num22] = "Dungeon Side: Left";
				}
				else if (Main.setting.DungeonSide == 2)
				{
					clickableLabelText[num22] = "Dungeon Side: Right";
				}
				if (main.selectedMenu == num22)
				{
					Main.setting.DungeonSide = (Main.setting.DungeonSide + 1) % 3;
				}

				num22++;
				if (Main.hardMode)
				{
					clickableLabelText[num22] = "Hardmode: Yes";
				}
				else
				{
					clickableLabelText[num22] = "Hardmode: No";
				}
				if (main.selectedMenu == num22)
				{
					Main.hardMode = !Main.hardMode;
				}

				num22++;
				if (Main.setting.HardmodeStripes)
				{
					clickableLabelText[num22] = "Spawn Hardmode stripes (if Hardmode is Yes): Yes";
				}
				else
				{
					clickableLabelText[num22] = "Spawn Hardmode stripes (if Hardmode is Yes): No";
				}
				if (main.selectedMenu == num22)
				{
					Main.setting.HardmodeStripes = !Main.setting.HardmodeStripes;
				}

				num22++;
				if (Main.setting.IsPyramid == 1)
				{
					clickableLabelText[num22] = "Pyramids: Yes";
				}
				else if (Main.setting.IsPyramid == 0)
				{
					clickableLabelText[num22] = "Pyramids: No";
				}
				else if (Main.setting.IsPyramid == 2)
				{
					clickableLabelText[num22] = "Pyramids: Random";
				}
				if (main.selectedMenu == num22)
				{
					if (Main.setting.IsPyramid == 1)
					{
						Main.setting.IsPyramid = 0;
					}
					else if (Main.setting.IsPyramid == 2)
					{
						Main.setting.IsPyramid = 1;
					}
					else if (Main.setting.IsPyramid == 0)
					{
						Main.setting.IsPyramid = 2;
					}
				}

				num22++;
				if (Main.setting.IsGiantTree == 1)
				{
					clickableLabelText[num22] = "Giant Trees: Yes";
				}
				else if (Main.setting.IsGiantTree == 0)
				{
					clickableLabelText[num22] = "Giant Trees: No";
				}
				else if (Main.setting.IsGiantTree == 2)
				{
					clickableLabelText[num22] = "Giant Trees: Random";
				}
				if (main.selectedMenu == num22)
				{
					if (Main.setting.IsGiantTree == 1)
					{
						Main.setting.IsGiantTree = 0;
					}
					else if (Main.setting.IsGiantTree == 2)
					{
						Main.setting.IsGiantTree = 1;
					}
					else if (Main.setting.IsGiantTree == 0)
					{
						Main.setting.IsGiantTree = 2;
					}
				}

				num22++;
				array4[num22] = 30;
				clickableLabelText[num22] = Lang.menu[5];
				if (main.selectedMenu == num22)
				{
					Main.menuMode = (int)MenuModes.Settings;
				}
			}
			else if (Main.menuMode == (int)MenuModes.Settings)
			{
				num = 200;
				num3 = 35;
				numberClickableLabels = 15;  // increment this.
				array4[numberClickableLabels - 1] = 9;
				for (int num23 = 0; num23 < numberClickableLabels; num23++)
				{
					clickableLabelScale[num23] = 0.73f;
				}
				clickableLabelScale[numberClickableLabels - 1] = 0.93f;
				int num24 = 0;
				clickableLabelText[num24] = "Reset All";
				if (main.selectedMenu == num24)
				{
					Main.menuMode = (int)MenuModes.ResetAllSettings /*114*/;
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -18;
				num24++;

				clickableLabelText[num24] = "Terrain";
				if (main.selectedMenu == num24)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.Terrain;
				}
				num24++;

				clickableLabelText[num24] = "Ores";
				if (main.selectedMenu == num24)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.Ores /*112*/;
				}
				num24++;
				clickableLabelText[num24] = "Ore Amount";
				if (main.selectedMenu == num24)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.OreAmount /*14*/;
				}
				num24++;
				clickableLabelText[num24] = "Graphic Styles";
				if (main.selectedMenu == num24)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.GraphicStyles /*25*/;
				}
				num24++;
				clickableLabelText[num24] = "Backgrounds";
				if (main.selectedMenu == num24)
				{
					main.selectedMenu = -1;

					Main.menuMode = (int)MenuModes.Backgrounds /*26*/;
					//Main.menuMode = (int)MenuModes.SurfaceBackgrounds /*26*/;
				}
				//num24++;
				//array9[num24] = "Underground Backgrounds";
				//if (main.selectedMenu == num24)
				//{
				//	main.selectedMenu = -1;

				//	Main.menuMode = (int)MenuModes.UndergroundBackgrounds;
				//}
				num24++;
				clickableLabelText[num24] = "Miscellaneous";
				if (main.selectedMenu == num24)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.Miscellaneous /*1111*/;
				}
				num24++;
				clickableLabelText[num24] = "Challenge option";
				if (main.selectedMenu == num24)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.ChallengeOption /*113*/;
				}
				num24++;

				clickableLabelText[num24] = "Micro Biomes";
				if (main.selectedMenu == num24)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.MicroBiomes;
				}
				num24++;

				clickableLabelText[num24] = "Various Spawns";
				if (main.selectedMenu == num24)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.VariousSpawns;
				}
				num24++;

				clickableLabelText[num24] = "Downed Bosses/Found NPCs";
				if (main.selectedMenu == num24)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.DownedFound;
				}
				num24++;

				clickableLabelText[num24] = "Chests";
				if (main.selectedMenu == num24)
				{
					main.selectedMenu = -1;
					Main.menuMode = (int)MenuModes.Chests;
				}
				num24++;

				clickableLabelText[num24] = Lang.menu[5];
				if (main.selectedMenu == num24)
				{
					Main.menuMode = (int)MenuModes.ChooseWorldSize /*0*/;
				}
				num24++;
				clickableLabelText[num24] = Lang.menu[28];
				if (main.selectedMenu == num24)
				{
					Main.menuMode = 10;
					Main.worldName = Main.newWorldName;
					Main.ActiveWorldFileData = WorldFile.CreateMetadata(Main.worldName, false, Main.expertMode);
					WorldGen.CreateNewWorld(null);


					//   Main.worldName = Main.newWorldName;
					//  Main.worldPathName = Main.getWorldPathName(Main.worldName);
					//   WorldGen.CreateNewWorld();
				}
			}
			else if (Main.menuMode == (int)MenuModes.GraphicStyles/*25*/)
			{
				Main.dayTime = false;
				num = 200;
				num3 = 30;
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
					Main.spriteBatch.Draw(Main.moonTexture[Main.moonType], new Vector2(0, Main.screenHeight - Main.moonTexture[Main.moonType].Height), Microsoft.Xna.Framework.Color.White);
				}

				if (main.lastSelectedMenu == 2 || main.lastSelectedMenu == 3 || (WorldGen.worldSize > 0 && main.lastSelectedMenu == 4) || (WorldGen.worldSize > 1 && main.lastSelectedMenu == 5))
				{
					Main.spriteBatch.Draw(Main.TCTreeTops, new Vector2(0, Main.screenHeight - Main.TCTreeTops.Height), Microsoft.Xna.Framework.Color.White);
				}
				if (WorldGen.worldSize == 0)
				{
					if (main.lastSelectedMenu == 5 || main.lastSelectedMenu == 6 || main.lastSelectedMenu == 7)
					{
						Main.spriteBatch.Draw(Main.TCMossColors, new Vector2(0, Main.screenHeight - Main.TCMossColors.Height), Microsoft.Xna.Framework.Color.White);

					}
				}
				else if (WorldGen.worldSize == 1)
				{
					if (main.lastSelectedMenu == 6 || main.lastSelectedMenu == 7 || main.lastSelectedMenu == 8)
					{
						Main.spriteBatch.Draw(Main.TCMossColors, new Vector2(0, Main.screenHeight - Main.TCMossColors.Height), Microsoft.Xna.Framework.Color.White);

					}
				}
				else
				{
					if (main.lastSelectedMenu == 7 || main.lastSelectedMenu == 8 || main.lastSelectedMenu == 9)
					{
						Main.spriteBatch.Draw(Main.TCMossColors, new Vector2(0, Main.screenHeight - Main.TCMossColors.Height), Microsoft.Xna.Framework.Color.White);

					}
				}

				if (main.lastSelectedMenu == 4 + WorldGen.worldSize)
				{
					Main.spriteBatch.Draw(Main.TCDungeonColors, new Vector2(0, Main.screenHeight - Main.TCDungeonColors.Height), Microsoft.Xna.Framework.Color.White);
				}

			}

			else if (Main.menuMode == (int)MenuModes.SurfaceBackgrounds /*26*/)
			{
				{
					Main.dayTime = true;
					num = 200;
					num3 = 30;
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
						Main.menuMode = (int)MenuModes.Backgrounds /*11*/;
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
				num = 200;
				num3 = Main.rand.Next(0, 100);//  30;
				numberClickableLabels = 3;
				for (int num38 = 0; num38 < numberClickableLabels; num38++)
				{
					clickableLabelScale[num38] = 0.73f;
				}
				clickableLabelText[0] = "Reset Ore Amount";
				if (main.selectedMenu == 0)
				{
					WorldGen.initializeOreAmount();
				}
				clickableLabelScale[0] = 0.53f;
				array4[0] = -17;
				string text4 = "setting 100% will generate default amount of ores";
				int num39 = Main.screenWidth / 2 - 220;
				int num40 = 240;
				Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, text4, (float)num39, (float)num40, Microsoft.Xna.Framework.Color.White, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);

				if (!Main.setting.PreSmashAltarOreAlternates)
				{
					clickableLabelText[1] = "PreSmash Altars generates both sets of ores : Disabled";
				}
				else
				{
					clickableLabelText[1] = "PreSmash Altars generates both sets of ores : Enabled";
				}
				if (main.selectedMenu == 1)
				{
					Main.setting.PreSmashAltarOreAlternates = !Main.setting.PreSmashAltarOreAlternates;
				}

				clickableLabelText[2] = Lang.menu[5];
				if (main.selectedMenu == 2)
				{
					Main.menuMode = (int)MenuModes.Settings  /*11*/;
				}



				int num41 = num40 + 30;
				string text5 = "";
				for (int num42 = 0; num42 < 14; num42++)
				{
					int num43 = num41;
					int num44 = 390 + Main.screenWidth / 2 - 400;
					switch (num42)
					{
						case 0:
							text5 = "Copper/Tin:";
							break;
						case 1:
							text5 = "Iron/Lead:";
							num43 += 30;
							break;
						case 2:
							text5 = "Silver/Tungsten:";
							num43 += 60;
							break;
						case 3:
							text5 = "Gold/Platinum:";
							num43 += 90;
							break;
						case 4:
							text5 = "Demonite/Crimtane:";
							num43 += 120;
							break;
						case 5:
							text5 = "Hellstone:";
							num43 += 150;
							break;
						case 6:
							if (Main.setting.PreSmashAltar > 0f && (double)Main.setting.PreSmashAltar < 0.3)
							{
								text5 = "Generate a little";
							}
							else if ((double)Main.setting.PreSmashAltar >= 0.3 && (double)Main.setting.PreSmashAltar < 0.7)
							{
								text5 = "Generate medium amount";
							}
							else if ((double)Main.setting.PreSmashAltar >= 0.7)
							{
								text5 = "Generate a lot";
							}
							else if (Main.setting.PreSmashAltar == 0f)
							{
								text5 = "Generate none";
							}
							num43 += 250;
							break;
						case 7:
							text5 = "(Same amount as smashing " + Math.Round((double)(Main.setting.PreSmashAltar * 50f)) + " altars)";
							num43 += 280;
							break;
						case 8:
							text5 = Math.Round((double)(Main.setting.PercCopp * 100f)) + "%";
							num44 += 220;
							break;
						case 9:
							text5 = Math.Round((double)(Main.setting.PercIron * 100f)) + "%";
							num44 += 220;
							num43 += 30;
							break;
						case 10:
							text5 = Math.Round((double)(Main.setting.PercSilv * 100f)) + "%";
							num44 += 220;
							num43 += 60;
							break;
						case 11:
							text5 = Math.Round((double)(Main.setting.PercGold * 100f)) + "%";
							num44 += 220;
							num43 += 90;
							break;
						case 12:
							text5 = Math.Round((double)(Main.setting.PercDemonite * 100f)) + "%";
							num44 += 220;
							num43 += 120;
							break;
						case 13:
							text5 = Math.Round((double)(Main.setting.PercHellstone * 100f)) + "%";
							num44 += 220;
							num43 += 150;
							break;
					}
					num40 = num43;
					Microsoft.Xna.Framework.Color textColor2 = color;
					textColor2.R = (byte)((255 + textColor2.R) / 2);
					textColor2.G = (byte)((255 + textColor2.R) / 2);
					textColor2.B = (byte)((255 + textColor2.R) / 2);
					int num45 = 255;
					int num46 = (int)textColor2.R - (255 - num45);
					if (num46 < 0)
					{
						num46 = 0;
					}
					textColor2 = new Microsoft.Xna.Framework.Color((int)((byte)num46), (int)((byte)num46), (int)((byte)num46), (int)((byte)num45));
					Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, text5, (float)num44, (float)num43, textColor2, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);
				}
				text4 = "Option to generate alternate hardmode ores in the beginning";
				num39 = Main.screenWidth / 2 - 300;
				num40 += 70;
				Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, text4, (float)num39, (float)num40, Microsoft.Xna.Framework.Color.White, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);
				IngameOptions.rightHover = -1;
				if (!Main.mouseLeft)
				{
					IngameOptions.rightLock = -1;
				}

				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 40), (float)(num41 - 18 + 30));
				float percCopp = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, Main.setting.PercCopp / 5f);
				if (IngameOptions.inBar || IngameOptions.rightLock == 2)
				{
					IngameOptions.rightHover = 2;
					if (Main.mouseLeft && IngameOptions.rightLock == 2)
					{
						Main.setting.PercCopp = percCopp * 5f;
					}
				}
				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 40), (float)(num41 - 18 + 60));
				float percIron = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, Main.setting.PercIron / 5f);
				if (IngameOptions.inBar || IngameOptions.rightLock == 3)
				{
					IngameOptions.rightHover = 3;
					if (Main.mouseLeft && IngameOptions.rightLock == 3)
					{
						Main.setting.PercIron = percIron * 5f;
					}
				}
				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 40), (float)(num41 - 18 + 90));
				float percSilv = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, Main.setting.PercSilv / 5f);
				if (IngameOptions.inBar || IngameOptions.rightLock == 4)
				{
					IngameOptions.rightHover = 4;
					if (Main.mouseLeft && IngameOptions.rightLock == 4)
					{
						Main.setting.PercSilv = percSilv * 5f;
					}
				}
				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 40), (float)(num41 - 18 + 120));
				float percGold = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, Main.setting.PercGold / 5f);
				if (IngameOptions.inBar || IngameOptions.rightLock == 5)
				{
					IngameOptions.rightHover = 5;
					if (Main.mouseLeft && IngameOptions.rightLock == 5)
					{
						Main.setting.PercGold = percGold * 5f;
					}
				}

				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 40), (float)(num41 - 18 + 150));
				float percDemonite = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, Main.setting.PercDemonite / 5f);
				if (IngameOptions.inBar || IngameOptions.rightLock == 6)
				{
					IngameOptions.rightHover = 6;
					if (Main.mouseLeft && IngameOptions.rightLock == 6)
					{
						Main.setting.PercDemonite = percDemonite * 5f;
					}
				}
				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 40), (float)(num41 - 18 + 180));
				float percHellstone = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, Main.setting.PercHellstone / 5f);
				if (IngameOptions.inBar || IngameOptions.rightLock == 7)
				{
					IngameOptions.rightHover = 7;
					if (Main.mouseLeft && IngameOptions.rightLock == 7)
					{
						Main.setting.PercHellstone = percHellstone * 5f;
					}
				}

				IngameOptions.valuePosition = new Vector2((float)(Main.screenWidth / 2 - 40), (float)(num41 - 18 + 280));
				float preSmashAltar = IngameOptions.DrawValueBar(Main.spriteBatch, 1.3f, Main.setting.PreSmashAltar);
				if (IngameOptions.inBar || IngameOptions.rightLock == 8)
				{
					IngameOptions.rightHover = 8;
					if (Main.mouseLeft && IngameOptions.rightLock == 8)
					{
						Main.setting.PreSmashAltar = preSmashAltar;
					}
				}
				if (IngameOptions.rightHover != -1)
				{
					IngameOptions.rightLock = IngameOptions.rightHover;
				}
				array4[1] = 360;
				array4[2] = 390;
			}



		}

		private static int DrawSliders(int num40, int num41, Microsoft.Xna.Framework.Color textColor3, string[] labels, float[] ratios, Func<float>[] getters, Action<float>[] setters, Func<float, string>[] estimationString)
		{
			for (int i = 0; i < labels.Length; i++)
			{
				int yPos = num41;
				int xPos = 390 + Main.screenWidth / 2 - 400 - 100;
				// String 1
				yPos += 0 + i * 30;
				num40 = yPos;
				Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, labels[i], (float)xPos, (float)yPos, textColor3, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);

				// String 2
				xPos += 270;//180;
				Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontDeathText, estimationString[i](getters[i]()), (float)xPos, (float)yPos, textColor3, Microsoft.Xna.Framework.Color.Black, Vector2.Zero, 0.5f);

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

		private static void PreviewDraw(Texture2D texture2D, int position)
		{
			switch (position)
			{
				case 0:
					Main.spriteBatch.Draw(texture2D, new Vector2(0, 0), Microsoft.Xna.Framework.Color.White);
					break;
				case 1:
					Main.spriteBatch.Draw(texture2D, new Vector2(Main.screenWidth - texture2D.Width, 0), Microsoft.Xna.Framework.Color.White);
					break;
				case 2:
					Main.spriteBatch.Draw(texture2D, new Vector2(0, Main.screenHeight - texture2D.Height), Microsoft.Xna.Framework.Color.White);
					break;
				case 3:
					Main.spriteBatch.Draw(texture2D, new Vector2(Main.screenWidth - texture2D.Width, Main.screenHeight - texture2D.Height), Microsoft.Xna.Framework.Color.White);
					break;
				case 4:
					Main.spriteBatch.Draw(texture2D, new Vector2(0, Main.screenHeight / 2 - texture2D.Height / 2), Microsoft.Xna.Framework.Color.White);
					break;
				case 5:
					Main.spriteBatch.Draw(texture2D, new Vector2(Main.screenWidth - texture2D.Width, Main.screenHeight / 2 - texture2D.Height / 2), Microsoft.Xna.Framework.Color.White);
					break;
				default:
					Main.spriteBatch.Draw(texture2D, new Vector2(0, Main.screenHeight - texture2D.Height), Microsoft.Xna.Framework.Color.White);
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
