namespace AirportSimulation
{
    internal class Airplane(string Manufacturer, TimeOnly ArrivalTime, TimeOnly Delay, int Fuel, int MaxFuel = 200)
    {
        public string Manufacturer { get; } = Manufacturer;
        public TimeOnly ArrivalTime { get; } = ArrivalTime;
        public TimeOnly Delay { get; set; } = Delay;
        public TimeOnly DepartureTime { get; set; } = TimeOnly.Parse("00:00:00");
        public int Fuel { get; set; } = Fuel;
        public int MaxFuel { get; } = MaxFuel;

        public void AddDelay(TimeSpan DelayIn)
        {
            Delay = Delay.Add(TimeSpan.Parse("00:20:00"));
        }
    }
}
