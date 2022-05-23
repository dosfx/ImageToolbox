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
            this.cancelLabel = new ImageToolbox.ActiveLabel();
            this.okLabel = new ImageToolbox.ActiveLabel();
            this.alphaLabel = new System.Windows.Forms.Label();
            this.redLabel = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.blueLabel = new System.Windows.Forms.Label();
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
            // cancelLabel
            // 
            this.cancelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cancelLabel.Location = new System.Drawing.Point(680, 70);
            this.cancelLabel.Name = "cancelLabel";
            this.cancelLabel.Size = new System.Drawing.Size(100, 30);
            this.cancelLabel.TabIndex = 18;
            this.cancelLabel.Text = "Cancel";
            this.cancelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cancelLabel.Click += new System.EventHandler(this.CancelLabel_Click);
            // 
            // okLabel
            // 
            this.okLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.okLabel.Location = new System.Drawing.Point(680, 20);
            this.okLabel.Name = "okLabel";
            this.okLabel.Size = new System.Drawing.Size(100, 30);
            this.okLabel.TabIndex = 17;
            this.okLabel.Text = "OK";
            this.okLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.okLabel.Click += new System.EventHandler(this.OkLabel_Click);
            // 
            // alphaLabel
            // 
            this.alphaLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.alphaLabel.Location = new System.Drawing.Point(460, 140);
            this.alphaLabel.Name = "alphaLabel";
            this.alphaLabel.Size = new System.Drawing.Size(280, 20);
            this.alphaLabel.TabIndex = 19;
            // 
            // redLabel
            // 
            this.redLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redLabel.Location = new System.Drawing.Point(460, 180);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(280, 20);
            this.redLabel.TabIndex = 20;
            // 
            // greenLabel
            // 
            this.greenLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.greenLabel.Location = new System.Drawing.Point(460, 220);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(280, 20);
            this.greenLabel.TabIndex = 21;
            // 
            // blueLabel
            // 
            this.blueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blueLabel.Location = new System.Drawing.Point(460, 260);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(280, 20);
            this.blueLabel.TabIndex = 22;
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(800, 440);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.greenLabel);
            this.Controls.Add(this.redLabel);
            this.Controls.Add(this.alphaLabel);
            this.Controls.Add(this.cancelLabel);
            this.Controls.Add(this.okLabel);
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
        private ActiveLabel okLabel;
        private ActiveLabel cancelLabel;
        private System.Windows.Forms.Label alphaLabel;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.Label blueLabel;
    }
}