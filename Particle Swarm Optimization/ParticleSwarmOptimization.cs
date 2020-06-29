using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particle_Swarm_Optimization
{
    public class ParticleSwarmOptimization
    {
        private IProblem problem;
        private PSOParameters parameters;

        private Random random = new Random();
        private int iterationsCount = 0;

        private Vector pBest = default(Vector); // Best global particle position

        private List<Vector> vi; // Velocity vector for each particle
        private List<Vector> pi; // The current position for every particle
        private List<Vector> piBest; // The best local solution for every particle

        private double pBestCost; // Best global particle position cost
        private List<double> piBestCost; //The best local solution for every particle cost

        private bool finishStatus = false; // Finish particle swarm optimization algorithm flag

        public ParticleSwarmOptimization(IProblem problem, PSOParameters parameters)
        {
            this.problem = problem;
            this.parameters = parameters;
            iterationsCount = 0;
        }

        public void Start()
        {
            PrepareParticleSwarm();

            while (CheckStop())
            {
                ParticleSwarmMove();
            }
        }

        public void NextMove()
        {
            if (iterationsCount == 0)
            {
                PrepareParticleSwarm();
            }

            if (CheckStop())
            {
                ParticleSwarmMove();
            }
        }

        public void Reset()
        {
            iterationsCount = 0;
            pBest = default(Vector);
            finishStatus = false;
        }

        private void PrepareParticleSwarm()
        {
            vi = new List<Vector>(parameters.ParticleCount);
            pi = new List<Vector>(parameters.ParticleCount);
            piBest = new List<Vector>(parameters.ParticleCount);
            piBestCost = new List<double>(parameters.ParticleCount);
            pBestCost = double.MaxValue;

            // Particle initialization
            for (int i = 0; i < parameters.ParticleCount; i++)
            {
                vi.Add(problem.GetRandomVector());
                pi.Add(problem.GetRandomPosition());
                piBest.Add(pi[i]);

                if (i == 0)
                    pBest = new Vector(vi[i].Size);

                piBestCost.Add(problem.CostFunction(piBest[i]));

                if (pBest.Equals(default(float)) || piBestCost[i] < pBestCost)
                {
                    pBest = piBest[i];
                    pBestCost = piBestCost[i];
                }
            }
        }

        private void ParticleSwarmMove()
        {
            for (int i = 0; i < parameters.ParticleCount; i++)
            {
                var c1 = parameters.C1;
                var c2 = parameters.C2;
                var r1 = (float)random.NextDouble();
                var r2 = (float)random.NextDouble();

                vi[i] = vi[i] + c1 * r1 * (piBest[i] - pi[i]) + c2 * r2 * (pBest - pi[i]);
                pi[i] = pi[i] + vi[i];

                double piCost = problem.CostFunction(pi[i]);

                if (piCost <= piBestCost[i])
                {
                    piBest[i] = pi[i];
                    piBestCost[i] = piCost;
                    if (piCost <= pBestCost)
                    {
                        pBest = pi[i];
                        pBestCost = piCost;
                    }
                }
            }
            iterationsCount++;
        }

        private bool CheckStop()
        {
            if (parameters.MaxIteration > 0 && parameters.MaxIteration == iterationsCount)
            {
                finishStatus = true;
                return false;
            }
            else if (problem.CostFunction(pBest) <= parameters.MinCostDifference)
            {
                finishStatus = true;
                return false;
            }
            else
                return true;
        }

        public Vector GetBestParticlePosition()
        {
            return pBest;
        }

        public List<Vector> GetParticlePositions()
        {
            return pi;
        }

        public int GetIterationsCount()
        {
            return iterationsCount;
        }

        public bool GetFinishStatus()
        {
            return finishStatus;
        }
    }
}
