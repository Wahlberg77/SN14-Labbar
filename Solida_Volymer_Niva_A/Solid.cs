using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solida_Volymer_Niva_A
{
    enum SolidType { CircularCone, Cylinder }

    public abstract class Solid
    {

        //Fields
        private double _height;
        private double _radius;
        
        //Abstrakt klass
        public abstract double BaseArea {get;}
        
        //Egenskaper
        public double Height 
        { 
        get
            {
                return _height;
            }
            
            set
            {
                if (_height < 0 )
                {
                    throw new ArgumentException();
                }
            }
        }
        public double HeightSquare 
        {
            get
            {
                return (_height * _height);
            }
        }
        public double Radius 
        {
            get
            {
                return _radius;
            }

            set
            {
                if (_radius < 0)
                {
                    throw new ArgumentException();
                }
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
                
        public abstract double Volume {get;}
        
        //Konstruktorn
        protected Solid(double radius, double height)
        {    
            Radius = radius;
            Height = height;
        }
  
        //Metoden ToString
        public override string ToString()
        {   //Kolla detta.. kommer se väldigt knas ut! :=)
            return string.Format(" {0} : {1} : {2} : {3} : {4}", Radius, Height, Volume, BaseArea, SurfaceArea);
        }
    }

}
