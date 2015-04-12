using System;
using SFML.Graphics;
using SFML.Window;
using SquareTerrain.Controllers;
using SquareTerrain.Models;
using SquareTerrain.Utils;

namespace SquareTerrain
{
    public class MapWindow
    {
        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 600;
        private DrawingTileMapController _drawingTileMapManager;
        private RenderWindow _mainWindow;
        private MapBlock[,] _tileMap;

        public void ShowWindow(LandGeneratorArguments args, int seed)
        {
            _tileMap = TileMapGeneratorController.GenerateTileMap();

            var landGenerator = new LandGeneratorController(ref _tileMap, args, seed);
            landGenerator.GenerateLand();

            _mainWindow = new RenderWindow(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), "Square Tiles terrain generator");
            _mainWindow.Closed += mainWindow_Closed;

            _drawingTileMapManager = new DrawingTileMapController(ref _tileMap);

            while (_mainWindow.IsOpen)
            {
                _mainWindow.DispatchEvents();

                _mainWindow.Clear(Color.Black);
                _mainWindow.Draw(_drawingTileMapManager);
                _mainWindow.Display();
            }
        }

        private void mainWindow_Closed(object sender, EventArgs e)
        {
            _mainWindow.Close();
        }
    }
}