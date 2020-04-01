using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Intelligent_robot_patrol
{
    class DataBase
    {
        /***
         * Mysql类 用于本地测试，之后放于云端
         * server - 数据库地址
         * database - 数据库名
         * id - 账号
         * password - 密码
         * open() - 连接数据库
         * close() - 关闭数据库
         * connectionString - 数据库连接语句
         * */
        public static string server = "127.0.0.1";
        public static string database = "final_design";
        public static string id = "root";
        public static string password = "zfd980323.";

        private static string connectionString = string.Format(
                "server={0};database={1};user id={2};Password={3};Charset=utf8;Allow Zero Datetime=True",
                server, database, id, password);

        public static MySqlConnection connection = new MySqlConnection(connectionString);
    }
}
