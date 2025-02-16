namespace AirportSimulation
{
    internal class Airport
    {
        public Airport(int NumberOfGates, Schedule Schedule)
        {
            string[] temp = new string[NumberOfGates + 1];
            for (int i = 0; i < NumberOfGates; i++)
            {
                Gates.Add(new Gate());
                temp[i] = $"Gate {i + 1}";
            }
            temp[NumberOfGates] = "Back";
            gatesMenu = temp;

            this.Schedule = Schedule;
        }

        public Schedule Schedule { get; }
        public List<Gate> Gates { get; set; } = new List<Gate>();
        public int NumberOfStrikes { get; set; } = 0;
        public static TimeOnly CurrentTime { get; set; } = TimeOnly.Parse("00:20:00");

        public readonly string[] airportMenu = ["Continue", "Control Tower", "Gates", "Show schedule", "Exit"];
        public readonly string[] controlTowerMenu = ["Authorise landing", "Authorise take off", "Back"];
        public readonly string[] gatesMenu;
        public readonly string[] gateMenu = ["Show plane info", "Allow boarding", "Refuel", "Back"];

        public Airplane AllowIn()
        {
            Airplane temp = Schedule.Airplanes[0];
            Schedule.Airplanes.RemoveAt(0);

            Schedule.Airplanes.Add(Schedule.GenerateAirplane());
            return temp;
        }
    }
}
