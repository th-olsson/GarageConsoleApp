namespace GarageConsoleApp
{
    internal static class ParkingUnits
    {
        public const int PerSpace = 3;

        public static int FromSpaces(int spaces) => spaces * PerSpace;

        /// <summary>Formats units as parking spaces, for example 1 -> "1/3", 3 -> "1", 4 -> "1 1/3".</summary>
        public static string Format(int units)
        {
            int whole = units / PerSpace;
            int thirds = units % PerSpace;

            if (thirds == 0)
                return whole.ToString();
            if (whole == 0)
                return $"{thirds}/{PerSpace}";

            return $"{whole} {thirds}/{PerSpace}";
        }
    }
}