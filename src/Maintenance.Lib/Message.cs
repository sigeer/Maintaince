namespace Maintenance.Lib
{
    public class Message
    {
        public static void ShowMessageWithColor(ConsoleColor color, string message)
        {
            if (System.Console.ForegroundColor != color)
            {
                var stashColor = System.Console.ForegroundColor;
                System.Console.ForegroundColor = color;
                System.Console.WriteLine(message);
                System.Console.ForegroundColor = stashColor;
            }
            else
            {
                System.Console.WriteLine(message);
            }
        }

        public static void PrintProgress(long total, long current)
        {
            System.Console.SetCursorPosition(0, System.Console.CursorTop);
            System.Console.Write($"已下载: {current} / {total} bytes ({(current * 100) / total}%)");

            // // \r也可以
            // System.Console.Write($"\rDownloaded: {current} / {total} bytes ({(current * 100) / total}%)");
        }
    }
}
