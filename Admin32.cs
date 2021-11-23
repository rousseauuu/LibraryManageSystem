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
    public partial class Admin32 : Form
    {
        public Admin32()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isTextBoxEmpty())
            {
                MessageBox.Show("输入不能有空");
                return;
            }

            string sql =
                $"UPDATE t_user " +
                $"SET " +
                $"id = '{textBox1.Text}', " +
                $"[name] = '{textBox2.Text}', " +
                $"[sex] = '{textBox3.Text}', " +
                $"pwd = '{textBox4.Text}', " +
                $"dept = '{textBox5.Text}' " +
                $"WHERE " +
                $"id = '{textBox6.Text}'";
            Dao dao = new Dao();

            if (0 < dao.Execute(sql))
            {
                MessageBox.Show("修改成功");
                clearAllTextBox();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            Dao dao = new Dao();
            string sql = $"SELECT * FROM t_user WHERE id = '{textBox6.Text}'";
            IDataReader dr = dao.Read(sql);

            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
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

        // 清空所有的 TextBox
        private void clearAllTextBox()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Text = "";
                }
            }
        }
    }
}
