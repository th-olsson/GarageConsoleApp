using static GarageConsoleApp.UI.ConsoleUI;

namespace GarageConsoleApp.UI.Menus
{
    internal static class GarageMenu
    {
        internal static void Run(Garage garage)
        {
            MenuRunner.Run($"{garage.Name}", "Back to start",
                ("Add Vehicle", () => { Text("This should run AddVehicleView..."); PressAnyKey(); }
            ),
                ("Remove Vehicle", () => { Text("This should run RemoveVehicleView..."); PressAnyKey(); }
            ),
                ("List Vehicles", () => { Text("This should run ListVehiclesView..."); PressAnyKey(); }
            ),
                ("Search Vehicles", () => { Text("This should run SearchVehiclesView..."); PressAnyKey(); }
            ));
        }
    }
}