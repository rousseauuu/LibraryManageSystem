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
    public partial class Admin21 : Form
    {
        public Admin21()
        {
            InitializeComponent();
        }

        // 添加图书
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isTextBoxEmpty())
            {
                Dao dao = new Dao();
                string sql = $"INSERT INTO t_book " +
                             $"VALUES (" +
                             $"'{textBox1.Text}'," +
                             $"'{textBox2.Text}'," +
                             $"'{textBox3.Text}'," +
                             $"'{textBox4.Text}'," +
                             $"{textBox5.Text}" +
                             $")";
                int n = dao.Execute(sql);
                if (0 < n)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                MessageBox.Show("不能有空值！");
            }
            
            // 清空所有的 TextBox
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Text = "";
                }
            }
        }
        
        // 判断是否有空的 TextBox
        private bool isTextBoxEmpty()
        {
            bool isTextBoxEmpty = false;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrEmpty((control as TextBox).Text))
                    {
                        isTextBoxEmpty = true;
                    }
                }
            }
            return isTextBoxEmpty;
        }

        // 清空
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Text = "";
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin21_Load(object sender, EventArgs e)
        {

        }
    }
}
