namespace Maintenance.Win
{
    partial class UpdationForm
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
            ListView_Log = new ListView();
            Btn_Cancel = new Button();
            ProgressBar_Main = new ProgressBar();
            SuspendLayout();
            // 
            // ListView_Log
            // 
            ListView_Log.Location = new Point(115, 111);
            ListView_Log.Name = "ListView_Log";
            ListView_Log.Size = new Size(555, 289);
            ListView_Log.TabIndex = 0;
            ListView_Log.UseCompatibleStateImageBehavior = false;
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.Location = new Point(595, 415);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(75, 23);
            Btn_Cancel.TabIndex = 1;
            Btn_Cancel.Text = "取消";
            Btn_Cancel.UseVisualStyleBackColor = true;
            Btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // ProgressBar_Main
            // 
            ProgressBar_Main.Location = new Point(115, 60);
            ProgressBar_Main.Name = "ProgressBar_Main";
            ProgressBar_Main.Size = new Size(555, 36);
            ProgressBar_Main.TabIndex = 2;
            // 
            // UpdationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 450);
            Controls.Add(ProgressBar_Main);
            Controls.Add(Btn_Cancel);
            Controls.Add(ListView_Log);
            Name = "UpdationForm";
            Text = "UpdationForm";
            Load += UpdationForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView ListView_Log;
        private Button Btn_Cancel;
        private ProgressBar ProgressBar_Main;
    }
}