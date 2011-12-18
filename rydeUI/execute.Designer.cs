namespace rydeUI
{
    partial class execute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(execute));
            this.codeWindow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // codeWindow
            // 
            this.codeWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeWindow.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeWindow.Location = new System.Drawing.Point(0, 0);
            this.codeWindow.Multiline = true;
            this.codeWindow.Name = "codeWindow";
            this.codeWindow.ReadOnly = true;
            this.codeWindow.Size = new System.Drawing.Size(467, 186);
            this.codeWindow.TabIndex = 0;
            this.codeWindow.TextChanged += new System.EventHandler(this.codeWindow_TextChanged);
            // 
            // execute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 186);
            this.Controls.Add(this.codeWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "execute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Execute Code";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.execute_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codeWindow;
    }
}