using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solida_Volymer_Niva_A
{
    public abstract class Solid
    {
        //-------------------------------------------------------------------------------------
        //----------------------- Andreas Wahlberg - Solida Volymer Nivå A --------------------
        //-------------------------------------------------------------------------------------
        //Fields
        private double _height;
        private double _radius;
        //Abstrakt klass
        public abstract double BaseArea { get; }
        //Egenskaper
        public double Height { get; set; }
        public double HeightSquare { get; }
        public double Radius { get; set; }
        public double RadiusSquare { get; }
        //Abstrakt klass
        public abstract double SurfaceArea { get; }
        public abstract double Volume { get; }
        //Konstruktorn
        private double Solid(double radius, double height);
        //Metoden ToString
        public override string ToString();
    }

}
