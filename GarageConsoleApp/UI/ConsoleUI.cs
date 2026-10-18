namespace GarageConsoleApp.UI
{
    internal static class ConsoleUI
    {
        internal static void Title(string text)
        {
            Console.Clear();
            Console.WriteLine($"=== {text} ===");
            Console.WriteLine();
        }

        internal static void Text(string text) => Console.WriteLine($"    {text}");

        internal static void HighlightedText(string text, bool withArrow = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (withArrow)
                Console.WriteLine($" -> {text}");
            else
                Text(text);
            Console.ResetColor();
        }

        internal static void Option(string label, bool highlighted)
        {
            if (highlighted)
                HighlightedText(label);
            else
                Text(label);
        }

        internal static void PressAnyKey()
        {
            Console.WriteLine();
            Text("Press any key to continue...");
            Console.ReadKey();
        }
    }
}