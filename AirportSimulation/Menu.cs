namespace AirportSimulation
{
    static class Menu
    {
        public static int ChooseMenu(string[] Menus)
        {
            int NumberOfMenus = Menus.Length;
            if (NumberOfMenus == 0) throw new ApplicationException("No menu items");
            int CurrentMenu = 0;
            ClearScreen();

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(Menus[0]);
            Console.ResetColor();
            for (int i = 1; i < Menus.Length; i++)
            {
                Console.WriteLine(Menus[i]);
            }
            Console.SetCursorPosition(60, 0);
            Console.Write($"Current time: {Airport.CurrentTime.ToString("HH:mm")}");

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
                        else
                            CurrentMenu = NumberOfMenus - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (CurrentMenu < NumberOfMenus - 1)
                            CurrentMenu++;
                        else
                            CurrentMenu = 0;
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
            ClearScreen();
            Console.WriteLine("Incoming Planes\n");

            foreach (var item in schedule.Airplanes)
                Console.WriteLine(item.Manufacturer);

            for (int i = 0; i < schedule.Airplanes.Count; i++)
            {
                Console.SetCursorPosition(30, i + 2);
                Console.Write(schedule.Airplanes[i].ArrivalTime.Add(schedule.Airplanes[i].Delay.ToTimeSpan()).ToString("HH:mm"));
            }

            Console.SetCursorPosition(50, 0);
            Console.Write("Delay");
            for (int i = 0; i < schedule.Airplanes.Count; i++)
            {
                Console.SetCursorPosition(50, i + 2);
                Console.Write(schedule.Airplanes[i].Delay.ToString("HH:mm"));
            }

            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey(true);
        }

        public static void ShowAirplaneInfo(Airplane airplane)
        {
            ClearScreen();
            Console.WriteLine($"Manufacturer: {airplane.Manufacturer}");
            Console.WriteLine($"Arrival time: {airplane.ArrivalTime.Add(airplane.Delay.ToTimeSpan()):HH:mm}");
            Console.WriteLine($"Departure time: {airplane.DepartureTime.Add(airplane.Delay.ToTimeSpan()):HH:mm}");
            Console.WriteLine($"Fuel: {airplane.Fuel}%");
            Console.WriteLine($"Delay: {airplane.Delay:HH:mm}");
            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey(true);
        }

        public static void PlaneTakeoff(bool bIsSuccessful = true)
        {
            ClearScreen();
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
            Console.ReadKey(true);
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

        public static void ClearScreen()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 30; i++)
                Console.WriteLine(new string(' ', 150));
            Console.SetCursorPosition(0, 0);
        }
    }
}
