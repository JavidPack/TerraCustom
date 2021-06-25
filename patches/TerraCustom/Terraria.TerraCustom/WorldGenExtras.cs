using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.World.Generation;

namespace Terraria
{
	public partial class WorldGen
	{
		private static int[] fihSX = new int[1000];
		private static int[] fihSY = new int[1000];
		private static int[] fihST = new int[1000];
		private static int NIH = 0;
		private static bool[] skyLake2 = new bool[1000];

		public static void generateWorldPostFinalCleanup() {
			if (Main.setting.RandomizedTiles == true) {
				AddGenerationPass("Mixing Tiles", delegate (GenerationProgress progress) {
					progress.Message = "Mixing...";

					ushort[] TileBlacklistOrigin = {21, 3, 4, 5, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20,
						24, 26, 27, 28, 29, 31, 33, 34, 35, 36, 42, 49, 50, 55, 61, 62, 72, 73, 74, 77, 78,
						79, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101,
						102, 103, 104, 105, 106, 110, 113, 114, 125, 126, 128, 129, 130, 131, 132, 133, 134,
						135, 136, 137, 138, 139, 141, 142, 143, 144, 149, 165, 171, 172, 173, 174, 178, 184,
						185, 186, 187, 201, 207, 209, 210, 212, 215, 216, 217, 218, 219, 220, 227, 228, 231,
						233, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 254, 269, 270,
						271, 275, 276, 277, 278, 279, 280, 281, 282, 283, 285, 286, 287, 288, 289, 290, 291,
						292, 293, 294, 295, 296, 297, 298, 299, 300, 301, 302, 303, 304, 305, 306, 307, 308,
						309, 310, 314, 316, 317, 318, 319, 320, 323, 330, 331, 332, 333, 334, 335, 337, 338,
						339, 349, 354, 355, 356, 358, 359, 360, 361, 362, 363, 364, 372, 377, 373, 374, 375,
						376, 378, 379, 380, 386, 387, 388, 389, 390, 391, 392, 393, 394, 395, 405, 406, 410,
						411, 412, 413, 414, 419, 420, 423, 424, 425, 428, 429, 440, 441, 442, 443, 444, 445,
						452, 453, 454, 455, 456, 457, 461, 462, 463, 464, 465, 466, 467, 468, 469, 470, 471};

					List<ushort> TileBlacklist = new List<ushort>(TileBlacklistOrigin);

					ushort[] DiscoveredTiles = new ushort[1000];

					List<ushort> PossibleTiles = new List<ushort>{0, 1, 2, 6, 7, 8, 9, 22, 23, 25, 30, 32, 37, 38, 39, 40, 41,
						43, 44, 45, 46, 47, 48, 51, 53, 54, 56, 57, 58, 59, 60, 63, 64, 65, 66, 67, 68, 69, 70,
						75, 76, 107, 108, 109, 111, 112, 116, 117, 118, 119, 120, 121, 122, 123, 140, 145, 146,
						145, 146, 147, 148, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163,
						164, 166, 167, 168, 169, 170, 175, 176, 177, 179, 180, 181, 182, 183, 188, 189, 190, 191,
						192, 193, 194, 195, 196, 197, 198, 199, 200, 202, 203, 204, 206, 208, 211, 221, 222, 223,
						224, 225, 226, 229, 230, 232, 234, 248, 249, 250, 251, 252, 253, 255, 256, 257, 258, 259,
						260, 261, 262, 263, 264, 265, 266, 267, 268, 272, 273, 274, 284, 311, 312, 313, 315, 321,
						322, 325, 346, 347, 348, 350, 357, 367, 368, 369, 370, 371, 381, 383, 384, 385, 396, 397,
						398, 399, 400, 401, 402, 403, 404, 407, 408, 409, 415, 416, 417, 418, 421, 422, 426, 430,
						431, 432, 433, 434, 446, 447, 448, 460};

					var random = new Random();
					for (int l = 0; l < Main.maxTilesX; l++) {
						for (int m = 0; m < Main.maxTilesY; m++) {
							if (Main.tile[l, m].active()) {
								ushort oldType = Main.tile[l, m].type;
								if (!TileBlacklist.Contains(oldType)) {
									ushort newType;
									if ((DiscoveredTiles)[oldType] == 0) {
										int newID = random.Next(PossibleTiles.Count);
										newType = PossibleTiles[newID];
										PossibleTiles.RemoveAt(newID);
										DiscoveredTiles[oldType] = (ushort)(newType + 1);
									}
									else {
										newType = (ushort)(DiscoveredTiles[oldType] - 1);
									}
									Main.tile[l, m].type = newType;
								}
							}
						}
					}
				});
			}


			if (Main.setting.RandomizedTiles == false && Main.setting.SwappedTiles == true) {
				WorldGen.AddGenerationPass("Swapping Tiles", delegate (GenerationProgress progress) {
					progress.Message = "Swapping...";

					ushort[] TileBlacklistOrigin = {21, 3, 4, 5, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20,
						24, 26, 27, 28, 29, 31, 33, 34, 35, 36, 42, 49, 50, 55, 61, 62, 72, 73, 74, 77, 78,
						79, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101,
						102, 103, 104, 105, 106, 110, 113, 114, 125, 126, 128, 129, 130, 131, 132, 133, 134,
						135, 136, 137, 138, 139, 141, 142, 143, 144, 149, 165, 171, 172, 173, 174, 178, 184,
						185, 186, 187, 201, 207, 209, 210, 212, 215, 216, 217, 218, 219, 220, 227, 228, 231,
						233, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 254, 269, 270,
						271, 275, 276, 277, 278, 279, 280, 281, 282, 283, 285, 286, 287, 288, 289, 290, 291,
						292, 293, 294, 295, 296, 297, 298, 299, 300, 301, 302, 303, 304, 305, 306, 307, 308,
						309, 310, 314, 316, 317, 318, 319, 320, 323, 330, 331, 332, 333, 334, 335, 337, 338,
						339, 349, 354, 355, 356, 358, 359, 360, 361, 362, 363, 364, 372, 377, 373, 374, 375,
						376, 378, 379, 380, 386, 387, 388, 389, 390, 391, 392, 393, 394, 395, 405, 406, 410,
						411, 412, 413, 414, 419, 420, 423, 424, 425, 428, 429, 440, 441, 442, 443, 444, 445,
						452, 453, 454, 455, 456, 457, 461, 462, 463, 464, 465, 466, 467, 468, 469, 470, 471};

					List<ushort> TileBlacklist = new List<ushort>(TileBlacklistOrigin);

					ushort[] DiscoveredTiles = new ushort[1000];
					List<int> SortedList = new List<int>();

					for (int l = 0; l < Main.maxTilesX; l++) {
						for (int m = 0; m < Main.maxTilesY; m++) {
							if (Main.tile[l, m].active()) {
								ushort oldType = Main.tile[l, m].type;
								if (!TileBlacklist.Contains(oldType)) {

									DiscoveredTiles[oldType] = (ushort)(DiscoveredTiles[oldType] + 1);

								}
							}
						}
					}

					bool E = true;

					while (E == true) {
						int biggestCOUNT = 0;
						int biggestPOS = -1;

						for (int i = 0; i < new List<ushort>(DiscoveredTiles).Count; i++) {
							if (DiscoveredTiles[i] > (ushort)biggestCOUNT) {
								biggestPOS = i;
								biggestCOUNT = (int)DiscoveredTiles[i];
							}
						}
						if (biggestPOS >= 0) {
							SortedList.Add(biggestPOS);
							DiscoveredTiles[biggestPOS] = (ushort)0;
						}
						else {
							E = false;
						}
					}

					while (SortedList.Count > 0) {
						DiscoveredTiles[SortedList[0]] = (ushort)(SortedList[SortedList.Count - 1] + 1);
						DiscoveredTiles[SortedList[SortedList.Count - 1]] = (ushort)(SortedList[0] + 1);
						SortedList.RemoveAt(SortedList.Count - 1);
						if (SortedList.Count > 0) {
							SortedList.RemoveAt(0);
						}
					}

					for (int l = 0; l < Main.maxTilesX; l++) {
						for (int m = 0; m < Main.maxTilesY; m++) {
							if (Main.tile[l, m].active()) {
								ushort oldType = Main.tile[l, m].type;
								if (!TileBlacklist.Contains(oldType)) {
									if ((DiscoveredTiles)[oldType] != 0) {
										Main.tile[l, m].type = (ushort)(DiscoveredTiles[oldType] - 1);
									}
								}
							}
						}
					}
				});
			}
			if (Main.setting.FlippedWorld == true) {
				WorldGen.AddGenerationPass("Flipping World", delegate (GenerationProgress progress) {
					progress.Message = "Turning World Upside-Down...";

					for (int l = 0; l < Main.maxTilesX; l++) {
						for (int m = 1; m < Main.maxTilesY / 2; m++) {
							//bool TileAActive = Main.tile[l, m].active();
							//bool TileBActive = Main.tile[l, Main.maxTilesY - m].active();
							if ((Main.tile[l, m].type == 21 && Main.tile[l, m + 1].type == 21) || (Main.tile[l, m].type == 12 && Main.tile[l, m + 1].type == 12) ||
							(Main.tile[l, m].type == 28 && Main.tile[l, m + 1].type == 28) || (Main.tile[l, m].type == 31 && Main.tile[l, m + 1].type == 31)) {
								Tile oldTile2 = Main.tile[l, m];
								Main.tile[l, m] = Main.tile[l, m + 1];
								Main.tile[l, m + 1] = oldTile2;
							}
							if ((Main.tile[l, Main.maxTilesY - m].type == 21 && Main.tile[l, Main.maxTilesY - m - 1].type == 21) ||
							(Main.tile[l, Main.maxTilesY - m].type == 12 && Main.tile[l, Main.maxTilesY - m - 1].type == 12) ||
							(Main.tile[l, Main.maxTilesY - m].type == 28 && Main.tile[l, Main.maxTilesY - m - 1].type == 28) ||
							(Main.tile[l, Main.maxTilesY - m].type == 31 && Main.tile[l, Main.maxTilesY - m - 1].type == 31)) {
								Tile oldTile3 = Main.tile[l, Main.maxTilesY - m];
								Main.tile[l, Main.maxTilesY - m] = Main.tile[l, Main.maxTilesY - m - 1];
								Main.tile[l, Main.maxTilesY - m - 1] = oldTile3;
							}
							Tile oldTile = Main.tile[l, m];
							Main.tile[l, m] = Main.tile[l, Main.maxTilesY - m];
							Main.tile[l, Main.maxTilesY - m] = oldTile;
							//if (!TileAActive) {
							//    Main.tile[l, Main.maxTilesY - m] = Main.tile[0, 0];
							//}
							//if (!TileBActive) {
							//    Main.tile[l, m] = Main.tile[0, 0];
							//}
						}
					}
				});
			}
			if (!(Main.setting.CorruptedWorld == 0)) {
				WorldGen.AddGenerationPass("Corrupting World", delegate (GenerationProgress progress) {
					progress.Message = "Making the world truely evil...";


					List<int> EffectedTiles = new List<int> { 69, 396, 397, 53, 161, 59, 1, 2, 60 };

					ushort[] ResultingTiles = new ushort[400];

					if (Main.setting.CorruptedWorld == 1) { // corruption
						ResultingTiles[69] = 32;
						ResultingTiles[396] = 400;
						ResultingTiles[397] = 398;
						ResultingTiles[53] = 112;
						ResultingTiles[161] = 163;
						ResultingTiles[59] = 0;
						ResultingTiles[1] = 25;
						ResultingTiles[2] = 23;
						ResultingTiles[60] = 23;
						//ResultingTiles.AddRange(new List<ushort> { 32, 400, 398, 112, 163, 0, 25, 23});
					}
					else {
						ResultingTiles[69] = 352;
						ResultingTiles[396] = 401;
						ResultingTiles[397] = 399;
						ResultingTiles[53] = 116;
						ResultingTiles[161] = 164;
						ResultingTiles[59] = 0;
						ResultingTiles[1] = 203;
						ResultingTiles[2] = 199;
						ResultingTiles[60] = 199;
						//ResultingTiles.AddRange(new List<ushort> { 352, 401, 399, 116, 164, 0, 203, 199});
					}



					var random = new Random();
					for (int l = 0; l < Main.maxTilesX; l++) {
						for (int m = 0; m < Main.maxTilesY; m++) {
							if (Main.tile[l, m].active()) {
								ushort oldType = Main.tile[l, m].type;
								if (EffectedTiles.Contains(oldType)) {
									Main.tile[l, m].type = ResultingTiles[oldType];
								}
							}
						}
					}
				});
			}

			if (false) { // currently unused because this, isn't fair...
				WorldGen.AddGenerationPass("Limbo World", delegate (GenerationProgress progress) {
					progress.Message = "Darkening...";

					for (int l = 0; l < Main.maxTilesX; l++) {
						for (int m = 1; m < Main.maxTilesY; m++) {
							if (Main.tile[l, m].active()) {
								WorldGen.paintTile(l, m, 29);
							}
							if (Main.tile[l, m].wall != 0) {
								WorldGen.paintWall(l, m, 29);
							}
							//Main.tile[l, m]. = paintColor(29);
						}
					}
				});
			}

			//AddGenerationPass("PAUSABLE", delegate (GenerationProgress progress) {
			//    progress.Message = "Doing Literally Nothing...";
			//    Main.tile[0, 0] = Main.tile[0, 0];
			//}); // this is for testing so i can see the results without having to use something like TEdit
		}


