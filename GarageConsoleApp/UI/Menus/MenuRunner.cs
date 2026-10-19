using static GarageConsoleApp.UI.ConsoleUI;

namespace GarageConsoleApp.UI.Menus
{
    internal static class MenuRunner
    {
        internal static void Run(string title, string exitLabel,
            params (string Label, Action Action)[] options)
        {
            // The exit option is always last, after the options the caller gave
            string[] labels = options.Select(option => option.Label).Append(exitLabel).ToArray();
            int exitIndex = options.Length;
            int selected = 0;

            while (true)
            {
                Title(title);
                selected = Choose(null, labels, selected, separateLast: true);

                if (selected == exitIndex)
                    return;

                Console.WriteLine();
                options[selected].Action();
            }
        }
    }
}