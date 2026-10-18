using static GarageConsoleApp.UI.ConsoleUI;

namespace GarageConsoleApp.UI
{
    internal static class MainMenu
    {
        internal static void Run()
        {
            MenuRunner.Run("Garage Management System", "Exit",
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