		private static void SpecialIslands(GenerationProgress progress) {
			//});

			//AddGenerationPass("Special Islands A", delegate (GenerationProgress progress) {
			//numIslandHouses = 0;
			//houseCount = 0;
			//int SnowCount = 0;
			progress.Message = "Sending Special Islands Into Orbit";
			if (Math.Floor(Main.setting.SnowIslands) > 0) {
				for (int num591 = 0; num591 < Math.Floor(Main.setting.SnowIslands); num591++) {
					int num592 = 1000;
					int num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
					while (--num592 > 0) {
						bool flag45 = true;
						while (num593 > Main.maxTilesX / 2 - 80 && num593 < Main.maxTilesX / 2 + 80) {
							num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
						}

						for (int num594 = 0; num594 < numIslandHouses; num594++) {
							if (num593 > fihX[num594] - 120 && num593 < fihX[num594] + 120) {
								flag45 = false;
								break;
							}
						}

						if (flag45) {
							flag45 = false;
							int num595 = 0;
							for (int num596 = 200; (double)num596 < Main.worldSurface; num596++) {
								if (Main.tile[num593, num596].active()) {
									num595 = num596;
									flag45 = true;
									break;
								}
							}

							if (flag45) {
								int val = genRand.Next(90, num595 - 100);
								val = Math.Min(val, (int)worldSurfaceLow - 50);
								if (val < 30) continue;
								//if (SnowCount < Math.Floor(Main.setting.SnowIslands)) {
								try { SnowIsland(num593, val); } catch { }
								//}

								fihX[numIslandHouses] = num593;
								fihY[numIslandHouses] = val;
								fihT[numIslandHouses] = 0;
								numIslandHouses++;
							}
						}
					}
				}
			}
			progress.Set(1 / 7f);
			if (Math.Floor(Main.setting.SandIslands) > 0) {
				for (int num591 = 0; num591 < Math.Floor(Main.setting.SandIslands); num591++) {
					int num592 = 1000;
					int num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
					while (--num592 > 0) {
						bool flag45 = true;
						while (num593 > Main.maxTilesX / 2 - 80 && num593 < Main.maxTilesX / 2 + 80) {
							num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
						}

						for (int num594 = 0; num594 < numIslandHouses; num594++) {
							if (num593 > fihX[num594] - 180 && num593 < fihX[num594] + 180) {
								flag45 = false;
								break;
							}
						}

						if (flag45) {
							flag45 = false;
							int num595 = 0;
							for (int num596 = 200; (double)num596 < Main.worldSurface; num596++) {
								if (Main.tile[num593, num596].active()) {
									num595 = num596;
									flag45 = true;
									break;
								}
							}

							if (flag45) {
								int val = genRand.Next(90, num595 - 100);
								val = Math.Min(val, (int)worldSurfaceLow - 50);
								if (val < 30) continue;
								//if (SnowCount < Math.Floor(Main.setting.SnowIslands)) {
								try { WorldGen.SandIsland(num593, val); } catch { }
								//}

								fihX[numIslandHouses] = num593;
								fihY[numIslandHouses] = val;
								fihT[numIslandHouses] = 0;
								numIslandHouses++;
							}
						}
					}
				}
			}
			progress.Set(2 / 7f);
			if (Math.Floor(Main.setting.JungleIslands) > 0) {
				for (int num591 = 0; num591 < Math.Floor(Main.setting.JungleIslands); num591++) {
					int num592 = 1000;
					int num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
					while (--num592 > 0) {
						bool flag45 = true;
						while (num593 > Main.maxTilesX / 2 - 80 && num593 < Main.maxTilesX / 2 + 80) {
							num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
						}

						for (int num594 = 0; num594 < numIslandHouses; num594++) {
							if (num593 > fihX[num594] - 120 && num593 < fihX[num594] + 120) {
								flag45 = false;
								break;
							}
						}

						if (flag45) {
							flag45 = false;
							int num595 = 0;
							for (int num596 = 200; (double)num596 < Main.worldSurface; num596++) {
								if (Main.tile[num593, num596].active()) {
									num595 = num596;
									flag45 = true;
									break;
								}
							}

							if (flag45) {
								int val = genRand.Next(90, num595 - 100);
								val = Math.Min(val, (int)worldSurfaceLow - 50);
								if (val < 30) continue;
								//if (SnowCount < Math.Floor(Main.setting.SnowIslands)) {
								try { WorldGen.SpecialIsland(num593, val, 59, 196, 1, 189, true, 60); } catch { }
								//}

								fihX[numIslandHouses] = num593;
								fihY[numIslandHouses] = val;
								fihT[numIslandHouses] = 0;
								numIslandHouses++;
							}
						}
					}
				}
			}
			progress.Set(3 / 7f);
			if (Math.Floor(Main.setting.MushroomIslands) > 0) {
				for (int num591 = 0; num591 < Math.Floor(Main.setting.MushroomIslands); num591++) {
					int num592 = 1000;
					int num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
					while (--num592 > 0) {
						bool flag45 = true;
						while (num593 > Main.maxTilesX / 2 - 80 && num593 < Main.maxTilesX / 2 + 80) {
							num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
						}

						for (int num594 = 0; num594 < numIslandHouses; num594++) {
							if (num593 > fihX[num594] - 120 && num593 < fihX[num594] + 120) {
								flag45 = false;
								break;
							}
						}

						if (flag45) {
							flag45 = false;
							int num595 = 0;
							for (int num596 = 200; (double)num596 < Main.worldSurface; num596++) {
								if (Main.tile[num593, num596].active()) {
									num595 = num596;
									flag45 = true;
									break;
								}
							}

							if (flag45) {
								int val = genRand.Next(90, num595 - 100);
								val = Math.Min(val, (int)worldSurfaceLow - 50);
								if (val < 30) continue;
								//if (SnowCount < Math.Floor(Main.setting.SnowIslands)) {
								try { WorldGen.SpecialIsland(num593, val, 59, 196, 1, 189, true, 70); } catch { }
								//}

								fihX[numIslandHouses] = num593;
								fihY[numIslandHouses] = val;
								fihT[numIslandHouses] = 0;
								numIslandHouses++;
							}
						}
					}
				}
			}
			progress.Set(4 / 7f);
			if (Math.Floor(Main.setting.RainIslands) > 0) {
				for (int num591 = 0; num591 < Math.Floor(Main.setting.RainIslands); num591++) {
					int num592 = 1000;
					int num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
					while (--num592 > 0) {
						bool flag45 = true;
						while (num593 > Main.maxTilesX / 2 - 80 && num593 < Main.maxTilesX / 2 + 80) {
							num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
						}

						for (int num594 = 0; num594 < numIslandHouses; num594++) {
							if (num593 > fihX[num594] - 120 && num593 < fihX[num594] + 120) {
								flag45 = false;
								break;
							}
						}

						if (flag45) {
							flag45 = false;
							int num595 = 0;
							for (int num596 = 200; (double)num596 < Main.worldSurface; num596++) {
								if (Main.tile[num593, num596].active()) {
									num595 = num596;
									flag45 = true;
									break;
								}
							}

							if (flag45) {
								int val = genRand.Next(90, num595 - 100);
								val = Math.Min(val, (int)worldSurfaceLow - 50);
								if (val < 30) continue;
								//if (SnowCount < Math.Floor(Main.setting.SnowIslands)) {
								try { WorldGen.SpecialIsland(num593, val, 0, 189, 1, 196, false, 70); } catch { }
								//}

								fihX[numIslandHouses] = num593;
								fihY[numIslandHouses] = val;
								fihT[numIslandHouses] = 0;
								numIslandHouses++;
							}
						}
					}
				}
			}
			progress.Set(5 / 7f);
			if (Math.Floor(Main.setting.Snow2Islands) > 0) {
				for (int num591 = 0; num591 < Math.Floor(Main.setting.Snow2Islands); num591++) {
					int num592 = 1000;
					int num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
					while (--num592 > 0) {
						bool flag45 = true;
						while (num593 > Main.maxTilesX / 2 - 80 && num593 < Main.maxTilesX / 2 + 80) {
							num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
						}

						for (int num594 = 0; num594 < numIslandHouses; num594++) {
							if (num593 > fihX[num594] - 120 && num593 < fihX[num594] + 120) {
								flag45 = false;
								break;
							}
						}

						if (flag45) {
							flag45 = false;
							int num595 = 0;
							for (int num596 = 200; (double)num596 < Main.worldSurface; num596++) {
								if (Main.tile[num593, num596].active()) {
									num595 = num596;
									flag45 = true;
									break;
								}
							}

							if (flag45) {
								int val = genRand.Next(90, num595 - 100);
								val = Math.Min(val, (int)worldSurfaceLow - 50);
								if (val < 30) continue;
								//if (SnowCount < Math.Floor(Main.setting.SnowIslands)) {
								try { WorldGen.SpecialIsland(num593, val, 147, 189, 1, 460, false, 70); } catch { }
								//}

								fihX[numIslandHouses] = num593;
								fihY[numIslandHouses] = val;
								fihT[numIslandHouses] = 0;
								numIslandHouses++;
							}
						}
					}
				}
			}
			progress.Set(6 / 7f);
			if (Math.Floor(Main.setting.UnderworldIslands) > 0) {
				for (int num591 = 0; num591 < Math.Floor(Main.setting.UnderworldIslands); num591++) {
					int num592 = 1000;
					int num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
					while (--num592 > 0) {
						bool flag45 = true;
						while (num593 > Main.maxTilesX / 2 - 80 && num593 < Main.maxTilesX / 2 + 80) {
							num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
						}

						for (int num594 = 0; num594 < numIslandHouses; num594++) {
							if (num593 > fihX[num594] - 120 && num593 < fihX[num594] + 120) {
								flag45 = false;
								break;
							}
						}

						if (flag45) {
							flag45 = false;
							int num595 = 0;
							for (int num596 = 200; (double)num596 < Main.worldSurface; num596++) {
								if (Main.tile[num593, num596].active()) {
									num595 = num596;
									flag45 = true;
									break;
								}
							}

							if (flag45) {
								int val = genRand.Next(90, num595 - 100);
								val = Math.Min(val, (int)worldSurfaceLow - 50);
								if (val < 30) continue;
								//if (SnowCount < Math.Floor(Main.setting.SnowIslands)) {
								try { WorldGen.SpecialIsland(num593, val, 57, 58, 2, 189, false, 70, 25); } catch { }
								//}

								fihX[numIslandHouses] = num593;
								fihY[numIslandHouses] = val;
								fihT[numIslandHouses] = 1;
								numIslandHouses++;
							}
						}
					}
				}
			}
			progress.Set(6 / 7f);
			if (0 > 0) {
				for (int num591 = 0; num591 < 2; num591++) {
					int num592 = 1000;
					int num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
					while (--num592 > 0) {
						bool flag45 = true;
						while (num593 > Main.maxTilesX / 2 - 80 && num593 < Main.maxTilesX / 2 + 80) {
							num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
						}

						for (int num594 = 0; num594 < numIslandHouses; num594++) {
							if (num593 > fihX[num594] - 120 && num593 < fihX[num594] + 120) {
								flag45 = false;
								break;
							}
						}

						if (flag45) {
							flag45 = false;
							int num595 = 0;
							for (int num596 = 200; (double)num596 < Main.worldSurface; num596++) {
								if (Main.tile[num593, num596].active()) {
									num595 = num596;
									flag45 = true;
									break;
								}
							}

							if (flag45) {
								int val = genRand.Next(90, num595 - 100);
								val = Math.Min(val, (int)worldSurfaceLow - 50);
								if (val < 30) continue;
								//if (SnowCount < Math.Floor(Main.setting.SnowIslands)) {
								try { WorldGen.SpecialIsland(num593, val, 189, 196, 1, 189, false, 70, 0); } catch { }
								//}

								fihX[numIslandHouses] = num593;
								fihY[numIslandHouses] = val;
								fihT[numIslandHouses] = 0;
								numIslandHouses++;
							}
						}
					}
				}
			}
			progress.Set(6 / 7f);
			if (0 > 0) {
				for (int num591 = 0; num591 < 2; num591++) {
					int num592 = 1000;
					int num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
					while (--num592 > 0) {
						bool flag45 = true;
						while (num593 > Main.maxTilesX / 2 - 80 && num593 < Main.maxTilesX / 2 + 80) {
							num593 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
						}

						for (int num594 = 0; num594 < numIslandHouses; num594++) {
							if (num593 > fihX[num594] - 120 && num593 < fihX[num594] + 120) {
								flag45 = false;
								break;
							}
						}

						if (flag45) {
							flag45 = false;
							int num595 = 0;
							for (int num596 = 200; (double)num596 < Main.worldSurface; num596++) {
								if (Main.tile[num593, num596].active()) {
									num595 = num596;
									flag45 = true;
									break;
								}
							}

							if (flag45) {
								int val = genRand.Next(90, num595 - 100);
								val = Math.Min(val, (int)worldSurfaceLow - 50);
								if (val < 30) continue;
								//if (SnowCount < Math.Floor(Main.setting.SnowIslands)) {
								try { WorldGen.SpecialIsland(num593, val, 189, 189, 5, 189, false, 70, 0); } catch { }
								//}

								fihX[numIslandHouses] = num593;
								fihY[numIslandHouses] = val;
								fihT[numIslandHouses] = 0;
								numIslandHouses++;
							}
						}
					}
				}
			}
			//int P2 = 0; this is for something i wanted to do, i might make this into a setting eventually
			//for (int Pos = 0; Pos < 999; Pos++) {
			//	if (fihX[Pos] == 0) {
			//if (P2 == 0) {
			//P2 = Pos;
			//}
			//fihX[Pos] = fihSX[Pos - P2];
			//fihY[Pos] = fihSY[Pos - P2];
			//fihT[Pos] = fihST[Pos - P2];
			//skyLake[Pos] = skyLake2[Pos - P2];
			//}
			//}
			//numIslandHouses = numIslandHouses + NIH;
		}

