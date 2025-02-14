using System.Net.Http.Headers;

namespace AirportSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(150, 40);
        }

        static void ShowSchedule(Schedule schedule)
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
    }
}
