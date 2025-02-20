﻿namespace AirportSimulation
{
    internal class Schedule
    {
        public Schedule(int NumberOfPlanes)
        {
            for (int i = 0; i < NumberOfPlanes; i++)
                Airplanes.Add(GenerateAirplane());
        }

        public List<Airplane> Airplanes { get; private set; } = new List<Airplane>();
        private readonly string[] AirplaneManufacturers = { "Airbus", "Boeing", "Embraer", "Lockheed Martin", "Bombardier", "Gulfstream Aerospace", "Dassault Aviaton", "Pilatus Aircraft", "Beechcraft" };

        public Airplane GenerateAirplane()
        {
            Random rand = new Random();

            int TimeInMinutes;
            if (Airplanes.Count > 0)
                TimeInMinutes = Airplanes[Airplanes.Count - 1].ArrivalTime.Hour * 60 + Airplanes[Airplanes.Count - 1].ArrivalTime.Minute + (rand.Next(0, 5) > 0 ? 20 : 0);
            else
                TimeInMinutes = 20;
            TimeOnly time = TimeOnly.Parse($"{Math.Floor(TimeInMinutes / 60.0)}:{TimeInMinutes % 60}:00");

            Airplane airplane = new Airplane(AirplaneManufacturers[rand.Next(0, 9)], time, TimeOnly.Parse("00:00:00"), rand.Next(0, 61));
            return airplane;
        }
    }
}
