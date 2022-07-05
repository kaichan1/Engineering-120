namespace OperatorsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Int operations
            //int x = 0;
            //int y = 0;
            //int a = x++;
            //int b = ++y;

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //var c = 5 / 2;
            //var d = 5.0 / 2;
            //var e = 5 / 3;
            #endregion

            #region Modulus
            // var g = 5 % 2;

            //in weeks and days - what is 15 days
            var weeks = 15 / 7;
            var days = 15 % 7;
            Console.WriteLine($"{weeks} weeks and {days} day/s");

            //Console.WriteLine(FindSumDiv5and7(100));

            const int NUM_ROWS = 2;
            const int NUM_COLS = 5;
            bool running = true;
            int row = 0;
            int col = 0;
            int sprintNo = -1;

            while (running)
            {
                sprintNo++;
                sprintNo %= (NUM_ROWS * NUM_COLS);
                row = sprintNo / NUM_COLS;
                col = sprintNo % NUM_COLS;
            }
            #endregion

            #region Logical Operators

            //bool isWearingParachute = false;
            //if (isWearingParachute & JumpOutOfPlane())
            //{
            //    Console.WriteLine("Congrats, you have made a successful jump");
            //}

            //string greeting = "Hello";
            //if (greeting != null & greeting.ToLower().StartsWith('h'))
            //{
            //    Console.WriteLine($"{greeting} starts with an 'h'");
            //}

            //int n = 0;
            //int o = 3;
            //if (n == 5 ^ o == 3)
            //{
            //    Console.WriteLine("Exclusive or");
            //}

            #endregion

            #region Selection

            #endregion
        }

        public static bool JumpOutOfPlane()
        {
            Console.WriteLine("Jump");
            return true;
        }

        //return sum of all numbers of 1 to n
        public static int FindSumDiv5and7(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 5 == 0 || i % 7 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}