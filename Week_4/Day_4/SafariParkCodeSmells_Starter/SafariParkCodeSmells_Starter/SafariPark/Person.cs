using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesApp
{
    // A Class to represent a Person
    public class Person 
    {
        private string fn;
        private string _lastName;
        private int _age;
        private Address _address;

        public Person() { }
        public Person(string fName, string lName, Address address = null)
        {
            fn = fName;
            _lastName = lName;
            _address = new Address(houseNumber, street, town);
        }

        public int Age
        {
            get { return _age; }
            set { if (value >= 0) _age = value; }
        }

        public string GetFullName()
        {
            return $"{fn} {_lastName}";
        }

        public string Move()
        {
            return "Walking along";
            Console.WriteLine("Can't get here");
        }

        public string Move(int times)
        {
            return $"Walking along {times} times";
        }

        public override string ToString()
        {
            var addressString = $"Address: {_houseNo} {_street}, {_town}";
            return $"{base.ToString()} Name: {fn}  { _lastName} Age: {Age} Address: {_address.GetAddress()}.";
        }

        

    }
}