		public static void SnowIsland(int i, int j) {
			double num = WorldGen.genRand.Next(100, 150);
			double num2 = num;
			float num3 = genRand.Next(20, 30);
			int num4 = i;
			int num5 = i;
			int num6 = i;
			int num7 = j;
			Vector2 vector = default(Vector2);
			vector.X = i;
			vector.Y = j;
			Vector2 vector2 = default(Vector2);
			vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			while (vector2.X > -2f && vector2.X < 2f) {
				vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			}

			vector2.Y = (float)genRand.Next(-20, -10) * 0.02f;
			while (num > 0.0 && num3 > 0f) {
				num -= (double)genRand.Next(4);
				num3 -= 1f;
				int num8 = (int)((double)vector.X - num * 0.5);
				int num9 = (int)((double)vector.X + num * 0.5);
				int num10 = (int)((double)vector.Y - num * 0.5);
				int num11 = (int)((double)vector.Y + num * 0.5);
				if (num8 < 0)
					num8 = 0;

				if (num9 > Main.maxTilesX)
					num9 = Main.maxTilesX;

				if (num10 < 0)
					num10 = 0;

				if (num11 > Main.maxTilesY)
					num11 = Main.maxTilesY;

				num2 = num * (double)genRand.Next(80, 120) * 0.01;
				float num12 = vector.Y + 1f;
				for (int k = num8; k < num9; k++) {
					if (genRand.Next(2) == 0)
						num12 += (float)genRand.Next(-1, 2);

					if (num12 < vector.Y)
						num12 = vector.Y;

					if (num12 > vector.Y + 2f)
						num12 = vector.Y + 2f;

					for (int l = num10; l < num11; l++) {
						if (!((float)l > num12))
							continue;

						float num13 = Math.Abs((float)k - vector.X);
						float num14 = Math.Abs((float)l - vector.Y) * 3f;
						if (Math.Sqrt(num13 * num13 + num14 * num14) < num2 * 0.4) {
							if (k < num4)
								num4 = k;

							if (k > num5)
								num5 = k;

							if (l < num6)
								num6 = l;

							if (l > num7)
								num7 = l;

							Main.tile[k, l].active(active: true);
							Main.tile[k, l].type = 189;
							SquareTileFrame(k, l);
						}
					}
				}

				vector += vector2;
				vector2.X += (float)genRand.Next(-20, 21) * 0.05f;
				if (vector2.X > 1f)
					vector2.X = 1f;

				if (vector2.X < -1f)
					vector2.X = -1f;

				if ((double)vector2.Y > 0.2)
					vector2.Y = -0.2f;

				if ((double)vector2.Y < -0.2)
					vector2.Y = -0.2f;
			}

			int num15 = num4;
			int num17;
			for (num15 += genRand.Next(5); num15 < num5; num15 += genRand.Next(num17, (int)((double)num17 * 1.5))) {
				int num16 = num7;
				while (!Main.tile[num15, num16].active()) {
					num16--;
				}

				num16 += genRand.Next(-3, 4);
				num17 = genRand.Next(4, 8);
				int num18 = 189;
				if (genRand.Next(4) == 0)
					num18 = 460;

				for (int m = num15 - num17; m <= num15 + num17; m++) {
					for (int n = num16 - num17; n <= num16 + num17; n++) {
						if (n > num6) {
							float num19 = Math.Abs(m - num15);
							float num20 = Math.Abs(n - num16) * 2;
							if (Math.Sqrt(num19 * num19 + num20 * num20) < (double)(num17 + genRand.Next(2))) {
								Main.tile[m, n].active(active: true);
								Main.tile[m, n].type = (ushort)num18;
								SquareTileFrame(m, n);
							}
						}
					}
				}
			}

			num = genRand.Next(80, 95);
			num2 = num;
			num3 = genRand.Next(10, 15);
			vector.X = i;
			vector.Y = num6;
			vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			while (vector2.X > -2f && vector2.X < 2f) {
				vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			}

			vector2.Y = (float)genRand.Next(-20, -10) * 0.02f;
			while (num > 0.0 && num3 > 0f) {
				num -= (double)genRand.Next(4);
				num3 -= 1f;
				int num8 = (int)((double)vector.X - num * 0.5);
				int num9 = (int)((double)vector.X + num * 0.5);
				int num10 = num6 - 1;
				int num11 = (int)((double)vector.Y + num * 0.5);
				if (num8 < 0)
					num8 = 0;

				if (num9 > Main.maxTilesX)
					num9 = Main.maxTilesX;

				if (num10 < 0)
					num10 = 0;

				if (num11 > Main.maxTilesY)
					num11 = Main.maxTilesY;

				num2 = num * (double)genRand.Next(80, 120) * 0.01;
				float num21 = vector.Y + 1f;
				for (int num22 = num8; num22 < num9; num22++) {
					if (genRand.Next(2) == 0)
						num21 += (float)genRand.Next(-1, 2);

					if (num21 < vector.Y)
						num21 = vector.Y;

					if (num21 > vector.Y + 2f)
						num21 = vector.Y + 2f;

					for (int num23 = num10; num23 < num11; num23++) {
						if ((float)num23 > num21) {
							float num24 = Math.Abs((float)num22 - vector.X);
							float num25 = Math.Abs((float)num23 - vector.Y) * 3f;
							if (Math.Sqrt(num24 * num24 + num25 * num25) < num2 * 0.4 && Main.tile[num22, num23].type == 189) {
								Main.tile[num22, num23].type = 147;
								SquareTileFrame(num22, num23);
							}
						}
					}
				}

				vector += vector2;
				vector2.X += (float)genRand.Next(-20, 21) * 0.05f;
				if (vector2.X > 1f)
					vector2.X = 1f;

				if (vector2.X < -1f)
					vector2.X = -1f;

				if ((double)vector2.Y > 0.2)
					vector2.Y = -0.2f;

				if ((double)vector2.Y < -0.2)
					vector2.Y = -0.2f;
			}

			int num26 = num4;
			num26 += genRand.Next(5);
			while (num26 < num5) {
				int num27 = num7;
				while ((!Main.tile[num26, num27].active() || Main.tile[num26, num27].type != 147) && num26 < num5) {
					num27--;
					if (num27 < num6) {
						num27 = num7;
						num26 += genRand.Next(1, 4);
					}
				}

				if (num26 >= num5)
					continue;

				num27 += genRand.Next(0, 4);
				int num28 = genRand.Next(2, 5);
				int num29 = 189;
				for (int num30 = num26 - num28; num30 <= num26 + num28; num30++) {
					for (int num31 = num27 - num28; num31 <= num27 + num28; num31++) {
						if (num31 > num6) {
							float num32 = Math.Abs(num30 - num26);
							float num33 = Math.Abs(num31 - num27) * 2;
							if (Math.Sqrt(num32 * num32 + num33 * num33) < (double)num28) {
								Main.tile[num30, num31].type = (ushort)num29;
								SquareTileFrame(num30, num31);
							}
						}
					}
				}

				num26 += genRand.Next(num28, (int)((double)num28 * 1.5));
			}

			for (int num34 = num4 - 20; num34 <= num5 + 20; num34++) {
				for (int num35 = num6 - 20; num35 <= num7 + 20; num35++) {
					bool flag = true;
					for (int num36 = num34 - 1; num36 <= num34 + 1; num36++) {
						for (int num37 = num35 - 1; num37 <= num35 + 1; num37++) {
							if (!Main.tile[num36, num37].active())
								flag = false;
						}
					}

					if (flag) {
						Main.tile[num34, num35].wall = 73;
						SquareWallFrame(num34, num35);
					}
				}
			}

			for (int num38 = num4; num38 <= num5; num38++) {
				int num39;
				for (num39 = num6 - 10; !Main.tile[num38, num39 + 1].active(); num39++) {
				}

				if (num39 >= num7 || Main.tile[num38, num39 + 1].type != 189)
					continue;

				if (genRand.Next(10) == 0) {
					int num40 = genRand.Next(1, 3);
					for (int num41 = num38 - num40; num41 <= num38 + num40; num41++) {
						if (Main.tile[num41, num39].type == 189) {
							Main.tile[num41, num39].active(active: false);
							Main.tile[num41, num39].liquid = byte.MaxValue;
							Main.tile[num41, num39].lava(lava: false);
							SquareTileFrame(num38, num39);
						}

						if (Main.tile[num41, num39 + 1].type == 189) {
							Main.tile[num41, num39 + 1].active(active: false);
							Main.tile[num41, num39 + 1].liquid = byte.MaxValue;
							Main.tile[num41, num39 + 1].lava(lava: false);
							SquareTileFrame(num38, num39 + 1);
						}

						if (num41 > num38 - num40 && num41 < num38 + 2 && Main.tile[num41, num39 + 2].type == 189) {
							Main.tile[num41, num39 + 2].active(active: false);
							Main.tile[num41, num39 + 2].liquid = byte.MaxValue;
							Main.tile[num41, num39 + 2].lava(lava: false);
							SquareTileFrame(num38, num39 + 2);
						}
					}
				}

				if (genRand.Next(5) == 0)
					Main.tile[num38, num39].liquid = byte.MaxValue;

				Main.tile[num38, num39].lava(lava: false);
				SquareTileFrame(num38, num39);
			}

			int num42 = genRand.Next(4);
			for (int num43 = 0; num43 <= num42; num43++) {
				int num44 = genRand.Next(num4 - 5, num5 + 5);
				int num45 = num6 - genRand.Next(20, 40);
				int num46 = genRand.Next(4, 8);
				int num47 = 189;
				if (genRand.Next(2) == 0)
					num47 = 460;

				for (int num48 = num44 - num46; num48 <= num44 + num46; num48++) {
					for (int num49 = num45 - num46; num49 <= num45 + num46; num49++) {
						float num50 = Math.Abs(num48 - num44);
						float num51 = Math.Abs(num49 - num45) * 2;
						if (Math.Sqrt(num50 * num50 + num51 * num51) < (double)(num46 + genRand.Next(-1, 2))) {
							Main.tile[num48, num49].active(active: true);
							Main.tile[num48, num49].type = (ushort)num47;
							SquareTileFrame(num48, num49);
						}
					}
				}

				for (int num52 = num44 - num46 + 2; num52 <= num44 + num46 - 2; num52++) {
					int num53;
					for (num53 = num45 - num46; !Main.tile[num52, num53].active(); num53++) {
					}

					Main.tile[num52, num53].active(active: false);
					Main.tile[num52, num53].liquid = byte.MaxValue;
					SquareTileFrame(num52, num53);
				}
			}
		}


