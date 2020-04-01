using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Intelligent_robot_patrol
{
    public partial class FormLogin : Form
    {

        [DllImport("kernel32.dll")]
        //配置文件读取写入
        private static extern long WritePrivateProfileString(string section, string key, string value, string filepath);

        [DllImport("kernel32.dll")]

        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder returnvalue, int buffersize, string filepath);

        //读取配置文件
        private string GetValue(string section, string key)
        {

            StringBuilder stringBuilder = new StringBuilder();

            GetPrivateProfileString(section, key, "", stringBuilder, 1024, Config.configFilePath);

            string value = stringBuilder.ToString();
            return value;

        }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            //读取Mysql配置
            Config.configFilePath = Application.StartupPath + "\\Config.ini";
            DataBase.server = GetValue("Mysql", "server");
            DataBase.id = GetValue("Mysql", "id");
            DataBase.password = GetValue("Mysql", "password");
            DataBase.database = GetValue("Mysql", "database");
            DataBase.connection.Open();//连接数据库
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlTransaction loginTran = DataBase.connection.BeginTransaction();
            MySqlCommand inspectorCmd = DataBase.connection.CreateCommand();
            inspectorCmd.Transaction = loginTran;
            try
            {
                if (tBoxAccount.Text != "" && tBoxpassword.Text != "")
                {
                    string password = "";
                    string inspectorSql = string.Format("select id,name,password,account from inspectors where account = '{0}'", tBoxAccount.Text);
                    inspectorCmd.CommandText = inspectorSql;
                    MySqlDataReader inspectorReader = inspectorCmd.ExecuteReader();
                    if (inspectorReader.Read())
                    {
                        Inspector.id = inspectorReader["id"].ToString();
                        Inspector.name = inspectorReader["name"].ToString();
                        Inspector.account = inspectorReader["account"].ToString();
                        password = inspectorReader["password"].ToString();
                        inspectorReader.Close();
                        inspectorCmd.Connection.Close();
                    }
                    if(password == tBoxpassword.Text)
                    {
                        FormMain formMain = new FormMain();
                        formMain.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("信息错误！");
                    }

                }
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                loginTran.Rollback();//事务回滚
                DataBase.connection.Close();
            }
            finally
            {
                if(DataBase.connection.State == ConnectionState.Open)
                {
                    loginTran.Commit();//事务提交
                    DataBase.connection.Close();
                    this.Dispose();
                }
            }
            
        }
    }
}
