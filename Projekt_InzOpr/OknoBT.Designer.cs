namespace Projekt_InzOpr
{
    partial class OknoBT
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonWlacz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(399, 297);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // buttonWlacz
            // 
            this.buttonWlacz.Location = new System.Drawing.Point(12, 316);
            this.buttonWlacz.Name = "buttonWlacz";
            this.buttonWlacz.Size = new System.Drawing.Size(75, 23);
            this.buttonWlacz.TabIndex = 2;
            this.buttonWlacz.Text = "Wlacz";
            this.buttonWlacz.UseVisualStyleBackColor = true;
            this.buttonWlacz.Click += new System.EventHandler(this.buttonWlacz_Click);
            // 
            // OknoBT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 351);
            this.Controls.Add(this.buttonWlacz);
            this.Controls.Add(this.richTextBox1);
            this.Name = "OknoBT";
            this.Text = "OknoBT";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonWlacz;
    }
}