using System.Windows.Forms;

namespace Lab4
{
    partial class Bai4
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelBrowser;
        private System.Windows.Forms.Button btnDownloadAll;
        private System.Windows.Forms.Button btnViewSource;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelBrowser = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            this.panelBrowser.Anchor = AnchorStyles.None;
            this.panelBrowser.Location = new System.Drawing.Point(14, 53);
            this.panelBrowser.Name = "panelBrowser";
            this.panelBrowser.Size = new System.Drawing.Size(1097, 640);
            this.panelBrowser.TabIndex = 3;

            this.btnDownloadAll = new System.Windows.Forms.Button();
            this.btnDownloadAll.Text = "Tải toàn bộ";
            this.btnDownloadAll.BackColor = System.Drawing.Color.Black;
            this.btnDownloadAll.Location = new System.Drawing.Point(0, 0);
            this.btnDownloadAll.AutoSize = true;
            this.btnDownloadAll.Name = "btnDownloadAll";
            this.btnDownloadAll.TabIndex = 1;
            this.btnDownloadAll.UseVisualStyleBackColor = true;
            this.btnDownloadAll.Click += new System.EventHandler(this.BtnDownloadAll_Click);
            this.Controls.Add(btnDownloadAll);

            this.btnViewSource = new System.Windows.Forms.Button();
            this.btnViewSource.Text = "Xem Source";
            this.btnViewSource.Location = new System.Drawing.Point(120, 0);
            this.btnViewSource.AutoSize = true;
            this.btnViewSource.Name = "btnViewSource";
            this.btnViewSource.TabIndex = 2;
            this.btnViewSource.Click += new System.EventHandler(this.BtnViewSource_Click);
            this.Controls.Add(this.btnViewSource);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 705);
            this.Controls.Add(this.panelBrowser);
            this.Name = "Bai4";
            this.Text = "Web Browser";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
