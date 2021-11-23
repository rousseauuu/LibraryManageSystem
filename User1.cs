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
    public partial class User1 : Form
    {
        public User1()
        {
            InitializeComponent();
        }

        private void User1_Load(object sender, EventArgs e)
        {

        }

        private void 图书查看和借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User2 user2 = new User2();
            user2.ShowDialog();
        }

        private void 当前已借和归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User3 user3 = new User3();
            user3.ShowDialog();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("联系电话：10086");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 联系管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("联系电话：10086");
        }
    }
}
