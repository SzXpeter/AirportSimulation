using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    internal class Airplane
    {
        public Airplane(string Manufacturer ,TimeOnly ArrivalTime, TimeOnly Delay, int Fuel)
        {
            this.Manufacturer = Manufacturer;
            this.ArrivalTime = ArrivalTime;
            this.Delay = Delay;
            this.Fuel = Fuel;
        }

        public string Manufacturer { get; private set; }
        public TimeOnly ArrivalTime { get; private set; }
        public TimeOnly Delay { get; set; }
        public int Fuel { get; private set; }
        public int MaxFuel { get; } = 60;

    }
}