		public static void SandIsland(int i, int j) {
			double num = genRand.Next(100, 150);
			double num2 = num;
			float num3 = genRand.Next(20, 30);
			int num4 = i;
			int num5 = i;
			int num6 = i;
			int num7 = j;
			Vector2 vector = default(Vector2);
			vector.X = i;
			vector.Y = j;
			Vector2 vector2 = default(Vector2);
			vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			while (vector2.X > -2f && vector2.X < 2f) {
				vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			}

			vector2.Y = (float)genRand.Next(-20, -10) * 0.02f;
			while (num > 0.0 && num3 > 0f) {
				num -= (double)genRand.Next(4);
				num3 -= 1f;
				int num8 = (int)((double)vector.X - num * 0.5);
				int num9 = (int)((double)vector.X + num * 0.5);
				int num10 = (int)((double)vector.Y - num * 0.5);
				int num11 = (int)((double)vector.Y + num * 0.5);
				if (num8 < 0)
					num8 = 0;

				if (num9 > Main.maxTilesX)
					num9 = Main.maxTilesX;

				if (num10 < 0)
					num10 = 0;

				if (num11 > Main.maxTilesY)
					num11 = Main.maxTilesY;

				num2 = num * (double)genRand.Next(80, 120) * 0.01;
				float num12 = vector.Y + 1f;
				for (int k = num8; k < num9; k++) {
					if (genRand.Next(2) == 0)
						num12 += (float)genRand.Next(-1, 2);

					if (num12 < vector.Y)
						num12 = vector.Y;

					if (num12 > vector.Y + 2f)
						num12 = vector.Y + 2f;

					for (int l = num10; l < num11; l++) {
						if (!((float)l > num12))
							continue;

						float num13 = Math.Abs((float)k - vector.X);
						float num14 = Math.Abs((float)l - vector.Y) * 3f;
						if (Math.Sqrt(num13 * num13 + num14 * num14) < num2 * 0.4) {
							if (k < num4)
								num4 = k;

							if (k > num5)
								num5 = k;

							if (l < num6)
								num6 = l;

							if (l > num7)
								num7 = l;

							Main.tile[k, l].active(active: true);
							Main.tile[k, l].type = 189;
							SquareTileFrame(k, l);
						}
					}
				}

				vector += vector2;
				vector2.X += (float)genRand.Next(-20, 21) * 0.05f;
				if (vector2.X > 1f)
					vector2.X = 1f;

				if (vector2.X < -1f)
					vector2.X = -1f;

				if ((double)vector2.Y > 0.2)
					vector2.Y = -0.2f;

				if ((double)vector2.Y < -0.2)
					vector2.Y = -0.2f;
			}

			int num15 = num4;
			int num17;
			for (num15 += genRand.Next(5); num15 < num5; num15 += genRand.Next(num17, (int)((double)num17 * 1.5))) {
				int num16 = num7;
				while (!Main.tile[num15, num16].active()) {
					num16--;
				}

				num16 += genRand.Next(-3, 4);
				num17 = genRand.Next(4, 8);
				int num18 = 189;
				//if (genRand.Next(4) == 0)
				//	num18 = 460;

				for (int m = num15 - num17; m <= num15 + num17; m++) {
					for (int n = num16 - num17; n <= num16 + num17; n++) {
						if (n > num6) {
							float num19 = Math.Abs(m - num15);
							float num20 = Math.Abs(n - num16) * 2;
							if (Math.Sqrt(num19 * num19 + num20 * num20) < (double)(num17 + genRand.Next(2))) {
								Main.tile[m, n].active(active: true);
								Main.tile[m, n].type = (ushort)num18;
								SquareTileFrame(m, n);
							}
						}
					}
				}
			}

			num = genRand.Next(80, 95);
			num2 = num;
			num3 = genRand.Next(10, 15);
			vector.X = i;
			vector.Y = num6;
			vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			while (vector2.X > -2f && vector2.X < 2f) {
				vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			}

			vector2.Y = (float)genRand.Next(-20, -10) * 0.02f;
			while (num > 0.0 && num3 > 0f) {
				num -= (double)genRand.Next(4);
				num3 -= 1f;
				int num8 = (int)((double)vector.X - num * 0.5);
				int num9 = (int)((double)vector.X + num * 0.5);
				int num10 = num6 - 1;
				int num11 = (int)((double)vector.Y + num * 0.5);
				if (num8 < 0)
					num8 = 0;

				if (num9 > Main.maxTilesX)
					num9 = Main.maxTilesX;

				if (num10 < 0)
					num10 = 0;

				if (num11 > Main.maxTilesY)
					num11 = Main.maxTilesY;

				num2 = num * (double)genRand.Next(80, 120) * 0.01;
				float num21 = vector.Y + 1f;
				for (int num22 = num8; num22 < num9; num22++) {
					if (genRand.Next(2) == 0)
						num21 += (float)genRand.Next(-1, 2);

					if (num21 < vector.Y)
						num21 = vector.Y;

					if (num21 > vector.Y + 2f)
						num21 = vector.Y + 2f;

					for (int num23 = num10; num23 < num11; num23++) {
						if ((float)num23 > num21) {
							float num24 = Math.Abs((float)num22 - vector.X);
							float num25 = Math.Abs((float)num23 - vector.Y) * 3f;
							if (Math.Sqrt(num24 * num24 + num25 * num25) < num2 * 0.4 && Main.tile[num22, num23].type == 189) {
								Main.tile[num22, num23].type = 53;
								SquareTileFrame(num22, num23);
							}
						}
					}
				}

				vector += vector2;
				vector2.X += (float)genRand.Next(-20, 21) * 0.05f;
				if (vector2.X > 1f)
					vector2.X = 1f;

				if (vector2.X < -1f)
					vector2.X = -1f;

				if ((double)vector2.Y > 0.2)
					vector2.Y = -0.2f;

				if ((double)vector2.Y < -0.2)
					vector2.Y = -0.2f;
			}

			int num26 = num4;
			num26 += genRand.Next(5);
			while (num26 < num5) {
				int num27 = num7;
				while ((!Main.tile[num26, num27].active() || Main.tile[num26, num27].type != 53) && num26 < num5) {
					num27--;
					if (num27 < num6) {
						num27 = num7;
						num26 += genRand.Next(1, 4);
					}
				}

				if (num26 >= num5)
					continue;

				num27 += genRand.Next(0, 4);
				int num28 = genRand.Next(2, 5);
				int num29 = 189;
				for (int num30 = num26 - num28; num30 <= num26 + num28; num30++) {
					for (int num31 = num27 - num28; num31 <= num27 + num28; num31++) {
						if (num31 > num6) {
							float num32 = Math.Abs(num30 - num26);
							float num33 = Math.Abs(num31 - num27) * 2;
							if (Math.Sqrt(num32 * num32 + num33 * num33) < (double)num28) {
								Main.tile[num30, num31].type = (ushort)num29;
								SquareTileFrame(num30, num31);
							}
						}
					}
				}

				num26 += genRand.Next(num28, (int)((double)num28 * 1.5));
			}

			for (int num34 = num4 - 20; num34 <= num5 + 20; num34++) {
				for (int num35 = num6 - 20; num35 <= num7 + 20; num35++) {
					bool flag = true;
					for (int num36 = num34 - 1; num36 <= num34 + 1; num36++) {
						for (int num37 = num35 - 1; num37 <= num35 + 1; num37++) {
							if (!Main.tile[num36, num37].active())
								flag = false;
						}
					}

					if (flag) {
						Main.tile[num34, num35].wall = 73;
						SquareWallFrame(num34, num35);
					}
				}
			}

			for (int num38 = num4; num38 <= num5; num38++) {
				int num39;
				for (num39 = num6 - 10; !Main.tile[num38, num39 + 1].active(); num39++) {
				}

				if (num39 >= num7 || Main.tile[num38, num39 + 1].type != 189)
					continue;

				if (genRand.Next(10) == 0) {
					int num40 = genRand.Next(1, 3);
					for (int num41 = num38 - num40; num41 <= num38 + num40; num41++) {
						if (Main.tile[num41, num39].type == 189) {
							Main.tile[num41, num39].active(active: false);
							Main.tile[num41, num39].liquid = 0;
							Main.tile[num41, num39].lava(lava: false);
							SquareTileFrame(num38, num39);
						}

						if (Main.tile[num41, num39 + 1].type == 189) {
							Main.tile[num41, num39 + 1].active(active: false);
							Main.tile[num41, num39 + 1].liquid = 0;
							Main.tile[num41, num39 + 1].lava(lava: false);
							SquareTileFrame(num38, num39 + 1);
						}

						if (num41 > num38 - num40 && num41 < num38 + 2 && Main.tile[num41, num39 + 2].type == 189) {
							Main.tile[num41, num39 + 2].active(active: false);
							Main.tile[num41, num39 + 2].liquid = 0;
							Main.tile[num41, num39 + 2].lava(lava: false);
							SquareTileFrame(num38, num39 + 2);
						}
					}
				}

				if (genRand.Next(5) == 0)
					Main.tile[num38, num39].liquid = 0;

				Main.tile[num38, num39].lava(lava: false);
				SquareTileFrame(num38, num39);
			}

			int num42 = genRand.Next(4);
			for (int num43 = 0; num43 <= num42; num43++) {
				int num44 = genRand.Next(num4 - 5, num5 + 5);
				int num45 = num6 - genRand.Next(20, 40);
				int num46 = genRand.Next(4, 8);
				int num47 = 189;
				//if (genRand.Next(2) == 0)
				//	num47 = 460;

				for (int num48 = num44 - num46; num48 <= num44 + num46; num48++) {
					for (int num49 = num45 - num46; num49 <= num45 + num46; num49++) {
						float num50 = Math.Abs(num48 - num44);
						float num51 = Math.Abs(num49 - num45) * 2;
						if (Math.Sqrt(num50 * num50 + num51 * num51) < (double)(num46 + genRand.Next(-1, 2))) {
							Main.tile[num48, num49].active(active: true);
							Main.tile[num48, num49].type = (ushort)num47;
							SquareTileFrame(num48, num49);
						}
					}
				}

				for (int num52 = num44 - num46 + 2; num52 <= num44 + num46 - 2; num52++) {
					int num53;
					for (num53 = num45 - num46; !Main.tile[num52, num53].active(); num53++) {
					}

					Main.tile[num52, num53].active(active: false);
					Main.tile[num52, num53].liquid = 0;
					SquareTileFrame(num52, num53);
				}
			}
		}

