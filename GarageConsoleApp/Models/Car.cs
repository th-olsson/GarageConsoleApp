namespace GarageConsoleApp.Models
{
    internal class Car : Vehicle
    {
        private static readonly int DefaultSizeInUnits = ParkingUnits.FromSpaces(1);

        public FuelType FuelType { get; }

        public Car(string registrationNumber, string model, string color,
            FuelType fuelType, int numberOfWheels = 4, int? sizeInUnits = null)
            : base(registrationNumber, model, color, numberOfWheels, sizeInUnits ?? DefaultSizeInUnits)
        {
            FuelType = fuelType;
        }
    }
}