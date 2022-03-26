
namespace ImageToolbox
{
    partial class LayerFolderPanel
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
            this.folderRowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.folderBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.hiddenLabel = new System.Windows.Forms.Label();
            this.layersPanel = new System.Windows.Forms.Panel();
            this.folderRowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folderBox)).BeginInit();
            this.SuspendLayout();
            // 
            // folderRowPanel
            // 
            this.folderRowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.folderRowPanel.Controls.Add(this.folderBox);
            this.folderRowPanel.Controls.Add(this.nameLabel);
            this.folderRowPanel.Controls.Add(this.hiddenLabel);
            this.folderRowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.folderRowPanel.Location = new System.Drawing.Point(0, 10);
            this.folderRowPanel.Name = "folderRowPanel";
            this.folderRowPanel.Padding = new System.Windows.Forms.Padding(10);
            this.folderRowPanel.Size = new System.Drawing.Size(500, 44);
            this.folderRowPanel.TabIndex = 0;
            this.folderRowPanel.WrapContents = false;
            // 
            // folderBox
            // 
            this.folderBox.Location = new System.Drawing.Point(10, 10);
            this.folderBox.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.folderBox.Name = "folderBox";
            this.folderBox.Size = new System.Drawing.Size(20, 20);
            this.folderBox.TabIndex = 0;
            this.folderBox.TabStop = false;
            this.folderBox.Click += new System.EventHandler(this.FolderBox_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(40, 10);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(100, 20);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Folder Name";
            // 
            // hiddenLabel
            // 
            this.hiddenLabel.AutoSize = true;
            this.hiddenLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.hiddenLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hiddenLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hiddenLabel.Location = new System.Drawing.Point(153, 10);
            this.hiddenLabel.Name = "hiddenLabel";
            this.hiddenLabel.Padding = new System.Windows.Forms.Padding(4);
            this.hiddenLabel.Size = new System.Drawing.Size(51, 23);
            this.hiddenLabel.TabIndex = 3;
            this.hiddenLabel.Text = "Hidden";
            // 
            // layersPanel
            // 
            this.layersPanel.AutoSize = true;
            this.layersPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layersPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.layersPanel.Location = new System.Drawing.Point(0, 54);
            this.layersPanel.Name = "layersPanel";
            this.layersPanel.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.layersPanel.Size = new System.Drawing.Size(500, 0);
            this.layersPanel.TabIndex = 1;
            // 
            // LayerFolderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.layersPanel);
            this.Controls.Add(this.folderRowPanel);
            this.MinimumSize = new System.Drawing.Size(500, 40);
            this.Name = "LayerFolderPanel";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Size = new System.Drawing.Size(500, 54);
            this.folderRowPanel.ResumeLayout(false);
            this.folderRowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folderBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel folderRowPanel;
        private System.Windows.Forms.PictureBox folderBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label hiddenLabel;
        private System.Windows.Forms.Panel layersPanel;
    }
}
