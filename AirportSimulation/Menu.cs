using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    static class Menu
    {
        public static int ChooseMenu(string[] Menus)
        {
            int NumberOfMenus = Menus.Length;
            int CurrentMenu = 0;

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(Menus[0]);
            Console.ResetColor();
            for (int i = 1; i < Menus.Length; i++)
            {
                Console.WriteLine(Menus[i]);
            }

            ConsoleKey v;
            do
            {
                v = Console.ReadKey(true).Key;
                int temp = CurrentMenu;
                switch (v)
                {
                    case ConsoleKey.UpArrow:
                        if (CurrentMenu > 0)
                            CurrentMenu--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (CurrentMenu < NumberOfMenus - 1)
                            CurrentMenu++;
                        break;
                    case ConsoleKey.Enter:
                        return CurrentMenu;
                    default:
                        break;
                }

                if (temp != CurrentMenu)
                {
                    Console.SetCursorPosition(0, temp);
                    Console.WriteLine(Menus[temp]);

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, CurrentMenu);
                    Console.WriteLine(Menus[CurrentMenu]);
                    Console.ResetColor();
                }
            } while (v != ConsoleKey.Enter);
            return -1;
        }

        public static void ShowSchedule(Schedule schedule)
        {
            Console.Clear();
            Console.WriteLine("Incoming Planes\n");

            List<Airplane> Airplanes = schedule.Airplanes;
            foreach (var item in Airplanes)
                Console.WriteLine(item.Manufacturer);

            for (int i = 0; i < Airplanes.Count; i++)
            {
                Console.SetCursorPosition(30, i + 2);
                Console.Write(Airplanes[i].ArrivalTime.Add(Airplanes[i].Delay.ToTimeSpan()).ToString("HH:mm"));
            }

            Console.SetCursorPosition(50, 0);
            Console.Write("Delay");
            for (int i = 0; i < Airplanes.Count; i++)
            {
                Console.SetCursorPosition(50, i + 2);
                Console.Write(Airplanes[i].Delay.ToString("HH:mm"));
            }

            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey(true);
        }

        private static void PlaneTakeoff(bool bIsSuccessful = true)
        {
            Console.Clear();
            DrawRunway();

            (int left, int top) = (74, 19);
            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(left + 1, top);
                Console.Write('_');
                Console.SetCursorPosition(left + 2, top);
                Console.Write('_');

                Console.SetCursorPosition(left, top);
                Console.Write('*');
                Console.SetCursorPosition(left + 1, top);
                Console.Write('*');
                left--;
                System.Threading.Thread.Sleep(50);
            }
            Console.SetCursorPosition(left + 1, top);
            Console.Write('_');
            Console.SetCursorPosition(left + 2, top);
            Console.Write('_');
            top -= 2;

            for (int i = 0; i < 15; i++)
            {
                Console.SetCursorPosition(left + 1, top);
                Console.Write(' ');
                Console.SetCursorPosition(left + 2, top + 1);
                Console.Write(' ');

                Console.SetCursorPosition(left, top - 1);
                Console.Write('*');
                Console.SetCursorPosition(left + 1, top);
                Console.Write('*');
                left--;
                top--;
                System.Threading.Thread.Sleep(100);
            }

            Console.SetCursorPosition(left + 1, top);
            Console.Write(' ');
            Console.SetCursorPosition(left + 2, top + 1);
            Console.Write(' ');

            if (!bIsSuccessful)
            {
                for (int i = 0; i < 15; i++)
                {
                    Console.SetCursorPosition(left + 1, top);
                    Console.Write(' ');
                    Console.SetCursorPosition(left + 2, top - 1);
                    Console.Write(' ');

                    Console.SetCursorPosition(left, top + 1);
                    Console.Write('*');
                    Console.SetCursorPosition(left + 1, top);
                    Console.Write('*');
                    left--;
                    top++;
                    System.Threading.Thread.Sleep(100);
                }
            }
        }

        private static void DrawRunway()
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
