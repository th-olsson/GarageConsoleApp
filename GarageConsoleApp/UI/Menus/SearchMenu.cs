using GarageConsoleApp.UI.Forms;
using static GarageConsoleApp.UI.ConsoleUI;

namespace GarageConsoleApp.UI.Menus
{
    internal static class SearchMenu
    {
        internal static void Run(Garage garage)
        {
            MenuRunner.Run("Search vehicles", "Back",
                ("By registration number", () => FindByRegistrationForm.Run(garage)),
                ("By properties", () => SearchByPropertiesForm.Run(garage))
            );
        }
    }
}