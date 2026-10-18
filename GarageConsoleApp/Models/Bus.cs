namespace GarageConsoleApp.Models
{
    internal class Bus : Vehicle
    {
        private static readonly int DefaultSizeInUnits = ParkingUnits.FromSpaces(3);
        public int NumberOfSeats { get; }

        public Bus(string registrationNumber, string model, string color, int numberOfSeats, int numberOfWheels, int? sizeInUnits = null) : base(registrationNumber, model, color, numberOfWheels, sizeInUnits ?? DefaultSizeInUnits)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}
