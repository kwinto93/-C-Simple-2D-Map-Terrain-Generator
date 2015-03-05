using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SquareTerrain.Controllers;

namespace SquareTerrain
{
    class Program
    {
        private static RenderWindow _mainWindow;
        private static DrawingTileMapController _drawingTileMapManager;

        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 600;

        static void Main(string[] args)
        {
            _mainWindow = new RenderWindow(new VideoMode(800,600), "Square Tiles terrain generator");
            _mainWindow.Closed += mainWindow_Closed;

            _drawingTileMapManager = new DrawingTileMapController();

            while (_mainWindow.IsOpen())
            {
                _mainWindow.DispatchEvents();

                _mainWindow.Clear(Color.Black);
                _mainWindow.Draw(_drawingTileMapManager);
                _mainWindow.Display();
            }
        }

        static void mainWindow_Closed(object sender, EventArgs e)
        {
            _mainWindow.Close();
        }
    }
}
