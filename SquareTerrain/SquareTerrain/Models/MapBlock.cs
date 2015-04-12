using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquareTerrain.Enums;

namespace SquareTerrain.Models
{
    public class MapBlock
    {
        public MapBlock LtBlock { get; set; }
        public MapBlock TBlock { get; set; }
        public MapBlock TrBlock { get; set; }
        public MapBlock LBlock { get; set; }
        public MapBlock RBlock { get; set; }
        public MapBlock LbBlock { get; set; }
        public MapBlock BBlock { get; set; }
        public MapBlock BrBlock { get; set; }
        public List<MapBlock> NearBlocks { get; private set; }

        public BlockTypesEnum.Types BlockType { get; set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        public int BlockSize { get; private set; }

        public MapBlock(int x, int y, int size)
        {
            BlockType = BlockTypesEnum.Types.Water; // default - water
            X = x;
            Y = y;
            BlockSize = size;
        }

        public void UpdateNearBlocksList()
        {
            if(NearBlocks != null)
                NearBlocks.Clear();

            NearBlocks = new List<MapBlock>(8)
            {
                LtBlock,TBlock,TrBlock,LBlock,RBlock,LBlock,BBlock,BrBlock
            };
        }
    }
}
