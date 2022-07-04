namespace CodeKatas
{
    public class Class1
    {
        public static int DuplicateChar(string word)
        {
            System.Collections.Generic.Dictionary<string, int> dic = new System.Collections.Generic.Dictionary<string, int>();
        }

        public static int Factorial(int num)
        {
            int product = num;
            for (int i = num - 1; i >= 0; i--)
            {
                product = product * i;
            }
            return product;
        }

        public static int Pallindrome(string word)
        {
            for (int i = word.Length / 2; i > 0; i--)
            {

            }
            return 0;
        }
    }
}