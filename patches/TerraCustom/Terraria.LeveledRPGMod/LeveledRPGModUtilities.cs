using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Terraria.ID;
using Terraria.Utilities;

namespace Terraria.LeveledRPGMod
{
	class LeveledRPGModUtilities
	{
		public static void saveEXP(bool useCloudSaving, string path)
		{
			//if (useCloudSaving && SocialAPI.Cloud == null)
			//{
			//	return;
			//}
			string text = path.Substring(0, path.Length - 4);
			string str = string.Concat(new object[]
			{
				text,
				".lvl" 
			});

			byte[] array = null;
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream(2000000))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					BitsByte bb = 0;
					binaryWriter.Write(Main.setting.LeveledRPGCriticalMode);
					binaryWriter.Write(Main.worldID);
					binaryWriter.Write(50);
					for (int i = 0; i < Main.maxTilesX; i++)
					{
						for (int j = 0; j < Main.maxTilesY; j += 8)
						{
							bb[0] = WorldSpawned(Main.tile[i, j]);
							if ((j + 1) <= Main.maxTilesY)
								bb[1] = WorldSpawned(Main.tile[i, j + 1]);
							if ((j + 2) <= Main.maxTilesY)
								bb[2] = WorldSpawned(Main.tile[i, j + 2]);
							if ((j + 3) <= Main.maxTilesY)
								bb[3] = WorldSpawned(Main.tile[i, j + 3]);
							if ((j + 4) <= Main.maxTilesY)
								bb[4] = WorldSpawned(Main.tile[i, j + 4]);
							if ((j + 5) <= Main.maxTilesY)
								bb[5] = WorldSpawned(Main.tile[i, j + 5]);
							if ((j + 6) <= Main.maxTilesY)
								bb[6] = WorldSpawned(Main.tile[i, j + 6]);
							if ((j + 7) <= Main.maxTilesY)
								bb[7] = WorldSpawned(Main.tile[i, j + 7]);
							binaryWriter.Write(bb);
						}
					}
				}
				array = memoryStream.ToArray();
				num = array.Length;
			}
			if (array == null)
			{
				return;
			}
			FileUtilities.Write(str, array, num, useCloudSaving);
		}

		public static bool WorldSpawned(Tile tile)
		{
			int type = tile.type;
			if (TileID.Sets.Ore[type] || (type == TileID.Obsidian) || (type == TileID.Sapphire) || (type == TileID.Ruby) || (type == TileID.Emerald) || (type == TileID.Topaz) || (type == TileID.Amethyst) || (type == TileID.Diamond))
			{
				return true;
			}
			return false;
		}
	}
}
