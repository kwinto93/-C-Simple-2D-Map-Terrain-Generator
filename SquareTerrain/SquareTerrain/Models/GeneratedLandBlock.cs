using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareTerrain.Models
{
    public class GeneratedLandBlock
    {
        public MapBlock Block { get; private set; }
        public int DistanceFromLandChunkSourceBlock { get; private set; }

        public GeneratedLandBlock(MapBlock block, int distanceToSourceBlock)
        {
            DistanceFromLandChunkSourceBlock = distanceToSourceBlock;
            Block = block;
        }
    }
}
