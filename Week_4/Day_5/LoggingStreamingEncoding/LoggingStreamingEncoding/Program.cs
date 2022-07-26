//#define TEST

using System;
using System.IO;
using System.Diagnostics;

namespace LoggingStreamingEncoding
{
    internal class Program
    {
        private static string _currentDirectory = Directory.GetCurrentDirectory();
        private static string _path = Path.Combine(_currentDirectory, @"../../../");
        static void Main(string[] args)
        {
            #region fileops
            //Console.WriteLine("What is your name?");
            //var name = Console.ReadLine();
            //Console.WriteLine($"Hello, {name}, it is now {DateTime.Now}");
            //string currentDirectory = Directory.GetCurrentDirectory();
            //var path = Path.Combine(currentDirectory, @"../../../");

            //var text = "Hello, world!";
            //File.WriteAllText(path + "Hello.txt", text);

            //string content = File.ReadAllText(path + "Hello.txt");
            //Console.WriteLine(content);

            //string[] lines = { "And after all", "You're my Wonderwall", "I Said maybe!" };
            //File.WriteAllLines(path + "Wonderwall.txt", lines);
            //string[] readLines = File.ReadAllLines(path + "Wonderwall.txt");
            //foreach (var item in readLines)
            //{
            //    Console.WriteLine(item);
            //}

            //Directory.CreateDirectory(path + "newfolder");
            #endregion

            #region Logging
            //Console.WriteLine($"This is being logged at time {DateTime.Now}");
            ////Listen for debugging or trace output
            ////Writes it to a text file
            //TextWriterTraceListener twtl = new TextWriterTraceListener(File.Create(_path + "TraceOutput.txt"));
            ////Assigns the twtl to be a listener
            //Trace.Listeners.Add(twtl);
            //int total = 0;
            //for (int i = 0; i <= 3; i++)
            //{
            //    Console.WriteLine(i);
            //    total += i;
            //    //Useful to find defect
            //    Debug.WriteLine($"Debug - The value of i is {i}");
            //    //Similar to debug - runs on seperate thread - monitor performance
            //    Trace.WriteLine($"Trace - The value of i is {i}");
            //}
            //Trace.Flush();
            #endregion

            #region Conditionally compiling code
            //            Console.WriteLine("Starting app");
            //#if TEST
            //            Console.WriteLine("This is debug code");
            //#endif
            //            Console.WriteLine("Finishing app");
            #endregion

            #region streaming
            //from application to directory
            using (StreamWriter sw = File.AppendText(_path + "Mary.txt"))
            {
                sw.WriteLine("Mary had a little lamb");
            }
            
            //to application
            using (StreamReader sr = File.OpenText(_path + "Mary.txt"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine();
                }
            }

            using (Stream ns = NetworkStream(clientSocket, true), bufStream = new BufferedStream(ns, 2014))
            {
                //do something
            }
            #endregion
        }
    }
}