namespace AirportSimulation
{
    internal class Gate
    {
        public Airplane? CurrentPlane { get; private set; } = null;
        public GateStatus GateStatus { get; set; } = GateStatus.Free;

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

            if (CurrentPlane!.Fuel < 50)
                throw new ArgumentException("The plane did not have enough fuel.");
            if (!CurrentPlane!.bIsBoarded)
                throw new ArgumentException("Plane was not boarded!");
            if (CurrentPlane.DepartureTime.Add(CurrentPlane.Delay.ToTimeSpan()) > Airport.CurrentTime)
                throw new Exception("Plane took off too early!");

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
            CurrentPlane!.bIsBoarded = true;
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
