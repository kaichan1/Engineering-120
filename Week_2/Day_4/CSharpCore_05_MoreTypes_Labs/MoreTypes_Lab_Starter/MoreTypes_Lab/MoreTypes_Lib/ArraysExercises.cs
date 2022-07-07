using System;
using System.Collections.Generic;

namespace MoreTypes_Lib
{
    public class ArraysExercises
    {
        // returns a 1D array containing the contents of a given List
        public static string[] Make1DArray(List<string> contents)
        {
            string[] myArray = new string[contents.Count];
            for (int i = 0; i < contents.Count; i++)
            {
                myArray[i] = contents[i];
            }
            return myArray;
        }

        // returns a 3D array containing the contents of a given List
        public static string[,,] Make3DArray(int length1, int length2, int length3, List<string> contents)
        {
            if (length1 + length2 + length3 != contents.Count)
                throw new ArgumentException("Number of elements in list must match array size");
            string[,,] myArray = new string[length1, length2, length3];
            int x = 0;
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    for (int k = 0; k < length3; k++)
                    {
                        myArray[i, j, k] = contents[x++];
                    }
                }
            }
            return myArray;
        }

        // returns a jagged array containing the contents of a given List
        public static string[][] MakeJagged2DArray(int countRow1, int countRow2, List<string> contents)
        {
            if (countRow1 + countRow2 != contents.Count)
                throw new ArgumentException("Number of elements in list must match array size");
            
            string[][] jag = new string[countRow1][];
            jag[0] = new string[countRow1];
            jag[1] = new string[countRow2];
            
            int x = 0;
            for (int i = 0; i < countRow1; i++)
                jag[0][i] = contents[x++];
            for (int i = 0; i < countRow2; i++)
                jag[1][i] = contents[x++];
            return jag;
        }
    }
}
