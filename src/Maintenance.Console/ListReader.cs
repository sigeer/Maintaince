namespace Maintenance.Console
{
    internal class ListReader
    {
        internal static List<string> GenerateListContent(string targetDir)
        {
            return GenerateFileList(targetDir).Select(x => "* " + Path.GetRelativePath(targetDir, x)).ToList();
        }

        internal static List<string> GenerateFileList(string targetDir)
        {
            return Directory.EnumerateFiles(targetDir, "*", SearchOption.AllDirectories).ToList();
        }
    }

    public class ListItem
    {

    }
}
