using Particle_Swarm_Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Treasure_Map_Logic
{
    public class TreasureMap
    {
        public int sizeX;
        public int sizeY;

        public Vector winnerPosition;

        public int[,] board;

        public TreasureMap()
        {
            sizeX = 0;
            sizeY = 0;
            board = new int[sizeX, sizeY];
        }

        public TreasureMap(int sizeX, int sizeY, Vector winnerPosition)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            board = new int[sizeX, sizeY];

            this.winnerPosition = winnerPosition;
        }

        public void SetWinnerPosition(Vector winnerPosition)
        {
            if (winnerPosition.Item[0] >= 0 && winnerPosition.Item[0] <= sizeX)
            {
                if (winnerPosition.Item[1] >= 0 && winnerPosition.Item[1] <= sizeY)
                    this.winnerPosition = winnerPosition;
            }
            else
            {
                throw new Exception("Bad winner position!");
            }
        }
    }
}
