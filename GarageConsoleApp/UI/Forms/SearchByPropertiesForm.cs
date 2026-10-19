using GarageConsoleApp.Models;
using static GarageConsoleApp.UI.ConsoleUI;

namespace GarageConsoleApp.UI.Forms
{
    internal static class SearchByPropertiesForm
    {
        private static readonly string[] TypeNames = ["Car", "Motorcycle", "Bus", "Boat", "Airplane"];

        internal static void Run(Garage garage)
        {
            Title("Search vehicles by properties");
            Text("Leave a field empty to skip it. Everything you fill in must match.");
            Console.WriteLine();

            for (int i = 0; i < TypeNames.Length; i++)
                Text($"{i + 1}. {TypeNames[i]}");

            int? typeChoice = ReadOptionalInt("Type (number): ", 1, TypeNames.Length);
            string? color = ReadOptionalString("Color: ");
            int? wheels = ReadOptionalInt("Number of wheels: ", 0, 100);
            string? model = ReadOptionalString("Model (part of the name): ");

            var filter = new VehicleFilter
            {
                TypeName = typeChoice == null ? null : TypeNames[typeChoice.Value - 1],
                Color = color,
                NumberOfWheels = wheels,
                Model = model
            };

            Console.WriteLine();

            if (filter.IsEmpty)
            {
                ErrorText("You did not fill in anything to search for.");
            }
            else
            {
                Vehicle[] matches = garage.Search(filter);

                if (matches.Length == 0)
                {
                    Text("No parked vehicles match.");
                }
                else
                {
                    VehicleTable.Print(matches);
                    Console.WriteLine();
                    Text($"{matches.Length} vehicle(s) found.");
                }
            }

            PressAnyKey();
        }
    }
}