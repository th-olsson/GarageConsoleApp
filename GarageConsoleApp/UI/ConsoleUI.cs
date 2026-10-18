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
        internal static void ErrorText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
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

        internal static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.CursorVisible = true;
                Console.Write($"    {prompt}");

                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;

                ErrorText($"Please enter a whole number between {min} and {max}.");
            }
        }

        internal static string ReadString(string prompt)
        {
            while (true)
            {
                Console.CursorVisible = true;
                Console.Write($"    {prompt}");
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                ErrorText("Input cannot be empty.");
            }
        }
    }
}