using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treasure_Map_Logic
{
    public class TreasureMap
    {
        public int sizeX;
        public int sizeY;

        public int winnerPosition;

        public int[,] board;

        public TreasureMap()
        {
            sizeX = 10;
            sizeY = 10;
            board = new int[sizeX, sizeY];
        }

        public TreasureMap(int sizeX, int sizeY, int winnerPosition)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            board = new int[sizeX, sizeY];

            this.winnerPosition = winnerPosition;
        }

        public void SetWinnerPosition(int winnerPosition)
        {
            if (winnerPosition > -1 && winnerPosition < sizeX * sizeY)
            {
                this.winnerPosition = winnerPosition;
            }
            else
            {
                throw new Exception("Bad winner position!");
            }
        }
    }
}
