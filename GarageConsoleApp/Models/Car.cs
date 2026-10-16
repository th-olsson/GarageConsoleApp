namespace GarageConsoleApp.Models
{
    internal class Car : Vehicle
    {
        public FuelType FuelType { get; }

        public Car(string model, string registrationNumber, FuelType fuelType, int numberOfWheels = 4) : base(model, registrationNumber, numberOfWheels)
        {
            FuelType = fuelType;
        }
    }
}
