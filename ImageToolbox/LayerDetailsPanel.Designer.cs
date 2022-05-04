
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
            this.totalLabel = new System.Windows.Forms.Label();
            this.weightedLabel = new System.Windows.Forms.Label();
            this.transparentLabel = new System.Windows.Forms.Label();
            this.averageLabel = new System.Windows.Forms.Label();
            this.insideCheckBox = new System.Windows.Forms.CheckBox();
            this.insidePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.outsidePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.outsideCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.insidePanel.SuspendLayout();
            this.outsidePanel.SuspendLayout();
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
            this.progressBar.Location = new System.Drawing.Point(10, 499);
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
            this.opacityLabel.Text = "Opacity";
            this.opacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalLabel
            // 
            this.totalLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.totalLabel.Location = new System.Drawing.Point(10, 296);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(200, 23);
            this.totalLabel.TabIndex = 6;
            this.totalLabel.Text = "Total Pixels";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // weightedLabel
            // 
            this.weightedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weightedLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.weightedLabel.Location = new System.Drawing.Point(10, 319);
            this.weightedLabel.Name = "weightedLabel";
            this.weightedLabel.Size = new System.Drawing.Size(200, 23);
            this.weightedLabel.TabIndex = 7;
            this.weightedLabel.Text = "Weighted Pixels";
            this.weightedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // transparentLabel
            // 
            this.transparentLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transparentLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.transparentLabel.Location = new System.Drawing.Point(10, 342);
            this.transparentLabel.Name = "transparentLabel";
            this.transparentLabel.Size = new System.Drawing.Size(200, 23);
            this.transparentLabel.TabIndex = 8;
            this.transparentLabel.Text = "Transparent Pixels";
            this.transparentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // averageLabel
            // 
            this.averageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.averageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.averageLabel.Location = new System.Drawing.Point(10, 365);
            this.averageLabel.Name = "averageLabel";
            this.averageLabel.Size = new System.Drawing.Size(200, 23);
            this.averageLabel.TabIndex = 9;
            this.averageLabel.Text = "Average Transparency";
            this.averageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // insideCheckBox
            // 
            this.insideCheckBox.AutoSize = true;
            this.insideCheckBox.Location = new System.Drawing.Point(3, 3);
            this.insideCheckBox.Name = "insideCheckBox";
            this.insideCheckBox.Size = new System.Drawing.Size(111, 17);
            this.insideCheckBox.TabIndex = 10;
            this.insideCheckBox.Text = "Pixels Inside Base";
            this.insideCheckBox.UseVisualStyleBackColor = true;
            this.insideCheckBox.CheckedChanged += new System.EventHandler(this.InsideCheckBox_CheckedChanged);
            // 
            // insidePanel
            // 
            this.insidePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.insidePanel.Controls.Add(this.insideCheckBox);
            this.insidePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.insidePanel.Location = new System.Drawing.Point(10, 388);
            this.insidePanel.Name = "insidePanel";
            this.insidePanel.Size = new System.Drawing.Size(200, 23);
            this.insidePanel.TabIndex = 11;
            this.insidePanel.Visible = false;
            // 
            // outsidePanel
            // 
            this.outsidePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outsidePanel.Controls.Add(this.outsideCheckBox);
            this.outsidePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.outsidePanel.Location = new System.Drawing.Point(10, 411);
            this.outsidePanel.Name = "outsidePanel";
            this.outsidePanel.Size = new System.Drawing.Size(200, 23);
            this.outsidePanel.TabIndex = 12;
            this.outsidePanel.Visible = false;
            // 
            // outsideCheckBox
            // 
            this.outsideCheckBox.AutoSize = true;
            this.outsideCheckBox.Location = new System.Drawing.Point(3, 3);
            this.outsideCheckBox.Name = "outsideCheckBox";
            this.outsideCheckBox.Size = new System.Drawing.Size(119, 17);
            this.outsideCheckBox.TabIndex = 10;
            this.outsideCheckBox.Text = "Pixels Outside Base";
            this.outsideCheckBox.UseVisualStyleBackColor = true;
            this.outsideCheckBox.CheckedChanged += new System.EventHandler(this.OutsideCheckBox_CheckedChanged);
            // 
            // LayerDetailsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.outsidePanel);
            this.Controls.Add(this.insidePanel);
            this.Controls.Add(this.averageLabel);
            this.Controls.Add(this.transparentLabel);
            this.Controls.Add(this.weightedLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.opacityLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.detailLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.pictureBox);
            this.Name = "LayerDetailsPanel";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(220, 532);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.insidePanel.ResumeLayout(false);
            this.insidePanel.PerformLayout();
            this.outsidePanel.ResumeLayout(false);
            this.outsidePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker detailsWorker;
        private System.Windows.Forms.Label opacityLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label weightedLabel;
        private System.Windows.Forms.Label transparentLabel;
        private System.Windows.Forms.Label averageLabel;
        private System.Windows.Forms.CheckBox insideCheckBox;
        private System.Windows.Forms.FlowLayoutPanel insidePanel;
        private System.Windows.Forms.FlowLayoutPanel outsidePanel;
        private System.Windows.Forms.CheckBox outsideCheckBox;
    }
}
