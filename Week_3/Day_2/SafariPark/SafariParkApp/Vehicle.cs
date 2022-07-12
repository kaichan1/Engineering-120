using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public class Vehicle
    {
        private int _capacity;
        private int _numPassengers;

        public int NumPassengers
        {
            get { return _numPassengers; }
            private set { _numPassengers = value < 0 || value > _capacity ? throw new ArgumentException() : value; }
        }

        public int Position { get; private set; } = 0;
        public int Speed { get; init; } = 10;

        public Vehicle() { }

        public Vehicle(int capacity, int speed = 10)
        {
            _capacity = capacity;
            Speed = speed;
        }

        public string Move()
        {
            Position += Speed;
            return "Moving along";
        }

        public string Move(int times)
        {
            Position += Speed * times;
            return $"Moving along {times} times";
        }

    }
}
