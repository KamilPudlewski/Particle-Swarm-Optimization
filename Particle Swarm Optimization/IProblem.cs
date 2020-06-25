using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particle_Swarm_Optimization
{
    public interface IProblem
    {
        int ParticleCount { get; set; }
        float C1 { get; set; }
        float C2 { get; set; }

        uint MaxIteration { get; set; }
        float MinCostDifference { get; set; }

        float GetRandomVector();
        float GetRandomPosition();
        float RandomValue();
        float CostFunction(float position);

    }
}
