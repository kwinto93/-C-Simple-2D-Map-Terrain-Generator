using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.Window;
using SquareTerrain.Controllers;
using SquareTerrain.Models;

namespace SquareTerrain
{
    class Program
    {
        private static MainWindow _mainWindow;

        private static void Main(String[] args)
        {
            _mainWindow = new MainWindow();
            Application.Run(_mainWindow);
        }
    }
}
