using System.Collections.Generic;

namespace CodeKatas
{
    public class Class1
    {

        //Given a string, how many duplicate character are there? e.g.Nishant Mandal should return an array(a, n)
        public static Array DuplicateChar(string word)
        {
            Dictionary<char, bool> dic1 = new Dictionary<char, bool>();
            Dictionary<char, bool> dic2 = new Dictionary<char, bool>();
            foreach (char c in word.ToLower())
            {
                if (dic1.ContainsKey(c))
                    dic2[c] = true;
                else
                    dic1[c] = true;
            }
            return dic2.Keys.ToArray();
        }

        //factorial
        public static int Factorial(int num)
        {
            int fac = num;
            for (int i = num - 1; i > 1; i--)
                fac *= i;
            return fac;
        }

        //Write a method which takes a string and returns true if the string is a pallindrome
        //Write unit tests and consider edge cases
        //Review how to use Coverlet and create a test coverage report
        public static bool Pallindrome(string word)
        {
            int len = word.Length;
            if (len == 0 || len == 1) return true;
            word = word.ToLower();
            for (int i = 0; i <= len/2; i++)
                if (word[i] != word[len - 1 - i])
                    return false;
            return true;
        }

        //Method which returns second highest number in a list
        public static int SecondHighest(List<int> myList)
        {
            if (myList == null || myList.Count <= 1)
                throw new ArgumentOutOfRangeException();
            myList.Sort();
            return myList[myList.Count - 2];
        }
        //{
        //    if (myList == null || myList.Count <= 1)
        //        throw new ArgumentOutOfRangeException();
        //    int highest = myList[0];
        //    int second;
        //    if (myList[1] < highest)
        //        second = myList[1];
        //    else
        //    {
        //        second = highest;
        //        highest = myList[1];
        //    }
        //    for (int i = 2; i < myList.Count; i++)
        //    {
        //        if (myList[i] > highest)
        //        {
        //            second = highest;
        //            highest = myList[i];
        //        }
        //        else if (myList[i] > second)
        //            second = myList[i];
        //    }
        //    return second;
        //}
    }
}