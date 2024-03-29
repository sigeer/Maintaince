using Maintenance.Lib.Domain;
using Maintenance.Win.Options;

namespace Maintenance.Win
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Btn_SelectFolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            var result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                Text_Dir.Text = fbd.SelectedPath;
            }
        }

        bool isPacking = false;
        private void Btn_Pack_Submit_Click(object sender, EventArgs e)
        {
            if (isPacking)
                return;

            var dir = Text_Dir.Text;
            if (!Directory.Exists(dir))
            {
                MessageBox.Show("失败：打包目录不存在");
                return;
            }

            if (int.TryParse(Text_VersionNumber.Text, out var versionNumber) && versionNumber > 0)
            {
                var s1ScriptPath = GenerateS1Script();
                var s0ScriptPath = GenerateS0Script();
                var option = new PackOptions()
                {
                    Dir = dir,
                    S1Script = s1ScriptPath,
                    S0Script = s0ScriptPath
                };

                isPacking = true;
                if (PackDomain.Generate(option, new MaintenanceMeta(Text_Version.Text, versionNumber)))
                    MessageBox.Show("生成成功");
                else
                    MessageBox.Show("生成失败");
                isPacking = false;

                CleanFile(s1ScriptPath);
                CleanFile(s0ScriptPath);
            }
            else
            {
                MessageBox.Show("失败：版本序列号应该是正整数");
            }

        }
        string? s1ScriptContent;
        private void Btn_SetScript1_Click(object sender, EventArgs e)
        {
            var textForm = new TextForm("编辑预处理脚本", s1ScriptContent);
            textForm.OnSubmit += (obj, evt) =>
            {
                s1ScriptContent = evt;
            };
            textForm.ShowDialog();
        }

        string? s0ScriptContent;
        private void Btn_SetScript0_Click(object sender, EventArgs e)
        {
            var textForm = new TextForm("编辑执行后脚本", s0ScriptContent);
            textForm.OnSubmit += (obj, evt) =>
            {
                s0ScriptContent = evt;
            };
            textForm.ShowDialog();
        }

        private string? GenerateS1Script()
        {
            if (!string.IsNullOrWhiteSpace(s1ScriptContent))
            {
                var filePath = Path.GetTempFileName();
                File.WriteAllText(filePath, s1ScriptContent);
                return filePath;
            }
            return null;
        }
        private string? GenerateS0Script()
        {
            if (!string.IsNullOrWhiteSpace(s0ScriptContent))
            {
                var filePath = Path.GetTempFileName();
                File.WriteAllText(filePath, s0ScriptContent);
                return filePath;
            }
            return null;
        }

        private void CleanFile(string? path)
        {
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                File.Delete(path);
        }
    }
}