		public static void SpecialIsland(int i, int j, int Ground = 0, int Rain = 196, int Fluid = 1, int Cloud = 189, bool GrassRunner = false, int GrassType = 0, int CloudPaint = 0) {
			double num = genRand.Next(100, 150);
			double num2 = num;
			float num3 = genRand.Next(20, 30);
			int num4 = i;
			int num5 = i;
			int num6 = i;
			int num7 = j;
			Vector2 vector = default(Vector2);
			vector.X = i;
			vector.Y = j;
			Vector2 vector2 = default(Vector2);
			vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			while (vector2.X > -2f && vector2.X < 2f) {
				vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			}

			vector2.Y = (float)genRand.Next(-20, -10) * 0.02f;
			while (num > 0.0 && num3 > 0f) {
				num -= (double)genRand.Next(4);
				num3 -= 1f;
				int num8 = (int)((double)vector.X - num * 0.5);
				int num9 = (int)((double)vector.X + num * 0.5);
				int num10 = (int)((double)vector.Y - num * 0.5);
				int num11 = (int)((double)vector.Y + num * 0.5);
				if (num8 < 0)
					num8 = 0;

				if (num9 > Main.maxTilesX)
					num9 = Main.maxTilesX;

				if (num10 < 0)
					num10 = 0;

				if (num11 > Main.maxTilesY)
					num11 = Main.maxTilesY;

				num2 = num * (double)genRand.Next(80, 120) * 0.01;
				float num12 = vector.Y + 1f;
				for (int k = num8; k < num9; k++) {
					if (genRand.Next(2) == 0)
						num12 += (float)genRand.Next(-1, 2);

					if (num12 < vector.Y)
						num12 = vector.Y;

					if (num12 > vector.Y + 2f)
						num12 = vector.Y + 2f;

					for (int l = num10; l < num11; l++) {
						if (!((float)l > num12))
							continue;

						float num13 = Math.Abs((float)k - vector.X);
						float num14 = Math.Abs((float)l - vector.Y) * 3f;
						if (Math.Sqrt(num13 * num13 + num14 * num14) < num2 * 0.4) {
							if (k < num4)
								num4 = k;

							if (k > num5)
								num5 = k;

							if (l < num6)
								num6 = l;

							if (l > num7)
								num7 = l;

							Main.tile[k, l].active(active: true);
							Main.tile[k, l].type = (ushort)Cloud;
							if (CloudPaint > 0) {
								WorldGen.paintTile(k, l, (byte)CloudPaint);
							}
							SquareTileFrame(k, l);
						}
					}
				}

				vector += vector2;
				vector2.X += (float)genRand.Next(-20, 21) * 0.05f;
				if (vector2.X > 1f)
					vector2.X = 1f;

				if (vector2.X < -1f)
					vector2.X = -1f;

				if ((double)vector2.Y > 0.2)
					vector2.Y = -0.2f;

				if ((double)vector2.Y < -0.2)
					vector2.Y = -0.2f;
			}

			int num15 = num4;
			int num17;
			for (num15 += genRand.Next(5); num15 < num5; num15 += genRand.Next(num17, (int)((double)num17 * 1.5))) {
				int num16 = num7;
				while (!Main.tile[num15, num16].active()) {
					num16--;
				}

				num16 += genRand.Next(-3, 4);
				num17 = genRand.Next(4, 8);
				int num18 = Cloud;
				if (genRand.Next(4) == 0)
					num18 = Rain;

				for (int m = num15 - num17; m <= num15 + num17; m++) {
					for (int n = num16 - num17; n <= num16 + num17; n++) {
						if (n > num6) {
							float num19 = Math.Abs(m - num15);
							float num20 = Math.Abs(n - num16) * 2;
							if (Math.Sqrt(num19 * num19 + num20 * num20) < (double)(num17 + genRand.Next(2))) {
								Main.tile[m, n].active(active: true);
								Main.tile[m, n].type = (ushort)num18;
								if (CloudPaint > 0 && num18 == Cloud) {
									WorldGen.paintTile(m, n, (byte)CloudPaint);
								}
								else {
									WorldGen.paintTile(m, n, 0);
								}
								SquareTileFrame(m, n);
							}
						}
					}
				}
			}

			num = genRand.Next(80, 95);
			num2 = num;
			num3 = genRand.Next(10, 15);
			vector.X = i;
			vector.Y = num6;
			vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			while (vector2.X > -2f && vector2.X < 2f) {
				vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			}

			vector2.Y = (float)genRand.Next(-20, -10) * 0.02f;
			while (num > 0.0 && num3 > 0f) {
				num -= (double)genRand.Next(4);
				num3 -= 1f;
				int num8 = (int)((double)vector.X - num * 0.5);
				int num9 = (int)((double)vector.X + num * 0.5);
				int num10 = num6 - 1;
				int num11 = (int)((double)vector.Y + num * 0.5);
				if (num8 < 0)
					num8 = 0;

				if (num9 > Main.maxTilesX)
					num9 = Main.maxTilesX;

				if (num10 < 0)
					num10 = 0;

				if (num11 > Main.maxTilesY)
					num11 = Main.maxTilesY;

				num2 = num * (double)genRand.Next(80, 120) * 0.01;
				float num21 = vector.Y + 1f;
				for (int num22 = num8; num22 < num9; num22++) {
					if (genRand.Next(2) == 0)
						num21 += (float)genRand.Next(-1, 2);

					if (num21 < vector.Y)
						num21 = vector.Y;

					if (num21 > vector.Y + 2f)
						num21 = vector.Y + 2f;

					for (int num23 = num10; num23 < num11; num23++) {
						if ((float)num23 > num21) {
							float num24 = Math.Abs((float)num22 - vector.X);
							float num25 = Math.Abs((float)num23 - vector.Y) * 3f;
							if (Math.Sqrt(num24 * num24 + num25 * num25) < num2 * 0.4 && Main.tile[num22, num23].type == Cloud) {
								Main.tile[num22, num23].type = (ushort)Ground;
								WorldGen.paintTile(num22, num23, 0);
								SquareTileFrame(num22, num23);
							}
						}
					}
				}

				vector += vector2;
				vector2.X += (float)genRand.Next(-20, 21) * 0.05f;
				if (vector2.X > 1f)
					vector2.X = 1f;

				if (vector2.X < -1f)
					vector2.X = -1f;

				if ((double)vector2.Y > 0.2)
					vector2.Y = -0.2f;

				if ((double)vector2.Y < -0.2)
					vector2.Y = -0.2f;
			}

			int num26 = num4;
			num26 += genRand.Next(5);
			while (num26 < num5) {
				int num27 = num7;
				while ((!Main.tile[num26, num27].active() || Main.tile[num26, num27].type != Ground) && num26 < num5) {
					num27--;
					if (num27 < num6) {
						num27 = num7;
						num26 += genRand.Next(1, 4);
					}
				}

				if (num26 >= num5)
					continue;

				num27 += genRand.Next(0, 4);
				int num28 = genRand.Next(2, 5);
				int num29 = Cloud;
				for (int num30 = num26 - num28; num30 <= num26 + num28; num30++) {
					for (int num31 = num27 - num28; num31 <= num27 + num28; num31++) {
						if (num31 > num6) {
							float num32 = Math.Abs(num30 - num26);
							float num33 = Math.Abs(num31 - num27) * 2;
							if (Math.Sqrt(num32 * num32 + num33 * num33) < (double)num28) {
								Main.tile[num30, num31].type = (ushort)num29;
								if (CloudPaint > 0) {
									WorldGen.paintTile(num30, num31, (byte)CloudPaint);
								}
								SquareTileFrame(num30, num31);
							}
						}
					}
				}

				num26 += genRand.Next(num28, (int)((double)num28 * 1.5));
			}

			for (int num34 = num4 - 20; num34 <= num5 + 20; num34++) {
				for (int num35 = num6 - 20; num35 <= num7 + 20; num35++) {
					bool flag = true;
					for (int num36 = num34 - 1; num36 <= num34 + 1; num36++) {
						for (int num37 = num35 - 1; num37 <= num35 + 1; num37++) {
							if (!Main.tile[num36, num37].active())
								flag = false;
						}
					}

					if (flag) {
						Main.tile[num34, num35].wall = 73;
						SquareWallFrame(num34, num35);
					}
				}
			}

			for (int num38 = num4; num38 <= num5; num38++) {
				int num39;
				for (num39 = num6 - 10; !Main.tile[num38, num39 + 1].active(); num39++) {
				}

				if (num39 >= num7 || Main.tile[num38, num39 + 1].type != Cloud)
					continue;

				if (genRand.Next(10) == 0) {
					int num40 = genRand.Next(1, 3);
					for (int num41 = num38 - num40; num41 <= num38 + num40; num41++) {
						if (Main.tile[num41, num39].type == Cloud) {
							Main.tile[num41, num39].active(active: false);
							if (Fluid == 1) {
								Main.tile[num41, num39].liquid = byte.MaxValue;
								Main.tile[num41, num39].lava(lava: false);
							}
							else if (Fluid == 2) {
								Main.tile[num41, num39].liquid = byte.MaxValue;
								Main.tile[num41, num39].lava(lava: true);
							}
							else if (Fluid == 2) {
								Main.tile[num41, num39].liquid = byte.MaxValue;
								Main.tile[num41, num39].honey(honey: true);
							}
							else {
								Main.tile[num41, num39].liquid = 0;
								Main.tile[num41, num39].lava(lava: false);
							}
							SquareTileFrame(num38, num39);
						}

						if (Main.tile[num41, num39 + 1].type == Cloud) {
							Main.tile[num41, num39 + 1].active(active: false);
							if (Fluid == 1) {
								Main.tile[num41, num39 + 1].liquid = byte.MaxValue;
								Main.tile[num41, num39 + 1].lava(lava: false);
							}
							else if (Fluid == 2) {
								Main.tile[num41, num39 + 1].liquid = byte.MaxValue;
								Main.tile[num41, num39 + 1].lava(lava: true);
							}
							else if (Fluid == 2) {
								Main.tile[num41, num39 + 1].liquid = byte.MaxValue;
								Main.tile[num41, num39 + 1].honey(honey: true);
							}
							else {
								Main.tile[num41, num39 + 1].liquid = 0;
								Main.tile[num41, num39 + 1].lava(lava: false);
							}
							SquareTileFrame(num38, num39 + 1);
						}

						if (num41 > num38 - num40 && num41 < num38 + 2 && Main.tile[num41, num39 + 2].type == Cloud) {
							Main.tile[num41, num39 + 2].active(active: false);
							if (Fluid == 1) {
								Main.tile[num41, num39 + 2].liquid = byte.MaxValue;
								Main.tile[num41, num39 + 2].lava(lava: false);
							}
							else if (Fluid == 2) {
								Main.tile[num41, num39 + 2].liquid = byte.MaxValue;
								Main.tile[num41, num39 + 2].lava(lava: true);
							}
							else if (Fluid == 2) {
								Main.tile[num41, num39 + 2].liquid = byte.MaxValue;
								Main.tile[num41, num39 + 2].honey(honey: true);
							}
							else {
								Main.tile[num41, num39 + 2].liquid = 0;
								Main.tile[num41, num39 + 2].lava(lava: false);
							}
							SquareTileFrame(num38, num39 + 2);
						}
					}
				}

				if (genRand.Next(5) == 0) {
					if (Fluid == 1) {
						Main.tile[num38, num39].liquid = byte.MaxValue;
						Main.tile[num38, num39].lava(lava: false);
					}
					else if (Fluid == 2) {
						Main.tile[num38, num39].liquid = byte.MaxValue;
						Main.tile[num38, num39].lava(lava: true);
					}
					else if (Fluid == 2) {
						Main.tile[num38, num39].liquid = byte.MaxValue;
						Main.tile[num38, num39].honey(honey: true);
					}
					else {
						Main.tile[num38, num39].liquid = 0;
						Main.tile[num38, num39].lava(lava: false);
					}
				}
				SquareTileFrame(num38, num39);
			}

			int num42 = genRand.Next(4);
			for (int num43 = 0; num43 <= num42; num43++) {
				int num44 = genRand.Next(num4 - 5, num5 + 5);
				int num45 = num6 - genRand.Next(20, 40);
				int num46 = genRand.Next(4, 8);
				int num47 = Cloud;
				if (genRand.Next(2) == 0)
					num47 = Rain;

				for (int num48 = num44 - num46; num48 <= num44 + num46; num48++) {
					for (int num49 = num45 - num46; num49 <= num45 + num46; num49++) {
						float num50 = Math.Abs(num48 - num44);
						float num51 = Math.Abs(num49 - num45) * 2;
						if (Math.Sqrt(num50 * num50 + num51 * num51) < (double)(num46 + genRand.Next(-1, 2))) {
							Main.tile[num48, num49].active(active: true);
							Main.tile[num48, num49].type = (ushort)num47;
							if (CloudPaint > 0 && num47 == Cloud) {
								WorldGen.paintTile(num48, num49, (byte)CloudPaint);
							}
							else {
								WorldGen.paintTile(num48, num49, 0);
							}
							SquareTileFrame(num48, num49);
						}
					}
				}

				for (int num52 = num44 - num46 + 2; num52 <= num44 + num46 - 2; num52++) {
					int num53;
					for (num53 = num45 - num46; !Main.tile[num52, num53].active(); num53++) {
					}

					Main.tile[num52, num53].active(active: false);
					if (Fluid == 1) {
						Main.tile[num52, num53].liquid = byte.MaxValue;
						Main.tile[num52, num53].lava(lava: false);
					}
					else if (Fluid == 2) {
						Main.tile[num52, num53].liquid = byte.MaxValue;
						Main.tile[num52, num53].lava(lava: true);
					}
					else if (Fluid == 2) {
						Main.tile[num52, num53].liquid = byte.MaxValue;
						Main.tile[num52, num53].honey(honey: true);
					}
					else {
						Main.tile[num52, num53].liquid = 0;
						Main.tile[num52, num53].lava(lava: false);
					}
					SquareTileFrame(num52, num53);
				}
			}
			if (GrassRunner == true) {
				for (int num601 = (int)(i - num); num601 < (int)(i + num); num601++) {
					for (int num602 = (int)(j - num); num602 < (int)(j + num); num602++) {
						if (Main.tile[num601, num602].active()) {
							grassSpread = 0;
							SpreadGrass(num601, num602, Ground, GrassType, repeat: true, 0);
							int GrassID = GrassType;
							//if (Main.setting.SwapShroomJungle) {
							//	GrassID = 70;
							//}
							WorldGen.SpreadGrass(num601, num602, Ground, GrassID, repeat: true, 0);
						}

						//progress.Set(0.2f * ((float)(num601 * Main.maxTilesY + num602) / (float)(Main.maxTilesX * Main.maxTilesY)));
					}
				}

				//for (int num603 = i - num; num603 < i + num; num603++) {
				//	for (int num604 = j - num; num604 < j + num; num604++) {
				//		if (Main.tile[num603, num604].active() && tileCounter(num603, num604) < tileCounterMax)
				//			tileCounterKill();

				//float num605 = (float)((num603 - 10) * (Main.maxTilesY - 20) + (num604 - 10)) / (float)((Main.maxTilesX - 20) * (Main.maxTilesY - 20));
				//progress.Set(0.2f + num605 * 0.8f);
				//}
				//}
			}
		}

