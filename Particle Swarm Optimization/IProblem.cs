﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particle_Swarm_Optimization
{
    public interface IProblem
    {
        Vector GetRandomVector();
        Vector GetRandomPosition();
        double CostFunction(Vector position);
    }
}
