namespace GarageConsoleApp
{
    internal static class ParkingUnits
    {
        public const int PerSpace = 3;

        public static int FromSpaces(int spaces) => spaces * PerSpace;
    }
}