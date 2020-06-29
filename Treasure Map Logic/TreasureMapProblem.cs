using Particle_Swarm_Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treasure_Map_Logic
{
    public class TreasureMapProblem : IProblem
    {
        public TreasureMap TreasureMap;

        private Random random = new Random();

        public TreasureMapProblem(TreasureMap TreasureMap)
        {
            this.TreasureMap = TreasureMap;
        }

        public double CostFunction(Vector position)
        {
            double cost = Math.Sqrt(Math.Pow(position.Item[0] - TreasureMap.winnerPosition.Item[0], 2) + Math.Pow(position.Item[1] - TreasureMap.winnerPosition.Item[1], 2));
            return cost;
        }

        public Vector GetRandomPosition()
        {
            Vector particle = new Vector(2);
            particle.Item[0] = random.Next(0, TreasureMap.sizeX);
            particle.Item[1] = random.Next(0, TreasureMap.sizeY);
            return particle;
        }

        public Vector GetRandomVector()
        {
            Vector particle = new Vector(2);
            particle.Item[0] = Convert.ToSingle((random.NextDouble() * 2) - 1.0);
            particle.Item[1] = Convert.ToSingle((random.NextDouble() * 2) - 1.0);
            return particle;
        }
    }
}
