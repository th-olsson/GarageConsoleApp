using GarageConsoleApp.Models;
using static GarageConsoleApp.UI.ConsoleUI;

namespace GarageConsoleApp.UI.Forms
{
    internal static class ManageParkingForm
    {
        internal static void Run(Garage garage, Vehicle[] vehicles)
        {
            // Start from what is parked right now
            bool[] isChecked = new bool[vehicles.Length];
            for (int i = 0; i < vehicles.Length; i++)
                isChecked[i] = garage.IsParked(vehicles[i].RegistrationNumber);

            int selected = 0;
            bool running = true;
            Console.CursorVisible = false;

            while (running)
            {
                int neededUnits = CountCheckedUnits(vehicles, isChecked);
                bool fits = neededUnits <= garage.TotalUnits;

                Title($"Manage parking - {garage.Name}");
                Text("Up/Down: move   Spacebar: check/uncheck   Enter: apply   Esc: cancel");
                Console.WriteLine();

                Text($"    {"Reg",-7} {"Model",-26} {"Type",-11} {"Space",6}");
                for (int i = 0; i < vehicles.Length; i++)
                {
                    string row = FormatRow(vehicles[i], isChecked[i], garage.IsParked(vehicles[i].RegistrationNumber));

                    if (i == selected)
                        HighlightedText(row);
                    else
                        Text(row);
                }

                Console.WriteLine();
                string summary = $"Parking spaces needed: {ParkingUnits.Format(neededUnits)} / {garage.Capacity}";
                if (fits)
                {
                    Text(summary);
                }
                else
                {
                    ErrorText($"{summary} - too much, uncheck something");
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selected = selected == 0 ? vehicles.Length - 1 : selected - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selected = selected == vehicles.Length - 1 ? 0 : selected + 1;
                        break;
                    case ConsoleKey.Spacebar:
                        isChecked[selected] = !isChecked[selected];
                        break;
                    case ConsoleKey.Enter:
                        if (fits)
                        {
                            Console.WriteLine();
                            Apply(garage, vehicles, isChecked);
                            PressAnyKey();
                            running = false;
                        }
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                }
            }

            Console.CursorVisible = true;
        }

        private static string FormatRow(Vehicle vehicle, bool isChecked, bool isParked)
        {
            string box = isChecked ? "[x]" : "[ ]";
            string status = (isChecked, isParked) switch
            {
                (true, false) => "to park",
                (false, true) => "to leave",
                (true, true) => "parked",
                _ => ""
            };

            return $"{box} {vehicle.RegistrationNumber,-7} {vehicle.Model,-26} {vehicle.TypeName,-11} {ParkingUnits.Format(vehicle.SizeInUnits),6}  {status}";
        }

        private static int CountCheckedUnits(Vehicle[] vehicles, bool[] isChecked)
        {
            int total = 0;
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (isChecked[i])
                    total += vehicles[i].SizeInUnits;
            }
            return total;
        }

        private static void Apply(Garage garage, Vehicle[] vehicles, bool[] isChecked)
        {
            Console.Clear();
            bool anyChange = false;

            // Remove first, so the freed space can be used by the vehicles parked next
            for (int i = 0; i < vehicles.Length; i++)
            {
                Vehicle vehicle = vehicles[i];
                if (!isChecked[i] && garage.IsParked(vehicle.RegistrationNumber))
                {
                    garage.Remove(vehicle.RegistrationNumber);
                    Text($"{vehicle.RegistrationNumber} {vehicle.Model}: left the garage");
                    anyChange = true;
                }
            }

            for (int i = 0; i < vehicles.Length; i++)
            {
                Vehicle vehicle = vehicles[i];
                if (isChecked[i] && !garage.IsParked(vehicle.RegistrationNumber))
                {
                    string message = garage.Park(vehicle) switch
                    {
                        ParkResult.Parked => "parked",
                        ParkResult.NotEnoughSpace => "could not be parked, not enough space",
                        ParkResult.AlreadyParked => "is already parked",
                        _ => "unknown result"
                    };

                    Text($"{vehicle.RegistrationNumber} {vehicle.Model}: {message}");
                    anyChange = true;
                }
            }

            if (!anyChange)
                Text("No changes.");
        }
    }
}