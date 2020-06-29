using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particle_Swarm_Optimization
{
    public class PSOParameters
    {
        public int ParticleCount;
        public float C1;
        public float C2;

        public uint MaxIteration;
        public float MinCostDifference;

        public PSOParameters()
        {
            ParticleCount = 5;
            C1 = 0.1f;
            C2 = 0.1f;
            MaxIteration = 100;
            MinCostDifference = 0f;
        }

        public PSOParameters(int ParticleCount, float C1, float C2, uint MaxIteration)
        {
            this.ParticleCount = ParticleCount;
            this.C1 = C1;
            this.C2 = C2;
            this.MaxIteration = MaxIteration;
            MinCostDifference = 0f;
        }

        public PSOParameters(int ParticleCount, float C1, float C2, uint MaxIteration, float MinCostDifference)
        {
            this.ParticleCount = ParticleCount;
            this.C1 = C1;
            this.C2 = C2;
            this.MaxIteration = MaxIteration;
            this.MinCostDifference = MinCostDifference;
        }
    }
}
