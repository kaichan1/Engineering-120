using System;

namespace CSharpIntroduction;

public class Program
{
    public static void Main(string[] args)
    {
        //int x = 100;
        //x += 10;
        //for (int i = 0; i < 10; i++)
        //{
        //    Console.WriteLine(i);
        //    x += i;
        //}
        Console.WriteLine("Write our command line arguments");
        foreach (string item in args) 
        {
            Console.WriteLine(item);
        }
    }
}
