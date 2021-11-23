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
    public partial class Admin33 : Form
    {
        public Admin33()
        {
            InitializeComponent();
            Table();
        }

        // 从数据库读取数据显示在表格控件中
        public void Table()
        {
            // 把控件中的旧数据清空
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql =
                $"SELECT * " +
                $"FROM " +
                $"t_lend";
            IDataReader dc = dao.Read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(
                    dc[0].ToString(),
                    dc[1].ToString(),
                    dc[2].ToString(),
                    dc[3].ToString(),
                    dc[4].ToString(),
                    dc[5].ToString(),
                    dc[6].ToString()
                    );
            }
            dc.Close();
            dao.DaoClose();
        }

        // 通过用户编号
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql =
                $"SELECT * " +
                $"FROM " +
                $"v_lend " +
                $"WHERE " +
                $"[uid] = '{textBox1.Text}'";
            IDataReader dc = dao.Read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(
                    dc[0].ToString(),
                    dc[1].ToString(),
                    dc[2].ToString(),
                    dc[3].ToString(),
                    dc[4].ToString(),
                    dc[5].ToString(),
                    dc[6].ToString()
                    );
            }
            dc.Close();
            dao.DaoClose();
        }

        // 通过图书编号
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql =
                $"SELECT * " +
                $"FROM " +
                $"v_lend " +
                $"WHERE " +
                $"[bid] = '{textBox2.Text}'";
            IDataReader dc = dao.Read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(
                    dc[0].ToString(),
                    dc[1].ToString(),
                    dc[2].ToString(),
                    dc[3].ToString(),
                    dc[4].ToString(),
                    dc[5].ToString(),
                    dc[6].ToString()
                    );
            }
            dc.Close();
            dao.DaoClose();
        }
    }
}
