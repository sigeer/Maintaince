using Maintenance.Lib;
using Maintenance.Lib.Domain;

namespace Maintenance.Win
{
    public partial class UpdationForm : Form
    {
        readonly IUpdationOptions _options;
        public UpdationForm(IUpdationOptions updationOptions)
        {
            _options = updationOptions;
            InitializeComponent();

            LogSinks.Sink.LogReceived += (obj, evt) =>
            {
                ListView_Log.Items.Add(evt);
            };
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private async void UpdationForm_Load(object sender, EventArgs e)
        {
            await UpdationDomain.Core(_options, (current, total) =>
            {
                ProgressBar_Main.Maximum = (int)total;
                ProgressBar_Main.Value = (int)current;
            });
        }
    }
}
