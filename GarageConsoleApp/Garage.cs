using GarageConsoleApp.Models;

namespace GarageConsoleApp
{
    internal class Garage
    {
        private readonly Vehicle[] _vehicles;
        
        public Garage(int capacity)
        {
            _vehicles = new Vehicle[capacity];
        }
    }
}
