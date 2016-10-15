using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_1_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = vScrollBar2.Value.ToString();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = vScrollBar1.Value.ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime now,max,min;
            now = DateTime.Now;
            max = new DateTime(now.Year + vScrollBar2.Value,now.Month,now.Day);
            min = new DateTime(now.Year - vScrollBar1.Value,now.Month, now.Day);
            dateTimePicker1.MinDate = min;
            dateTimePicker1.MaxDate = max;
        }


    }
}
