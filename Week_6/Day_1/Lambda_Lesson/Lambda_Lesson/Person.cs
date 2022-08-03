using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Lesson
{
    public class Person
    {
        public string Name { get; set; }

        private int myVar;
        public int MyProperty
        {
            get => myVar;
            set => myVar = value;
        }
        public int Age { get; set; }
        public string City { get; set; }
        public override string ToString() => $"{Name} - {City} - {Age}";
    }
}
