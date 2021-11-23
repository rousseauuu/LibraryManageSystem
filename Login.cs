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
    public partial class Login : Form
    {
        public Login()
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
                signIn();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }

        // 验证是否允许登录，允许返回 True
        public void signIn()
        {
            // 用户
            if (radioButtonUser.Checked)
            {
                Dao dao = new Dao();
                string sql = 
                    $"SELECT * " +
                    $"FROM t_user " +
                    $"WHERE id = '{textBox1.Text}' " +
                    $"AND pwd = '{textBox2.Text}'";
                IDataReader dc = dao.Read(sql);    
                
                if (dc.Read())
                {
                    Data.UID   = dc["id"].ToString();
                    Data.UName = dc["name"].ToString();
                    Data.UDept = dc["dept"].ToString();

                    MessageBox.Show("登录成功");

                    User1 user = new User1();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
                dao.DaoClose();
            }
            
            // 管理员
            if (radioButtonAdmin.Checked)
            {
                Dao dao = new Dao();
                string sql = 
                    $"SELECT * FROM t_admin " +
                    $"WHERE id = '{textBox1.Text}' " +
                    $"AND pwd = '{textBox2.Text}'";
                IDataReader dc = dao.Read(sql);
                
                if (dc.Read())
                {
                    MessageBox.Show("登录成功");

                    Admin1 admin = new Admin1();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
                dao.DaoClose();
            }
        }

        //  取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
