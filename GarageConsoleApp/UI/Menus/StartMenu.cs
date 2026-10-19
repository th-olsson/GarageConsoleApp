using GarageConsoleApp.Models;
using GarageConsoleApp.UI.Forms;

namespace GarageConsoleApp.UI.Menus
{
    internal static class StartMenu
    {
        internal static void Run()
        {
            MenuRunner.Run("Garage Manager", "Exit",
                ("Create garage", () =>
                {
                    Vehicle[] vehicles = VehicleRegistry.CreateSeed();
                    Garage garage = CreateGarageForm.Run(vehicles);
                    GarageMenu.Run(garage, vehicles);
                }
            ));
        }
    }
}