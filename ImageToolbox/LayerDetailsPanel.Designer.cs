
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
            this.detailLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.detailsWorker = new System.ComponentModel.BackgroundWorker();
            this.opacityLabel = new System.Windows.Forms.Label();
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
            // detailLabel
            // 
            this.detailLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.detailLabel.Location = new System.Drawing.Point(10, 250);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(200, 23);
            this.detailLabel.TabIndex = 3;
            this.detailLabel.Text = "Hidden";
            this.detailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(10, 383);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 23);
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // detailsWorker
            // 
            this.detailsWorker.WorkerReportsProgress = true;
            this.detailsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DetailsWorker_DoWork);
            this.detailsWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DetailsWorker_ProgressChanged);
            this.detailsWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DetailsWorker_RunWorkerCompleted);
            // 
            // opacityLabel
            // 
            this.opacityLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.opacityLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.opacityLabel.Location = new System.Drawing.Point(10, 273);
            this.opacityLabel.Name = "opacityLabel";
            this.opacityLabel.Size = new System.Drawing.Size(200, 23);
            this.opacityLabel.TabIndex = 5;
            this.opacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LayerDetailsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.opacityLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.detailLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.pictureBox);
            this.Name = "LayerDetailsPanel";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(220, 416);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker detailsWorker;
        private System.Windows.Forms.Label opacityLabel;
    }
}
