using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solida_Volymer_Niva_A
{
    public class Cylinder : Solid
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
                return (2 * (Math.PI * Radius) * (Height + Radius));
            }
        }
        public double Volume
        {
            get
            {
                return (Math.PI * (Radius * Radius) * Height);
            }
        }

        public Cylinder(double radius, double height) : base (radius, height){} 
    }
}
