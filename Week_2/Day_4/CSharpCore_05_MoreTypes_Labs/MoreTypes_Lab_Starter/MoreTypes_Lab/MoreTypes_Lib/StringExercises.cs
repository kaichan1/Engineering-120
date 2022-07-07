using System;
using System.Text;

namespace MoreTypes_Lib
{
    public class StringExercises
    {
        // manipulates and returns a string - see the unit test for requirements
        public static string ManipulateString(string input, int num)
        {
            StringBuilder sb = new StringBuilder(input.Trim().ToUpper());
            for (int i = 0; i < num; i++)
            {
                sb.Append(i);
            }
            return sb.ToString();
        }

        // returns a formatted address string given its components
        public static string Address(int number, string street, string city, string postcode)
        {
            return $"{number} {street}, {city} {postcode}.";
        }
        // returns a string representing a test score, written as percentage to 1 decimal place
        public static string Scorer(int score, int outOf)
        {
            return $"You got {score} out of {outOf}: {(float)score/outOf:P1}";
        }

        // returns the double represented by the string, or -999 if conversion is not possible
        public static double ParseNum(string numString)
        {
            if (Double.TryParse(numString, out double result))
                return result;
            else
                return -999;
        }

        // Returns the a string containing the count of As, Bs, Cs and Ds in the parameter string
        // all other letters are ignored
        public static string CountLetters(string input)
        {
            int sumA = 0, sumB = 0, sumC = 0, sumD = 0;
            foreach (char c in input.ToUpper())
            {
                if (c == 'A')
                    sumA++;
                else if (c == 'B')
                    sumB++;
                else if (c == 'C')
                    sumC++;
                else if (c == 'D')
                    sumD++;
            }
            return $"A:{sumA} B:{sumB} C:{sumC} D:{sumD}";
        }
    }
}
