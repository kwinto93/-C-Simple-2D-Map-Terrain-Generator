using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SquareTerrain.Controllers
{
    public class DrawingTileMapController : Transformable, Drawable
    {
        private const int SquareBlockSize = 2;
        private const int TileMapWidth = Program.WINDOW_WIDTH / SquareBlockSize;
        private const int TileMapHeight = Program.WINDOW_HEIGHT / SquareBlockSize;

        private readonly VertexArray _tileMapVertexArray;

        public int[,] Map { get; set; }

        public DrawingTileMapController()
        {
            Map = new int[TileMapWidth, TileMapHeight];
            _tileMapVertexArray = new VertexArray(PrimitiveType.Quads, TileMapHeight * TileMapWidth * 4);
            PrepareTileMap();
        }

        private void PrepareTileMap()
        {
            for (int i = 0; i < TileMapWidth; i++)
                for (int j = 0; j < TileMapHeight; j++)
                {
                    UpdateTileBlock(i, j, Color.Blue);
                }
        }

        public void UpdateTileBlock(int i, int j, Color color)
        {
            _tileMapVertexArray[(uint)((i + j * TileMapWidth) * 4)] = new Vertex(new Vector2f(i * SquareBlockSize, j * SquareBlockSize), color);
            _tileMapVertexArray[(uint)((i + j * TileMapWidth) * 4) + 1] = new Vertex(new Vector2f((i + 1) * SquareBlockSize, j * SquareBlockSize), color);
            _tileMapVertexArray[(uint)((i + j * TileMapWidth) * 4) + 2] = new Vertex(new Vector2f((i + 1) * SquareBlockSize, (j + 1) * SquareBlockSize), color);
            _tileMapVertexArray[(uint)((i + j * TileMapWidth) * 4) + 3] = new Vertex(new Vector2f(i * SquareBlockSize, (j + 1) * SquareBlockSize), color);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform = this.Transform;

            target.Draw(_tileMapVertexArray, states);
        }
    }
}
