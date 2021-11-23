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
    public partial class User3 : Form
    {
        public User3()
        {
            InitializeComponent();
        }

        private void User3_Load(object sender, EventArgs e)
        {
            Table();
        }

        // 从数据库读取数据显示在表格控件中
        public void Table()
        {
            // 把控件中的旧数据清空
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = 
                $"SELECT " +
                $"[no], [bid], [datetime] " +
                $"FROM " +
                $"t_lend " +
                $"WHERE " +
                $"[uid] = '{Data.UID}'";
            IDataReader dc = dao.Read(sql);
            
            while (dc.Read())
            {
                dataGridView1.Rows.Add(
                    dc[0].ToString(),
                    dc[1].ToString(),
                    dc[2].ToString()
                    );
            }
            dc.Close();
            dao.DaoClose();
        }

        // 归还
        private void button1_Click(object sender, EventArgs e)
        {
            string no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string sql =
                $"DELETE FROM t_lend " +
                $"WHERE [no] = {no}; " +
                $"UPDATE t_book " +
                $"SET " +
                $"number = number + 1 " +
                $"WHERE " +
                $"id = '{id}'";
            Dao dao = new Dao();

            if (1 < dao.Execute(sql))
            {
                MessageBox.Show("归还成功");
                Table();
            }
        }

        
    }
}
