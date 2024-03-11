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
        private void Btn_Pack_Submit_Click(object sender, EventArgs e)
        {
            var option = new PackOptions()
            {
                Dir = Text_Dir.Text,
            };
            if (int.TryParse(Text_VersionNumber.Text, out var versionNumber) && versionNumber > 0)
            {
                if (PackDomain.Generate(option, new MaintenanceMeta(Text_Version.Text, versionNumber)))
                    MessageBox.Show("生成成功");
            }

        }
    }
}
