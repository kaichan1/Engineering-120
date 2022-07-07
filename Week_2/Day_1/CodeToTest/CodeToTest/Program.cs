using System;

namespace CodeToTest;

public class Program
{
    static void Main(string[] args)
    {
        int timeOfDay = 21;
        var greet = Greeting(timeOfDay);
        Console.WriteLine(greet);
    }

    public static string Greeting(int timeOfDay)
    {
        string greeting;
        
        if (timeOfDay < 0 || timeOfDay > 24)
        {
            throw new ArgumentOutOfRangeException("Time has to be between 0 to 24.");
        }
        else if (timeOfDay >= 5 && timeOfDay < 12)
        {
            greeting = "Good morning!";
        }
        else if (timeOfDay >= 12 && timeOfDay <= 18)
        {
            greeting = "Good afternoon!";
        }
        else
        {
            greeting = "Good evening!";
        }
        return greeting;
    }

    public static string AvailableClassifications(int ageOfViewer)
    {
        string result;        
        if (ageOfViewer < 12)
        {
            result = "U, PG & 12 films are available.";
        }
        else if (ageOfViewer < 15)
        {
            result = "U, PG, 12 & 15 films are available.";
        }
        else
        {
            result = "All films are available.";
        }
        return result;
    }

    public static string AvailableClassificationsUpdated(int ageOfViewer)
    {
        if (ageOfViewer < 0)
        {
            throw new ArgumentOutOfRangeException("Age cannot be negative.");
        }
        string result;
        if (ageOfViewer >= 18)
        {
            result = "All films are available.";
        }
        else if (ageOfViewer >= 15)
        {
            result = "U, PG, 12 & 15 films are available.";
        }
        else if (ageOfViewer >= 12)
        {
            result = "U, PG & 12 films are available.";
        }
        else if (ageOfViewer >= 8)
        {
            result = "U & PG films are available.";
        }
        else
        {
            result = "U films are available.";
        }
        return result;
    }
}
