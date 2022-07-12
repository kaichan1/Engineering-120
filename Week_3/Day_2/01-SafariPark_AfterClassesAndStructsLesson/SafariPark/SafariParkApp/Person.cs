using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public  class Person
    {


        private readonly string _hairColour;
        private const int numberOfFinders =12;
        public string FirstName { get;  set; }
        public string LastName { get;  set; }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value < 0 ? throw new ArgumentException() : value;   }
        }



        public Person(string firstName, string lastName, int age, string hairCol = "Yellow")
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            _hairColour = hairCol;
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person(){}

        public string FullName => $"{FirstName} {LastName}";

        //public void SetFullName(string fName, string lName)
        //{
        //    _firstName = fName;
        //    _lastName = lName;
        //}
    }
}
