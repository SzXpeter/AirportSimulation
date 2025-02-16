using System.IO.Pipes;

namespace AirportSimulation
{
    internal class Gate
    {
        public Airplane? CurrentPlane { get; private set; } = null;
        public GateStatus GateStatus { get; set; } = GateStatus.Free;
        public bool bBoarded { get; private set; } = false;

        public void AirplaneLanding(Airplane AirplaneIn)
        {
            if (GateStatus != GateStatus.Free) throw new Exception(GetGateStatus());
            GateStatus = GateStatus.Landing;
            CurrentPlane = AirplaneIn;
            CurrentPlane.DepartureTime = CurrentPlane.ArrivalTime.Add(CurrentPlane.Delay.Add(TimeSpan.Parse("01:00:00")).ToTimeSpan());
        }

        public void AirplaneTakeOff()
        { 
            if (GateStatus != GateStatus.Free) throw new Exception(GetGateStatus());
            GateStatus = GateStatus.TakingOff;
            CurrentPlane = null;
        }

        public void RefuelAirplane()
        {
            if (GateStatus != GateStatus.Free) throw new Exception(GetGateStatus());
            GateStatus = GateStatus.Refueling;
            Airplane temp = CurrentPlane!;
            temp.Fuel = temp.MaxFuel;
            CurrentPlane = temp;
        }

        public void BoardAirplane()
        {
            if (GateStatus != GateStatus.Free) throw new Exception(GetGateStatus());
            GateStatus = GateStatus.Boarding;
            bBoarded = true;
        }

        public string GetGateStatus()
        {
            switch (GateStatus)
            {
                case GateStatus.Landing:
                    return "A plane is currently landing";
                case GateStatus.Boarding:
                    return "A plane is currently boarding";
                case GateStatus.Refueling:
                    return "A plane is currently refueling";
                case GateStatus.TakingOff:
                    return "A plane is currently taking off";
                default:
                    return "";
            }
        }
    }
}
