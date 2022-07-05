using System;
using System.Collections.Generic;


namespace Op_CtrlFlow
{
    public class Exercises
    {
        public static bool MyMethod(int num1, int num2)
        {
            return num1 == num2 ? false : (num1 % num2) == 0;
        }

        // returns the average of the array nums
        public static double Average(List<int> nums)
        {
            if (nums.Count == 0)
            {
                return 0;
            }
            int count = 0;
            int sum = 0;
            foreach (int num in nums)
            {
                count++;
                sum += num;
            }
            return Convert.ToDouble(sum)/Convert.ToDouble(count);
        }

        // returns the type of ticket a customer is eligible for based on their age
        // "Standard" if they are between 18 and 59 inclusive
        // "OAP" if they are 60 or over
        // "Student" if they are 13-17 inclusive
        // "Child" if they are 5-12
        // "Free" if they are under 5
        public static string TicketType(int age)
        {
            string ticketType = age >= 18 && age <= 59 ? "Standard" :
                age >= 60 ? "OAP" :
                age >= 13 && age <= 17 ? "Student" :
                age >= 5 && age <= 12 ? "Child" :
                age < 5 ? "Free" : string.Empty;
            return ticketType;
        }

        public static string Grade(int mark)
        {
            var grade = "";
            if (mark >= 75 && mark <= 100)
            {
                grade = "Pass with Distinction";
            }
            else if (mark >= 60 && mark <= 74)
            {
                grade = "Pass with Merit";
            }
            else if (mark >= 40 && mark <= 59)
            {
                grade = "Pass";
            }
            else if (mark >= 0 && mark <= 39)
            {
                grade = "Fail";
            }
            return grade;
        }

        public static int GetScottishMaxWeddingNumbers(int covidLevel)
        {
            int max;
            switch (covidLevel)
            {
                case 4:
                    max = 20;
                    break;
                case 3:
                case 2:
                    max = 50;
                    break;
                case 1:
                    max = 100;
                    break;
                default:
                    max = 200;
                    break;
            }
            return max;
        }
    }
}
