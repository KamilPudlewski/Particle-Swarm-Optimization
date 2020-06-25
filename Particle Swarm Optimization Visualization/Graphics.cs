using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particle_Swarm_Optimization_Visualization
{
    public static class Graphics
    {
        public static Brush SetColorBrush(int number)
        {
            switch (number)
            {
                case 0:
                    return Brushes.Black;
                case 1:
                    return Brushes.Red;
                case 2:
                    return Brushes.Blue;
                case 3:
                    return Brushes.Green;
                case 4:
                    return Brushes.Orange;
                case 5:
                    return Brushes.Gray;
                case 6:
                    return Brushes.Brown;
                case 7:
                    return Brushes.Aqua;
                case 8:
                    return Brushes.Olive;
                case 9:
                    return Brushes.BlueViolet;
                case 10:
                    return Brushes.DarkGoldenrod;
                case 11:
                    return Brushes.DeepPink;
                case 12:
                    return Brushes.LimeGreen;
                case 13:
                    return Brushes.Pink;
                case 14:
                    return Brushes.OrangeRed;
                case 15:
                    return Brushes.LemonChiffon;
                case 16:
                    return Brushes.AliceBlue;
                case 17:
                    return Brushes.BurlyWood;
                case 18:
                    return Brushes.Moccasin;
                case 19:
                    return Brushes.MistyRose;
                case 20:
                    return Brushes.OliveDrab;
                default:
                    return Brushes.Black;
            }
        }
    }
}
