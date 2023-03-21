using System;
namespace program
{
public class Program
{

    public static int AddNumbers(int a, int b, int c)
    {
        return a + b + c;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Podaj pierwszą liczbę:");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Podaj drugą liczbę:");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Podaj trzecią liczbę:");
        int c = Convert.ToInt32(Console.ReadLine());

        int suma = AddNumbers(a, b, c);

        Console.WriteLine("Suma liczb to: " + suma);
    }
}
}
