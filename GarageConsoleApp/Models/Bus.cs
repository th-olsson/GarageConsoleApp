namespace GarageConsoleApp.Models
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; }

        public Bus(string model, string registrationNumber, int numberOfSeats, int numberOfWheels) : base(model, registrationNumber, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}
