namespace Lab4
{
    partial class Lab4
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
            this.bttnBai1 = new System.Windows.Forms.Button();
            this.bttnBai2 = new System.Windows.Forms.Button();
            this.bttnBai4 = new System.Windows.Forms.Button();
            this.bttnBai3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttnBai1
            // 
            this.bttnBai1.Location = new System.Drawing.Point(113, 51);
            this.bttnBai1.Name = "bttnBai1";
            this.bttnBai1.Size = new System.Drawing.Size(191, 108);
            this.bttnBai1.TabIndex = 0;
            this.bttnBai1.Text = "Bai 1";
            this.bttnBai1.UseVisualStyleBackColor = true;
            this.bttnBai1.Click += new System.EventHandler(this.bttnBai1_Click);
            // 
            // bttnBai2
            // 
            this.bttnBai2.Location = new System.Drawing.Point(482, 51);
            this.bttnBai2.Name = "bttnBai2";
            this.bttnBai2.Size = new System.Drawing.Size(191, 108);
            this.bttnBai2.TabIndex = 1;
            this.bttnBai2.Text = "Bai 2";
            this.bttnBai2.UseVisualStyleBackColor = true;
            this.bttnBai2.Click += new System.EventHandler(this.bttnBai2_Click);
            // 
            // bttnBai4
            // 
            this.bttnBai4.Location = new System.Drawing.Point(482, 244);
            this.bttnBai4.Name = "bttnBai4";
            this.bttnBai4.Size = new System.Drawing.Size(191, 108);
            this.bttnBai4.TabIndex = 3;
            this.bttnBai4.Text = "Bai 4";
            this.bttnBai4.UseVisualStyleBackColor = true;
            this.bttnBai4.Click += new System.EventHandler(this.bttnBai4_Click);
            // 
            // bttnBai3
            // 
            this.bttnBai3.Location = new System.Drawing.Point(113, 244);
            this.bttnBai3.Name = "bttnBai3";
            this.bttnBai3.Size = new System.Drawing.Size(191, 108);
            this.bttnBai3.TabIndex = 2;
            this.bttnBai3.Text = "Bai 3";
            this.bttnBai3.UseVisualStyleBackColor = true;
            this.bttnBai3.Click += new System.EventHandler(this.bttnBai3_Click);
            // 
            // Lab4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bttnBai4);
            this.Controls.Add(this.bttnBai3);
            this.Controls.Add(this.bttnBai2);
            this.Controls.Add(this.bttnBai1);
            this.Name = "Lab4";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttnBai1;
        private System.Windows.Forms.Button bttnBai2;
        private System.Windows.Forms.Button bttnBai4;
        private System.Windows.Forms.Button bttnBai3;
    }
}

