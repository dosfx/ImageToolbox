using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImageToolbox
{
    partial class LayerPanel : UserControl
    {
        public const string HiddenText = "Hidden";
        public const string VisibleText = "Visible";
        public static readonly Color SelectedColor = Color.FromArgb(38, 79, 120);

        private bool _selected;

        public LayerPanel()
        {
            InitializeComponent();

            List<Control> controls = new List<Control>(new Control[] { panel1 });
            Control[] noClick = new Control[]
            {
                baseLayerRadioButton,
                rightArrowLabel,
            };
            while (controls.Count > 0)
            {
                Control control = controls.Last();
                controls.RemoveAt(controls.Count - 1);
                controls.AddRange(control.Controls.Cast<Control>());
                if (!noClick.Contains(control))
                {
                    control.Click += Control_Click;
                }
            }

            IsHidden = false;
        }

        public event EventHandler BaseLayerCheckedChanged;
        public event EventHandler RightArrowClick;
        public event EventHandler SelectedChanged;

        public bool BaseLayerChecked
        {
            get => baseLayerRadioButton.Checked;
            set => baseLayerRadioButton.Checked = value;
        }

        public bool RightArrowVisible
        {
            get => rightArrowLabel.Visible;
            set => rightArrowLabel.Visible = value;
        }

        public bool Selected 
        {
            get => _selected;
            set
            {
                if (value != _selected)
                {
                    _selected = value;
                    panel1.BackColor = value ? SelectedColor : Color.Transparent;
                    SelectedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public double LayerOpacity
        {
            set => opacityLabel.Text = $"{value:.00}% opacity";
        }

        public Image Image
        {
            get => imageBox.Image;
            set => imageBox.Image = value;
        }

        public bool IsHidden
        {
            get => hiddenLabel.Text == HiddenText;
            set => hiddenLabel.Text = value ? HiddenText : VisibleText;
        }

        public string LayerName
        {
            get => nameLabel.Text;
            set => nameLabel.Text = value;
        }

        private void Control_Click(object sender, EventArgs e)
        {
            Selected = !Selected;
        }

        private void BaseLayerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BaseLayerCheckedChanged?.Invoke(this, EventArgs.Empty);
        }

        private void RightArrowLabel_Click(object sender, EventArgs e)
        {
            RightArrowClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
