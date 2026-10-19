namespace GarageConsoleApp.UI
{
    internal static class Table
    {
        /// <summary>
        /// Formats a header and rows into aligned lines. Column widths come from the widest cell.
        /// The first returned line is the header, followed by the rows in the same order.
        /// </summary>
        internal static string[] Format(string[] headers, string[][] rows, params int[] rightAlignedColumns)
        {
            int[] widths = new int[headers.Length];

            for (int c = 0; c < headers.Length; c++)
            {
                widths[c] = headers[c].Length;
                foreach (string[] row in rows)
                    widths[c] = Math.Max(widths[c], row[c].Length);
            }

            string[] lines = new string[rows.Length + 1];
            lines[0] = FormatLine(headers, widths, rightAlignedColumns);

            for (int r = 0; r < rows.Length; r++)
                lines[r + 1] = FormatLine(rows[r], widths, rightAlignedColumns);

            return lines;
        }

        private static string FormatLine(string[] cells, int[] widths, int[] rightAlignedColumns)
        {
            string[] padded = new string[cells.Length];

            for (int c = 0; c < cells.Length; c++)
            {
                padded[c] = Array.IndexOf(rightAlignedColumns, c) >= 0
                    ? cells[c].PadLeft(widths[c])
                    : cells[c].PadRight(widths[c]);
            }

            return string.Join("  ", padded);
        }
    }
}