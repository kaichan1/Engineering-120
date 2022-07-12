using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public class Person
    {
        //public int Age { get; set; } = 1;

        private readonly string _hairColour;
        private const int numberOfFinders = 12;
        private string _firstName;
        private string _lastName;

        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value < 0 ? throw new ArgumentException() : value; }
        }

        public Person(string firstName, string lastName, int age, string hairCol = "Yellow")
        {
            _firstName = firstName;
            _lastName = lastName;
            Age = age;
            _hairColour = hairCol;
        }

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public Person() { }

        public string FullName => $"{_firstName} {_lastName}";

        //public void SetNames(string fName, string lName)
        //{
        //    _firstName = fName;
        //    _lastName = lName;
        //}
    }
}
