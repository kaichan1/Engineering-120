namespace Lambda_Lesson
{
    /*
     Lambdas:
        Have no name
        Is declared at the place it is used
        Cannot be reused anywhere else
        The types of parameter/s are inferred from context
    .Sum(method that returns a number)
    .Where(method that returns a bool)
    .OrderBy(method that returns a key)
    .Count(method that returns a bool)
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { 3, 7, 1, 2, 8, 3, 0, 4, 5 };
            //int allCount = nums.Count();
            //int allCountAlt = 0;
            //foreach (var num in nums)
            //{
            //    allCountAlt++;
            //}

            //int countEven = 0;
            //foreach (var num in nums)
            //{
            //    if (IsEven(num))
            //    {
            //        countEven++;
            //    }
            //}

            int countMEven = nums.Count(IsEven);
            //DO NOT USE ANONYMOUS METHODS!!!!
            int countDEven = nums.Count(delegate (int n) { return n % 2 == 0; });
            int countLEven = nums.Count(x => x % 2 == 0);

            var people = new List<Person>
            {
                new Person {Name = "Nish", Age = 40, City = "Birmingham"},
                new Person {Name = "Cathy", Age = 20, City = "Ottawa"},
                new Person {Name = "Peter", Age = 55, City = "London"}
            };

            int countYoungPeople = people.Count(IsYoung);
            int countYoungPeopleLambda = people.Count(x => x.Age < 30);
            int totalAge = people.Sum(x => x.Age);
            int totalAgeAlt = people.Select(x => x.Age).Sum();

            //using a lambda expression, in one line
            //find the total age of people older than or equal to 30
            int totalAgeLambda = people.Sum(x => x.Age >= 30 ? x.Age : 0);

            //WHERE
            //var londonPeopleQuery = people.Where(p => p.City == "London");
            //foreach (var p in londonPeopleQuery)
            //{
            //    Console.WriteLine(p);
            //}

            //ORDER BY
            //var peopleOrderByAge = people.OrderBy(x => x.Age).OrderByDescending(x => x.Name);
            //foreach (var p in peopleOrderByAge)
            //{
            //    Console.WriteLine(p);
            //}

            //SELECT
            var londonAges = people.Where(p => p.City == "london").Select(x => x.Age);
            foreach (var p in londonAges)
            {
                Console.WriteLine(p);
            }

            var anon = people.Select(x => new { FullName = x.Name });
            var employee = new { Age = 30, Name = 12 };
        }
        public static bool IsYoung(Person p)
        {
            return p.Age < 30;
        }
        public static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
    }
}