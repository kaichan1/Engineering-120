using System.Diagnostics;
using System.Text;

namespace MoreDataTypesApp
{
    public enum Pokemon
    {
        GRASS, FIRE, ELEC, WATER
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //String message = "I like donuts";
            //Console.WriteLine(message);
            //message = message.Insert(message.Length - 1, "Actually, I like pie");
            //string reminder = "don't forget to cook it.";
            //string completeMessage = String.Concat(message, reminder);
            //Console.WriteLine(message + reminder);
            //Console.WriteLine(completeMessage);

            //Console.WriteLine(StringExercise(" C# list fundamentals "));
            //StringBuilder sb = new StringBuilder("Hello World");
            //Console.WriteLine(StringBuilderExercise(" C# list fundamentals "));

            #region string interpolation
            //string a = "A";
            //string b = "B";
            //string aAndB = "Your blood type is " + a + " " + b + ".";
            //Console.WriteLine(aAndB);
            //aAndB = String.Concat(a, b);
            //Console.WriteLine(aAndB);

            //Console.WriteLine(String.Concat(arrayOfStrings));
            //Console.WriteLine(String.Concat(arrayOfChars));

            //string interpolatedString = $"Your blood type is {a} {b.ToLower()}.";
            //Console.WriteLine(interpolatedString);

            //int num1 = 2;
            //int num2 = 7;

            //string logOfNum1Num2 = $"The log to base {num1} of {num2} is {Math.Log(num2, num1):0.###}";
            //Console.WriteLine(logOfNum1Num2);
            //string money = $"The change is {(num2 - num1):C}";
            //Console.WriteLine(money);
            #endregion

            #region string parsing


            #endregion

            #region array
            
            //1D Arrays
            //string[] arrayOfStrings = { "hello", "world" };
            //char[] arrayOfChars = { 'a', 'b', 'c' };
            //int[] arrayOfInts = new int[10];

            //arrayOfInts[6] = 7;

            //foreach (int n in arrayOfInts)
            //{
            //    Console.WriteLine(n);
            //}

            //string sparta = "SpartaGlobal";
            //var spartaArray = sparta.ToCharArray();

            //var greetings = "Hello,Hi,Hola,Hallo,Hej";
            //var greetingsArray = greetings.Split(',');


            ////2D Arrays
            //int[,] grid = new int[2,4];
            //grid[0,1] = 6;
            //grid[1,3] = 8;

            //foreach(var element in grid)
            //{
            //    Console.WriteLine(element);
            //}

            //string[,] chessBoard = {{ "pawn", "king" },{ "blank", "blank" }, { "enemy king", "enemy pawn"}};
            //int lower1D = chessBoard.GetLowerBound(0);
            //int lower2D = chessBoard.GetLowerBound(1);
            //int upper1D = chessBoard.GetUpperBound(0);
            //int upper2D = chessBoard.GetUpperBound(1);

            //string theBoard = "";
            //for (int i = lower1D; i <= upper1D; i++)
            //{
            //    for (int j = lower2D; j <= upper2D; j++)
            //    {
            //        theBoard += $"{chessBoard[i, j]} is at {i} and {j}\n";
            //    }
            //}
            //Console.WriteLine(theBoard);


            //Jagged Arrays
            //int[][] jaggedIntArray = new int[2][];
            //jaggedIntArray[0] = new int[4];
            //jaggedIntArray[1] = new int[2];

            //jaggedIntArray[0][3] = 666;

            //jaggedIntArray[0] = new int[] { 1, 1, 1, 1 };

            //foreach (int[] innerArray in jaggedIntArray)
            //{
            //    foreach (int value in innerArray)
            //    {
            //        Console.WriteLine(value);
            //    }
            //}

            //string piece = chessBoard[0, 1];
            //int score = jaggedIntArray[0][2];

            #endregion

            #region DateTime

            //var now = DateTime.Now;
            //Console.WriteLine(now);
            //var tomorrow = now.AddDays(1);
            //Console.WriteLine(tomorrow);

            //var nishBday = new DateOnly(1989, 11, 2);
            //Console.WriteLine(nishBday);

            //var now2 = DateOnly.FromDateTime(now);
            //Console.WriteLine(now2);

            //var stopwatch = new Stopwatch();
            //stopwatch.Start();
            //int total = 0;
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    total += i;
            //}
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.Elapsed);

            #endregion

            #region Enums

            Pokemon type = Pokemon.FIRE;

            if (type == Pokemon.WATER) Console.WriteLine("Water is the type");
            else if (type == Pokemon.FIRE) Console.WriteLine("Fire is the type");

            switch (type)
            {
                case Pokemon.ELEC:
                    Console.WriteLine("Bzz");
                    break;
                case Pokemon.GRASS:
                    Console.WriteLine("The worst type");
                    break;
                case Pokemon.FIRE:
                    Console.WriteLine($"Beats {Pokemon.GRASS}");
                    break;
                default:
                    Console.WriteLine("No type found :(");
                    break;
            }

            var poke = (int)Pokemon.GRASS;
            var theType = (Pokemon)60;
            Console.WriteLine(poke);

            var anotherType = Enum.Parse(typeof(Pokemon), "WATER");

            #endregion
        }
        public static void ParsingStrings()
        {
            Console.WriteLine("How many cars do you own?");
            string input = Console.ReadLine();
            //int numOfCars = Int32.Parse(input);

            var success = Int32.TryParse(input, out int numOfCars);

            Console.WriteLine(numOfCars);
        }
        public static string StringExercise(string myString)
        {
            myString = myString.Trim();
            myString = myString.ToUpper();
            myString = myString.Replace('L', '*');
            myString = myString.Replace('T', '*');
            myString = myString.Remove(myString.IndexOf('N')+1);
            return myString;
        }

        public static string StringBuilderExercise(string myString)
        {
            string ucTrimmedString = myString.Trim().ToUpper();
            int nPos = ucTrimmedString.IndexOf('N');

            StringBuilder sb = new StringBuilder(ucTrimmedString);
            sb.Replace('L', '*').Replace('T', '*');
            sb.Remove(nPos + 1, sb.Length - nPos - 1);

            return sb.ToString();
        }
    }
}