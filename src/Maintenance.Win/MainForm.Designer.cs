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
            TabPage_Pack = new TabPage();
            Btn_SetScript0 = new Button();
            label3 = new Label();
            Label_S1 = new Label();
            Btn_SetScript1 = new Button();
            label2 = new Label();
            Text_VersionNumber = new TextBox();
            Text_Version = new TextBox();
            label1 = new Label();
            Btn_Pack_Submit = new Button();
            Text_Dir = new TextBox();
            Btn_SelectFolder = new Button();
            TabControl_Pack.SuspendLayout();
            TabPage_Pack.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl_Pack
            // 
            TabControl_Pack.Controls.Add(TabPage_Pack);
            TabControl_Pack.Location = new Point(13, 6);
            TabControl_Pack.Name = "TabControl_Pack";
            TabControl_Pack.SelectedIndex = 0;
            TabControl_Pack.Size = new Size(595, 311);
            TabControl_Pack.TabIndex = 0;
            // 
            // TabPage_Pack
            // 
            TabPage_Pack.Controls.Add(Btn_SetScript0);
            TabPage_Pack.Controls.Add(label3);
            TabPage_Pack.Controls.Add(Label_S1);
            TabPage_Pack.Controls.Add(Btn_SetScript1);
            TabPage_Pack.Controls.Add(label2);
            TabPage_Pack.Controls.Add(Text_VersionNumber);
            TabPage_Pack.Controls.Add(Text_Version);
            TabPage_Pack.Controls.Add(label1);
            TabPage_Pack.Controls.Add(Btn_Pack_Submit);
            TabPage_Pack.Controls.Add(Text_Dir);
            TabPage_Pack.Controls.Add(Btn_SelectFolder);
            TabPage_Pack.Location = new Point(4, 26);
            TabPage_Pack.Name = "TabPage_Pack";
            TabPage_Pack.Padding = new Padding(3);
            TabPage_Pack.Size = new Size(587, 281);
            TabPage_Pack.TabIndex = 0;
            TabPage_Pack.Text = "打包";
            TabPage_Pack.UseVisualStyleBackColor = true;
            TabPage_Pack.DragDrop += tabPage1_DragDrop;
            TabPage_Pack.DragEnter += tabPage1_DragEnter;
            // 
            // Btn_SetScript0
            // 
            Btn_SetScript0.Location = new Point(87, 155);
            Btn_SetScript0.Name = "Btn_SetScript0";
            Btn_SetScript0.Size = new Size(156, 23);
            Btn_SetScript0.TabIndex = 10;
            Btn_SetScript0.Text = "设置完成脚本";
            Btn_SetScript0.UseVisualStyleBackColor = true;
            Btn_SetScript0.Click += Btn_SetScript0_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 158);
            label3.Name = "label3";
            label3.Size = new Size(70, 17);
            label3.TabIndex = 9;
            label3.Text = "设置脚本S2";
            // 
            // Label_S1
            // 
            Label_S1.AutoSize = true;
            Label_S1.Location = new Point(11, 120);
            Label_S1.Name = "Label_S1";
            Label_S1.Size = new Size(70, 17);
            Label_S1.TabIndex = 8;
            Label_S1.Text = "设置脚本S1";
            // 
            // Btn_SetScript1
            // 
            Btn_SetScript1.Location = new Point(87, 117);
            Btn_SetScript1.Name = "Btn_SetScript1";
            Btn_SetScript1.Size = new Size(156, 23);
            Btn_SetScript1.TabIndex = 7;
            Btn_SetScript1.Text = "设置预处理脚本";
            Btn_SetScript1.UseVisualStyleBackColor = true;
            Btn_SetScript1.Click += Btn_SetScript1_Click;
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
            // Text_VersionNumber
            // 
            Text_VersionNumber.Location = new Point(87, 79);
            Text_VersionNumber.Name = "Text_VersionNumber";
            Text_VersionNumber.Size = new Size(156, 23);
            Text_VersionNumber.TabIndex = 5;
            // 
            // Text_Version
            // 
            Text_Version.Location = new Point(87, 41);
            Text_Version.Name = "Text_Version";
            Text_Version.Size = new Size(156, 23);
            Text_Version.TabIndex = 4;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 323);
            Controls.Add(TabControl_Pack);
            Name = "MainForm";
            Text = "工具";
            TabControl_Pack.ResumeLayout(false);
            TabPage_Pack.ResumeLayout(false);
            TabPage_Pack.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControl_Pack;
        private TabPage TabPage_Pack;
        private TextBox Text_Dir;
        private Button Btn_SelectFolder;
        private Button Btn_Pack_Submit;
        private Label label1;
        private Label label2;
        private TextBox Text_VersionNumber;
        private TextBox Text_Version;
        private Label Label_S1;
        private Button Btn_SetScript1;
        private Button Btn_SetScript0;
        private Label label3;
    }
}
