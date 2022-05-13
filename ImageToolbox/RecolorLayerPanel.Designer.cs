namespace ImageToolbox
{
    partial class RecolorLayerPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.upLabel = new ImageToolbox.ActiveLabel();
            this.removeLabel = new ImageToolbox.ActiveLabel();
            this.downLabel = new ImageToolbox.ActiveLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(41, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(64, 64);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoEllipsis = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(111, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(146, 32);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // upLabel
            // 
            this.upLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upLabel.Location = new System.Drawing.Point(3, 3);
            this.upLabel.Name = "upLabel";
            this.upLabel.Size = new System.Drawing.Size(32, 32);
            this.upLabel.TabIndex = 0;
            this.upLabel.Text = "▲";
            this.upLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upLabel.Click += new System.EventHandler(this.UpLabel_Click);
            // 
            // removeLabel
            // 
            this.removeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.removeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeLabel.Location = new System.Drawing.Point(111, 35);
            this.removeLabel.Name = "removeLabel";
            this.removeLabel.Size = new System.Drawing.Size(32, 32);
            this.removeLabel.TabIndex = 1;
            this.removeLabel.Text = "✖";
            this.removeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.removeLabel.Click += new System.EventHandler(this.RemoveLabel_Click);
            // 
            // downLabel
            // 
            this.downLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.downLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downLabel.Location = new System.Drawing.Point(3, 35);
            this.downLabel.Name = "downLabel";
            this.downLabel.Size = new System.Drawing.Size(32, 32);
            this.downLabel.TabIndex = 2;
            this.downLabel.Text = "▼";
            this.downLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.downLabel.Click += new System.EventHandler(this.DownLabel_Click);
            // 
            // RecolorLayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.upLabel);
            this.Controls.Add(this.removeLabel);
            this.Controls.Add(this.downLabel);
            this.Name = "RecolorLayerPanel";
            this.Size = new System.Drawing.Size(260, 70);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ActiveLabel upLabel;
        private ActiveLabel removeLabel;
        private ActiveLabel downLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label nameLabel;
    }
}
