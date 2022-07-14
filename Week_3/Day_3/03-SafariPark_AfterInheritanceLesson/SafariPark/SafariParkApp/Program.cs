using SafariParkApp.Misc;

namespace SafariParkApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Person jon = new Person("Jon", "Crofts", 22);
            //jon.Age = 23;
            //Console.WriteLine(jon.Age);
            //Console.WriteLine(jon.GetFullName());
            //Console.WriteLine(jon.FirstName);
            //Person charlie = new Person("Charlie");
            //Person peter = new Person();
            //peter.Age = 3;
            //Person dan = new Person("Dan", "Summerside") { Age = 100 };
            //Person laba = new Person { FirstName = "Laba", LastName = "Limbu", Age = 33};

            //var shop1 = new Shopping { Ties = 3, Shirts = 3, Trousers = 1 };
            //var shop2 = new Shopping { Socks = 10 };

            //var kai = new Spartan { FullName = "Kai", Course = "C# SDET", Personalid = 999};

            //Point3d p3d;
            //p3d.x = 2;


            //Point3d pt = new Point3d(3,6,2);
            //Person jon = new Person("Jon", "Crofts", 22);
            //DemoMethod(pt, jon);

            Hunter maks = new Hunter("Maks", "Hadys", "Sony") { Age = 10 };
            //Console.WriteLine(maks.Age);
            //Console.WriteLine(maks.Shoot());

            Person dan = new Person("Dan", "Daaboul") { Age = 1 };
            //Console.WriteLine(nish.Shoot());
            var maks2 = maks;
            //Console.WriteLine($"h equals h2? {maks.Equals(dan)}");
            //Console.WriteLine(maks.GetHashCode());
            //Console.WriteLine(maks2.GetHashCode());
            //Console.WriteLine(dan.GetHashCode());
            //Console.WriteLine(1.GetHashCode());
            //Console.WriteLine(1.GetHashCode());
            Console.WriteLine(maks.ToString());

            //var shape = new Shape();
            var rect = new Rectangle(1,2);
            Console.WriteLine(rect.CalculateArea());


            Airplane a = new Airplane(200, 100, "JetsRUs")​;
            a.NumPassengers = 150 ;
            a.Ascend(500);​
            Console.WriteLine(a.Move(3));​
            Console.WriteLine(a);​
            a.Descend(200);​
            Console.WriteLine(a.Move());​
            a.Move();​
            Console.WriteLine(a);
        }

        public static void DemoMethod(Point3d pt, Person p)
        {
            pt.x = 100;
            p.Age = 100;
        }
    }
}