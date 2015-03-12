using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solida_Volymer_Niva_A
{


    public abstract class Solid
    {
        //Fields
        private double _height;
        private double _radius;

        //Abstrakt klass
        public abstract double BaseArea { get; }

        //Egenskaper
        public double Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _height = value;
            }
        }
        public double HeightSquare
        {
            get
            {
                return (_height * _height);
            }
        }
        public double Radius { get{ return _radius; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _radius = value;
            }
        }
        public double RadiusSquare
        {
            get
            {
                return (_radius * _radius);
            }
        }

        //Abstrakt klass
        public abstract double SurfaceArea { get; }
        public abstract double Volume { get; }

        //Konstruktorn
        protected Solid(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }

        //Metoden ToString
        public override string ToString()
        {
            string returnValue;
            returnValue = String.Format("{0,-12}{10,-8}{1:F2}\n{2,-12}{10,-8}{3:F2}\n{4,-12}{10,-8}{5:F2}\n{6,-12}{10,-8}{7:F2}\n{8,-12}{10,-8}{9:F2}",
                " Radie (r)", Radius,
                " Höjd (h)", Height,
                " Volym", Volume,
                " Basarea", BaseArea,
                " Ytarea", SurfaceArea,
                ":");
            return returnValue;
        }
    }
}
