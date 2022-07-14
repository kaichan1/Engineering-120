using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public class Vehicle : IMovable
    {
        protected int _capacity;
        //public int Capacity { get; set; }
        public int Speed { get; init; } = 10;
        public int Position { get; private set; } = 0;

        private int _numPassengers;
        public int NumPassengers
        {
            get { return _numPassengers; }
            set { _numPassengers = value < 0 || value > _capacity ? throw new ArgumentException() : value; }
        }

        public Vehicle() { }

        public Vehicle(int capacity, int speed = 10)
        {
            _capacity = capacity;
            Speed = speed;
        }

        public virtual string Move()
        {
            Position += Speed;
            return "Moving along";
        }
        public virtual string Move(int times)
        {
            Position += Speed * times;
            return $"Moving along {times} times";
        }

        public override string ToString() => base.ToString() + $" capacity: {_capacity} passengers: {_numPassengers} speed: {Speed} position: {Position}";
    }
}
