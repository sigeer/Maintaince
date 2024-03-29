namespace Maintenance.Win
{
    partial class TextForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Text_Content = new TextBox();
            Btn_Save = new Button();
            Btn_Cancel = new Button();
            SuspendLayout();
            // 
            // Text_Content
            // 
            Text_Content.Location = new Point(0, 0);
            Text_Content.Multiline = true;
            Text_Content.Name = "Text_Content";
            Text_Content.Size = new Size(500, 420);
            Text_Content.TabIndex = 0;
            // 
            // Btn_Save
            // 
            Btn_Save.Location = new Point(425, 426);
            Btn_Save.Name = "Btn_Save";
            Btn_Save.Size = new Size(75, 23);
            Btn_Save.TabIndex = 1;
            Btn_Save.Text = "保存修改";
            Btn_Save.UseVisualStyleBackColor = true;
            Btn_Save.Click += Btn_Save_Click;
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.Location = new Point(344, 426);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(75, 23);
            Btn_Cancel.TabIndex = 2;
            Btn_Cancel.Text = "放弃修改";
            Btn_Cancel.UseVisualStyleBackColor = true;
            Btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // TextForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 454);
            Controls.Add(Btn_Cancel);
            Controls.Add(Btn_Save);
            Controls.Add(Text_Content);
            Name = "TextForm";
            Text = "TextForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Text_Content;
        private Button Btn_Save;
        private Button Btn_Cancel;
    }
}