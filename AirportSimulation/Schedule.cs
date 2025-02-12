using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    internal class Schedule
    {
        public Schedule()
        {
            for (int i = 0; i < 20; i++)
                Airplanes.Add(GenerateAirplane());
        }

        public List<Airplane> Airplanes { get; private set; } = new List<Airplane>();
        private string[] AirplaneManufacturers = { "Airbus", "Boeing", "Embraer", "Lockheed Martin", "Bombardier", "Gulfstream Aerospace", "Dassault Aviaton", "Pilatus Aircraft", "Beechcraft" };

        public Airplane AllowIn()
        {
            Airplane temp = Airplanes[0];
            Airplanes.RemoveAt(0);

            Airplanes.Add(GenerateAirplane());
            return temp;
        }

        private Airplane GenerateAirplane()
        {
            Random rand = new Random();

            int TimeInMinutes;
            if (Airplanes.Count > 0)
                TimeInMinutes = Airplanes[Airplanes.Count - 1].ArrivalTime.Hour * 60 + Airplanes[Airplanes.Count - 1].ArrivalTime.Minute + (rand.Next(0, 5) > 0 ? 20 : 0);
            else
                TimeInMinutes = rand.Next(0, 1) * 10;
            TimeOnly time = TimeOnly.Parse($"{Math.Floor(TimeInMinutes / 60.0)}:{TimeInMinutes % 60}:00");

            Airplane airplane = new Airplane(AirplaneManufacturers[rand.Next(0, 9)], time, TimeOnly.Parse("00:00:00"), rand.Next(0, 60));
            return airplane;
        }
    }
}
