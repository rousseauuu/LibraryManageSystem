using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagementSystem
{
    public partial class Admin3 : Form
    {
        public Admin3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin31 admin31 = new Admin31();
            admin31.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin32 admin32 = new Admin32();
            admin32.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin33 admin33 = new Admin33();
            admin33.ShowDialog();
        }
    }
}
