namespace GarageConsoleApp.Models
{
    internal class Airplane : Vehicle
    {
        private static readonly int DefaultSizeInUnits = ParkingUnits.FromSpaces(8);
        public int NumberOfEngines { get; }

        public Airplane(string registrationNumber, string model, string color, int numberOfWheels, int numberOfEngines, int? sizeInUnits = null) : base(registrationNumber, model, color, numberOfWheels, sizeInUnits ?? DefaultSizeInUnits)
        {
            NumberOfEngines = numberOfEngines;
        }
    }
}
