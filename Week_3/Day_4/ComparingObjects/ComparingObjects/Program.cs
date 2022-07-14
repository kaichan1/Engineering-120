namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Comparing objects
            var nish = new Person("Nish", "Mandal") { Age = 22 };
            var david = nish;
            object tom = new Person("Nish", "Mandal") { Age = 22 };
            object charlie = new object();
            var isNish = nish.Equals(tom);
            var isNish2 = nish.Equals(charlie);
            //Console.WriteLine(nish.Equals(tom));
            //Console.WriteLine(nish.Equals(tom));

            //Console.WriteLine(nish.GetHashCode());
            //Console.WriteLine(david.GetHashCode());
            //Console.WriteLine(tom.GetHashCode());
            
            int a = 1;
            var equalsOne = a == 1;            
            var bob = new Person("Bob", "Builder") { Age = 25 };
            var people = new List<Person>
            {
                new Person("Cath", "Cookson"),
                new Person("Bob", "Builder"){ Age = 25 },
                new Person("Dan", "Dare"),
                new Person("Amy", "Andrews"){ Age = 32 },
            };
            //Is there a person named BobBuilder in the list?
            //true:
            //var hasBob = people.Where(x => x.GetFullName() == "Bob Builder").Any();
            //bool hasBob2 = people.Contains(bob);
            #endregion

            #region Hash code
            //var cj = new Person("James Charles", "Charles") { Age = 32 };
            //var jc = new Person("Charles James", "James") { Age = 32 };
            //Console.WriteLine(cj.GetHashCode());
            //Console.WriteLine(jc.GetHashCode());
            #endregion

            #region Sorting
            people.ForEach(x => Console.WriteLine(x.GetFullName()));
            people.Sort();
            people.OrderBy(x => x.Age);
            Console.WriteLine();
            people.ForEach(x => Console.WriteLine(x.GetFullName()));
            //Less than zero, nish comes before bob
            //More than zero, nish comes after bob
            //zero nish and bob same position
            nish.CompareTo(bob);
            #endregion
        }
    }
    public class Person : IEquatable<Person?>, IComparable<Person?>

    {
        private string _firstName;
        private string _lastName;
        private int _age;
        public Person() { }
        public Person(string fName, string lName)
        {
            _firstName = fName;
            _lastName = lName;
        }

        public int Age
        {
            get { return _age; }
            set { if (value >= 0) _age = value; }
        }

        public int CompareTo(Person? other)
        {
            if (other == null) return 1;
            if (this._lastName != other._lastName)
            {
                return this._lastName.CompareTo(other._lastName);
            }
            else if (this._firstName != other._firstName)
            {
                return this._firstName.CompareTo(other._firstName);
            }
            else
            {
                return this._age.CompareTo(other._age);
            }
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person? other)
        {
            return other is not null &&
                   _firstName == other._firstName &&
                   _lastName == other._lastName &&
                   _age == other._age &&
                   Age == other.Age;
        }

        public string GetFullName()
        {
            return $"{_firstName} {_lastName}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_firstName, _lastName, _age, Age);
        }

        public static bool operator ==(Person? left, Person? right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person? left, Person? right)
        {
            return !(left == right);
        }
    }
}