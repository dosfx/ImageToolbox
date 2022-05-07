
namespace ImageToolbox
{
    partial class ImageToolbox
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
            this.openPsdDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openPsdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.openFileProgressBar = new System.Windows.Forms.ProgressBar();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.layersPanel = new System.Windows.Forms.Panel();
            this.openFileWorker = new System.ComponentModel.BackgroundWorker();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.spacer = new System.Windows.Forms.Label();
            this.noDetailsLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // openPsdDialog
            // 
            this.openPsdDialog.Filter = "PSD Files|*.psd";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPsdMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // openPsdMenuItem
            // 
            this.openPsdMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.openPsdMenuItem.Name = "openPsdMenuItem";
            this.openPsdMenuItem.Size = new System.Drawing.Size(81, 20);
            this.openPsdMenuItem.Text = "Open PSD...";
            this.openPsdMenuItem.Click += new System.EventHandler(this.OpenPsdMenuItem_Click);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPictureBox.Location = new System.Drawing.Point(10, 10);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(200, 200);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainPictureBox.TabIndex = 3;
            this.mainPictureBox.TabStop = false;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.Location = new System.Drawing.Point(220, 20);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(58, 20);
            this.pathLabel.TabIndex = 4;
            this.pathLabel.Text = "No File";
            // 
            // imagePanel
            // 
            this.imagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePanel.Controls.Add(this.openFileProgressBar);
            this.imagePanel.Controls.Add(this.sizeLabel);
            this.imagePanel.Controls.Add(this.mainPictureBox);
            this.imagePanel.Controls.Add(this.pathLabel);
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.imagePanel.Location = new System.Drawing.Point(10, 10);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(518, 220);
            this.imagePanel.TabIndex = 5;
            // 
            // openFileProgressBar
            // 
            this.openFileProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileProgressBar.Location = new System.Drawing.Point(216, 187);
            this.openFileProgressBar.Name = "openFileProgressBar";
            this.openFileProgressBar.Size = new System.Drawing.Size(297, 23);
            this.openFileProgressBar.TabIndex = 6;
            this.openFileProgressBar.Visible = false;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(221, 40);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(0, 13);
            this.sizeLabel.TabIndex = 5;
            // 
            // layersPanel
            // 
            this.layersPanel.AutoScroll = true;
            this.layersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.layersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layersPanel.Location = new System.Drawing.Point(10, 240);
            this.layersPanel.Name = "layersPanel";
            this.layersPanel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.layersPanel.Size = new System.Drawing.Size(518, 287);
            this.layersPanel.TabIndex = 6;
            // 
            // openFileWorker
            // 
            this.openFileWorker.WorkerReportsProgress = true;
            this.openFileWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OpenFileWorker_DoWork);
            this.openFileWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OpenFileWorker_ProgressChanged);
            this.openFileWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OpenFileWorker_RunWorkerCompleted);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.layersPanel);
            this.splitContainer.Panel1.Controls.Add(this.spacer);
            this.splitContainer.Panel1.Controls.Add(this.imagePanel);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add(this.noDetailsLabel);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer.Panel2MinSize = 242;
            this.splitContainer.Size = new System.Drawing.Size(784, 537);
            this.splitContainer.SplitterDistance = 538;
            this.splitContainer.TabIndex = 7;
            // 
            // spacer
            // 
            this.spacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.spacer.Location = new System.Drawing.Point(10, 230);
            this.spacer.Name = "spacer";
            this.spacer.Size = new System.Drawing.Size(518, 10);
            this.spacer.TabIndex = 7;
            // 
            // noDetailsLabel
            // 
            this.noDetailsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noDetailsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.noDetailsLabel.Location = new System.Drawing.Point(10, 10);
            this.noDetailsLabel.Name = "noDetailsLabel";
            this.noDetailsLabel.Size = new System.Drawing.Size(222, 22);
            this.noDetailsLabel.TabIndex = 0;
            this.noDetailsLabel.Text = "Select a layer";
            this.noDetailsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImageToolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ImageToolbox";
            this.Text = "Image Toolbox";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.imagePanel.ResumeLayout(false);
            this.imagePanel.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openPsdDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openPsdMenuItem;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Panel layersPanel;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.ProgressBar openFileProgressBar;
        private System.ComponentModel.BackgroundWorker openFileWorker;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label spacer;
        private System.Windows.Forms.Label noDetailsLabel;
    }
}

