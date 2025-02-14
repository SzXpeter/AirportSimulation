using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    internal class Gate
    {
        public Airplane? CurrentPlane { get; private set; } = null;
        public GateStatus GateStatus { get; set; } = GateStatus.Free;
        public bool bBoarded { get; private set; } = false;

        public void AirplaneLanding(Airplane AirplaneIn)
        {
            GateStatus = GateStatus.Landing;
            CurrentPlane = AirplaneIn;
        }

        public void AirplaneTakeOff()
        {
            GateStatus = GateStatus.TakingOff;
            CurrentPlane = null;
        }

        public void RefuelAirplane()
        {
            GateStatus = GateStatus.Refueling;
            Airplane temp = CurrentPlane!.Value;
            temp.Fuel = temp.MaxFuel;
            CurrentPlane = temp;
        }
    }
}
