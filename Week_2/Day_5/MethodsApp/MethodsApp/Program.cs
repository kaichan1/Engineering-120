namespace MethodsApp;

public class Program
{
    static void Main(string[] args)
    {
        //var result = DoThis(y:"Happy", x:10);
        //var spartaPizza = OrderPizza(pepperoni: true, chicken:true, true, true);
        //Console.WriteLine(spartaPizza);
        //var add2 = Add(1, 2, 3);
        //var add3 = Add(1, 2);
        var myTuple = ("Kai", "Chan", 60);
        (string fName, string lName, int age) myTuple2 = ("Kai", "Chan", 60);
        var myTuple3 = (title: "Lord of the Rings", copies: 3);
        //Console.WriteLine(myTuple);
        //Console.WriteLine(myTuple.Item1);
        //Console.WriteLine(myTuple2.lName);
        //var result = ConvertPoundsToStones(78);
        //var stones = result.stones;

        bool z;
        var result2 = DoThat(11, "Hello", out z);
        Console.WriteLine(z);
        //bool z;
        //var result2 = DoThat(11, "Hello", out z);

        int number = -10;
        Subtract(number);
        Console.WriteLine(number);
        Subtract(ref number);
        Console.WriteLine(number);

    }
    public static void Subtract(int num)
    {
        num--;
    }
    public static void Subtract(ref int num)
    {
        num--;
    }
    public static int DoThat(int x, string y, out bool z)
    {
        Console.WriteLine(y);
        z = (x > 10);
        return x * x;
    }
    public static (int stones, int lbs) ConvertPoundsToStones(int pound)
    {
        //stones and pounds
        var stones = pound / 14;
        var lbs = pound % 14;
        return (stones, lbs);
    }

    private static int DoThis(int x, string y = "Sad")
    {
        Console.WriteLine($"I'm feeling {y}");
        return x * x;
    }
    public static int Add (int num1, int num2)
    {
        return num1 + num2;
    }
    public static int Add(int num1, int num2, int num3 = 3)
    {
        return num1 + num2 + num3;
    }


    public static string OrderPizza(bool pepperoni, bool chicken, bool jalapenos, bool kiwi = false)
    {
        var pizza = "Pizza with tomato sauce, cheese";
        if (pepperoni) pizza += " pepperoni, ";
        if (chicken) pizza += " chicken, ";
        if (jalapenos) pizza += " jalapenos, ";
        if (kiwi) pizza += " kiwi, ";

        return pizza.Remove(pizza.Length - 2, 2);
    }
}