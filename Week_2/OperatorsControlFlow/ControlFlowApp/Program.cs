using System;

namespace ControlFlowApp;

public class Program
{
    public static void Main(string[] args)
    {
        #region ternary operators
        //int mark = 35;
        ////string grade = mark >= 65 ? "Pass" : "Fail";
        ////Console.WriteLine(grade);

        //string grade2 = mark >= 65 ? (mark >= 85 ? "Distinction" : "Pass") : (mark < 20 ? "Failed no retake" : "Fail with retake");
        //Console.WriteLine(grade2);
        #endregion

        #region switch
        //Console.WriteLine(Priority(1));
        //Console.WriteLine(DrivingLaws(18));
        #endregion

        #region loops
        List<int> nums = new List<int> { 10, 6, 22, -17, 3 };
        Console.WriteLine("Highest foreach loop: " + LoopTypes.HighestForEachLoop(nums));
        Console.WriteLine("Highest for- loop: " + LoopTypes.HighestForLoop(nums));
        Console.WriteLine("Highest while- loop: " + LoopTypes.HighestWhileLoop(nums));
        Console.WriteLine("Highest do-while loop: " + LoopTypes.HighestDoWhileLoop(nums));
        #endregion
    }

    public static string DrivingLaws(int age)
    {
        string law = "";
        switch (age)
        {
            case < 18:
                law = "Cannot legally drive";
                break;
            case < 23:
                law = "Can legally drive but cannot hire a car";
                break;
            default:
                law = "Can legally drive and rent a car";
                break;
        }
        return law;
    }
    public static string Priority(int level)
    {
        string priority = "Code ";

        switch (level)
        {
            case 3:
                priority = priority + "Red";
                break;
            case 2:
            case 1:
                priority = priority + "Amber";
                break;
            case 0:
                priority = priority + "Green";
                break;
            default:
                priority = "Error";
                break;
        }
        return priority;
    }

    public static string Grade(int mark)
    {
        return mark >= 65 ? (mark >= 85 ? "Distinction" : "Pass") : (mark < 20 ? "Failed no retake" : "Fail with retake");
    }
}
