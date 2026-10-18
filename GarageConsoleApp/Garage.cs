using GarageConsoleApp.Models;

namespace GarageConsoleApp
{
    internal class Garage
    {
        private readonly Vehicle[] _vehicles;
        public string Name { get; }

        public Garage(string name, int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than 0.");

            _vehicles = new Vehicle[capacity];
            Name = name;
        }
    }
}
