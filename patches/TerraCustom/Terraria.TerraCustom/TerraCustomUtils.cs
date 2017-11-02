using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using System;
using Terraria.Localization;

namespace Terraria.TerraCustom
{
	class TerraCustomUtils
	{
		internal static string TCText(string key)
		{
			return Language.GetTextValue("TerraCustom." + key);
		}

		internal static Texture2D GetEmbeddedTexture2D(string name)
		{
			return Texture2D.FromStream(Main.instance.GraphicsDevice, Assembly.GetExecutingAssembly().GetManifestResourceStream(name));
		}

		public static void findBackgrounds(int bg, int style)
		{
			if (bg == 0)
			{
				WorldGen.treeBG = style;
				Main.treeMntBG[0] = 7;
				Main.treeMntBG[1] = 8;
				if (style == 1)
				{
					Main.treeBG[0] = 50;
					Main.treeBG[1] = 51;
					Main.treeBG[2] = 52;
					return;
				}
				if (style == 2)
				{
					Main.treeBG[0] = 53;
					Main.treeBG[1] = 54;
					Main.treeBG[2] = 55;
					return;
				}
				if (style == 3)
				{
					Main.treeMntBG[1] = 90;
					Main.treeBG[0] = 91;
					Main.treeBG[1] = -1;
					Main.treeBG[2] = 92;
					return;
				}
				if (style == 9)
				{
					Main.treeMntBG[1] = 90;
					Main.treeBG[0] = 91;
					Main.treeBG[1] = -1;
					Main.treeBG[2] = 11;
					return;
				}
				if (style == 4)
				{
					Main.treeMntBG[0] = 93;
					Main.treeMntBG[1] = 94;
					Main.treeBG[0] = -1;
					Main.treeBG[1] = -1;
					Main.treeBG[2] = -1;
					return;
				}
				if (style == 5)
				{
					Main.treeMntBG[0] = 93;
					Main.treeMntBG[1] = 94;
					Main.treeBG[0] = -1;
					Main.treeBG[1] = -1;
					Main.treeBG[2] = 55;
					return;
				}
				if (style == 10)
				{
					Main.treeMntBG[0] = 93;
					Main.treeMntBG[1] = 94;
					Main.treeBG[0] = -1;
					Main.treeBG[1] = -1;
					Main.treeBG[2] = 11;
					return;
				}
				if (style == 6)
				{
					Main.treeMntBG[0] = 171;
					Main.treeMntBG[1] = 172;
					Main.treeBG[0] = 173;
					Main.treeBG[1] = -1;
					Main.treeBG[2] = -1;
					return;
				}
				if (style == 7)
				{
					Main.treeMntBG[0] = 176;
					Main.treeMntBG[1] = 177;
					Main.treeBG[0] = 178;
					Main.treeBG[1] = -1;
					Main.treeBG[2] = -1;
					return;
				}
				if (style == 11)
				{
					Main.treeMntBG[0] = 176;
					Main.treeMntBG[1] = 177;
					Main.treeBG[0] = 178;
					Main.treeBG[1] = -1;
					Main.treeBG[2] = 11;
					return;
				}
				if (style == 12)
				{
					Main.treeMntBG[0] = 176;
					Main.treeMntBG[1] = 177;
					Main.treeBG[0] = 178;
					Main.treeBG[1] = -1;
					Main.treeBG[2] = 52;
					return;
				}
				if (style == 13)
				{
					Main.treeMntBG[0] = 176;
					Main.treeMntBG[1] = 177;
					Main.treeBG[0] = 178;
					Main.treeBG[1] = -1;
					Main.treeBG[2] = 55;
					return;
				}
				if (style == 8)
				{
					Main.treeMntBG[0] = 179;
					Main.treeMntBG[1] = 180;
					Main.treeBG[0] = 184;
					Main.treeBG[1] = -1;
					Main.treeBG[2] = -1;
					return;
				}
				Main.treeBG[0] = 9;
				Main.treeBG[1] = 10;
				Main.treeBG[2] = 11;
				return;
			}
			else if (bg == 1)
			{
				WorldGen.corruptBG = style;
				if (style == 1)
				{
					Main.corruptBG[0] = 56;
					Main.corruptBG[1] = 57;
					Main.corruptBG[2] = 58;
					return;
				}
				Main.corruptBG[0] = 12;
				Main.corruptBG[1] = 13;
				Main.corruptBG[2] = 14;
				return;
			}
			else if (bg == 2)
			{
				WorldGen.jungleBG = style;
				if (style == 1)
				{
					Main.jungleBG[0] = 59;
					Main.jungleBG[1] = 60;
					Main.jungleBG[2] = 61;
					return;
				}
				Main.jungleBG[0] = 15;
				Main.jungleBG[1] = 16;
				Main.jungleBG[2] = 17;
				return;
			}
			else if (bg == 3)
			{
				WorldGen.snowBG = style;
				Main.snowMntBG[0] = 35;
				Main.snowMntBG[1] = 36;
				if (style == 1)
				{
					Main.snowBG[0] = 97;
					Main.snowBG[1] = 96;
					Main.snowBG[2] = 95;
					return;
				}
				if (style == 2)
				{
					Main.snowMntBG[0] = 98;
					Main.snowMntBG[1] = 99;
					Main.snowBG[0] = -1;
					Main.snowBG[1] = -1;
					Main.snowBG[2] = -1;
					return;
				}
				if (style == 3)
				{
					Main.snowMntBG[0] = 98;
					Main.snowMntBG[1] = 100;
					Main.snowBG[0] = -1;
					Main.snowBG[1] = -1;
					Main.snowBG[2] = -1;
					return;
				}
				if (style == 4)
				{
					Main.snowMntBG[0] = 98;
					Main.snowMntBG[1] = 101;
					Main.snowBG[0] = -1;
					Main.snowBG[1] = -1;
					Main.snowBG[2] = -1;
					return;
				}
				if (style == 5)
				{
					Main.snowMntBG[0] = 98;
					Main.snowMntBG[1] = 99;
					Main.snowBG[0] = 95;
					Main.snowBG[1] = 96;
					Main.snowBG[2] = 97;
					return;
				}
				if (style == 6)
				{
					Main.snowMntBG[0] = 98;
					Main.snowMntBG[1] = 99;
					Main.snowBG[0] = 37;
					Main.snowBG[1] = 38;
					Main.snowBG[2] = 39;
					return;
				}
				if (style == 7)
				{
					Main.snowMntBG[0] = 98;
					Main.snowMntBG[1] = 100;
					Main.snowBG[0] = 95;
					Main.snowBG[1] = 96;
					Main.snowBG[2] = 97;
					return;
				}
				if (style == 8)
				{
					Main.snowMntBG[0] = 98;
					Main.snowMntBG[1] = 100;
					Main.snowBG[0] = 37;
					Main.snowBG[1] = 38;
					Main.snowBG[2] = 39;
					return;
				}
				if (style == 9)
				{
					Main.snowMntBG[0] = 98;
					Main.snowMntBG[1] = 101;
					Main.snowBG[0] = 95;
					Main.snowBG[1] = 96;
					Main.snowBG[2] = 97;
					return;
				}
				if (style == 10)
				{
					Main.snowMntBG[0] = 98;
					Main.snowMntBG[1] = 101;
					Main.snowBG[0] = 37;
					Main.snowBG[1] = 38;
					Main.snowBG[2] = 39;
					return;
				}
				Main.snowBG[0] = 37;
				Main.snowBG[1] = 38;
				Main.snowBG[2] = 39;
				return;
			}
			else if (bg == 4)
			{
				WorldGen.hallowBG = style;
				if (style == 1)
				{
					Main.hallowBG[0] = 102;
					Main.hallowBG[1] = 103;
					Main.hallowBG[2] = 104;
					return;
				}
				Main.hallowBG[0] = 29;
				Main.hallowBG[1] = 30;
				Main.hallowBG[2] = 31;
				return;
			}
			else if (bg == 5)
			{
				WorldGen.crimsonBG = style;
				if (style == 1)
				{
					Main.crimsonBG[0] = 105;
					Main.crimsonBG[1] = 106;
					Main.crimsonBG[2] = 107;
					return;
				}
				if (style == 2)
				{
					Main.crimsonBG[0] = 174;
					Main.crimsonBG[1] = -1;
					Main.crimsonBG[2] = 175;
					return;
				}
				Main.crimsonBG[0] = 43;
				Main.crimsonBG[1] = 44;
				Main.crimsonBG[2] = 45;
				return;
			}
			else
			{
				if (bg != 6)
				{
					if (bg == 7)
					{
						WorldGen.oceanBG = style;
						if (style == 1)
						{
							Main.oceanBG = 110;
							return;
						}
						if (style == 2)
						{
							Main.oceanBG = 111;
							return;
						}
						Main.oceanBG = 28;
					}
					return;
				}
				WorldGen.desertBG = style;
				if (style == 1)
				{
					Main.desertBG[0] = 108;
					Main.desertBG[1] = 109;
					return;
				}
				Main.desertBG[0] = 21;
				Main.desertBG[1] = 20;
				return;
			}
		}

