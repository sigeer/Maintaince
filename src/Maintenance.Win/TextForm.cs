using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maintenance.Win
{
    public partial class TextForm : Form
    {
        private TextEditorControl textEditorControl;
        public TextForm(string title, string? str = null)
        {
            InitializeComponent();

            Text = title;

            // 创建 TextEditor 控件实例
            textEditorControl = new TextEditorControl();
            textEditorControl.Dock = DockStyle.Fill;
            textEditorControl.Encoding = System.Text.Encoding.UTF8;
            textEditorControl.Font = new System.Drawing.Font("Consolas", 10);
            // 将 TextEditor 控件添加到窗体中
            Text_Container.Controls.Add(textEditorControl);

            textEditorControl.Text = str;
            InitializeHighLighting();
            textEditorControl.SetHighlighting("PowerShell");
        }

        private void InitializeHighLighting()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HighLighting");
            if (Directory.Exists(path))
            {
                var fsmp = new FileSyntaxModeProvider(path);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
                // 更多高亮配置：https://github.com/xv/ICSharpCode.TextEditor-Lexers/tree/master/Syntax
            }
        }


        public event EventHandler<string>? OnSubmit;
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            OnSubmit?.Invoke(textEditorControl, textEditorControl.Text);
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
