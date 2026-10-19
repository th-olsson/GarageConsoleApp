using GarageConsoleApp.Models;
using GarageConsoleApp.UI.Forms;

namespace GarageConsoleApp.UI.Menus
{
    internal static class GarageMenu
    {
        internal static void Run(Garage garage, Vehicle[] vehicles)
        {
            MenuRunner.Run(garage.Name, "Back to start",
                ("Manage parking", () => ManageParkingForm.Run(garage, vehicles)));
        }
    }
}