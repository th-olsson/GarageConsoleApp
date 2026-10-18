using static GarageConsoleApp.UI.ConsoleUI;

namespace GarageConsoleApp.UI.Menus
{
    internal static class MenuRunner
    {
        private const int NoSelection = -1;
        private const string HelpText = "(Use Arrow keys to navigate up and down and Enter to select)";

        internal static void Run(string title, string exitLabel,
            params (string Label, Action Action)[] options)
        {
            bool running = true;
            var items = options.Append((exitLabel, () => running = false)).ToArray();
            int lastIndex = items.Length - 1;
            int selected = NoSelection;

            while (running)
            {
                Console.CursorVisible = false;

                Title(title);
                if (selected == NoSelection)
                    HighlightedText(HelpText, withArrow: false);
                else
                    Text(HelpText);
                Console.WriteLine();

                for (int i = 0; i < items.Length; i++)
                {
                    if (i == lastIndex) // spacer before the exit item
                        Console.WriteLine();

                    Option(items[i].Label, i == selected);
                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        if (selected != NoSelection)
                        {
                            Console.CursorVisible = true;
                            Console.WriteLine();
                            items[selected].Action();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selected = selected == lastIndex ? 0 : selected + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        selected = selected <= 0 ? lastIndex : selected - 1;
                        break;
                }
            }
        }
    }
}