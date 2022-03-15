
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.folderRowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.collapseButton = new System.Windows.Forms.Button();
            this.folderBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.folderRowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folderBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.folderRowPanel, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(756, 46);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // folderRowPanel
            // 
            this.tableLayoutPanel.SetColumnSpan(this.folderRowPanel, 2);
            this.folderRowPanel.Controls.Add(this.collapseButton);
            this.folderRowPanel.Controls.Add(this.folderBox);
            this.folderRowPanel.Controls.Add(this.nameLabel);
            this.folderRowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderRowPanel.Location = new System.Drawing.Point(3, 3);
            this.folderRowPanel.Name = "folderRowPanel";
            this.folderRowPanel.Padding = new System.Windows.Forms.Padding(10);
            this.folderRowPanel.Size = new System.Drawing.Size(750, 40);
            this.folderRowPanel.TabIndex = 0;
            this.folderRowPanel.WrapContents = false;
            // 
            // collapseButton
            // 
            this.collapseButton.Location = new System.Drawing.Point(10, 10);
            this.collapseButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.collapseButton.Name = "collapseButton";
            this.collapseButton.Size = new System.Drawing.Size(20, 20);
            this.collapseButton.TabIndex = 2;
            this.collapseButton.Text = "-";
            this.collapseButton.UseVisualStyleBackColor = true;
            this.collapseButton.Click += new System.EventHandler(this.CollapseButton_Click);
            // 
            // folderBox
            // 
            this.folderBox.Location = new System.Drawing.Point(40, 10);
            this.folderBox.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.folderBox.Name = "folderBox";
            this.folderBox.Size = new System.Drawing.Size(20, 20);
            this.folderBox.TabIndex = 0;
            this.folderBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(70, 10);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(100, 20);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Folder Name";
            // 
            // LayerFolderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(0, 40);
            this.Name = "LayerFolderPanel";
            this.Size = new System.Drawing.Size(756, 46);
            this.tableLayoutPanel.ResumeLayout(false);
            this.folderRowPanel.ResumeLayout(false);
            this.folderRowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folderBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel folderRowPanel;
        private System.Windows.Forms.PictureBox folderBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button collapseButton;
    }
}
