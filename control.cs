using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Geometry;
namespace Intelligent_robot_patrol
{
    public partial class FormControl : Form
    {
        private static readonly string Uri = "ws://localhost:8888";
        private static RosSocket RosSocket;
        public FormControl()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            RosSocket = new RosSocket(new RosSharp.RosBridgeClient.Protocols.WebSocketNetProtocol(Uri));
            MessageBox.Show("连接成功!");
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            string id = RosSocket.Advertise<Twist>("/cmd_vel");
            Vector3 linear = new Vector3(0.5, 0.0, 0.0);
            Vector3 angular = new Vector3(0.0, 0.0, 0.0);
            Twist forward = new Twist(linear, angular);
            RosSocket.Publish(id, forward);//发布
            RosSocket.Unadvertise(id);//取消发布
            Thread.Sleep(100);
            //System.Net.WebSockets.WebSocketException 一方关闭webSocket报错，未完成握手
        }

        private void FormControl_Load(object sender, EventArgs e)
        {

        }
    }
}
