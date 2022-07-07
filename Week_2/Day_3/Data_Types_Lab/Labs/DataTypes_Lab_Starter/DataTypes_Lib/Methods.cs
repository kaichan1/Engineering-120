using System;

namespace DataTypes_Lib
{
    public static class Methods
    {
        // write a method to return the product of all numbers from 1 to n inclusive
        public static long Factorial(int n)
        {
            long fac = n;
            for (int i = n-1; i > 1; i--)
            {
                fac *= i;
            }
            return fac;
        }

        public static float Mult(float num1, float num2)
        {
            return num1 * num2;
        }
    }
}
