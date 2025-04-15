using System.Windows.Forms;

namespace Lab4
{
    partial class Bai2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Panel panelBrowser;
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
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.panelBrowser = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(14, 13);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(571, 22);
            this.textBoxUrl.TabIndex = 0;
            this.textBoxUrl.Text = "https://google.com";
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Location = new System.Drawing.Point(592, 13);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(171, 24);
            this.comboBoxDevice.TabIndex = 1;
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(770, 13);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(86, 25);
            this.buttonGo.TabIndex = 2;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // panelBrowser
            // 
            this.panelBrowser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelBrowser.Location = new System.Drawing.Point(14, 53);
            this.panelBrowser.Name = "panelBrowser";
            this.panelBrowser.Size = new System.Drawing.Size(1097, 640);
            this.panelBrowser.TabIndex = 3;
            // 
            // Bai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 705);
            this.Controls.Add(this.panelBrowser);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.comboBoxDevice);
            this.Controls.Add(this.textBoxUrl);
            this.Name = "Bai2";
            this.Text = "Web Emulator - Device Switcher";
            this.Load += new System.EventHandler(this.Bai2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
