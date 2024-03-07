namespace Maintenance.Console
{
    internal class Message
    {
        internal static void ShowMessageWithColor(ConsoleColor color, string message)
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
    }
}
