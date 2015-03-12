using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solida_Volymer_Niva_A
{
    public class CircularCone : Solid
    {
        public override double BaseArea
        {
            get
            {
                return Math.PI * RadiusSquare;
            }
        }

        public override double SurfaceArea
        {
            get
            {
                return ((Math.PI * Radius) * (Radius + Math.Round(Math.Sqrt(RadiusSquare + HeightSquare))));
            }
        }

        public override double Volume
        {
            get
            {
                return Math.PI * RadiusSquare * Height;
            }
        }

        public CircularCone(double radius, double height) : base(radius, height) { }
    }
}
