using static GarageConsoleApp.UI.ConsoleUI;

namespace GarageConsoleApp.UI.Forms
{
    internal static class CreateGarageForm
    {
        private const int MinCapacity = 1;
        private const int MaxCapacity = 1000;
        internal static Garage Run()
        {
            Title("Create garage");
            string name = ReadString("Garage name: ");
            int capacity = ReadInt($"How many parking spaces do you want? ({MinCapacity}-{MaxCapacity}): ", MinCapacity, MaxCapacity);
            Console.WriteLine();
            Text($"Garage \"{name}\" created with {capacity} parking spaces.");
            PressAnyKey();


            return new Garage(name, capacity);
        }
    }
}