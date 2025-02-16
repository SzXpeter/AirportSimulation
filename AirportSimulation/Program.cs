namespace AirportSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(180, 40);

            Schedule schedule = new Schedule(20);
            Airport airport = new Airport(10, schedule);
            while (Airport.CurrentTime != TimeOnly.Parse("00:00:00"))
                try
                {
                    AirportMenu(airport);
                }
                catch (ApplicationException e)
                {
                    Menu.ClearScreen();
                    Console.WriteLine(e.Message);
                    break;
                }
                catch (ArgumentException e)
                {
                    Menu.ClearScreen();
                    Console.Write(e.Message);
                    airport.NumberOfStrikes++;
                    Console.WriteLine($" Your current number of strikes: {airport.NumberOfStrikes} of 3");
                    if (airport.NumberOfStrikes == 3)
                    {
                        Console.WriteLine("You have reached the maximum number of strikes! The airport has been shut down!");
                        break;
                    }
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Menu.ClearScreen();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
        }

        static void AirportMenu(Airport airport)
        {
            switch (Menu.ChooseMenu(airport.airportMenu))
            {
                case 0:
                    {
                        TimeOnly temp = Airport.CurrentTime.Add(TimeSpan.Parse("00:20:00"));
                        if (temp == TimeOnly.Parse("00:00:00"))
                        {
                            throw new ApplicationException("Day is over! Congratulations");
                        }
                        Airport.CurrentTime = temp;

                        for (int i = 0; i < airport.Gates.Count; i++)
                        {
                            airport.Gates[i].GateStatus = GateStatus.Free;
                        }

                        Random random = new Random();
                        for (int i = 0; i < airport.Schedule.Airplanes.Count; i++)
                            if (random.Next(0, 10) == 0 || airport.Schedule.Airplanes[i].ArrivalTime < Airport.CurrentTime)
                                airport.Schedule.Airplanes[i].AddDelay(TimeSpan.Parse("00:20:00"));

                        for (int i = 0; i < airport.Gates.Count; i++)
                            if (airport.Gates[i].CurrentPlane != null && airport.Gates[i].CurrentPlane!.DepartureTime < Airport.CurrentTime)
                                airport.Gates[i].CurrentPlane!.DepartureTime = Airport.CurrentTime;
                        break;
                    }
                case 1:
                    ControlTowerMenu(airport);
                    break;
                case 2:
                    {
                        int GateNumber = Menu.ChooseMenu(airport.gatesMenu);
                        if (GateNumber < airport.Gates.Count && airport.Gates[GateNumber].CurrentPlane != null)
                        {
                            string status = airport.Gates[GateNumber].GetGateStatus();
                            if (status == "")
                            {
                                int MenuNumber = Menu.ChooseMenu(airport.gateMenu);
                                switch (MenuNumber)
                                {
                                    case 0:
                                        Menu.ShowAirplaneInfo(airport.Gates[GateNumber].CurrentPlane!);
                                        break;
                                    case 1:
                                        airport.Gates[GateNumber].BoardAirplane();
                                        break;
                                    case 2:
                                        airport.Gates[GateNumber].RefuelAirplane();
                                        break;
                                }
                            }
                            else
                                throw new Exception(status + $" Gate-{GateNumber + 1}\n");
                        }
                        else if (GateNumber < airport.Gates.Count && airport.Gates[GateNumber].CurrentPlane == null)
                        {
                            throw new Exception("No plane at gate!");
                        }
                        break;
                    }
                case 3:
                    Menu.ShowSchedule(airport.Schedule);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.SetCursorPosition(0, 10);
        }

        static void ControlTowerMenu(Airport airport)
        {
            switch (Menu.ChooseMenu(airport.controlTowerMenu))
            {
                case 0:
                    {
                        if (airport.Schedule.Airplanes[0].ArrivalTime > Airport.CurrentTime.Add(airport.Schedule.Airplanes[0].Delay.ToTimeSpan()))
                            throw new Exception("Plane is not here yet!");

                        int GateNumber = Menu.ChooseMenu(airport.gatesMenu);
                        if (GateNumber < airport.Gates.Count && airport.Gates[GateNumber].CurrentPlane == null)
                            airport.Gates[GateNumber].AirplaneLanding(airport.AllowIn());
                        else
                            throw new Exception("A plane is already at the gate!");
                        break;
                    }
                case 1:
                    {
                        int GateNumber = Menu.ChooseMenu(airport.gatesMenu);
                        if (GateNumber < airport.Gates.Count && airport.Gates[GateNumber].CurrentPlane != null)
                        {
                            if (airport.Gates[GateNumber].GateStatus != GateStatus.Free)
                                throw new Exception(airport.Gates[GateNumber].GetGateStatus());

                            Menu.PlaneTakeoff(airport.Gates[GateNumber].CurrentPlane!.Fuel >= 50);
                            airport.Gates[GateNumber].AirplaneTakeOff();
                        }
                        else
                            throw new Exception("No plane at gate!");
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
