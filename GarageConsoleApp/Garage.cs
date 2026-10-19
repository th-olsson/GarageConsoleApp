using GarageConsoleApp.Models;

namespace GarageConsoleApp
{
    internal class Garage
    {
        // One entry per parked vehicle. The length is the most vehicles that could ever fit
        // (every vehicle takes at least one unit), while the real limit is the total units.
        private readonly Vehicle?[] _vehicles;
        public string Name { get; }
        /// <summary>The number of parking spaces.</summary>
        public int Capacity { get; }
        public int TotalUnits => ParkingUnits.FromSpaces(Capacity);
        public int UsedUnits
        {
            get
            {
                int used = 0;
                foreach (Vehicle? vehicle in _vehicles)
                {
                    if (vehicle != null)
                        used += vehicle.SizeInUnits;
                }
                return used;
            }
        }
        public int FreeUnits => TotalUnits - UsedUnits;

        public Garage(string name, int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than 0.");

            Name = name;
            Capacity = capacity;
            _vehicles = new Vehicle?[ParkingUnits.FromSpaces(capacity)];
        }

        public bool IsParked(string registrationNumber) => FindIndex(registrationNumber) != -1;
        public bool Remove(string registrationNumber)
        {
            int index = FindIndex(registrationNumber);
            if (index == -1)
                return false;

            _vehicles[index] = null;
            return true;
        }
        public ParkResult Park(Vehicle vehicle)
        {
            if (FindIndex(vehicle.RegistrationNumber) != -1)
                return ParkResult.AlreadyParked;

            int slot = FindFreeSlot();
            if (slot == -1 || vehicle.SizeInUnits > FreeUnits)
                return ParkResult.NotEnoughSpace;

            _vehicles[slot] = vehicle;
            return ParkResult.Parked;
        }
        private int FindFreeSlot()
        {
            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] == null)
                    return i;
            }
            return -1;
        }
        private int FindIndex(string registrationNumber)
        {
            for (int i = 0; i < _vehicles.Length; i++)
            {
                Vehicle? vehicle = _vehicles[i];
                if (vehicle != null &&
                    vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }
    }
}