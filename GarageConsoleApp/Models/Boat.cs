 namespace GarageConsoleApp.Models
{
    internal class Boat : Vehicle
    {
        /// <summary> The length of the boat in meters </summary>
        public double Length { get; }

        /// <param name="length">The length of the boat in meters.</param>
        public Boat(string model, string registrationNumber, double length) : base(model, registrationNumber, numberOfWheels: 0)
        {
            Length = length;
        }
    }
}
