namespace AirportSimulation
{
    internal struct Airplane(string Manufacturer, TimeOnly ArrivalTime, TimeOnly Delay, int Fuel, int MaxFuel = 200)
    {
        public string Manufacturer { get; } = Manufacturer;
        public TimeOnly ArrivalTime { get; } = ArrivalTime;
        public TimeOnly Delay { get; set; } = Delay;
        public TimeOnly DepartureTime { get; set; } = ArrivalTime.Add(TimeSpan.Parse("00:40:00"));
        public int Fuel { get; set; } = Fuel;
        public int MaxFuel { get; } = MaxFuel;
    }
}
