namespace Maintenance.Console
{
    internal class ListReader
    {
        internal static List<string> GenerateListContent(string targetDir)
        {
            return Directory.EnumerateFiles(targetDir, "*", SearchOption.AllDirectories).Select(x => "* " + Path.GetRelativePath(targetDir, x)).ToList();
        }
    }

    public class ListItem
    {

    }
}
