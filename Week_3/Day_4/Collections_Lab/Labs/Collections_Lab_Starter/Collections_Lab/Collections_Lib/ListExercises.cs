using System;
using System.Collections.Generic;

namespace Collections_Lib
{
    public class ListExercises
    {
        // returns a list of all the integers between 1 to max inclusive
        // that are multiples of 5
        public static List<int> MakeFiveList(int max)
        {
            List<int> result = new List<int>();
            for (int i = 5; i <= max; i += 5)
                result.Add(i);
            return result;
        }

        // returns a list of all the strings in sourceList that start with the letter 'A' or 'a'
        public static List<string> MakeAList(List<string> sourceList)
        {
            List<string> result = new List<string>();
            foreach (string word in sourceList)
                if (word.ToUpper()[0] == 'A')
                    result.Add(word);
            return result;
        }
    }
}
