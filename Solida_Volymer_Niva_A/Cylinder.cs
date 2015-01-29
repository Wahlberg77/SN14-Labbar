using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solida_Volymer_Niva_A
{
    class Cylinder : Solid
    {
        public double BaserArea { get; }
        public double SurfaceArea { get; }
        public double Volume { get; }

        public double CircularCone(double radius, double height);


        public override double BaseArea
        {
            get { throw new NotImplementedException(); }
        }
    }
}
