namespace CodeKatas
{
    public class Class1
    {
        public static Array DuplicateChar(string word)
        {
            System.Collections.Generic.Dictionary<char, int> dic = new System.Collections.Generic.Dictionary<char, int>();
            foreach (char c in word)
            {
                dic[c] = dic.TryGetValue(c, out int 0) + 1;
            }
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

        public static bool Pallindrome(string word)
        {
            int len = word.Length;
            for (int i = 0; i <= len/2; i++)
            {
                if (word[i] != word[len - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}