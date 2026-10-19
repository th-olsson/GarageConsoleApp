using GarageConsoleApp.Models;
using static GarageConsoleApp.UI.ConsoleUI;

namespace GarageConsoleApp.UI.Forms
{
    internal static class CreateGarageForm
    {
        private const int MinCapacity = 1;
        private const int MaxCapacity = 1000;

        internal static Garage Run(Vehicle[] vehicles)
        {
            Title("Create garage");
            string name = ReadString("Garage name: ");
            int capacity = ReadInt($"How many parking spaces do you want? ({MinCapacity}-{MaxCapacity}): ", MinCapacity, MaxCapacity);

            Console.WriteLine();
            int choice = Choose("Do you want an empty or populated garage?", "Empty garage", "Populated garage");

            var garage = new Garage(name, capacity);

            Console.WriteLine();
            Text($"Garage \"{name}\" created with {capacity} parking spaces.");

            if (choice == 1)
            {
                int parked = Populate(garage, vehicles);
                Text($"{parked} of {vehicles.Length} vehicles from the registry were parked.");
            }

            PressAnyKey();
            return garage;
        }

        // Parks vehicles from the registry in random order, skipping any that do not fit
        private static int Populate(Garage garage, Vehicle[] vehicles)
        {
            // Shuffle a copy so the registry keeps its own order
            Vehicle[] shuffled = (Vehicle[])vehicles.Clone();
            Random.Shared.Shuffle(shuffled);

            int parked = 0;
            foreach (Vehicle vehicle in shuffled)
            {
                if (garage.Park(vehicle) == ParkResult.Parked)
                    parked++;
            }
            return parked;
        }
    }
}