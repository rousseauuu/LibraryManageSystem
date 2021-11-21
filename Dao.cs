using System.Data.SqlClient;

namespace BookManagementSystem
{
    internal class Dao
    {
        SqlConnection sc;
        // 连接数据库
        public SqlConnection Connect()
        {
            // 数据库连接字符串 DESKTOP-A0467QR  DESKTOP-N1AQVOP
            string str = @"Data Source=DESKTOP-A0467QR;Initial Catalog=BookDB;Integrated Security=True";
            // 创建数据库连接对象
            sc = new SqlConnection(str);
            sc.Open();
            return sc;
        }
        // 生成对数据库的操作对象
        public SqlCommand Command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connect());
            return cmd;
        }
        // 更新操作, 返回受影响的行数
        public int Execute(string sql)
        {
            return Command(sql).ExecuteNonQuery();
        }
        // 读取操作
        public SqlDataReader Read(string sql)
        {
            return Command(sql).ExecuteReader();
        }
        // 关闭数据库连接 
        public void DaoClose()
        {
            sc.Close();
        }
    }
}
