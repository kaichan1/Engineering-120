using System;
using System.Threading;
using System.Threading.Tasks;

namespace AysncCake
{
    class Program
    {
        #region version 1
        //public static void Main(string[] args)
        //{
        //    Console.WriteLine("Welcome to my birthday party");
        //    HaveAParty();
        //    Console.WriteLine("Thanks for a lovely party");
        //    Console.ReadLine();
        //}
        //private static void HaveAParty()
        //{
        //    var name = "Cathy";
        //    var cakeTask = BakeCakeAsync();
        //    PlayPartyGames();
        //    OpenPresents();
        //    //Wait here until we get a result from the task
        //    //Means that control is not handed back to the Main method
        //    var cake = cakeTask.Result;
        //    Console.WriteLine($"Happy birthday, {name}, {cake}!!");
        //}
        #endregion

        #region version 2
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to my birthday party");
            await HaveAParty();
            Console.WriteLine("Thanks for a lovely party");
            Console.ReadLine();
        }

        //Void --> Task
        private static async Task HaveAParty()
        {
            var name = "Cathy";
            var cakeTask = BakeCakeAsync();
            var pastaTask = BakePastaAsync();
            PlayPartyGames();
            OpenPresents();
            await CallUber();
            await pastaTask;
            var cake = await cakeTask;
            Console.WriteLine($"Happy birthday, {name}, {cake}!!");
        }
        #endregion

        private static async Task<Pasta> BakePastaAsync()
        {
            Console.WriteLine("Pasta is in the oven");
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Pasta is done");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished pasta");
            return new Pasta();
        }
        private static async Task CallUber()
        {
            Console.WriteLine("Uber called");
            await Task.Delay(TimeSpan.FromSeconds(9));
            Console.WriteLine("Uber is here");
        }

        //Cake --> Task<cake>
        private static async Task<Cake> BakeCakeAsync()
        {
            Console.WriteLine("Cake is in the oven");
            //Await for this task to be complete
            //Whist waiting, got back to the caller method
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Cake is done");
            return new Cake();
        }
        private static void PlayPartyGames()
        {
            Console.WriteLine("Starting games");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Finishing Games");
        }

        private static void OpenPresents()
        {
            Console.WriteLine("Opening Presents");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished Opening Presents");
        }
    }

    public class Cake
    {
        public override string ToString()
        {
            return "Here's a cake";
        }
    }
    public class Pasta
    {
        public override string ToString()
        {
            return "Here's a baked pasta";
        }
    }
}
