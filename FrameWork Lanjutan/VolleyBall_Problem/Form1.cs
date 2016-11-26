using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolleyBall_Problem
{
        public partial class Form1 : Form
    {

        public int Mod = 1000000007;

        public Form1()
        {
            InitializeComponent();
            TxtHasil.Text = "";
        }

        private long PowerMod(long a, long power, long n)
        {
            long mod = 1;

            while (power != 0)
            {
                if ((power & 1) == 1)
                    mod = mod * a % n;

                a = (a * a) % n;
                power >>= 1;
            }

            return mod;
        }

        private long Volleyball(int a, int b)
        {
            int max = 25;
            if (a > b) return Volleyball(b, a);
            if (b < max) return 0;
            if (b > max && b != a + 2) return 0;
            if (b == max && b - a < 2) return 0;

            long[,] value = new long[max, max];

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    if (i == 0 || j == 0)
                        value[i, j] = 1;
                    else
                        value[i, j] = (value[i - 1, j] + value[i, j - 1]) % Mod;
                }
            }

            if (b == max)
                return value[24, a];

            return value[24, 24] % Mod * PowerMod(2, (a - 24), Mod) % Mod;
        }

        private void Txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Txt1_KeyPress(sender, e);
        }


        private void btnHitung_Click_1(object sender, EventArgs e)
        {
            if (Txt1.Text == "")
            {
                MessageBox.Show("Anda harus memasukkan nilai akhir A", "Error");
                return;
            }
            if (Txt2.Text == "")
            {
                MessageBox.Show("Anda harus memasukkan nilai akhir B", "Error");
                return;
            }
            int a = Convert.ToInt32(Txt1.Text);
            int b = Convert.ToInt32(Txt2.Text);
            TxtHasil.Text = (Volleyball(a, b)).ToString();
        }
    }
}
