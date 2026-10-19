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
        internal static int Choose(string prompt, params string[] options)
        {
            Text(prompt);
            Text("(Use Arrow keys to navigate up and down and Enter to select)");
            Console.WriteLine();
            Console.CursorVisible = false;

            int selected = 0;
            int top = -1; // first row of the option list, known after the first draw

            while (true)
            {
                if (top != -1)
                    Console.SetCursorPosition(0, top);

                for (int i = 0; i < options.Length; i++)
                    Option(options[i], i == selected);

                // Calculated after drawing, so it is still right if the window scrolled
                if (top == -1)
                    top = Console.CursorTop - options.Length;

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        selected = selected == options.Length - 1 ? 0 : selected + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        selected = selected == 0 ? options.Length - 1 : selected - 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return selected;
                }
            }
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
        internal static string? ReadOptionalString(string prompt)
        {
            Console.CursorVisible = true;
            Console.Write(prompt);
            string? input = Console.ReadLine();

            return string.IsNullOrWhiteSpace(input) ? null : input.Trim();
        }
        internal static int? ReadOptionalInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.CursorVisible = true;
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    return null;

                if (int.TryParse(input, out int value) && value >= min && value <= max)
                    return value;

                Console.WriteLine($"Please enter a whole number between {min} and {max}, or leave empty to skip.");
            }
        }
    }
}