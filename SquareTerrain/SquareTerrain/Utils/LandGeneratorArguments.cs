using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareTerrain.Utils
{
    public struct LandGeneratorArguments
    {
        public float LandSourcePointsDensity;
        public float DistanceFromSourceBlockImpact;
        public double LandGenerationPower;
        public int MinSize;
        public int MaxSize;
    }
}
