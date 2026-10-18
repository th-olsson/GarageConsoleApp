namespace GarageConsoleApp
{
    internal class DuplicateRegistrationNumberException : Exception
    {
        public string RegistrationNumber { get; }

        public DuplicateRegistrationNumberException(string registrationNumber)
            : base($"Duplicate registration number: {registrationNumber}")
        {
            RegistrationNumber = registrationNumber;
        }
    }
}