using GarageConsoleApp.Models;

namespace GarageConsoleApp
{
    internal class VehicleFilter
    {
        public string? TypeName { get; set; }
        public string? Color { get; set; }
        public int? NumberOfWheels { get; set; }
        public string? Model { get; set; }

        public bool IsEmpty =>
            TypeName == null && Color == null && NumberOfWheels == null && Model == null;

        public bool Matches(Vehicle vehicle) =>
            (TypeName == null || vehicle.TypeName.Equals(TypeName, StringComparison.OrdinalIgnoreCase)) &&
            (Color == null || vehicle.Color.Equals(Color, StringComparison.OrdinalIgnoreCase)) &&
            (NumberOfWheels == null || vehicle.NumberOfWheels == NumberOfWheels) &&
            (Model == null || vehicle.Model.Contains(Model, StringComparison.OrdinalIgnoreCase));
    }
}