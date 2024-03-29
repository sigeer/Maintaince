using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maintenance.Win
{
    public partial class TextForm : Form
    {
        public TextForm(string title, string? str = null)
        {
            InitializeComponent();
            Text_Content.Text = str;
            Text = title;
        }

        public event EventHandler<string>? OnSubmit;
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            OnSubmit?.Invoke(Text_Content, Text_Content.Text);
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
