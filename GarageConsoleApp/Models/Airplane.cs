namespace GarageConsoleApp.Models
{
    internal class Airplane : Vehicle
    {
        public int NumberOfEngines { get; }

        public Airplane(string model, string registrationNumber, int numberOfEngines, int numberOfWheels) : base(model, registrationNumber, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }
    }
}
