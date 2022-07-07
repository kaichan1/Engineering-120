namespace ExceptionsApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var theBeatles = new string[] {"John", "Paul", "Ringo", "George"};
            //theBeatles[4] = "Yoko";
            //string text;
            //var fileName = File.ReadAllText("Wonderwall.txt");
            //try
            //{
            //    text = File.ReadAllText(fileName);
            //    Console.WriteLine(text);
            //}
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine("Sorry can't find " + fileName);
            //}

            #region Throw
            // DIDN'T WORK:
            //int a = 1;
            //int b = 0;
            //try
            //{
            //    Console.WriteLine(a/b);
            //}
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine("Can't divide by zero");
            //    b = 1;
            //    throw;
            //}
            #endregion

            //try
            //{
            //    Console.WriteLine("Charlie received 88: " + Grade(88));
            //    Console.WriteLine("Thomas received -100: " + Grade(-100));
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("I will always execute");
            //}

            //int anInt = 3;//explicitly typed
            //var vInt = 3; //implicitly typed

            //var name = "Peter";
            //var isClean = true;
            //var letter = 'p';
            //var uLongNum = 52uL;

            //string[]
            //string[] arr = new string()

            //var list = new List<string>();
            //List<string> list2 = new List<string>();
            //short n1 = -65;
            //ushort n2 = 65;
            //int n3 = -100_000;
            //short u2 = 1;
            //uint n4 = 100_000;
            //uint n5 = 4_000_000_000;
            //long n6 = -5_000_000_000;
            //ulong n7 = 5_000_000_000;

            //float sum = 0;
            //for (int i = 0; i < 100_000; i++)
            //{
            //    sum += 2 / 5.0f;
            //}
            //Console.WriteLine("2/5 added 100,000 times: " + sum);
            //Console.WriteLine("2/5 multiplied 100,000: " + 2/5.0f * 100_000);

            //var result = 5.0 / 5;

            //int a = 3;
            //double b = a;

            //double c = 3.1;
            //int d = c;        //implicit casting
            //int d = (int)c;   //explicit casting (manual):

            int a = 3;
            double b = (double)a;
            Console.WriteLine(b);

            //int max = int.MaxValue;
            //max++;
            //checked
            //{
            //    sbyte sNum = SByte.MaxValue;
            //    Console.WriteLine("SByte max: " + sNum);
            //    sNum += 1;
            //    Console.WriteLine(sNum);
            //}

            //ulong bankBalance = 4_294_967_300;
            //uint posBalance = (uint)bankBalance;
            //uint posBalance2 = Convert.ToUInt32(bankBalance);

            //Console.WriteLine(Convert.ToString(bankBalance, 2);
            //Console.WriteLine(Convert.ToString(posBalance, 2);

            //char n = 'N';
            //int i = n;
            //Console.WriteLine((int)n);
            //Console.WriteLine(i);

            //var theInt = 78;
            //var anotherInt = Convert.ToChar(theInt);
            //var doubleEx = Convert.ToDouble(theInt);
            //Console.WriteLine(anotherInt);  

            double myDouble = 3.4;
            int myInt2 = Convert.ToInt32(myDouble);

            //Invalid casting
            //var date = Convert.ToDateTime(myInt2);
        }

        public static string Grade(int mark)
        {
            if (mark < 0 || mark > 100)
            {
                throw new ArgumentOutOfRangeException("Mark: " + mark + " Allowed range 0-100");
            }
            return mark >= 65 ? (mark >= 85 ? "Distinction" : "Pass") : "Fail";
        }
    }
}