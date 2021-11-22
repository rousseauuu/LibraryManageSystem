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
    public partial class Admin2 : Form
    {
        public Admin2()
        {
            InitializeComponent();
        }

        private void Admin2_Load(object sender, EventArgs e)
        {
            Table();
            
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            label2.Text = id + " " + name;
        }

        // 从数据库读取数据显示在表格控件中
        public void Table()
        {
            // 把控件中的旧数据清空
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = "SELECT * FROM t_book";
            IDataReader dc = dao.Read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(
                    dc[0].ToString(),
                    dc[1].ToString(),
                    dc[2].ToString(),
                    dc[3].ToString(),
                    dc[4].ToString()
                    );
            }
            dc.Close();
            dao.DaoClose();
        }

        // 添加图书
        private void button1_Click(object sender, EventArgs e)
        {
            Admin21 admin21 = new Admin21();
            admin21.ShowDialog();
        }

        // 修改图书
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id     = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name   = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string press  = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string number = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                Admin22 admin22 = new Admin22(id, name, author, press, number);
                admin22.ShowDialog();
                // 刷新页面
                Table();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        // 删除图书
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"DELETE FROM t_book WHERE id='{id}'";
                    Dao dao = new Dao();
                    
                    if (0 < dao.Execute(sql))
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败" + sql);
                    }
                    dao.DaoClose();
                }
            }
            catch
            {
                MessageBox.Show("请先选中！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 刷新
        private void button4_Click(object sender, EventArgs e)
        {
            Table();

            // 清空所有的 TextBox
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Text = "";
                }
            }
        }

        // 书号查询
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"SELECT * FROM t_book WHERE id = '{textBox1.Text}'";
            IDataReader dc = dao.Read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(
                    dc[0].ToString(),
                    dc[1].ToString(),
                    dc[2].ToString(),
                    dc[3].ToString(),
                    dc[4].ToString()
                    );
            }
            dc.Close();
            dao.DaoClose();
        }

        // 书名查询
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"SELECT * FROM t_book WHERE name LIKE '%{textBox2.Text}%'";
            IDataReader dc = dao.Read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(
                    dc[0].ToString(),
                    dc[1].ToString(),
                    dc[2].ToString(),
                    dc[3].ToString(),
                    dc[4].ToString()
                    );
            }
            dc.Close();
            dao.DaoClose();
        }

        // 选中图书
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            label2.Text = id + " " + name;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
