using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    internal class Airport
    {
        public Airport(int NumberOfGates)
        {
            string[] temp = new string[NumberOfGates + 1];
            for (int i = 0; i < NumberOfGates; i++)
            {
                Gates.Add(new Gate());
                temp[0] = $"Gate {i + 1}";
            }
            temp[NumberOfGates + 1] = "Back";
            gatesMenu = temp;
        }

        public Schedule Schedule { get; set; } = new Schedule();
        public List<Gate> Gates { get; set; } = new List<Gate>();


        private string[] airportMenu = { "Continue", "Control Tower", "Gates", "Show schedule", "Exit" };
        private string[] controlTowerMenu = { "Let a plane land", "Let a plane take off", "Back" };
        private string[] gateMenu = {  };
        private string[] gatesMenu;

        public void AirportMenu()
        {
            switch (Menu.ChooseMenu(airportMenu))
            {
                case 0:
                    ControlTowerMenu();
                    break;
                case 1:
                    GatesMenu();
                    break;
                case 2:
                    Menu.ShowSchedule(Schedule);
                    break;
                case 3:
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
                    break;
                case 1:
                    break;
                default:
                    break;
            }
        }

        private void GatesMenu()
        {
            switch (Menu.ChooseMenu(gatesMenu))
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
}
