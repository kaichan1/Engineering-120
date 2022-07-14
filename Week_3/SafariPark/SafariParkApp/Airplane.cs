using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public class Airplane : Vehicle
    {
        //private string _airline;
        public string Airline { get; private set; }
        
        private int _altitude;
        public int Altitude
        {
            get { return _altitude; }
            set { _altitude = value < 0 ? throw new ArgumentOutOfRangeException() : value; }
        }

        public Airplane(int capacity) : base(capacity) { }
        public Airplane(int capacity, int speed, string airline) : base (capacity, speed)
        {
            Airline = airline;
        }
        public void Ascend(int metres)
        {
            Altitude += metres;
        }
        public void Descend(int metres)
        {
            Altitude -= metres;
        }
        public override string Move()
        {
            return $"{base.Move()} at an altitude of {Altitude} metres.";
        }
        public override string Move(int times)
        {
            return $"{base.Move(times)} at an altitude of {Altitude} metres.";
        }
        public override string ToString()
        {
            return $"Thank you for flying {Airline}: ClassApp.Airplane capacity: {_capacity} passengers: {NumPassengers} speed: {Speed} position: {Position} altitude: {Altitude}.";
        }
    }
}
