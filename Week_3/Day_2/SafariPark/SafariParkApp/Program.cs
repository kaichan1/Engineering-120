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
            //jon.FirstName = "John";
            //Person charlie = new Person("Charlie");
            //Person peter = new Person();
            //Person dan = new Person("Dan", "Summerside") { Age = 100 };
            //Person laba = new Person { FirstName = "Laba", LastName = "Limbu", Age = 33 };

            //var shop1 = new Shopping { Ties = 3, Shirts = 3, Trousers = 1 };
            //var shop2 = new Shopping { Socks = 10 };

            ////var kai = new Spartan { FullName = "Kai", Course = "C# SDET", Personalid = 999 };
            //var kai = new Spartan(999) { FullName = "Kai", Course = "C# SDET"};
            ////kai.Personalid = 998;

            //Point3d p3d;
            //p3d.x = 2;

            //Point3d pt = new Point3d(3, 6, 2);
            //Person jon = new Person("Jon", "Crofts", 22);
            //DemoMethod(pt, jon);

            //Hunter maks = new Hunter("Maks", "Hadys", "Sony") { Age = 10 };
            //Console.WriteLine(maks.Age);
            //Console.WriteLine(maks.Shoot());

            Hunter nish = new Hunter();
            Console.WriteLine(nish.Shoot());
        }

        public static void DemoMethod(Point3d pt, Person p)
        {
            pt.x = 100;
            p.Age = 100;
        }
    }
}