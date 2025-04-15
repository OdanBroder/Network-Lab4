namespace Lab4
{
    partial class Bai1
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
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.labelURL = new System.Windows.Forms.Label();
            this.bttnClick = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.richTextBoxHTML = new System.Windows.Forms.RichTextBox();
            this.listViewHeader = new System.Windows.Forms.ListView();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(67, 10);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(566, 22);
            this.textBoxURL.TabIndex = 0;
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelURL.Location = new System.Drawing.Point(12, 9);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(49, 20);
            this.labelURL.TabIndex = 1;
            this.labelURL.Text = "Host";
            // 
            // bttnClick
            // 
            this.bttnClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnClick.Location = new System.Drawing.Point(661, 6);
            this.bttnClick.Name = "bttnClick";
            this.bttnClick.Size = new System.Drawing.Size(127, 26);
            this.bttnClick.TabIndex = 2;
            this.bttnClick.Text = "Get";
            this.bttnClick.UseVisualStyleBackColor = true;
            this.bttnClick.Click += new System.EventHandler(this.bttnClick_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.listViewHeader);
            this.groupBox.Controls.Add(this.richTextBoxHTML);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.Location = new System.Drawing.Point(12, 38);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(776, 400);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Respone";
            // 
            // richTextBoxHTML
            // 
            this.richTextBoxHTML.Location = new System.Drawing.Point(6, 21);
            this.richTextBoxHTML.Name = "richTextBoxHTML";
            this.richTextBoxHTML.ReadOnly = true;
            this.richTextBoxHTML.Size = new System.Drawing.Size(399, 373);
            this.richTextBoxHTML.TabIndex = 0;
            this.richTextBoxHTML.Text = "";
            // 
            // listViewHeader
            // 
            this.listViewHeader.HideSelection = false;
            this.listViewHeader.Location = new System.Drawing.Point(425, 21);
            this.listViewHeader.Name = "listViewHeader";
            this.listViewHeader.Size = new System.Drawing.Size(345, 372);
            this.listViewHeader.TabIndex = 1;
            this.listViewHeader.UseCompatibleStateImageBehavior = false;
            // 
            // Bai1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.bttnClick);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.textBoxURL);
            this.Name = "Bai1";
            this.Text = "Bai1";
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.Button bttnClick;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ListView listViewHeader;
        private System.Windows.Forms.RichTextBox richTextBoxHTML;
    }
}