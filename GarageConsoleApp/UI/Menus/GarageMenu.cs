using GarageConsoleApp.Models;
using GarageConsoleApp.UI.Forms;
using GarageConsoleApp.UI.Views;

namespace GarageConsoleApp.UI.Menus
{
    internal static class GarageMenu
    {
        internal static void Run(Garage garage, Vehicle[] vehicles)
        {
            MenuRunner.Run(garage.Name, "Back to start",
                ("Manage parking", () => ManageParkingForm.Run(garage, vehicles)),
                ("List Vehicles", () => ListVehiclesView.Run(garage))
            );
        }
    }
}