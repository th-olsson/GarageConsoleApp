using GarageConsoleApp.UI.Views;

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
                    GarageMenu.Run(garage);
                }
            ));
        }
    }
}