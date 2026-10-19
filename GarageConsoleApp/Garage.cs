using GarageConsoleApp.Models;

namespace GarageConsoleApp
{
    internal class Garage
    {
        private readonly Vehicle?[] _vehicles;
        private static readonly string[] _typeNames = ["Car", "Motorcycle", "Bus", "Boat", "Airplane"];
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
        public Vehicle[] GetParkedVehicles()
        {
            int count = 0;
            foreach (Vehicle? vehicle in _vehicles)
            {
                if (vehicle != null)
                    count++;
            }

            Vehicle[] parked = new Vehicle[count];
            int next = 0;
            foreach (Vehicle? vehicle in _vehicles)
            {
                if (vehicle != null)
                    parked[next++] = vehicle;
            }

            return parked;
        }
        public (string TypeName, int Count)[] CountByType()
        {
            Vehicle[] parked = GetParkedVehicles();
            var result = new (string TypeName, int Count)[_typeNames.Length];

            for (int i = 0; i < _typeNames.Length; i++)
            {
                string name = _typeNames[i];
                result[i] = (name, Array.FindAll(parked, v => v.TypeName == name).Length);
            }

            return result;
        }
        public Vehicle? Find(string registrationNumber)
        {
            int index = FindIndex(registrationNumber);
            return index == -1 ? null : _vehicles[index];
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