﻿namespace Particle_Swarm_Optimization_Visualization
{
    partial class MapForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label particleLabel;
            System.Windows.Forms.Label maxEpochLabel;
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.psoStartButton = new System.Windows.Forms.Button();
            this.iterationLabel = new System.Windows.Forms.Label();
            this.iterationCounterLabel = new System.Windows.Forms.Label();
            this.particleTextBox = new System.Windows.Forms.TextBox();
            this.maxEpochTextBox = new System.Windows.Forms.TextBox();
            this.c1TextBox = new System.Windows.Forms.TextBox();
            this.c1Label = new System.Windows.Forms.Label();
            this.c2Label = new System.Windows.Forms.Label();
            this.c2TextBox = new System.Windows.Forms.TextBox();
            this.horizontalSeparatorLabel = new System.Windows.Forms.Label();
            particleLabel = new System.Windows.Forms.Label();
            maxEpochLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // particleLabel
            // 
            particleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            particleLabel.Location = new System.Drawing.Point(375, 25);
            particleLabel.Name = "particleLabel";
            particleLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            particleLabel.Size = new System.Drawing.Size(130, 20);
            particleLabel.TabIndex = 5;
            particleLabel.Text = "Particle count:";
            particleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maxEpochLabel
            // 
            maxEpochLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            maxEpochLabel.Location = new System.Drawing.Point(686, 25);
            maxEpochLabel.Name = "maxEpochLabel";
            maxEpochLabel.Size = new System.Drawing.Size(175, 20);
            maxEpochLabel.TabIndex = 12;
            maxEpochLabel.Text = "Max epoch count:";
            maxEpochLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.mapPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapPictureBox.Location = new System.Drawing.Point(11, 130);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(850, 411);
            this.mapPictureBox.TabIndex = 0;
            this.mapPictureBox.TabStop = false;
            this.mapPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseClick);
            // 
            // psoStartButton
            // 
            this.psoStartButton.Location = new System.Drawing.Point(20, 25);
            this.psoStartButton.Name = "psoStartButton";
            this.psoStartButton.Size = new System.Drawing.Size(150, 90);
            this.psoStartButton.TabIndex = 1;
            this.psoStartButton.Text = "Start PSO";
            this.psoStartButton.UseVisualStyleBackColor = true;
            this.psoStartButton.Click += new System.EventHandler(this.psoStartButton_Click);
            // 
            // iterationLabel
            // 
            this.iterationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.iterationLabel.Location = new System.Drawing.Point(176, 25);
            this.iterationLabel.Name = "iterationLabel";
            this.iterationLabel.Size = new System.Drawing.Size(170, 20);
            this.iterationLabel.TabIndex = 2;
            this.iterationLabel.Text = "Iteration count:";
            this.iterationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iterationCounterLabel
            // 
            this.iterationCounterLabel.BackColor = System.Drawing.SystemColors.Window;
            this.iterationCounterLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iterationCounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.iterationCounterLabel.Location = new System.Drawing.Point(200, 60);
            this.iterationCounterLabel.Name = "iterationCounterLabel";
            this.iterationCounterLabel.Size = new System.Drawing.Size(130, 50);
            this.iterationCounterLabel.TabIndex = 3;
            this.iterationCounterLabel.Text = "0";
            this.iterationCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // particleTextBox
            // 
            this.particleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.particleTextBox.Location = new System.Drawing.Point(375, 70);
            this.particleTextBox.Name = "particleTextBox";
            this.particleTextBox.Size = new System.Drawing.Size(130, 30);
            this.particleTextBox.TabIndex = 6;
            this.particleTextBox.Text = "10";
            this.particleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.particleTextBox.TextChanged += new System.EventHandler(this.particleTextBox_KeyPress);
            // 
            // maxEpochTextBox
            // 
            this.maxEpochTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.maxEpochTextBox.Location = new System.Drawing.Point(690, 70);
            this.maxEpochTextBox.Name = "maxEpochTextBox";
            this.maxEpochTextBox.Size = new System.Drawing.Size(160, 30);
            this.maxEpochTextBox.TabIndex = 13;
            this.maxEpochTextBox.Text = "100";
            this.maxEpochTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // c1TextBox
            // 
            this.c1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.c1TextBox.Location = new System.Drawing.Point(531, 70);
            this.c1TextBox.Name = "c1TextBox";
            this.c1TextBox.Size = new System.Drawing.Size(56, 30);
            this.c1TextBox.TabIndex = 14;
            this.c1TextBox.Text = "0.1";
            this.c1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.c1TextBox.TextChanged += new System.EventHandler(this.c1TextBox_KeyPress);
            // 
            // c1Label
            // 
            this.c1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.c1Label.Location = new System.Drawing.Point(531, 25);
            this.c1Label.Name = "c1Label";
            this.c1Label.Size = new System.Drawing.Size(56, 23);
            this.c1Label.TabIndex = 15;
            this.c1Label.Text = "C1:";
            this.c1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c2Label
            // 
            this.c2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.c2Label.Location = new System.Drawing.Point(609, 25);
            this.c2Label.Name = "c2Label";
            this.c2Label.Size = new System.Drawing.Size(56, 23);
            this.c2Label.TabIndex = 16;
            this.c2Label.Text = "C2:";
            this.c2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c2TextBox
            // 
            this.c2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.c2TextBox.Location = new System.Drawing.Point(613, 70);
            this.c2TextBox.Name = "c2TextBox";
            this.c2TextBox.Size = new System.Drawing.Size(52, 30);
            this.c2TextBox.TabIndex = 17;
            this.c2TextBox.Text = "0.1";
            this.c2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.c2TextBox.TextChanged += new System.EventHandler(this.c2TextBox_KeyPress);
            // 
            // horizontalSeparatorLabel
            // 
            this.horizontalSeparatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalSeparatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.horizontalSeparatorLabel.Location = new System.Drawing.Point(352, 15);
            this.horizontalSeparatorLabel.Name = "horizontalSeparatorLabel";
            this.horizontalSeparatorLabel.Size = new System.Drawing.Size(2, 105);
            this.horizontalSeparatorLabel.TabIndex = 18;
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 553);
            this.Controls.Add(this.horizontalSeparatorLabel);
            this.Controls.Add(this.c2TextBox);
            this.Controls.Add(this.c2Label);
            this.Controls.Add(this.c1Label);
            this.Controls.Add(this.c1TextBox);
            this.Controls.Add(this.maxEpochTextBox);
            this.Controls.Add(maxEpochLabel);
            this.Controls.Add(this.particleTextBox);
            this.Controls.Add(particleLabel);
            this.Controls.Add(this.iterationCounterLabel);
            this.Controls.Add(this.iterationLabel);
            this.Controls.Add(this.psoStartButton);
            this.Controls.Add(this.mapPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MapForm";
            this.Text = "PSO Map";
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.Button psoStartButton;
        private System.Windows.Forms.Label iterationLabel;
        private System.Windows.Forms.Label iterationCounterLabel;
        private System.Windows.Forms.TextBox particleTextBox;
        private System.Windows.Forms.TextBox maxEpochTextBox;
        private System.Windows.Forms.TextBox c1TextBox;
        private System.Windows.Forms.Label c1Label;
        private System.Windows.Forms.Label c2Label;
        private System.Windows.Forms.TextBox c2TextBox;
        private System.Windows.Forms.Label horizontalSeparatorLabel;
    }
}