		public static int WorldSize
		{
			get
			{
				if (Main.maxTilesX <= 4200)
				{
					return 0;
				}
				else if (Main.maxTilesX <= 6400)
				{
					return 1;
				}
				else// (Main.maxTilesX <= 8400)
				{
					return 2;
				}
			}
		}

		internal static void FixTreeStyles()
		{
			if (Main.setting.SelectTreeStyle[0] != 6)
				Main.treeStyle[0] = Main.setting.SelectTreeStyle[0];

			if (Main.setting.SelectTreeStyle[1] != 6)
				Main.treeStyle[1] = Main.setting.SelectTreeStyle[1];

			if (WorldSize > 1)
			{
				if (Main.setting.SelectTreeStyle[2] != 6)
					Main.treeStyle[2] = Main.setting.SelectTreeStyle[2];
			}
			if (WorldSize > 2)
			{
				if (Main.setting.SelectTreeStyle[0] != 6)
					Main.treeStyle[3] = Main.setting.SelectTreeStyle[3];
			}
		}

		internal static void FixMossStyles()
		{
			if (Main.setting.SelectMossType0 != 5)
				WorldGen.mossType[0] = Main.setting.SelectMossType0;
			if (Main.setting.SelectMossType1 != 5)
				WorldGen.mossType[1] = Main.setting.SelectMossType1;
			if (Main.setting.SelectMossType2 != 5)
				WorldGen.mossType[2] = Main.setting.SelectMossType2;
		}
	}
}
