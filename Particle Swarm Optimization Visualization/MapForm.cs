using Treasure_Map_Logic;
using Particle_Swarm_Optimization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Particle_Swarm_Optimization_Visualization
{
    public partial class MapForm : Form
    {
        private TreasureMap map;
        private ParticleSwarmOptimization pso;

        private int particleSize = 10;
        private int rectangleSize = 20;

        private bool newStartPoint = true;

        public MapForm()
        {
            InitializeComponent();
            PreparePSO();
        }

        private void PreparePSO()
        {
            Vector winnerPosition = RandomWinnerPosition();
            map = new TreasureMap(mapPictureBox.Width, mapPictureBox.Height, winnerPosition);
        }

        private Vector RandomWinnerPosition()
        {
            Random random = new Random();
            Vector winnerPosition = new Vector(2);
            winnerPosition.Item[0] = random.Next(0, mapPictureBox.Width);
            winnerPosition.Item[1] = random.Next(0, mapPictureBox.Height);
            return winnerPosition;
        }

        private void mapPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;

            Vector winnerPosition = new Vector(2);
            winnerPosition.Item[0] = mouseX;
            winnerPosition.Item[1] = mouseY;
            map.SetWinnerPosition(winnerPosition);
            newStartPoint = true;
            Invalidate();
        }
        
        private void particleTextBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(particleTextBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Please enter numbers only!", "Input value error");
                if (particleTextBox.Text.Length == 1)
                    particleTextBox.Text = "1";
                else
                    particleTextBox.Text = particleTextBox.Text.Remove(particleTextBox.Text.Length - 1);
            }
        }

        private void c1TextBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(c1TextBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Please enter numbers only!", "Input value error");
                if (c1TextBox.Text.Length == 1)
                    c1TextBox.Text = "0.1";
                else
                    c1TextBox.Text = c1TextBox.Text.Remove(c1TextBox.Text.Length - 1);
            }
        }

        private void c2TextBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(c2TextBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Please enter numbers only!", "Input value error");
                if (c2TextBox.Text.Length == 1)
                    c2TextBox.Text = "0.1";
                else
                    c2TextBox.Text = c2TextBox.Text.Remove(c2TextBox.Text.Length - 1);
            }
        }

        private bool ValidateParticleCount()
        {
            if (particleTextBox.Text == "")
            {
                MessageBox.Show("Incorrect particle number count!", "Particle value error");
                particleTextBox.Text = "1";
                return false;
            }
            else if (Int32.Parse(particleTextBox.Text) < 1)
            {
                MessageBox.Show("Particle number count must be at least 1!", "Particle value error");
                particleTextBox.Text = "1";
                return false;
            }

            return true;
        }

        private void psoStartButton_Click(object sender, EventArgs e)
        {
            if (psoStartButton.Text == "Start PSO")
            {
                StartPSO();
                psoStartButton.Text = "Stop PSO";
            }
            else
            {
                psoStartButton.Text = "Start PSO";
            }
        }

        private void StartPSO()
        {
            if (!ValidateParticleCount())
                return;

            newStartPoint = false;

            int particleCount = Int32.Parse(particleTextBox.Text);
            uint maxIteration = UInt32.Parse(maxEpochTextBox.Text);
            float c1 = float.Parse(c1TextBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            float c2 = float.Parse(c2TextBox.Text, CultureInfo.InvariantCulture.NumberFormat);

            TreasureMapProblem problem = new TreasureMapProblem(map);
            PSOParameters parameters = new PSOParameters(particleCount, c1, c2, maxIteration, 2f);

            pso = new ParticleSwarmOptimization(problem, parameters);

            Thread psoThread = new Thread(delegate ()
            {
                while (!pso.GetFinishStatus() && psoStartButton.Text == "Stop PSO")
                {
                    pso.NextMove();

                    iterationCounterLabel.Invoke((ThreadStart)delegate ()
                    {
                        iterationCounterLabel.Text = pso.GetIterationsCount().ToString();
                    });

                    Invalidate();

                    Thread.Sleep(80);
                }
                psoStartButton.Invoke((ThreadStart)delegate (){psoStartButton.Text = "Start PSO";});
            });
            psoThread.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw win position rectangle
            ResetPictureBox();
            DrawWinPosition();

            if (pso != null && !newStartPoint)
            {
                // Draw winner particle position rectangle
                Vector winnerPosition = pso.GetBestParticlePosition();
                if (winnerPosition != null)
                    DrawColorRectangle(winnerPosition, Brushes.DarkGreen);

                DrawParticles();
            }
        }

        private void DrawWinPosition()
        {
            Vector winPosition = map.winnerPosition;
            Rectangle winRectangle = new Rectangle((int)winPosition.Item[0] - (rectangleSize/2), (int)winPosition.Item[1] - (rectangleSize/2), rectangleSize, rectangleSize);

            mapPictureBox.CreateGraphics().FillRectangle(Brushes.Lime, winRectangle);
        }

        private void DrawColorRectangle(Vector position, Brush color)
        {
            Rectangle winRectangle = new Rectangle((int)position.Item[0] - (rectangleSize/2), (int)position.Item[1] - (rectangleSize/2), rectangleSize, rectangleSize);

            mapPictureBox.CreateGraphics().FillRectangle(color, winRectangle);
        }

        private void DrawParticles()
        {
            var resultParticlePositions = pso.GetParticlePositions();

            Brush colorBrush = Brushes.Blue;
            int particleNumber = Int32.Parse(particleTextBox.Text);

            for (int i = 0; i < resultParticlePositions.Count; i++)
            {
                if (particleNumber < 21)
                    colorBrush = Graphics.SetColorBrush(i);

                mapPictureBox.CreateGraphics().FillEllipse(colorBrush, resultParticlePositions[i].Item[0] - (particleSize/2), resultParticlePositions[i].Item[1] - (particleSize/2), particleSize, particleSize);
            }
        }

        private void ResetPictureBox()
        {
            mapPictureBox.Image = null;
            mapPictureBox.Refresh();
        }
    }
}