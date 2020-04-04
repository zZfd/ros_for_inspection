using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace Intelligent_robot_patrol
{
    public partial class FormScan : Form
    {
        private static Socket socket;
        private static string serverIP = "47.97.173.230";//serverIP of fy
        //private static string serverIP = "192.168.1.135";//serverIP of fy
        private static IPAddress ip = IPAddress.Parse(serverIP);
        private static int port = 2020;
        private static IPEndPoint location = new IPEndPoint(ip, port);
        private static string imgURI = "file:///E:/final_design/master_design/Intelligent_robot_patrol/test.png";
        private static WebRequest webReq = WebRequest.Create(imgURI);
        private static WebResponse webRes = webReq.GetResponse();


        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public FormScan()
        {
            InitializeComponent();
            
        }

        private void FormScan_Load(object sender, EventArgs e)
        {
            //与服务端建立通信
            //try
            //{
                socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(location);
                MessageBox.Show("连接成功!");
//}
            //catch (Exception) { MessageBox.Show("建立通信失败！"); };
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += Scan;
        }

        private void Scan(object sender, EventArgs e)
        {
            using (System.IO.Stream stream = webRes.GetResponseStream())
            {
                Bitmap img = new Bitmap(Image.FromStream(stream));
                MultiFormatReader reader = new MultiFormatReader();
                ZXing.Multi.GenericMultipleBarcodeReader barcodeReader = new ZXing.Multi.GenericMultipleBarcodeReader(reader);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    LuminanceSource source = new BitmapLuminanceSource(img);
                    BinaryBitmap binaryBitmap = new BinaryBitmap(new ZXing.Common.HybridBinarizer(source));
                    Result[] results = barcodeReader.decodeMultiple(binaryBitmap);
                    if (results != null)
                    {
                        timer.Stop();
                        foreach (Result result in results)
                        {
                             //firstly upload img. 
                            //Because that server communication with algorithm after getting projectInfo
                           //sync not async
                            UploadProImg(img);//upload project img
                            Thread.Sleep(500);//process wait 500, socket sync is stupid
                            string identifyResult = UploadProInfo(result);//prase project info and upload
                            MessageBox.Show(identifyResult);
                        }
                    }
                }
            }
        }

        private string UploadProInfo(Result result)
        {

            //二维码识别到的字符串，10位，前三位设备ID，后三位部件ID，再后三位项目ID，最后一位类型ID

            Project.currentDevID = result.Text.Substring(0, 3);//QRresult.Text[0] + QRresult.Text[1] + QRresult.Text[2];
            Project.currentComID = result.Text.Substring(3, 3);
            Project.currentProID = result.Text.Substring(6, 3);
            Project.currentProType = result.Text.Substring(9, 1);
            //MessageBox.Show("类型"+messages.currentProType+"坐标"+messages.currentDevID+"  " + messages.currentComID+"  "+messages.currentProID);

            //以及二维码位置是否正确
            //二维码三个标识块坐标
            ResultPoint rp0 = (ResultPoint)result.ResultPoints.GetValue(0);//下
            ResultPoint rp2 = (ResultPoint)result.ResultPoints.GetValue(2);//右
            ResultPoint rp1 = (ResultPoint)result.ResultPoints.GetValue(1);//左

            //算法所需坐标  socket传输 49 189 214 207 72  顺序别错，算法是这样接收的
            Project.QRcodePos += ((int)rp0.Y).ToString() + " " //下Y
                                + ((int)rp2.X).ToString() + " " //右X
                                + ((int)rp2.Y).ToString() + " " //右Y
                                + ((int)rp1.X).ToString() + " " //左X
                                + ((int)rp1.Y).ToString(); //左Y

          
            /*
             * 项目socket有两个版本(发送和接收端要对应好)
             * 发送接收都为同步操作
             * 发送的信息又所增加
             * 发送的标识有所修改
             * 最后一个版本是(张飞达-->丰舆)
             * 发送的项目信息最多，项目类型ID +二维码位置(下Y 右X 右Y 左X 左Y)  项目ID 任务ID 巡检员ID  巡检设备ID
             * 因为最后把数据库操作全部转移到服务器上了
             * 表示为在发送的数组前多两个二进制数，标识图片还是信息
             * 现在socket都采用最后一个版本
            * */
            string missionID = "1";
            string inspectorID = "1";
            string equipmentID = "1";
            //项目类型ID + 二维码位置(下Y 右X 右Y 左X 左Y)  项目ID 任务ID 巡检员ID 巡检设备ID
            string proInfo = Project.currentProType + " " + Project.QRcodePos + " "
                    + Project.currentProID + " "
                    + missionID + " "
                    + inspectorID + " "
                    + equipmentID;
            //MessageBox.Show(sseID);
            byte[] proInfoBuf = Encoding.ASCII.GetBytes(proInfo);
            List<byte> list = new List<byte>();
            list.Add(2);//添加标识符
            list.AddRange(proInfoBuf);
            byte[] sendBuf = list.ToArray();
            socket.Send(sendBuf,sendBuf.Length, SocketFlags.None);
            //List<byte> list = new List<byte>();
            //list.Add(2);
            //list.AddRange(msbuf);
            //byte[] newBuffer = list.ToArray();
            //socket.Send(proInfoBuf, proInfoBuf);

            //receive identify result from server
            byte[] identifyResBuf = new byte[100];
            int len = socket.Receive(identifyResBuf);
            string identifyResult = Encoding.ASCII.GetString(identifyResBuf,0,len);
            return identifyResult;

        }

        private void UploadProImg(Bitmap bitmap)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //string imgLength = ms.Length.ToString();
            //byte[] imgLenBuf = Encoding.ASCII.GetBytes(imgLength);
            byte[] imgBuf = ms.GetBuffer();
            List<byte> list = new List<byte>();
            list.Add(1);
            list.AddRange(imgBuf);

            socket.Send(list.ToArray());
                                            
            //long send = 0; //发送的字节数                 
            /*while (true)  //大文件断点多次传输
            {
                byte[] buffer = null;
                buffer = ms.GetBuffer();
                int r = buffer.Length;

                //int r = ms.Read(buffer, 0, buffer.Length);

                if (r == 0)
                {
                    break;
                }
                socket.Send(buffer, 0, r, SocketFlags.None);
                //send += r;
                //break;
            }*/

            ms.Close();
        }

        private void FormScan_FormClosed(object sender, FormClosedEventArgs e)
        {
            socket.Close();
            Application.Exit();
        }
    }
}
