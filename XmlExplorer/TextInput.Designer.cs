namespace XmlExplorer
{
    partial class TextInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextInput));
            this.doneButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(279, 57);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 3;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBox.Location = new System.Drawing.Point(12, 14);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(342, 22);
            this.textBox.TabIndex = 2;
            // 
            // TextInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 95);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TextInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TextInput";
            this.Load += new System.EventHandler(this.TextInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.TextBox textBox;
    }
}