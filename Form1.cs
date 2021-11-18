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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                login();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }

        // 验证是否允许登录，允许返回 True
        public bool login()
        {
            if (radioButtonUser.Checked)
            {
                Dao dao = new Dao();
                string sql = $"SELECT * FROM t_user WHERE id = '{textBox1.Text}' and pwd = '{textBox2.Text}'";
                IDataReader dc = dao.Read(sql);    
                dc.Read();
                MessageBox.Show(dc[0].ToString(), dc["name"].ToString());
            }
            if (radioButtonAdmin.Checked)
            { 

            }
            return true;
        }
    }
}
