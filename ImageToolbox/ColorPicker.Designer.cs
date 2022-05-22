namespace ImageToolbox
{
    partial class ColorPicker
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
            this.pickerLabel = new System.Windows.Forms.Label();
            this.newColorLabel = new System.Windows.Forms.Label();
            this.oldColorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pickerLabel
            // 
            this.pickerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pickerLabel.Location = new System.Drawing.Point(20, 20);
            this.pickerLabel.Name = "pickerLabel";
            this.pickerLabel.Size = new System.Drawing.Size(400, 400);
            this.pickerLabel.TabIndex = 14;
            this.pickerLabel.Text = "Placeholder";
            // 
            // newColorLabel
            // 
            this.newColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newColorLabel.Location = new System.Drawing.Point(440, 20);
            this.newColorLabel.Name = "newColorLabel";
            this.newColorLabel.Size = new System.Drawing.Size(100, 50);
            this.newColorLabel.TabIndex = 15;
            // 
            // oldColorLabel
            // 
            this.oldColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oldColorLabel.Location = new System.Drawing.Point(440, 70);
            this.oldColorLabel.Name = "oldColorLabel";
            this.oldColorLabel.Size = new System.Drawing.Size(100, 50);
            this.oldColorLabel.TabIndex = 16;
            // 
            // 
            // 
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(800, 440);
            this.Controls.Add(this.oldColorLabel);
            this.Controls.Add(this.newColorLabel);
            this.Controls.Add(this.pickerLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorPicker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ColorPicker";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label pickerLabel;
        private System.Windows.Forms.Label newColorLabel;
        private System.Windows.Forms.Label oldColorLabel;
    }
}