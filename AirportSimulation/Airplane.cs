using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    internal struct Airplane(string Manufacturer, TimeOnly ArrivalTime, TimeOnly Delay, int Fuel)
    {
        public string Manufacturer { get; } = Manufacturer;
        public TimeOnly ArrivalTime { get; } = ArrivalTime;
        public TimeOnly Delay { get; set; } = Delay;
        public int Fuel { get; set; } = Fuel;
        public int MaxFuel { get; } = 60;
    }
}
