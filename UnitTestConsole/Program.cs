using UnitTestConsole.Tests;

namespace UnitTestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            FunctionsTests.Functions_ReturnPikachuIfZero_ReturnString();
        }
    }
}