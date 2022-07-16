using System;
using System.Collections.Generic;

namespace Collections_Lib
{
    public class CollectionsExercises
    {

        /* removes and returns the next num entries in the queue, as a comma separated string */
        public static string NextInQueue(int num, Queue<string> queue)
        {
            string result = "";
            if (num == 0) return result;
            result += queue.Dequeue();
            for (int i = num - 1; i > 0; i--)
                if (queue.TryDequeue(out string word))
                    result += ", " + word;
            return result;
        }

        /* uses a Stack to create and return array of ints in reverse order to the one supplied */
        public static int[] Reverse(int[] original)
        {
            Stack<int> stack = new Stack<int>();
            foreach (int num in original)
                stack.Push(num);
            int[] result = new int[original.Length];
            for (int i = 0; i < original.Length; i++)
                result[i] = stack.Pop();
            return result;
        }
        // using a Dictionary, counts and returns (as a string) the occurence of the digits 0-9 in the given string
        public static string CountDigits(string input)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in input)
            {
                //if (Int32.TryParse(c.ToString(), out int num))
                //    dict[num] = dict.ContainsKey(num) ? dict[num]+1 : 1;
                if (Char.IsDigit(c))
                    dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
            }
            string result = "";
            foreach (KeyValuePair<char, int> pair in dict)
                result += pair;
            return result;
        }
    }
}
