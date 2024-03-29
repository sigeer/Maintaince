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
                MessageBox.Show("ʧ�ܣ����Ŀ¼������");
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
                    MessageBox.Show("���ɳɹ�");
                else
                    MessageBox.Show("����ʧ��");
                isPacking = false;

                CleanFile(s1ScriptPath);
                CleanFile(s0ScriptPath);
            }
            else
            {
                MessageBox.Show("ʧ�ܣ��汾���к�Ӧ����������");
            }

        }
        string? s1ScriptContent;
        private void Btn_SetScript1_Click(object sender, EventArgs e)
        {
            var textForm = new TextForm("�༭Ԥ����ű�", s1ScriptContent);
            textForm.OnSubmit += (obj, evt) =>
            {
                s1ScriptContent = evt;
            };
            textForm.ShowDialog();
        }

        string? s0ScriptContent;
        private void Btn_SetScript0_Click(object sender, EventArgs e)
        {
            var textForm = new TextForm("�༭ִ�к�ű�", s0ScriptContent);
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
