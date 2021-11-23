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
    public partial class Admin1 : Form
    {
        public Admin1()
        {
            InitializeComponent();
        }

        private void 图书管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin2 admin2 = new Admin2();
            admin2.ShowDialog();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin3 admin3 = new Admin3();
            admin3.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("联系电话：10086");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
