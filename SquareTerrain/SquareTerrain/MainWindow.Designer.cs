namespace SquareTerrain
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.distanceFromSourceTextBox = new System.Windows.Forms.TextBox();
            this.pointsDensityTextBox = new System.Windows.Forms.TextBox();
            this.landGenerationPowerTextBox = new System.Windows.Forms.TextBox();
            this.groundMinSizeTextBox = new System.Windows.Forms.TextBox();
            this.groundMaxSizeTextBox = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.seedTextBox = new System.Windows.Forms.TextBox();
            this.buttonRandomSeed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distance from the source land block impact ratio: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Land source points count: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Land generation power: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ground min/max size: ";
            // 
            // distanceFromSourceTextBox
            // 
            this.distanceFromSourceTextBox.Location = new System.Drawing.Point(258, 10);
            this.distanceFromSourceTextBox.Name = "distanceFromSourceTextBox";
            this.distanceFromSourceTextBox.Size = new System.Drawing.Size(100, 20);
            this.distanceFromSourceTextBox.TabIndex = 4;
            this.distanceFromSourceTextBox.Text = "5.0";
            this.distanceFromSourceTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.distanceFromSourceTextBox_KeyUp);
            // 
            // pointsDensityTextBox
            // 
            this.pointsDensityTextBox.Location = new System.Drawing.Point(258, 36);
            this.pointsDensityTextBox.Name = "pointsDensityTextBox";
            this.pointsDensityTextBox.Size = new System.Drawing.Size(100, 20);
            this.pointsDensityTextBox.TabIndex = 5;
            this.pointsDensityTextBox.Text = "3";
            this.pointsDensityTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pointsDensityTextBox_KeyUp);
            // 
            // landGenerationPowerTextBox
            // 
            this.landGenerationPowerTextBox.Location = new System.Drawing.Point(258, 63);
            this.landGenerationPowerTextBox.Name = "landGenerationPowerTextBox";
            this.landGenerationPowerTextBox.Size = new System.Drawing.Size(100, 20);
            this.landGenerationPowerTextBox.TabIndex = 6;
            this.landGenerationPowerTextBox.Text = "0.125";
            this.landGenerationPowerTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.landGenerationPowerTextBox_KeyUp);
            // 
            // groundMinSizeTextBox
            // 
            this.groundMinSizeTextBox.Location = new System.Drawing.Point(258, 90);
            this.groundMinSizeTextBox.Name = "groundMinSizeTextBox";
            this.groundMinSizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.groundMinSizeTextBox.TabIndex = 7;
            this.groundMinSizeTextBox.Text = "40";
            this.groundMinSizeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.groundMinSizeTextBox_KeyUp);
            // 
            // groundMaxSizeTextBox
            // 
            this.groundMaxSizeTextBox.Location = new System.Drawing.Point(364, 90);
            this.groundMaxSizeTextBox.Name = "groundMaxSizeTextBox";
            this.groundMaxSizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.groundMaxSizeTextBox.TabIndex = 8;
            this.groundMaxSizeTextBox.Text = "300";
            this.groundMaxSizeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.groundMaxSizeTextBox_KeyUp);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(365, 9);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(99, 20);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(365, 35);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(99, 21);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save as image";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Seed: ";
            // 
            // seedTextBox
            // 
            this.seedTextBox.Location = new System.Drawing.Point(258, 116);
            this.seedTextBox.Name = "seedTextBox";
            this.seedTextBox.Size = new System.Drawing.Size(100, 20);
            this.seedTextBox.TabIndex = 12;
            // 
            // buttonRandomSeed
            // 
            this.buttonRandomSeed.Location = new System.Drawing.Point(365, 116);
            this.buttonRandomSeed.Name = "buttonRandomSeed";
            this.buttonRandomSeed.Size = new System.Drawing.Size(99, 21);
            this.buttonRandomSeed.TabIndex = 13;
            this.buttonRandomSeed.Text = "Random";
            this.buttonRandomSeed.UseVisualStyleBackColor = true;
            this.buttonRandomSeed.Click += new System.EventHandler(this.buttonRandomSeed_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 141);
            this.Controls.Add(this.buttonRandomSeed);
            this.Controls.Add(this.seedTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groundMaxSizeTextBox);
            this.Controls.Add(this.groundMinSizeTextBox);
            this.Controls.Add(this.landGenerationPowerTextBox);
            this.Controls.Add(this.pointsDensityTextBox);
            this.Controls.Add(this.distanceFromSourceTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(500, 180);
            this.MinimumSize = new System.Drawing.Size(500, 180);
            this.Name = "MainWindow";
            this.Text = "2D Map Land Generating Alpha 0.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox distanceFromSourceTextBox;
        private System.Windows.Forms.TextBox pointsDensityTextBox;
        private System.Windows.Forms.TextBox landGenerationPowerTextBox;
        private System.Windows.Forms.TextBox groundMinSizeTextBox;
        private System.Windows.Forms.TextBox groundMaxSizeTextBox;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox seedTextBox;
        private System.Windows.Forms.Button buttonRandomSeed;
    }
}