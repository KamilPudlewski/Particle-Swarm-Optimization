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

        private int cellSize = 50;
        private Rectangle[,] grid;

        private ParticleSwarmOptimization pso;

        private int minSizeX = 1;
        private int minSizeY = 10;

        public MapForm()
        {
            InitializeComponent();
            PreparePSO();

            // Connect the Paint event of the PictureBox to the event handler method.
            mapPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CreateMapGrid);
        }

        private void PreparePSO()
        {
            int row = Int32.Parse(rowTextBox.Text);
            int column = Int32.Parse(columnTextBox.Text);

            // Random winner position
            Random random = new Random();
            int winnerPosition = random.Next(0, (row* column) - 1);

            map = new TreasureMap(row, column, winnerPosition);
            grid = new Rectangle[map.sizeX, map.sizeY];
        }

        private void CreateMapGrid(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            ChangeWindowSize();

            int height = 0;

            for (int i = 0; i < map.sizeX; i++)
            {
                int width = 0;
                for (int j = 0; j < map.sizeY; j++)
                {
                    Rectangle cellRectangle = new Rectangle(width, height, cellSize, cellSize);
                    grid[i, j] = cellRectangle;
                    e.Graphics.DrawRectangle(Pens.Black, cellRectangle);
                    width += cellSize;
                }
                height += cellSize;
            }
        }

        private void ChangeWindowSize()
        {
            int widthWindow = 20 + ((cellSize + 1) * map.sizeY) + 20;
            int heightWindow = 160 + ((cellSize + 1) * map.sizeX) + 20;

            this.Size = new System.Drawing.Size(widthWindow, heightWindow);
            mapPictureBox.Size = new System.Drawing.Size(widthWindow, heightWindow);
        }

        private void labyrinthPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            ResetPictureBox();

            int mouseX = e.X;
            int mouseY = e.Y;

            for (int i = 0; i < map.sizeX; i++)
            {
                for (int j = 0; j < map.sizeY; j++)
                {
                    if (grid[i, j].X < mouseX && grid[i, j].Y < mouseY && (grid[i, j].X + grid[i, j].Width) > mouseX && (grid[i, j].Y + grid[i, j].Height) > mouseY)
                    {
                        map.SetWinnerPosition((i * map.sizeY) + j);
                        mapPictureBox.CreateGraphics().FillRectangle(Brushes.Lime, grid[i, j]);
                    }
                }
            }
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

        private void rowTextBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(rowTextBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Please enter numbers only!", "Input value error");
                if (rowTextBox.Text.Length == 1)
                    rowTextBox.Text = "1";
                else
                    rowTextBox.Text = rowTextBox.Text.Remove(rowTextBox.Text.Length - 1);
            }
        }

        private void columnTextBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(columnTextBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Please enter numbers only!", "Input value error");
                if (columnTextBox.Text.Length == 1)
                    columnTextBox.Text = "1";
                else
                    columnTextBox.Text = columnTextBox.Text.Remove(columnTextBox.Text.Length - 1);
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

        private void changeMapButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(rowTextBox.Text) < minSizeX)
                {
                    MessageBox.Show("Row count must be at least " + minSizeX + "!", "Error row count!");
                    rowTextBox.Text = minSizeX.ToString();
                    return;
                }

                if (Int32.Parse(columnTextBox.Text) < minSizeY)
                {
                    MessageBox.Show("Column count must be at least " + minSizeY + "!", "Error row count!");
                    columnTextBox.Text = minSizeY.ToString();
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }

            PreparePSO();
            ResetPictureBox();
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
            StartPSO();
        }

        private void StartPSO()
        {

            if (!ValidateParticleCount())
                return;

            ResetPictureBox();

            int particleCount = Int32.Parse(particleTextBox.Text);
            uint maxIteration = UInt32.Parse(maxEpochTextBox.Text);
            float c1 = float.Parse(c1TextBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            float c2 = float.Parse(c2TextBox.Text, CultureInfo.InvariantCulture.NumberFormat);

            TreasureMapProblem problem = new TreasureMapProblem(map, particleCount);
            problem.MaxIteration = maxIteration;
            problem.C1 = c1;
            problem.C2 = c2;
            pso = new ParticleSwarmOptimization(problem);


            while (!pso.GetFinishStatus())
            {
                ResetPictureBox();

                pso.NextMove();

                DrawWinPosition();

                var result = pso.GetParticlePositions();

                // Color winner particle rectangle
                int winnerPosition = (int)Math.Round(pso.GetBestParticlePosition());
                if (winnerPosition < 0)
                    winnerPosition = 0;
                else if (winnerPosition > (map.sizeX * map.sizeY))
                    winnerPosition = map.sizeX * map.sizeY;
                ColorRectangle(winnerPosition, Brushes.DarkGreen);

                DrawParticle();

                iterationCounterLabel.Text = pso.GetIterationsCount().ToString();
                iterationCounterLabel.Refresh();

                Thread.Sleep(500);
            }
        }

        private void DrawWinPosition()
        {
            int winPosition = map.winnerPosition;

            int cellX = (int)winPosition / map.sizeY;
            int cellY = (int)winPosition % map.sizeY;

            mapPictureBox.CreateGraphics().FillRectangle(Brushes.Lime, grid[cellX, cellY]);
        }

        private void ColorRectangle(int position, Brush color)
        {
            int cellX = position / map.sizeY;
            int cellY = position % map.sizeY;

            mapPictureBox.CreateGraphics().FillRectangle(color, grid[cellX, cellY]);
        }

        private void DrawParticle()
        {
            var resultParticlePositions = pso.GetParticlePositions();

            // Lista która ma postać [pozycja][ilosc wystapien] służąca do odpwiedniego wyświetlania cząsteczek
            List<int> scheduleParticle = new List<int>();
            for (int i = 0; i < map.sizeX * map.sizeY + 1; i++)
            {
                scheduleParticle.Add(0);
            }

            int color = 0;

            foreach (var particle in pso.GetParticlePositions())
            {
                int position = (int)Math.Round(particle);

                if (particle < 0)
                    position = 0;
                else if (position >= map.sizeX * map.sizeY)
                    position = (map.sizeX * map.sizeY) - 1;

                int particleInRow = 4;
                int heightOffset = ((scheduleParticle[position])/ particleInRow) * 10;
                int widthOffset = ((((scheduleParticle[position]) - ((scheduleParticle[position] / particleInRow) * particleInRow))) * 10);

                scheduleParticle[position] += 1;

                int cellX = (int)position / map.sizeY;
                int cellY = (int)position % map.sizeY;

                Brush colorBrush = Brushes.Blue;
                if (Int32.Parse(particleTextBox.Text) < 21)
                {
                    colorBrush = Graphics.SetColorBrush(color);
                }

                mapPictureBox.CreateGraphics().FillEllipse(colorBrush, grid[cellX, cellY].X + widthOffset, grid[cellX, cellY].Y + heightOffset, 10, 10);
                color++;
            }
        }

        private void ResetPictureBox()
        {
            mapPictureBox.Image = null;
            mapPictureBox.Refresh();
        }
    }
}