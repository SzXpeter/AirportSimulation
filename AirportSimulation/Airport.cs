using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                temp[0] = $"Gate {i + 1}";
            }
            temp[NumberOfGates + 1] = "Back";
            gatesMenu = temp;

            this.Schedule = Schedule;
        }

        public Schedule Schedule { get; }
        public List<Gate> Gates { get; set; } = new List<Gate>();

        private readonly string[] airportMenu = ["Continue", "Control Tower", "Gates", "Show schedule", "Exit"];
        private readonly string[] controlTowerMenu = ["Authorise landing", "Authorise take off", "Back"];
        private string[] gatesMenu;
        private readonly string[] gateMenu = ["Show plane info", "Allow boarding", "Refuel", "Back"];

        public Airplane AllowIn()
        {
            Airplane temp = Schedule.Airplanes[0];
            Schedule.Airplanes.RemoveAt(0);

            Schedule.Airplanes.Add(Schedule.GenerateAirplane());
            return temp;
        }

        public void AirportMenu()
        {
            switch (Menu.ChooseMenu(airportMenu))
            {
                case 0:
                    //TODO
                    break;
                case 1:
                    ControlTowerMenu();
                    break;
                case 2:
                    {
                        int GateNumber = Menu.ChooseMenu(gatesMenu);
                        if (GateNumber < Gates.Count && Gates[GateNumber].CurrentPlane != null)
                        {
                            Menu.ChooseMenu(gateMenu);
                        }
                        else if(GateNumber < Gates.Count && Gates[GateNumber].CurrentPlane == null)
                        {
                            throw new Exception("No plane at gate!\nPress any key to continue...");
                        }
                        break;
                    }
                case 3:
                    Menu.ShowSchedule(Schedule);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.SetCursorPosition(0, 10);
        }

        private void ControlTowerMenu()
        {
            switch (Menu.ChooseMenu(controlTowerMenu))
            {
                case 0:
                    {
                        int GateNumber = Menu.ChooseMenu(gatesMenu);
                        if (GateNumber < Gates.Count)
                            Gates[GateNumber].AirplaneLanding(AllowIn());
                        break;
                    }
                case 1:
                    break;
                default:
                    break;
            }
        }
    }
}
