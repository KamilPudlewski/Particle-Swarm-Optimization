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
        private int iterationsCount = 0;

        private float pBest = default(float); // Best global particle position

        private List<float> vi; // Velocity vector for each particle
        private List<float> pi; // The current position for every particle
        private List<float> piBest; // The best local solution for every particle

        private bool finishStatus = false; // Finish particle swarm optimization algorithm flag

        public ParticleSwarmOptimization(IProblem problem)
        {
            this.problem = problem;
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
            pBest = default(float);
            finishStatus = false;
        }

        private void PrepareParticleSwarm()
        {
            vi = new List<float>(problem.ParticleCount);
            pi = new List<float>(problem.ParticleCount);
            piBest = new List<float>(problem.ParticleCount);

            // Inicjalizacja cząstek
            for (int i = 0; i < problem.ParticleCount; i++)
            {
                vi.Add(problem.GetRandomVector());
                pi.Add(problem.GetRandomPosition());
                piBest.Add(pi[i]);

                if (pBest.Equals(default(float)) || problem.CostFunction(piBest[i]) < problem.CostFunction(pBest))
                {
                    pBest = piBest[i];
                }
            }
        }

        private void ParticleSwarmMove()
        {
            for (int i = 0; i < problem.ParticleCount; i++)
            {
                var c1 = problem.C1;
                var c2 = problem.C2;
                var r1 = problem.RandomValue();
                var r2 = problem.RandomValue();

                vi[i] = vi[i] + c1 * r1 * (piBest[i] - pi[i]) + c2 * r2 * (pBest - pi[i]);
                pi[i] = pi[i] + vi[i];

                if (problem.CostFunction(pi[i]) <= problem.CostFunction(piBest[i]))
                {
                    piBest[i] = pi[i];
                    if (problem.CostFunction(pi[i]) <= problem.CostFunction(pBest))
                    {
                        pBest = pi[i];
                    }
                }
            }
            iterationsCount++;
        }

        private bool CheckStop()
        {
            if (problem.MaxIteration > 0 && problem.MaxIteration == iterationsCount)
            {
                finishStatus = true;
                return false;
            }
            else if (problem.CostFunction(pBest) <= problem.MinCostDifference)
            {
                finishStatus = true;
                return false;
            }
            else
                return true;
        }

        public float GetBestParticlePosition()
        {
            return pBest;
        }

        public List<float> GetParticlePositions()
        {
            return pi;
        }

        public float GetIterationsCount()
        {
            return iterationsCount;
        }

        public bool GetFinishStatus()
        {
            return finishStatus;
        }
    }
}
