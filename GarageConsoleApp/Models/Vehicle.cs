namespace GarageConsoleApp.Models
{
    internal abstract class Vehicle
    {
        public string RegistrationNumber { get; }
        public string Model { get; }
        public string Color { get; }
        public int NumberOfWheels { get; }

        /// <summary>
        /// Space the vehicle needs, in thirds of a parking space (3 = one full space).
        /// </summary>
        public int SizeInUnits { get; }
        public string TypeName => GetType().Name;

        protected Vehicle(string registrationNumber, string model, string color, int numberOfWheels, int sizeInUnits)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
            Model = model;
            SizeInUnits = sizeInUnits;
        }
    }
}