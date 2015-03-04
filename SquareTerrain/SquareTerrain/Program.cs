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
        private static DrawingController _drawingManager;

        static void Main(string[] args)
        {
            _mainWindow = new RenderWindow(new VideoMode(800,600), "Square terrain generator");
            _mainWindow.Closed += mainWindow_Closed;

            _drawingManager = new DrawingController(_mainWindow);

            while (_mainWindow.IsOpen())
            {
                _mainWindow.DispatchEvents();

                _mainWindow.Clear(Color.Black);
                _drawingManager.Draw();
                _mainWindow.Display();
            }
        }

        static void mainWindow_Closed(object sender, EventArgs e)
        {
            _mainWindow.Close();
        }
    }
}
