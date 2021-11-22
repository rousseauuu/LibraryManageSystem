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
    public partial class user2 : Form
    {
        public user2()
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
    }
}
