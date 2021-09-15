namespace HomeAssignment
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 0 to 4 DIGITS between 2 and 9!");
            string input = Console.ReadLine();
            Console.WriteLine(Solution.Combinations(input));
            Console.ReadKey();
        }
    }
}
