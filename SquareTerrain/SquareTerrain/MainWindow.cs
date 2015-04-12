using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using SquareTerrain.Utils;

namespace SquareTerrain
{
    public partial class MainWindow : Form
    {
        private readonly List<TextBox> _numericTextBoxes = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();

            InitNumericTextBoxesList();
        }

        private void InitNumericTextBoxesList()
        {
            _numericTextBoxes.Clear();

            _numericTextBoxes.Add(distanceFromSourceTextBox);
            _numericTextBoxes.Add(landGenerationPowerTextBox);
            _numericTextBoxes.Add(pointsDensityTextBox);
            _numericTextBoxes.Add(groundMinSizeTextBox);
            _numericTextBoxes.Add(groundMaxSizeTextBox);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var mapWindow = new MapWindow();

            if (AreTextBoxesValid())
                mapWindow.ShowWindow(new LandGeneratorArguments
                {
                    DistanceFromSourceBlockImpact =
                        float.Parse(distanceFromSourceTextBox.Text, CultureInfo.InvariantCulture),
                    LandGenerationPower = double.Parse(landGenerationPowerTextBox.Text, CultureInfo.InvariantCulture),
                    LandSourcePointsDensity = float.Parse(pointsDensityTextBox.Text, CultureInfo.InvariantCulture),
                    MaxSize = Int32.Parse(groundMaxSizeTextBox.Text),
                    MinSize = Int32.Parse(groundMaxSizeTextBox.Text)
                },
                    String.IsNullOrEmpty(seedTextBox.Text)
                        ? DateTime.Now.Millisecond
                        : ConvertStringSeedToInt(seedTextBox.Text));
            else
                MessageBox.Show("Some fields are empty!");
        }

        private int ConvertStringSeedToInt(string seedStr)
        {
            var tmp = 0;
            for (var i = 0; i < seedStr.Length; i++)
            {
                tmp += seedStr[i];
            }
            return tmp;
        }

        private bool AreTextBoxesValid()
        {
            foreach (var textBox in _numericTextBoxes)
                if (String.IsNullOrEmpty(textBox.Text))
                    return false;

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Have not been implemented yet!");
        }

        private void ShowError(TextBox source)
        {
            if (!String.IsNullOrEmpty(source.Text))
                try
                {
                    float.Parse(source.Text, CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong number format (Ex. 4.00, 5, 6.2555)");
                }
        }

        private void distanceFromSourceTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ShowError((TextBox) sender);
        }

        private void pointsDensityTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ShowError((TextBox) sender);
        }

        private void landGenerationPowerTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ShowError((TextBox) sender);
        }

        private void groundMinSizeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ShowError((TextBox) sender);
        }

        private void groundMaxSizeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ShowError((TextBox) sender);
        }

        private void buttonRandomSeed_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            seedTextBox.Text = rand.Next().ToString();
        }
    }
}