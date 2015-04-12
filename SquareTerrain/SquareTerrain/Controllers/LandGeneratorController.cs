using System;
using System.Collections.Generic;
using SFML.System;
using SquareTerrain.Enums;
using SquareTerrain.Models;
using SquareTerrain.Utils;

namespace SquareTerrain.Controllers
{
    public class LandGeneratorController
    {
        private readonly List<GeneratedLandBlock> _landSources;
        private readonly MapBlock[,] _map;
        private readonly Random _rand;
        private readonly int _seed;
        private readonly int[,] _visited;

        /// <summary>
        ///     Maximum radius of generated land from land source position
        /// </summary>
        private int _maxLandSquareBoundSize;

        private LandGeneratorController(ref MapBlock[,] map, int seed)
        {
            _map = map;
            _landSources = new List<GeneratedLandBlock>();
            _visited = new int[TileMapGeneratorController.TileMapWidth, TileMapGeneratorController.TileMapHeight];

            _seed = seed;
            _rand = new Random(seed);
        }

        public LandGeneratorController(ref MapBlock[,] map, LandGeneratorArguments args, int seed)
            : this(ref map, seed)
        {
            LandSourcePointsDensity = args.LandSourcePointsDensity;
            DistanceFromSourceLandBlockImpact = args.DistanceFromSourceBlockImpact;
            LandGenerationPower = args.LandGenerationPower;
            MinMaxLandSize = new Vector2i(args.MinSize, args.MaxSize);
        }

        /// <summary>
        ///     Number of land source points
        /// </summary>
        public float LandSourcePointsDensity { get; set; }

        /// <summary>
        ///     Higher value - lower probablity of land generation; compute using distance to land source point;
        ///     While generating, we are getting further and further from source land block and probability of putting new land
        ///     block decreases with distance.
        /// </summary>
        public float DistanceFromSourceLandBlockImpact { get; set; }

        /// <summary>
        ///     probability = 1/(distanceToSourceLandBlock)^LandGenerationPower
        /// </summary>
        public double LandGenerationPower { get; set; }

        public Vector2i MinMaxLandSize { get; set; }

        public void GenerateLand()
        {
            Choose_randomLandSourcePoints();
            GenerateLandFromLandSources();
        }

        private void GenerateLandFromLandSources()
        {
            foreach (var generatedLandBlock in _landSources)
            {
                _maxLandSquareBoundSize = _rand.Next(MinMaxLandSize.X, MinMaxLandSize.Y);

                PutNextLandBlocks(generatedLandBlock.Block, 0);
            }
        }

        private void PutNextLandBlocks(MapBlock sourceLandBlock, int distance)
        {
            if (distance < _maxLandSquareBoundSize && sourceLandBlock.BlockType.Equals(BlockTypesEnum.Types.Land))
            {
                _visited[sourceLandBlock.X, sourceLandBlock.Y] = 1; // visited
                var currentLandGenerationProbality = ProbabilityFunction(distance);

                MapBlock[] randomNearBlockList;
                ShufflingNearBlock(sourceLandBlock.NearBlocks, out randomNearBlockList);

                for (var i = 0; i < randomNearBlockList.Length; i++)
                {
                    if (randomNearBlockList[i] != null &&
                        _visited[randomNearBlockList[i].X, randomNearBlockList[i].Y] == 0 &&
                        _rand.Next(100) < currentLandGenerationProbality*100)
                    {
                        randomNearBlockList[i].BlockType = BlockTypesEnum.Types.Land;
                        PutNextLandBlocks(randomNearBlockList[i], ++distance);
                    }
                }
            }
        }

        private double ProbabilityFunction(int distanceFromSource)
        {
            return Math.Pow(1f/(distanceFromSource/100f*DistanceFromSourceLandBlockImpact + 1f), LandGenerationPower);
        }

        private void ShufflingNearBlock(List<MapBlock> nearBlocks, out MapBlock[] _randomBlockList)
        {
            _randomBlockList = new MapBlock[8];

            for (var i = 0; i < nearBlocks.Count; i++)
            {
                _randomBlockList[i] = nearBlocks[i];
            }

            for (var i = 0; i < _randomBlockList.Length; i++)
            {
                ShuffleBlock(_rand.Next(8), _rand.Next(8), ref _randomBlockList);
            }
        }

        private void ShuffleBlock(int source, int destination, ref MapBlock[] _randomBlockList)
        {
            var tmp = _randomBlockList[source];
            _randomBlockList[source] = _randomBlockList[destination];
            _randomBlockList[destination] = tmp;
        }

        private void Choose_randomLandSourcePoints()
        {
            for (var i = 0; i < LandSourcePointsDensity; i++)
            {
                var x = _rand.Next(TileMapGeneratorController.TileMapWidth);
                var y = _rand.Next(TileMapGeneratorController.TileMapHeight);

                if (_landSources.Count <= 0)
                {
                    _map[x, y].BlockType = BlockTypesEnum.Types.Land;
                    _landSources.Add(new GeneratedLandBlock(_map[x, y], 0));
                }
                else
                {
                    var iterationCount = TileMapGeneratorController.TileMapHeight*
                                         TileMapGeneratorController.TileMapWidth;

                    while (_landSources.Exists(item => item.Block.X == x) && iterationCount > 0)
                    {
                        x = _rand.Next(TileMapGeneratorController.TileMapWidth);
                        iterationCount--; // block infinity loops, always has end
                    }

                    while (_landSources.Exists(item => item.Block.Y == y) && iterationCount > 0)
                    {
                        y = _rand.Next(TileMapGeneratorController.TileMapHeight);
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
    }
}