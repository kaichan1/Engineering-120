using System;
using System.Text;

namespace StringCalculatorApp;
public class Program
{
    public static void Main(string[] args)
    {
        int x = Add("//-\n5;50;35");
    }

    public static int Add(string numbers)
    {
        if (numbers == "")
            return 0;

        string extraDelimiter = "";

        // "//-\n"
        if (numbers.Length > 5 && numbers[..2] == "//" && numbers[3..4] == "\n")
        {
            extraDelimiter += numbers.Substring(2, 1);
            Console.WriteLine("The delimiter is:" + extraDelimiter);
            numbers = numbers[4..];
        }

        var delimiters = new string[] { ",", "\n", extraDelimiter };
        var numberArray = numbers.Split(delimiters, StringSplitOptions.None);
        int result = 0;

        foreach (string i in numberArray)
        {
            if (i == "")
            {
                throw new ArgumentException("Delimiters Cannot Be Adjacent");
            }
            else if (Int32.TryParse(i, out int num))
            {
                result += num;
            }
        }
        return result;
    }
}