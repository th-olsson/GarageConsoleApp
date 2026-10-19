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
                    Garage garage = CreateGarageForm.Run();
                    Vehicle[] vehicles = VehicleRegistry.CreateSeed();
                    GarageMenu.Run(garage, vehicles);
                }
            ));
        }
    }
}