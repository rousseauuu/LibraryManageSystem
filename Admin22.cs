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
    public partial class Admin22 : Form
    {
        string ID = "";

        public Admin22()
        {
            InitializeComponent();
        }

        public Admin22(string id, string name, string author, string press, string number)
        {
            InitializeComponent();

            ID = textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = author;
            textBox4.Text = press;
            textBox5.Text = number;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql =
                $"UPDATE t_book " +
                $"SET " +
                $"id = '{textBox1.Text}', " +
                $"[name] = '{textBox2.Text}', " +
                $"author = '{textBox3.Text}', " +
                $"press = '{textBox4.Text}', " +
                $"number = {textBox5.Text} " +
                $"WHERE " +
                $"id = '{ID}'";
            Dao dao = new Dao();
            
            if (0 < dao.Execute(sql))
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        }
    }
}
