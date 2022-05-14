namespace ImageToolbox
{
    partial class RecolorPanel
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
            this.layersPanel = new System.Windows.Forms.Panel();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.addRecolorLabel = new ImageToolbox.ActiveLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.colorsPanel = new System.Windows.Forms.Panel();
            this.previewPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layersPanel
            // 
            this.layersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layersPanel.Location = new System.Drawing.Point(0, 200);
            this.layersPanel.Margin = new System.Windows.Forms.Padding(0);
            this.layersPanel.Name = "layersPanel";
            this.layersPanel.Size = new System.Drawing.Size(260, 294);
            this.layersPanel.TabIndex = 1;
            // 
            // previewPanel
            // 
            this.previewPanel.Controls.Add(this.addRecolorLabel);
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanel.Location = new System.Drawing.Point(260, 0);
            this.previewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(401, 200);
            this.previewPanel.TabIndex = 0;
            // 
            // addRecolorLabel
            // 
            this.addRecolorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addRecolorLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.addRecolorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRecolorLabel.Location = new System.Drawing.Point(0, 0);
            this.addRecolorLabel.Name = "addRecolorLabel";
            this.addRecolorLabel.Size = new System.Drawing.Size(60, 200);
            this.addRecolorLabel.TabIndex = 0;
            this.addRecolorLabel.Text = "+";
            this.addRecolorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addRecolorLabel.Click += new System.EventHandler(this.AddRecolorLabel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.layersPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.previewPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorsPanel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 494);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // colorsPanel
            // 
            this.colorsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorsPanel.Location = new System.Drawing.Point(260, 200);
            this.colorsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.colorsPanel.Name = "colorsPanel";
            this.colorsPanel.Size = new System.Drawing.Size(401, 294);
            this.colorsPanel.TabIndex = 2;
            this.colorsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorsPanel_Paint);
            // 
            // RecolorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RecolorPanel";
            this.Size = new System.Drawing.Size(661, 494);
            this.previewPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel layersPanel;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel colorsPanel;
        private ActiveLabel addRecolorLabel;
    }
}
