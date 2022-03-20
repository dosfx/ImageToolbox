
namespace ImageToolbox
{
    partial class LayerPanel
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
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.displayPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.hiddenLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.weightedLabel = new System.Windows.Forms.Label();
            this.transparentLabel = new System.Windows.Forms.Label();
            this.averageLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.extraBorder = new System.Windows.Forms.Label();
            this.opacityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.displayPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.imageBox.Location = new System.Drawing.Point(0, 0);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(100, 100);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(101, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.nameLabel.Size = new System.Drawing.Size(104, 30);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Layer Name";
            // 
            // displayPanel
            // 
            this.displayPanel.Controls.Add(this.hiddenLabel);
            this.displayPanel.Controls.Add(this.opacityLabel);
            this.displayPanel.Controls.Add(this.totalLabel);
            this.displayPanel.Controls.Add(this.weightedLabel);
            this.displayPanel.Controls.Add(this.transparentLabel);
            this.displayPanel.Controls.Add(this.averageLabel);
            this.displayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayPanel.Location = new System.Drawing.Point(101, 30);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Padding = new System.Windows.Forms.Padding(10);
            this.displayPanel.Size = new System.Drawing.Size(619, 70);
            this.displayPanel.TabIndex = 2;
            // 
            // hiddenLabel
            // 
            this.hiddenLabel.AutoSize = true;
            this.hiddenLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.hiddenLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hiddenLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hiddenLabel.Location = new System.Drawing.Point(13, 10);
            this.hiddenLabel.Name = "hiddenLabel";
            this.hiddenLabel.Padding = new System.Windows.Forms.Padding(4);
            this.hiddenLabel.Size = new System.Drawing.Size(51, 23);
            this.hiddenLabel.TabIndex = 0;
            this.hiddenLabel.Text = "Hidden";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.totalLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.totalLabel.Location = new System.Drawing.Point(86, 10);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Padding = new System.Windows.Forms.Padding(4);
            this.totalLabel.Size = new System.Drawing.Size(10, 23);
            this.totalLabel.TabIndex = 1;
            // 
            // weightedLabel
            // 
            this.weightedLabel.AutoSize = true;
            this.weightedLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.weightedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weightedLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.weightedLabel.Location = new System.Drawing.Point(102, 10);
            this.weightedLabel.Name = "weightedLabel";
            this.weightedLabel.Padding = new System.Windows.Forms.Padding(4);
            this.weightedLabel.Size = new System.Drawing.Size(10, 23);
            this.weightedLabel.TabIndex = 3;
            // 
            // transparentLabel
            // 
            this.transparentLabel.AutoSize = true;
            this.transparentLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.transparentLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transparentLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.transparentLabel.Location = new System.Drawing.Point(118, 10);
            this.transparentLabel.Name = "transparentLabel";
            this.transparentLabel.Padding = new System.Windows.Forms.Padding(4);
            this.transparentLabel.Size = new System.Drawing.Size(10, 23);
            this.transparentLabel.TabIndex = 2;
            // 
            // averageLabel
            // 
            this.averageLabel.AutoSize = true;
            this.averageLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.averageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.averageLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.averageLabel.Location = new System.Drawing.Point(134, 10);
            this.averageLabel.Name = "averageLabel";
            this.averageLabel.Padding = new System.Windows.Forms.Padding(4);
            this.averageLabel.Size = new System.Drawing.Size(10, 23);
            this.averageLabel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.displayPanel);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Controls.Add(this.extraBorder);
            this.panel1.Controls.Add(this.imageBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 102);
            this.panel1.TabIndex = 3;
            // 
            // extraBorder
            // 
            this.extraBorder.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.extraBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.extraBorder.Location = new System.Drawing.Point(100, 0);
            this.extraBorder.Name = "extraBorder";
            this.extraBorder.Size = new System.Drawing.Size(1, 100);
            this.extraBorder.TabIndex = 3;
            this.extraBorder.Text = "label1";
            // 
            // opacityLabel
            // 
            this.opacityLabel.AutoSize = true;
            this.opacityLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.opacityLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.opacityLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.opacityLabel.Location = new System.Drawing.Point(70, 10);
            this.opacityLabel.Name = "opacityLabel";
            this.opacityLabel.Padding = new System.Windows.Forms.Padding(4);
            this.opacityLabel.Size = new System.Drawing.Size(10, 23);
            this.opacityLabel.TabIndex = 5;
            // 
            // LayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "LayerPanel";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.Size = new System.Drawing.Size(732, 112);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.displayPanel.ResumeLayout(false);
            this.displayPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.FlowLayoutPanel displayPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label extraBorder;
        private System.Windows.Forms.Label hiddenLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label transparentLabel;
        private System.Windows.Forms.Label weightedLabel;
        private System.Windows.Forms.Label averageLabel;
        private System.Windows.Forms.Label opacityLabel;
    }
}
