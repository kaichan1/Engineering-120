namespace CodeKatas
{
    public class Class1
    {

        //Given a string, how many duplicate character are there? e.g.Nishant Mandal should return an array(a, n)
        public static Array DuplicateChar(string word)
        {
            System.Collections.Generic.Dictionary<char, int> dic1 = new System.Collections.Generic.Dictionary<char, int>();
            System.Collections.Generic.Dictionary<char, int> dic2 = new System.Collections.Generic.Dictionary<char, int>();
            foreach (char c in word)
            {
                if (dic1.TryGetValue(c, out int v))
                    dic2[c] += 1;
                else
                    dic1[c] = 1;
            }
            return dic2.ToArray();
        }

        //factorial
        public static int Factorial(int num)
        {
            int fac = num;
            for (int i = num - 1; i > 1; i--)
            {
                fac *= i;
            }
            return fac;
        }

        //Write a method which takes a string and returns true if the string is a pallindrome
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

        //Method which returns second highest number in a list
        public static int SecondHighest(List<int> myList)
        {
            if (myList == null || myList.Count <= 1)
                throw new ArgumentNullException();
            int highest = myList[0];
            int second;
            if (myList[1] < highest)
                second = myList[1];
            else
            {
                second = highest;
                highest = myList[1];
            }
            if (myList.Count > 2)
            {
                for (int i = 0; i < myList.Count; i++)
                {
                    if (myList[i] > highest)
                    {
                        second = highest;
                        highest = myList[i];
                    }
                    else if (myList[i] > second)
                    {
                        second = myList[i];
                    }
                }
            }
            return second;
        }
    }
}