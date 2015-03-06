using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SquareTerrain.Enums;
using SquareTerrain.Models;

namespace SquareTerrain.Controllers
{
    public class DrawingTileMapController : Transformable, Drawable
    {
        private readonly VertexArray _tileMapVertexArray;

        private MapBlock[,] _map;

        public DrawingTileMapController(ref MapBlock[,] map)
        {
            _map = map;
            _tileMapVertexArray = new VertexArray(PrimitiveType.Quads, TileMapGeneratorController.TileMapHeight * TileMapGeneratorController.TileMapWidth * 4);
            PrepareTileMap();
        }

        private void PrepareTileMap()
        {
            for (int i = 0; i < TileMapGeneratorController.TileMapWidth; i++)
                for (int j = 0; j < TileMapGeneratorController.TileMapHeight; j++)
                {
                    switch (_map[i, j].BlockType)
                    {
                        case BlockTypesEnum.Types.Water: UpdateTileBlock(i, j, Color.Blue);
                            break;
                        case BlockTypesEnum.Types.Land: UpdateTileBlock(i, j, Color.Green);
                            break;
                    }
                }
        }

        public void UpdateTileBlock(int i, int j, Color color)
        {
            _tileMapVertexArray[(uint)((i + j * TileMapGeneratorController.TileMapWidth) * 4)] = new Vertex(new Vector2f(i * TileMapGeneratorController.SquareBlockSize, j * TileMapGeneratorController.SquareBlockSize), color);
            _tileMapVertexArray[(uint)((i + j * TileMapGeneratorController.TileMapWidth) * 4) + 1] = new Vertex(new Vector2f((i + 1) * TileMapGeneratorController.SquareBlockSize, j * TileMapGeneratorController.SquareBlockSize), color);
            _tileMapVertexArray[(uint)((i + j * TileMapGeneratorController.TileMapWidth) * 4) + 2] = new Vertex(new Vector2f((i + 1) * TileMapGeneratorController.SquareBlockSize, (j + 1) * TileMapGeneratorController.SquareBlockSize), color);
            _tileMapVertexArray[(uint)((i + j * TileMapGeneratorController.TileMapWidth) * 4) + 3] = new Vertex(new Vector2f(i * TileMapGeneratorController.SquareBlockSize, (j + 1) * TileMapGeneratorController.SquareBlockSize), color);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform = this.Transform;

            target.Draw(_tileMapVertexArray, states);
        }
    }
}
