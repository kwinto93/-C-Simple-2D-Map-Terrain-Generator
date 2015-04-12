using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using SquareTerrain.Utils;

namespace SquareTerrain
{
    public partial class MainWindow : Form
    {
        private readonly List<TextBox> _textBoxes = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();

            InitTextBoxesList();
        }

        private void InitTextBoxesList()
        {
            _textBoxes.Clear();

            _textBoxes.Add(distanceFromSourceTextBox);
            _textBoxes.Add(landGenerationPowerTextBox);
            _textBoxes.Add(pointsDensityTextBox);
            _textBoxes.Add(groundMinSizeTextBox);
            _textBoxes.Add(groundMaxSizeTextBox);
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
                });
            else
                MessageBox.Show("Some fields are empty!");
        }

        private bool AreTextBoxesValid()
        {
            foreach (var textBox in _textBoxes)
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
            ShowError((TextBox)sender);
        }

        private void pointsDensityTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ShowError((TextBox)sender);
        }

        private void landGenerationPowerTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ShowError((TextBox)sender);
        }

        private void groundMinSizeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ShowError((TextBox)sender);
        }

        private void groundMaxSizeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ShowError((TextBox)sender);
        }
    }
}