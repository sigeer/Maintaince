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
            Btn_Save = new Button();
            Btn_Cancel = new Button();
            Text_Container = new Panel();
            SuspendLayout();
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
            // Text_Container
            // 
            Text_Container.Location = new Point(0, 0);
            Text_Container.Name = "Text_Container";
            Text_Container.Size = new Size(500, 420);
            Text_Container.TabIndex = 3;
            // 
            // TextForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 454);
            Controls.Add(Text_Container);
            Controls.Add(Btn_Cancel);
            Controls.Add(Btn_Save);
            Name = "TextForm";
            Text = "TextForm";
            ResumeLayout(false);
        }

        #endregion
        private Button Btn_Save;
        private Button Btn_Cancel;
        private Panel Text_Container;
    }
}