using System.Net.Http.Headers;

namespace AirportSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 40);
            //█
            PlaneTakeoff();
        }

        static void PlaneTakeoff(bool bIsSuccessful = true)
        {
            Console.Clear();
            DrawRunway();

            (int left, int top) = (74, 18);
            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(left + 1, top);
                Console.Write(' ');
                Console.SetCursorPosition(left + 2, top);
                Console.Write(' ');

                Console.SetCursorPosition(left, top);
                Console.Write('*');
                Console.SetCursorPosition(left + 1, top);
                Console.Write('*');
                left--;
                System.Threading.Thread.Sleep(50);
            }

        }

        static void DrawRunway()
        {
            Console.WriteLine();
            Console.WriteLine($"{new string(' ', 117)}██████");
            Console.WriteLine($"{new string(' ', 115)}██████████");
            Console.WriteLine($"{new string(' ', 115)}██████████");
            Console.WriteLine($"{new string(' ', 117)}██████");
            for (int i = 0; i < 6; i++)
                Console.WriteLine($"{new string(' ', 118)}████");
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"{new string(' ', 80)}{new string('█', 50)}");
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"{new string(' ', 80)}{new string('█', 10)}{new string("|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|")}{new string('█', 9)}");
            Console.WriteLine($"{new string(' ', 80)}{new string('█', 50)}");
            Console.WriteLine($"{new string(' ', 80)}{new string('█', 50)}");
            Console.WriteLine($"{new string(' ', 10)}{new string('_', 70)}{new string('█', 50)}");
        }
    }
}
