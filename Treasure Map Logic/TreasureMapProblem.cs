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
        public int ParticleCount { get; set; }
        public float C1 { get; set; }
        public float C2 { get; set; }

        public uint MaxIteration { get; set; }
        public float MinCostDifference { get; set; }

        public TreasureMap TreasureMap;

        private Random random = new Random();

        public TreasureMapProblem(TreasureMap TreasureMap, int ParticleCount)
        {
            this.TreasureMap = TreasureMap;
            this.ParticleCount = ParticleCount;
            MaxIteration = 100;
            MinCostDifference = 0.5f;
            C1 = 0.1f;
            C2 = 0.2f;
        }

        public TreasureMapProblem(TreasureMap TreasureMap, int ParticleCount, uint MaxIteration, int MinCostDifference)
        {
            this.TreasureMap = TreasureMap;
            this.ParticleCount = ParticleCount;
            this.MaxIteration = MaxIteration;
            this.MinCostDifference = MinCostDifference;
            C1 = 0.1f;
            C2 = 0.2f;
        }

        public TreasureMapProblem(TreasureMap TreasureMap, int ParticleCount, uint MaxIteration, int MinCostDifference, float C1, float C2)
        {
            this.TreasureMap = TreasureMap;
            this.ParticleCount = ParticleCount;
            this.MaxIteration = MaxIteration;
            this.MinCostDifference = MinCostDifference;
            this.C1 = 0.1f;
            this.C2 = 0.2f;
        }

        public float CostFunction(float position)
        {
            float cost = Math.Abs(position - TreasureMap.winnerPosition);
            return cost;
        }

        public float GetRandomPosition()
        {
            int vector = random.Next(0, (TreasureMap.sizeX * TreasureMap.sizeY)); // Random position in map
            return vector;
        }

        public float GetRandomVector()
        {
            int vector = random.Next(-1, 1); // Movement vector
            return vector;
        }

        public float RandomValue()
        {
            float vector = (float)random.NextDouble(); // Random number between [0,1]
            return vector;
        }
    }
}
