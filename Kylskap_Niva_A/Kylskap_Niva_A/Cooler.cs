using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylskap_Niva_A
{
    class Cooler
    {
        //Fält
        private decimal _insideTemperature; //Aktuella temperaturen i kylskåpet.
        private decimal _targetTemperature; //Måltemperaturen för kylskåpet.
        //Konstant
        private const decimal OutsideTemperature = 23.7m; //Symboliserar den temperatur som är runt kylskåpet
        private bool isOn;

        //Egenskaper
        public bool DoorIsOpen
        {
            get;
            set;
        }

        public bool IsOn
        {
            get;
            set;
        }

        public decimal InsideTemperature
        {
            get { return _insideTemperature; }

            set
            {
                if (0 > value || value > 40)
                {
                    throw new ArgumentException();
                }

                _insideTemperature = value;
            }

        }

        public decimal TargetTemperature
        {
            get { return _targetTemperature; }

            set
            {
                if (0 > value || value > 20)
                {
                    throw new ArgumentException();
                }

                _targetTemperature = value;
            }
        }

        //Metoder        
        public void Tick()
        {

            if (IsOn)
            {
                if (DoorIsOpen)
                {
                    InsideTemperature += 0.2m;
                }

                else
                {
                    InsideTemperature -= 0.2m;
                }

            }

            else
            {
                if (DoorIsOpen)
                {
                    InsideTemperature += 0.5m;
                }
                else
                {
                    InsideTemperature += 0.1m;
                }

            }
            // Inte sjunker under TargetTemperature
            if (InsideTemperature <= TargetTemperature)
            {
                InsideTemperature = TargetTemperature;
            }
            if (InsideTemperature >= OutsideTemperature)
            {
                InsideTemperature = OutsideTemperature;
            }
        }

        ////Använd en decimaler i temperaturen, ConverseParse...?
        public override string ToString()
        {

            string onOff = IsOn ? "PÅ" : "AV";
            string doorIsOpen = DoorIsOpen ? "Öppet" : "Stängt";

            //Console.WriteLine("[PÅ/AV] : Aktuell temp : (måltemp) - Öppet/Stängt");
            return String.Format("[{0}] : {1:F1}°C : ({2:F1}°C) - {3}", onOff, InsideTemperature, TargetTemperature, doorIsOpen);
        }

        //Konstruktorerna
        public Cooler()
            : this(0.0m, 0.0m)
        {

        }

        public Cooler(decimal insideTemperature, decimal targetTemperature)
            : this(insideTemperature, targetTemperature, false, false)
        {

        }

        public Cooler(decimal insideTemperature, decimal targetTemperature, bool isOn, bool doorIsOpen)
        {
            InsideTemperature = insideTemperature;
            TargetTemperature = targetTemperature;
            IsOn = isOn;
            DoorIsOpen = doorIsOpen;
        }

        public string message { get; set; }
    }
}
