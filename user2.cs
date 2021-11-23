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
    public partial class User2 : Form
    {
        public User2()
        {
            InitializeComponent();
        }

        private void user2_Load(object sender, EventArgs e)
        {
            Table();
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

        // 借书
        private void button1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            
            if (overtime() > 0)
            {
                int n = overtime();
                MessageBox.Show($"您当前有{n}本书籍超时未还，请先归还并缴纳{n * 50}元罚金！");
                return;
            }

            if (isFull())
            {
                MessageBox.Show("您借书数目已达上限");
                return;
            }

            if (1 > number)
            {
                MessageBox.Show("库存不足，请联系管理员");
            }
            else
            {
                string sql =
                    $"INSERT INTO t_lend " +
                    $"([uid], bid, [datetime]) " +
                    $"VALUES (" +
                    $"'{Data.UID}', " +
                    $"'{id}', " +
                    $"getdate()" +
                    $"); " +
                    $"UPDATE t_book " +
                    $"SET " +
                    $"number = number - 1 " +
                    $"WHERE " +
                    $"id = " +
                    $"'{id}'";
                Dao dao = new Dao();
                
                // > 1 : 两条 SQL 语句都执行成功
                if (1 < dao.Execute(sql))
                {
                    MessageBox.Show($"用户：{Data.UName} 借出了图书{id}");
                    Table();
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

        // 刷新
        private void button2_Click(object sender, EventArgs e)
        {
            Table();
        }

        // 判断是否达到上限
        private bool isFull()
        {
            bool isFull = false;
            Dao d = new Dao();

            string query =
                $"SELECT COUNT(*) " +
                $"FROM t_lend " +
                $"WHERE uid = {Data.UID}";
            IDataReader dr = d.Read(query);

            if (dr.Read())
            {
                if (Data.UDept == "教职工")
                {
                    if ((int)dr[0] == 10)
                    {
                        isFull = true;
                    }
                }
                if (Data.UDept == "学生")
                {
                    if ((int)dr[0] == 15)
                    {
                        isFull = true;
                    }
                }
            }
            return isFull;
        }

        // 超期图书数
        private int overtime()
        {
            int result = 0;
            Dao dao = new Dao();

            string sql =
                $"SELECT COUNT(*) " +
                $"FROM t_lend " +
                $"WHERE " +
                $"uid = '{Data.UID}' " +
                $"AND " +
                $"DATEDIFF(mm, [datetime], getdate()) > 2";
            IDataReader dr = dao.Read(sql);

            if (dr.Read())
            {
                result = (int)dr[0];
            }

            return result;
        }
    }
}
