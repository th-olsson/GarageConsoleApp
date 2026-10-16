namespace GarageConsoleApp.Models
{
    internal class Motorcycle : Vehicle
    {
        public TransmissionType TransmissionType { get; }
        public Motorcycle(string model, string registrationNumber, TransmissionType transmissionType, int numberOfWheels = 2) : base(model, registrationNumber, numberOfWheels)
        {
            TransmissionType = transmissionType;
        }
    }
}
