using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquareTerrain.Models;

namespace SquareTerrain.Controllers
{
    public static class TileMapGeneratorController
    {
        public const int SquareBlockSize = 2;
        public const int TileMapWidth = Program.WINDOW_WIDTH / SquareBlockSize;
        public const int TileMapHeight = Program.WINDOW_HEIGHT / SquareBlockSize;

        private static MapBlock ReturnBlockOrNull(int i, int j, ref MapBlock[,] map)
        {
            return (i >= 0 && i < TileMapWidth && j >= 0 && j < TileMapHeight) ? map[i, j] : null;
        }

        private static void UpdateReferences(ref MapBlock[,] map)
        {
            for (int i = 0; i < TileMapWidth; i++)
                for (int j = 0; j < TileMapHeight; j++)
                {
                    map[i, j].BBlock = ReturnBlockOrNull(i, j + 1, ref map);
                    map[i, j].BrBlock = ReturnBlockOrNull(i + 1, j + 1, ref map);
                    map[i, j].LBlock = ReturnBlockOrNull(i - 1, j, ref map);
                    map[i, j].LbBlock = ReturnBlockOrNull(i - 1, j + 1, ref map);
                    map[i, j].LtBlock = ReturnBlockOrNull(i - 1, j - 1, ref map);
                    map[i, j].RBlock = ReturnBlockOrNull(i + 1, j, ref map);
                    map[i, j].TBlock = ReturnBlockOrNull(i, j - 1, ref map);
                    map[i, j].TrBlock = ReturnBlockOrNull(i + 1, j - 1, ref map);

                    map[i,j].UpdateNearBlocksList();
                }
        }

        private static void MakeBlocks(ref MapBlock[,] map)
        {
            for (int i = 0; i < TileMapWidth; i++)
                for (int j = 0; j < TileMapHeight; j++)
                    map[i, j] = new MapBlock(i, j, SquareBlockSize);
        }

        public static MapBlock[,] GenerateTileMap()
        {
            MapBlock[,] tmpMapBlocks = new MapBlock[TileMapWidth, TileMapHeight];

            MakeBlocks(ref tmpMapBlocks);
            UpdateReferences(ref tmpMapBlocks);

            return tmpMapBlocks;
        }
    }
}
