using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SquareTerrain.Enums;
using SquareTerrain.Models;

namespace SquareTerrain.Controllers
{
    public class LandGeneratorController
    {
        private MapBlock[,] _map;
        private List<GeneratedLandBlock> _landSources;
        private int _maxLandSquareBoundSize;
        private int[,] _visited;

        public float LandSourcePointsDensity { get; set; }

        public float DistanceFromSourceLandBlockImpact { get; set; }

        public double LandGenerationPower { get; set; }

        public Vector2i MinMaxLandSize { get; set; }

        public LandGeneratorController(ref MapBlock[,] map)
        {
            _map = map;
            _landSources = new List<GeneratedLandBlock>();
            _visited = new int[TileMapGeneratorController.TileMapWidth, TileMapGeneratorController.TileMapHeight];
        }

        public LandGeneratorController(ref MapBlock[,] map, float landSourcePointsDensity)
            : this(ref map)
        {
            LandSourcePointsDensity = landSourcePointsDensity;
            //DistanceFromSourceLandBlockImpact = 4f;
            DistanceFromSourceLandBlockImpact = 5f;
            //LandGenerationPower = 1 / 2d;
            LandGenerationPower = 1/8d;
            //MinMaxLandSize = new Vector2i(20, 40);
            MinMaxLandSize = new Vector2i(40, 300);
        }

        private double ProbabilityFunction(int distanceFromSource)
        {
            return Math.Pow(1f / (distanceFromSource / 100f * DistanceFromSourceLandBlockImpact + 1f), LandGenerationPower);
        }

        private void PutNextLandBlocks(MapBlock sourceLandBlock, Random rand, int distance)
        {
            if (distance < _maxLandSquareBoundSize && sourceLandBlock.BlockType.Equals(BlockTypesEnum.Types.Land))
            {
                _visited[sourceLandBlock.X, sourceLandBlock.Y] = 1; // visited
                double currentLandGenerationProbality = ProbabilityFunction(distance);

                foreach (var nearBlock in sourceLandBlock.NearBlocks)
                {
                    if (nearBlock != null && _visited[nearBlock.X, nearBlock.Y] == 0 && rand.Next(100) < currentLandGenerationProbality * 100)
                    {
                        nearBlock.BlockType = BlockTypesEnum.Types.Land;
                        PutNextLandBlocks(nearBlock, rand, ++distance); // only land blocks can generate next land block
                    }
                }
            }
        }

        private void GenerateLandFromLandSources()
        {
            foreach (var generatedLandBlock in _landSources)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                _maxLandSquareBoundSize = rand.Next(MinMaxLandSize.X, MinMaxLandSize.Y);

                PutNextLandBlocks(generatedLandBlock.Block, rand, 0);
            }
        }

        private void ChooseRandomLandSourcePoints()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < LandSourcePointsDensity; i++)
            {
                int x = rand.Next(TileMapGeneratorController.TileMapWidth);
                int y = rand.Next(TileMapGeneratorController.TileMapHeight);

                if (_landSources.Count <= 0)
                {
                    _map[x, y].BlockType = BlockTypesEnum.Types.Land;
                    _landSources.Add(new GeneratedLandBlock(_map[x, y], 0));
                }
                else
                {
                    int iterationCount = TileMapGeneratorController.TileMapHeight *
                                         TileMapGeneratorController.TileMapWidth;

                    while (_landSources.Exists(item => item.Block.X == x) && iterationCount > 0)
                    {
                        x = rand.Next(TileMapGeneratorController.TileMapWidth);
                        iterationCount--; // block infinity loops, always has end
                    }

                    while (_landSources.Exists(item => item.Block.Y == y) && iterationCount > 0)
                    {
                        y = rand.Next(TileMapGeneratorController.TileMapHeight);
                        iterationCount--;
                    }

                    // if found something before possibilities was ended
                    if (iterationCount > 0)
                    {
                        _map[x, y].BlockType = BlockTypesEnum.Types.Land;
                        _landSources.Add(new GeneratedLandBlock(_map[x, y], 0));
                    }
                }
            }
        }

        public void GenerateLand()
        {
            ChooseRandomLandSourcePoints();
            GenerateLandFromLandSources();
        }
    }
}
