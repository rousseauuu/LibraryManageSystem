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
            label1.Text = $"欢迎{Data.UName}登录";
        }

        private void 图书管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin2 admin = new Admin2();
            admin.ShowDialog();
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
