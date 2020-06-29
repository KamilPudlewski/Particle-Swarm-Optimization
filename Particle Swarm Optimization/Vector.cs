using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particle_Swarm_Optimization
{
    public class Vector
    {
        public int Size;
        public float[] Item;

        public Vector(int Size)
        {
            this.Size = Size;
            Item = new float[Size];
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            if (v1.Size != v2.Size)
                throw new Exception("Vectors length are not equal!");

            Vector result = new Vector(v1.Size);

            for (int i = 0; i < v1.Size; i++)
            {
                result.Item[i] = v1.Item[i] + v2.Item[i];
            }

            return result;
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            if (v1.Size != v2.Size)
                throw new Exception("Vectors length are not equal!");

            Vector result = new Vector(v1.Size);

            for (int i = 0; i < v1.Size; i++)
            {
                result.Item[i] = v1.Item[i] - v2.Item[i];
            }

            return result;
        }

        public static Vector operator *(Vector v, float f)
        {
            Vector result = new Vector(v.Size);

            for (int i = 0; i < v.Size; i++)
            {
                result.Item[i] = v.Item[i] * f;
            }

            return result;
        }

        public static Vector operator *(float f, Vector v)
        {
            Vector result = new Vector(v.Size);

            for (int i = 0; i < v.Size; i++)
            {
                result.Item[i] = v.Item[i] * f;
            }

            return result;
        }
    }
}
