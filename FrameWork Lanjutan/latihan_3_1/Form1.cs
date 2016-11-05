using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace latihan_3_1
{
    public partial class Form1 : Form
    {
        public int check;
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i <= 100; i++)
            {
                fontsize.Items.Add(i);
            }
            foreach (KnownColor warna in Enum.GetValues(typeof(KnownColor)))
            {
                fontcolor.Items.Add(warna);
            }
            check = 0;
            fontfamily.SelectedIndex = 15;
            fontsize.SelectedIndex = 12;
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            Font bold;
            if (text.SelectionFont == null)
            {
                return;
            }
            if (text.SelectionFont.Style.ToString().Contains("Bold"))
            {
                bold = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style & ~FontStyle.Bold);
                btnBold.Checked = false;
            }
            else
            {
                bold = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style | FontStyle.Bold);
                btnBold.Checked = true;
            }
            text.SelectionFont = bold;
        }

        private void btnItal_Click(object sender, EventArgs e)
        {
            Font italic;
            if (text.SelectionFont == null)
            {
                return;
            }
            if (text.SelectionFont.Style.ToString().Contains("Italic"))
            {
                italic = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style & ~FontStyle.Italic);
                btnItal.Checked = false;
            }
            else
            {
                italic = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style | FontStyle.Italic);
                btnItal.Checked = true;
            }
            text.SelectionFont = italic;
        }

        private void btnUnder_Click(object sender, EventArgs e)
        {
            Font underline;
            if (text.SelectionFont == null)
            {
                return;
            }
            if (text.SelectionFont.Style.ToString().Contains("Underline"))
            {
                underline = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style & ~FontStyle.Underline);
                btnUnder.Checked = false;
            }
            else
            {
                underline = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style | FontStyle.Underline);
                btnUnder.Checked = true;
            }
            text.SelectionFont = underline;
        }


        private void fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (text.SelectionFont == null)
            {
                return;
            }
            text.SelectionFont = new System.Drawing.Font(text.SelectionFont.FontFamily, Convert.ToInt32(fontsize.Text), text.SelectionFont.Style);
        }

        private void fontcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (text.SelectionFont == null)
            {
                return;
            }
            text.SelectionColor = Color.FromName(fontcolor.Text);
        }

    }
}
