using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solida_Volymer_Niva_A
{
    public class CircularCone : Solid
    {
        public double BaseArea
        {
            get
            {
                return Math.PI * (Radius * Radius);
            }
        }

        public double SurfaceArea
        {
            get
            {
                return ((Math.PI * Radius) * (Radius + Math.Round(Math.Sqrt(RadiusSquare + HeightSquare))));
            }
        }

        public double Volume
        {
            get
            {
                return (Math.PI * (Radius * Radius) * Height);
            }
        }

        public CircularCone(double radius, double height) : base(radius, height) { }

    }
}
