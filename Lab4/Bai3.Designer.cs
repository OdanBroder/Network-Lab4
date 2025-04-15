namespace Lab4
{
    partial class Bai3
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
            this.bttnClick = new System.Windows.Forms.Button();
            this.listViewPost = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // bttnClick
            // 
            this.bttnClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnClick.Location = new System.Drawing.Point(713, 12);
            this.bttnClick.Name = "bttnClick";
            this.bttnClick.Size = new System.Drawing.Size(75, 32);
            this.bttnClick.TabIndex = 0;
            this.bttnClick.Text = "Get Post";
            this.bttnClick.UseVisualStyleBackColor = true;
            this.bttnClick.Click += new System.EventHandler(this.bttnClick_Click);
            // 
            // listViewPost
            // 
            this.listViewPost.HideSelection = false;
            this.listViewPost.Location = new System.Drawing.Point(12, 50);
            this.listViewPost.Name = "listViewPost";
            this.listViewPost.Size = new System.Drawing.Size(776, 388);
            this.listViewPost.TabIndex = 1;
            this.listViewPost.UseCompatibleStateImageBehavior = false;
            // 
            // Bai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewPost);
            this.Controls.Add(this.bttnClick);
            this.Name = "Bai3";
            this.Text = "Bai3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttnClick;
        private System.Windows.Forms.ListView listViewPost;
    }
}