		public static void STileRunner(int i, int j, double strength, int steps, int type, bool addTile = false, float speedX = 0f, float speedY = 0f, bool noYChange = false, bool overRide = true) {
			double num = strength;
			float num2 = steps;
			Vector2 vector = default(Vector2);
			vector.X = i;
			vector.Y = j;
			Vector2 vector2 = default(Vector2);
			vector2.X = (float)genRand.Next(-10, 11) * 0.1f;
			vector2.Y = (float)genRand.Next(-10, 11) * 0.1f;
			if (speedX != 0f || speedY != 0f) {
				vector2.X = speedX;
				vector2.Y = speedY;
			}

			bool flag = type == 368;
			bool flag2 = type == 367;
			while (num > 0.0 && num2 > 0f) {
				if (vector.Y < 0f && num2 > 0f && type == 59)
					num2 = 0f;

				num = strength * (double)(num2 / (float)steps);
				num2 -= 1f;
				int num3 = (int)((double)vector.X - num * 0.5);
				int num4 = (int)((double)vector.X + num * 0.5);
				int num5 = (int)((double)vector.Y - num * 0.5);
				int num6 = (int)((double)vector.Y + num * 0.5);
				if (num3 < 1)
					num3 = 1;

				if (num4 > Main.maxTilesX - 1)
					num4 = Main.maxTilesX - 1;

				if (num5 < 1)
					num5 = 1;

				if (num6 > Main.maxTilesY - 1)
					num6 = Main.maxTilesY - 1;

				for (int k = num3; k < num4; k++) {
					for (int l = num5; l < num6; l++) {
						if (!((double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.5 * (1.0 + (double)genRand.Next(-10, 11) * 0.015)))
							continue;

						if (mudWall && (double)l > Main.worldSurface && Main.tile[k, l - 1].wall != 2 && l < Main.maxTilesY - 210 - genRand.Next(3)) {
							if (l > lavaLine - genRand.Next(0, 4) - 50) {
								if (Main.tile[k, l - 1].wall != 64 && Main.tile[k, l + 1].wall != 64 && Main.tile[k - 1, l].wall != 64 && Main.tile[k, l + 1].wall != 64)
									PlaceWall(k, l, 15, mute: true);
							}
							else if (Main.tile[k, l - 1].wall != 15 && Main.tile[k, l + 1].wall != 15 && Main.tile[k - 1, l].wall != 15 && Main.tile[k, l + 1].wall != 15) {
								PlaceWall(k, l, 64, mute: true);
							}
						}

						if (type < 0) {
							if (type == -2 && Main.tile[k, l].active() && (l < waterLine || l > lavaLine)) {
								Main.tile[k, l].liquid = byte.MaxValue;
								if (l > lavaLine)
									Main.tile[k, l].lava(lava: true);
							}

							Main.tile[k, l].active(active: false);
							continue;
						}

						if (flag && (double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.3 * (1.0 + (double)genRand.Next(-10, 11) * 0.01))
							PlaceWall(k, l, 180, mute: true);

						if (flag2 && (double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.3 * (1.0 + (double)genRand.Next(-10, 11) * 0.01))
							PlaceWall(k, l, 178, mute: true);

						if (overRide || !Main.tile[k, l].active()) {
							Tile tile = Main.tile[k, l];
							bool flag3 = false;
							flag3 = (Main.tileStone[type] && tile.type != 1);
							if (!(TileID.Sets.CanBeClearedDuringGeneration[tile.type] || tile.type == 147 || tile.type == 53) || tile.type == 460)
								flag3 = true;

							switch (tile.type) {
								//case 53:
								//if (type == 40)
								//	flag3 = true;
								//if ((double)l < Main.worldSurface && type != 59)
								//	flag3 = true;
								//break;
								case 45:
								//case 147:
								case 189:
								case 190:
								case 196:
									flag3 = true;
									break;
								case 396:
								case 397:
									flag3 = !TileID.Sets.Ore[type];
									break;
								case 1:
									if (type == 59 && (double)l < Main.worldSurface + (double)genRand.Next(-50, 50))
										flag3 = true;
									break;
								case 367:
								case 368:
									if (type == 59)
										flag3 = true;
									break;
							}

							if (!flag3)
								tile.type = (ushort)type;
						}

						if (addTile) {
							Main.tile[k, l].active(active: true);
							Main.tile[k, l].liquid = 0;
							Main.tile[k, l].lava(lava: false);
						}

						if (noYChange && (double)l < Main.worldSurface && type != 59)
							Main.tile[k, l].wall = 2;

						if (type == 59 && l > waterLine && Main.tile[k, l].liquid > 0) {
							Main.tile[k, l].lava(lava: false);
							Main.tile[k, l].liquid = 0;
						}
					}
				}

				vector += vector2;
				if (num > 50.0) {
					vector += vector2;
					num2 -= 1f;
					vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
					vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
					if (num > 100.0) {
						vector += vector2;
						num2 -= 1f;
						vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
						vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
						if (num > 150.0) {
							vector += vector2;
							num2 -= 1f;
							vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
							vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
							if (num > 200.0) {
								vector += vector2;
								num2 -= 1f;
								vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
								vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
								if (num > 250.0) {
									vector += vector2;
									num2 -= 1f;
									vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
									vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
									if (num > 300.0) {
										vector += vector2;
										num2 -= 1f;
										vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
										vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
										if (num > 400.0) {
											vector += vector2;
											num2 -= 1f;
											vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
											vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
											if (num > 500.0) {
												vector += vector2;
												num2 -= 1f;
												vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
												vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
												if (num > 600.0) {
													vector += vector2;
													num2 -= 1f;
													vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
													vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
													if (num > 700.0) {
														vector += vector2;
														num2 -= 1f;
														vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
														vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
														if (num > 800.0) {
															vector += vector2;
															num2 -= 1f;
															vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
															vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
															if (num > 900.0) {
																vector += vector2;
																num2 -= 1f;
																vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
																vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}

				vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
				if (vector2.X > 1f)
					vector2.X = 1f;

				if (vector2.X < -1f)
					vector2.X = -1f;

				if (!noYChange) {
					vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
					if (vector2.Y > 1f)
						vector2.Y = 1f;

					if (vector2.Y < -1f)
						vector2.Y = -1f;
				}
				else if (type != 59 && num < 3.0) {
					if (vector2.Y > 1f)
						vector2.Y = 1f;

					if (vector2.Y < -1f)
						vector2.Y = -1f;
				}

				if (type == 59 && !noYChange) {
					if ((double)vector2.Y > 0.5)
						vector2.Y = 0.5f;

					if ((double)vector2.Y < -0.5)
						vector2.Y = -0.5f;

					if ((double)vector.Y < Main.rockLayer + 100.0)
						vector2.Y = 1f;

					if (vector.Y > (float)(Main.maxTilesY - 300))
						vector2.Y = -1f;
				}
			}
		}
	}
}
