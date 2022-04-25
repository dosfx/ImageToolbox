
namespace ImageToolbox
{
    partial class LayerDetailsPanel
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
            this.hiddenLabel = new System.Windows.Forms.Label();
            this.processLayerWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox.Location = new System.Drawing.Point(10, 10);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(200, 200);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoEllipsis = true;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(10, 210);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.nameLabel.Size = new System.Drawing.Size(200, 40);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Layer Name";
            // 
            // hiddenLabel
            // 
            this.hiddenLabel.AutoSize = true;
            this.hiddenLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.hiddenLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hiddenLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.hiddenLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hiddenLabel.Location = new System.Drawing.Point(10, 250);
            this.hiddenLabel.Margin = new System.Windows.Forms.Padding(3);
            this.hiddenLabel.Name = "hiddenLabel";
            this.hiddenLabel.Padding = new System.Windows.Forms.Padding(4);
            this.hiddenLabel.Size = new System.Drawing.Size(51, 23);
            this.hiddenLabel.TabIndex = 3;
            this.hiddenLabel.Text = "Hidden";
            // 
            // processLayerWorker
            // 
            this.processLayerWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ProcessLayerWorker_DoWork);
            // 
            // LayerDetailsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.hiddenLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.pictureBox);
            this.Name = "LayerDetailsPanel";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(220, 416);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label hiddenLabel;
        private System.ComponentModel.BackgroundWorker processLayerWorker;
    }
}
