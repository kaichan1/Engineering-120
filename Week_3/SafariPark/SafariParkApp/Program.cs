using System.Collections;
using SafariParkApp.Misc;

namespace SafariParkApp
{
    public class Program
    {
        private ICalculator _calc;
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
            ////Person laba = new Person { FirstName = "Laba", LastName = "Limbu", Age = 33 };
            //Person x = new Person("x", "y") { };

            //var shop1 = new Shopping { Ties = 3, Shirts = 3, Trousers = 1 };
            //var shop2 = new Shopping { Socks = 10 };

            //var kai = new Spartan { FullName = "Kai", Course = "C# SDET", Personalid = 999 };
            //var kai = new Spartan(999) { FullName = "Kai", Course = "C# SDET"};
            //kai.Personalid = 998;

            #region Struct
            //Point3d p3d;
            //p3d.x = 2;

            //Point3d pt = new Point3d(3, 6, 2);
            //Person jon = new Person("Jon", "Crofts", 22);
            //DemoMethod(pt, jon);
            #endregion

            //Hunter maks = new Hunter("Maks", "Hadys", "Sony") { Age = 10 };
            //Console.WriteLine(maks.Age);
            //Console.WriteLine(maks.Shoot());

            //Person dan = new Person("Dan", "Daaboul") { Age = 1 };
            //Console.WriteLine(nish.Shoot());
            //var maks2 = maks;
            //Console.WriteLine($"h equals h2? {maks.Equals(dan)}");
            //Console.WriteLine(maks.GetHashCode());
            //Console.WriteLine(maks2.GetHashCode());
            //Console.WriteLine(dan.GetHashCode());
            //Console.WriteLine(1.GetHashCode());
            //Console.WriteLine(1.GetHashCode());
            //Console.WriteLine(maks.ToString());

            //var shape = new Shape();
            //var rect = new Rectangle(1,2);
            //Console.WriteLine(rect.CalculateArea());

            //Airplane a = new Airplane(200, 100, "JetsRUs") { NumPassengers = 150 };
            //a.Ascend(500);
            //Console.WriteLine(a.Move(3));
            //Console.WriteLine(a);
            //a.Descend(200);
            //Console.WriteLine(a.Move());
            //a.Move();
            //Console.WriteLine(a);

            //var ellis = new Hunter("Ellis", "Witten", "Nikon") { Age = 21 };
            //var plane = new Airplane(400, 200, "Virgin");
            //var vehicle = new Vehicle(20, 20);
            //var kenny = new Person("Kenny", "harvey") { Age = 22 };

            //List<Object> gameObjs = new List<Object>
            //{
            //    ellis, plane, vehicle, kenny
            //};

            //foreach (var gameObj in gameObjs)
            //{
            //    Console.WriteLine(gameObjs);
            //}

            //SpartaWrite(ellis);

            //var ellis2 = (Person)ellis;
            //Console.WriteLine(ellis2.Equals(ellis));
            //ellis2.Age = 31;
            //Console.WriteLine(ellis.Age);

            #region Interface exercise
            //List<IMovable> gameObjs = new List<IMovable> { plane, vehicle, kenny };
            //foreach (IMovable gameObj in gameObjs)
            //    Console.WriteLine(gameObj.Move());
            #endregion

            #region Group project
            //WaterPistol pistol = new WaterPistol("Supersoaker");
            //LaserGun laserGun = new LaserGun("Acme");
            //Camera pentax = new Camera("Pentax");
            //Hunter ellis = new Hunter("Ellis", "Witten", pistol) { Age = 21 };
            //Hunter muhammad = new Hunter("Muhammad", "Daaboul", pentax) { Age = 60 };
            //List<IShootable> shootableObjs = new List<IShootable> { pistol, laserGun, ellis, muhammad, pentax };
            //foreach (var shootableObj in shootableObjs)
            //{
            //    Console.WriteLine(shootableObj.Shoot());
            ////}
            //ellis.Shooter = laserGun;
            //Console.WriteLine(ellis.Shoot());
            //ellis.Shooter = pentax;
            //Console.WriteLine(ellis.Shoot());

            //Console.WriteLine(pistol.ToString());
            //Console.WriteLine(pentax.ToString());
            //Console.WriteLine(ellis.ToString());
            #endregion

            //var hare = new Hare();
            //List<ISingleMovable> movers = new List<ISingleMovable>
            //{
            //    ellis, plane, vehicle, kenny, hare
            //};

            //dynamic example = 1;
            //example = "Nish";
            //example = new Hare();

            //_calc = new Mock(ICalculator).Instance;

            #region List
            //List<Person> peopleList = new List<Person>()
            //{ 
            //    new Person("Nish", "Mandal") { Age = 32 }
            //};
            //var kai = new Person("Kai", "Chan");
            //var tom = new Person("Tom", "W");

            //peopleList.Add(tom);

            //var newerList = new List<Person>();
            //newerList.AddRange(peopleList);
            //newerList.Add(kai);

            //peopleList.ForEach(x => Console.WriteLine(x));
            //Console.WriteLine();
            //newerList.ForEach(x => Console.WriteLine(x));

            //peoplelist.ToArray();
            #endregion

            #region ArrayList
            //ArrayList al = new ArrayList();
            //al.Add(1);
            //al.Add(kai);
            //al.Add("Hello");

            //foreach (var item in al)
            //{
            //    Console.WriteLine(item);
            //}

            //int i = 100;
            ////Boxing
            //object i2 = i;
            ////Unboxing
            //int a = (int)i2;
            #endregion

            #region List exercise
            //List<int> intList = new List<int>() { 5, 4, 3, 9, 0 };
            //intList.Add(8);
            //intList.Sort();
            //intList.RemoveRange(1, 2);
            //intList.Reverse();
            //intList.Remove(9);
            //foreach (int i in intList)
            //    Console.Write(i + " ");
            #endregion

            #region Linked list
            //Console.WriteLine("LinkedList of People");
            //var linkedList = new LinkedList<Person>();
            //linkedList.AddFirst(kai);
            //linkedList.AddLast(tom);
            ////linkedList[0];    //won't work:
            //var tommy = linkedList.Find(tom).Value;
            //Console.WriteLine(linkedList.Find(tom).Value);
            //foreach (var item in linkedList)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

        }

        public static void SpartaWrite(Object obj)
        {
            Console.WriteLine(obj);
            if (obj is Hunter)
            {
                var hunterObj = (Hunter)obj;
                Console.WriteLine(hunterObj.Shoot());
            }
        }
        public static void DemoMethod(Point3d pt, Person p)
        {
            pt.x = 100;
            p.Age = 100;
        }
    }
}