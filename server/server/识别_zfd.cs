﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;

using System.IO;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace 服务端
{
    public partial class formRec_zfd : Form
    {
        private static Socket socketServer; //服务套接词
        private static Socket socketWatch;//监听套接词
        private static Thread recThread;//接收线程
        //MySqlConnection mycon;//数据库连接
        private static string IniFilePath;
        private static string saveImgpath;
        public formRec_zfd()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
       
        [DllImport("kernel32.dll")]

        private static extern long WritePrivateProfileString(string section, string key, string value, string filepath);

        [DllImport("kernel32.dll")]

        private static extern int GetPrivateProfileString(string section,string key,string def,StringBuilder returnvalue,int buffersize,string filepath);

        private void newRecon_zfd_Load(object sender, EventArgs e)
        {
            openBtn.PerformClick();
            //打开数据库
            //mycon = new MySqlConnection(message.MysqlStr);
            //mycon.Open();
            IniFilePath = Application.StartupPath + "\\Config.ini";
            saveImgpath = @GetValue("Information", "SaveImgPath");
        }
        
        /// <summary>
        /// 打开socket通信
        /// </summary>
        private void openBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //服务端创建一个负责监听IP和端口号的Socket
                socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(message.serverIP);
                IPEndPoint point = new IPEndPoint(ip, 10001);
                socketWatch.Bind(point);//绑定端口号
                socketWatch.Listen(10);//监听队列的长度
                //创建监听线程
                Thread listenThread = new Thread(listen);
                listenThread.IsBackground = true;
                listenThread.Start(socketWatch);
                closeBtn.Enabled = true;
                openBtn.Enabled = false;
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
                
            }
           
        }

        //监听客户端连接
        private void listen(object o) {
            Socket socketWatch = o as Socket; //连接套接词
            
                while (true)
                {
                    try
                    {
                    socketServer = socketWatch.Accept();
                    //MessageBox.Show("客户端已连接");
                    #region
                    /*//客户端网络结点号
                    string remoteEndPoint = socketSend.RemoteEndPoint.ToString();
                    //添加客户端信息
                    ClientConnectionItems.Add(remoteEndPoint, socketSend);
                    ShowMsg("\r\n[客户端" + remoteEndPoint + "建立连接成功!客户端数量：" + ClientConnectionItems.Count + "]");*/
                    #endregion//节点号和客户端信息已注释
                    recThread = new Thread(recieve);
                    recThread.IsBackground = true;
                    recThread.Start(socketServer);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("listen 客户端连接失败!"+ex.Message  );
                    }
            }
            
        }

        //接收客户端信息
        private void recieve(object o){
            int imgPathLength = 0;//文件名长度
            string imgPath = null;//文件名
                while (true)
                {
                    try
            {
                    byte[] tokenBuf = new byte[6];//标志位字节数为6 img<<<
                   
                    //实际接收到的有效字节数
                    int len = socketServer.Receive(tokenBuf);
                    if (len == 0)
                        break;
                    string token = Encoding.ASCII.GetString(tokenBuf, 0, len);
                    
                    if (token=="img<<<")
                    {
                        byte[] imgLenBuf = new byte[6];
                        socketServer.Receive(imgLenBuf);
                        int imgLen = Convert.ToInt32(Encoding.ASCII.GetString(imgLenBuf));
                        byte[] imgBuf = new byte[imgLen];
                        byte[] buf = new byte[imgLen];
                        int len2;
                        int index = 0;
                        do
                        {
                            len2 = socketServer.Receive(buf, imgLen - index, SocketFlags.None);
                            Array.Copy(buf, 0, imgBuf, index, len2);
                            index += len2;
                        } while (index < imgBuf.Length);
                        MemoryStream ms = new MemoryStream(imgBuf);
                        ms.Write(imgBuf, 0, imgBuf.Length);
                        Image photo;
                        photo = Image.FromStream(ms, true);
                        ms.Close();
                        imgPath = saveImgpath+@"\server"
                           + DateTime.Now.Year.ToString() + "-"
                           + DateTime.Now.Month.ToString() + "-"
                           + DateTime.Now.Day.ToString() + "-"
                           + DateTime.Now.Hour.ToString() + "-"
                           + DateTime.Now.Minute.ToString() + "-"
                           + DateTime.Now.Second.ToString()
                           + ".bmp";
                        //文件名 和 文件名长度 需发送给识别算法
                        imgPathLength = imgPath.Length;
                        photo.Save(imgPath, ImageFormat.Bmp);//保存图片
                        pictureBox1.Image = photo;
                        textBox1.Text = imgPath;
                        imgLenBuf = null;
                        imgBuf = null;
                    }
                    else if(token == "msg<<<")
                    {
                        //类型ID +二维码位置(下Y 右X 右Y 左X 左Y)  1 49 189 214 207 72
                        byte[] msgBuf = new byte[21];
                        socketServer.Receive(msgBuf, msgBuf.Length, SocketFlags.None);
                        string message = Encoding.ASCII.GetString(msgBuf);
                        //MessageBox.Show(message);
                        string[] messageInfo = message.Split(' ');
                        textBox2.Text = messageInfo[0];//项目类型 1
                        //49 189 214 207 72
                        textBox3.Text = messageInfo[1] + " " + messageInfo[2] + " " + messageInfo[3] + " " + messageInfo[4] + " " + messageInfo[5];
                        //算法识别仪器是否正常
                        String sse = rec(imgPath,imgPathLength);               
                        if (sse.Substring(0, 2) == "-1")
                        {
                            sse = "failed";
                        }
                        if (sse.Substring(0, 2) == "-3")
                        {
                            sse = "hotSpot";
                        }
                        byte[] se = Encoding.ASCII.GetBytes(sse);
                        socketServer.Send(se, se.Length, 0);//将结果回传给手持端
                    }

            }
                    catch (Exception ) { 
                        recThread.Abort();//无客户端连接时断开接收线程
                    } 
                }     
    }

        //服务端与识别算法的通信得到返回结果
        private string rec(string fileName,int fileNameLength)
        {
            string result = null;

            try
            {
                //建立管理端与识别算法的通信
                IPAddress ip = IPAddress.Parse(message.serverIP);
                IPEndPoint ipport = new IPEndPoint(ip, 10002);
                Socket client;
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ipport);   
                //发送给识别算法 类型ID 文件名长度 文件名 二维码位置
                String sse = textBox2.Text + " " + fileNameLength + " " + fileName + " " + textBox3.Text;
                byte[] se = Encoding.ASCII.GetBytes(sse);
                client.Send(se, se.Length, 0);
                client.Shutdown(System.Net.Sockets.SocketShutdown.Send);   
                /*if (fileName != null)
                {
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    byte[] fssize = new byte[fs.Length];
                    BinaryReader strread = new BinaryReader(fs);
                    strread.Read(fssize, 0, fssize.Length - 1);
                    client.Send(fssize);
                    fs.Close();
                   
                }*/

                //接收识别结果
                byte[] re = new byte[1024];
                int bytes = client.Receive(re, re.Length, 0);
                result = Encoding.ASCII.GetString(re, 0, bytes);
                //double res = Convert.ToDouble(result);
                //将结果写入数据库
                //insert into result(ResultID,TypeID,Type1) values(58,1,2.22);
                /*string str2 = "select max(ResultID) from result";
                MySqlCommand mycom2 = new MySqlCommand(str2, mycon);
                int intcont2 = Convert.ToInt32(mycom2.ExecuteScalar());//新设备ID
                string str1 = "insert into result(ResultID,TypeID,Type" + textBox2.Text + @") values(@resultID,@typeId,@res)";
                MySqlCommand mycom = new MySqlCommand(str1, mycon);

                mycom.Parameters.Add(new MySqlParameter("@resultID", MySqlDbType.Int32));
                mycom.Parameters.Add(new MySqlParameter("@typeId", MySqlDbType.Int32));
                mycom.Parameters.Add(new MySqlParameter("@res", MySqlDbType.Float));

                mycom.Parameters["@resultID"].Value = intcont2 + 1;
                mycom.Parameters["@typeId"].Value = Convert.ToInt32(textBox2.Text);
                mycom.Parameters["@res"].Value = (float)res;
                //mycom.ExecuteNonQuery();
                if (mycom.ExecuteReader().HasRows) MessageBox.Show("添加成功");*/
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            return result;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (pictureBox1.Image != null)
                {
                    saveFileDialog1.ShowDialog();
                    //bmp = (Bitmap)pictureBox1.Image;
                    //bmp.Save(saveFileDialog1.FileName);
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
                }
                else
                    MessageBox.Show("no photo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            socketWatch.Close();
            socketServer.Close();
            openBtn.Enabled = true;
            closeBtn.Enabled = false;
        }

        private void newRecon_zfd_FormClosing(object sender, FormClosingEventArgs e)
        {
            //mycon.Close();//关闭数据库
            socketWatch.Close();
            if(socketServer != null)
            {
                socketServer.Close();
            }
        }

        private void btnImgPth_Click(object sender, EventArgs e)
        {
           
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                string path = folderBrowserDialog1.SelectedPath;
                WritePrivateProfileString("Information", "SaveImgPath", path, IniFilePath);
                saveImgpath = @GetValue("Information","SaveImgPath");
            }
        }

        private string GetValue(string section, string key)
        {

            StringBuilder stringBuilder = new StringBuilder();

            GetPrivateProfileString(section,key,"", stringBuilder, 1024, IniFilePath);

            string value = stringBuilder.ToString();
            return value;

        }
    }
}
