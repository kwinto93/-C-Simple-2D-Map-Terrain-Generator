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

        private void ShuffleBlock(int source, int destination, ref MapBlock[] randomBlockList)
        {
            MapBlock tmp = randomBlockList[source];
            randomBlockList[source] = randomBlockList[destination];
            randomBlockList[destination] = tmp;
        }

        private void ShufflingNearBlock(List<MapBlock> nearBlocks, out MapBlock[] randomBlockList)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            randomBlockList = new MapBlock[8];

            for (int i = 0; i < nearBlocks.Count; i++)
            {
                randomBlockList[i] = nearBlocks[i];
            }

            for (int i = 0; i < randomBlockList.Length; i++)
            {
                ShuffleBlock(rand.Next(8), rand.Next(8), ref randomBlockList);
            }
        }

        private void PutNextLandBlocks(MapBlock sourceLandBlock, Random rand, int distance)
        {
            if (distance < _maxLandSquareBoundSize && sourceLandBlock.BlockType.Equals(BlockTypesEnum.Types.Land))
            {
                _visited[sourceLandBlock.X, sourceLandBlock.Y] = 1; // visited
                double currentLandGenerationProbality = ProbabilityFunction(distance);

                MapBlock[] randomNearBlockList;
                ShufflingNearBlock(sourceLandBlock.NearBlocks, out randomNearBlockList);

                for(int i = 0; i<randomNearBlockList.Length; i++)
                {
                    if (randomNearBlockList[i] != null && _visited[randomNearBlockList[i].X, randomNearBlockList[i].Y] == 0 && rand.Next(100) < currentLandGenerationProbality * 100)
                    {
                        randomNearBlockList[i].BlockType = BlockTypesEnum.Types.Land;
                        PutNextLandBlocks(randomNearBlockList[i], rand, ++distance); // only land blocks can generate next land block
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
