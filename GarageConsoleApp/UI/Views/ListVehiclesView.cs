using GarageConsoleApp.Models;
using static GarageConsoleApp.UI.ConsoleUI;

namespace GarageConsoleApp.UI.Views
{
    internal static class ListVehiclesView
    {
        internal static void Run(Garage garage)
        {
            Title($"Parked vehicles - {garage.Name}");

            Vehicle[] parked = garage.GetParkedVehicles();

            if (parked.Length == 0)
            {
                Text("The garage is empty.");
            }
            else
            {
                string[][] rows = new string[parked.Length][];
                for (int i = 0; i < parked.Length; i++)
                {
                    Vehicle v = parked[i];
                    rows[i] =
                    [
                        v.TypeName,
                        v.RegistrationNumber,
                        v.Model,
                        v.Color,
                        v.NumberOfWheels.ToString(),
                        ParkingUnits.Format(v.SizeInUnits)
                    ];
                }

                string[] lines = Table.Format(["Type", "Reg", "Model", "Color", "Wheels", "Space"], rows, 4, 5);

                Text(lines[0]);
                Text(new string('-', lines[0].Length));
                for (int i = 1; i < lines.Length; i++)
                    Text(lines[i]);
            }

            Console.WriteLine();
            Text($"Parking spaces used: {ParkingUnits.Format(garage.UsedUnits)} / {garage.Capacity}");
            PressAnyKey();
        }
    }
}