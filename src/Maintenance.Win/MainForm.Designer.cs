namespace Maintenance.Win
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabControl_Pack = new TabControl();
            tabPage1 = new TabPage();
            Btn_Pack_Submit = new Button();
            Text_Dir = new TextBox();
            Btn_SelectFolder = new Button();
            tabPage2 = new TabPage();
            label1 = new Label();
            Text_Version = new TextBox();
            Text_VersionNumber = new TextBox();
            label2 = new Label();
            TabControl_Pack.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl_Pack
            // 
            TabControl_Pack.Controls.Add(tabPage1);
            TabControl_Pack.Controls.Add(tabPage2);
            TabControl_Pack.Location = new Point(13, 6);
            TabControl_Pack.Name = "TabControl_Pack";
            TabControl_Pack.SelectedIndex = 0;
            TabControl_Pack.Size = new Size(595, 311);
            TabControl_Pack.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(Text_VersionNumber);
            tabPage1.Controls.Add(Text_Version);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(Btn_Pack_Submit);
            tabPage1.Controls.Add(Text_Dir);
            tabPage1.Controls.Add(Btn_SelectFolder);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(587, 281);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // Btn_Pack_Submit
            // 
            Btn_Pack_Submit.Location = new Point(506, 252);
            Btn_Pack_Submit.Name = "Btn_Pack_Submit";
            Btn_Pack_Submit.Size = new Size(75, 23);
            Btn_Pack_Submit.TabIndex = 2;
            Btn_Pack_Submit.Text = "确定";
            Btn_Pack_Submit.UseVisualStyleBackColor = true;
            Btn_Pack_Submit.Click += Btn_Pack_Submit_Click;
            // 
            // Text_Dir
            // 
            Text_Dir.Location = new Point(87, 6);
            Text_Dir.Name = "Text_Dir";
            Text_Dir.Size = new Size(494, 23);
            Text_Dir.TabIndex = 1;
            // 
            // Btn_SelectFolder
            // 
            Btn_SelectFolder.Location = new Point(6, 6);
            Btn_SelectFolder.Name = "Btn_SelectFolder";
            Btn_SelectFolder.Size = new Size(75, 23);
            Btn_SelectFolder.TabIndex = 0;
            Btn_SelectFolder.Text = "选择目录";
            Btn_SelectFolder.UseVisualStyleBackColor = true;
            Btn_SelectFolder.Click += Btn_SelectFolder_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(587, 281);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 44);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 3;
            label1.Text = "版本号";
            // 
            // Text_Version
            // 
            Text_Version.Location = new Point(87, 41);
            Text_Version.Name = "Text_Version";
            Text_Version.Size = new Size(156, 23);
            Text_Version.TabIndex = 4;
            // 
            // Text_VersionNumber
            // 
            Text_VersionNumber.Location = new Point(87, 79);
            Text_VersionNumber.Name = "Text_VersionNumber";
            Text_VersionNumber.Size = new Size(156, 23);
            Text_VersionNumber.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 79);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 6;
            label2.Text = "版本号序列";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 450);
            Controls.Add(TabControl_Pack);
            Name = "MainForm";
            Text = "Form1";
            TabControl_Pack.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControl_Pack;
        private TabPage tabPage1;
        private TextBox Text_Dir;
        private Button Btn_SelectFolder;
        private TabPage tabPage2;
        private Button Btn_Pack_Submit;
        private Label label1;
        private Label label2;
        private TextBox Text_VersionNumber;
        private TextBox Text_Version;
    }
}
