namespace GarageConsoleApp.Models
{
    internal abstract class Vehicle
    {
        public string Model { get; }
        public string RegistrationNumber { get; }
        public int NumberOfWheels { get; }


        protected Vehicle(string model, string registrationNumber, int numberOfWheels)
        {
            Model = model;
            RegistrationNumber = registrationNumber;
            NumberOfWheels = numberOfWheels;
        }
    }
}
