using System;

namespace Terraria
{
	internal class CustomScreen
	{
		private static bool isCorruption = true;
		private static string[] Menu;
		private static int selectedMenu = -1;

		public static void DrawCustomScreen()
		{
			CustomScreen.Menu = new string[Main.maxMenuItems];
			CustomScreen.optionBiome();
		}

		private static void optionBiome()
		{
			if (CustomScreen.isCorruption)
			{
				CustomScreen.Menu[0] = "is corruption";
			}
			else
			{
				CustomScreen.Menu[0] = "is crimson";
			}
			if (CustomScreen.selectedMenu == 0)
			{
				Main.PlaySound(12, -1, -1, 1);
				if (CustomScreen.isCorruption)
				{
					CustomScreen.isCorruption = false;
					return;
				}
				CustomScreen.isCorruption = true;
			}
		}

		private static void Accept()
		{
			Main.menuMode = 10;
			Main.worldName = Main.newWorldName;
			//Main.worldPathName = Main.GetWorldPathFromName(Main.worldName, false);
			//Main.worldPathName = Main.getWorldPathName(Main.worldName);
			WorldGen.CreateNewWorld();
		}
	}
}
