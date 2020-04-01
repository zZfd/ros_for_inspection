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
using std_msgs = RosSharp.RosBridgeClient.MessageTypes.Std;
using rosapi = RosSharp.RosBridgeClient.MessageTypes.Rosapi;
using nav_msgs = RosSharp.RosBridgeClient.MessageTypes.Nav;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.InteropServices;
using CefSharp;
using CefSharp.WinForms;

namespace Intelligent_robot_patrol
{
    [ComVisible(true)]
    public partial class FormMain : Form
    {

        //私有变量
        private  static RosSocket rosSocket;
        private static ChromiumWebBrowser browser;
        private MySqlCommand mainCmd = new MySqlCommand();
        private MySqlDataAdapter mainAdp = null;
        private DataTable robotIpList = new DataTable();
        private DataTable robotMapList = new DataTable();
        private DataTable robotRouteList = new DataTable();
        private ManualResetEvent OnMessageReceived = new ManualResetEvent(false);

        //导航坐标消息类型在Geometry目录下
        private void MapSubscriptionHandler(nav_msgs.OccupancyGrid message)
        {
            //MessageBox.Show(message.header.ToString());
            OnMessageReceived.Set();
        }
        public FormMain()
        {
            InitializeComponent();
            
            //webRobot.Navigate(Path.Combine(Application.StartupPath, "roslibjs\\map.html"));
            //MessageBox.Show(Path.Combine(Application.StartupPath, "roslibjs\\map.html"));
            //webRobot.ObjectForScripting = this;
            //webRobot.Document.InvokeScript("init", new[] { Robot.ip });
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            

            //browser.JavascriptObjectRepository.UnRegisterAll();

            //browser.JavascriptObjectRepository.ResolveObject += (senders, es) =>
            //{
            //    var repo = es.ObjectRepository;
            //    if (es.ObjectName == "boundAsync2")
            //    {
            //        repo.Register("boundAsync2", new BoundAsyncROS(), isAsync: true, options: BindingOptions.DefaultBinder);
            //    }
            //};
            //browser.JavascriptObjectRepository.Register("boundAsync", new BoundAsyncROS(), isAsync: true, options: BindingOptions.DefaultBinder);

            
            lbId.Text = Inspector.id;
            lbName.Text = Inspector.name;
            DataBase.connection.Open();


            string ipListSql = "select id, name, ip from robots";
            mainCmd.CommandText = ipListSql;
            mainCmd.Connection = DataBase.connection;
            mainAdp = new MySqlDataAdapter(mainCmd);
            mainAdp.Fill(robotIpList);
            cBoxRobot.DataSource = robotIpList;
            cBoxRobot.DisplayMember = "ip";//测试展示ip,实际展示名字或ID
            cBoxRobot.SelectedIndex = 0;
            Robot.ip = robotIpList.Rows[cBoxRobot.SelectedIndex]["ip"].ToString();
            Robot.id = robotIpList.Rows[cBoxRobot.SelectedIndex]["id"].ToString();
            Robot.name = robotIpList.Rows[cBoxRobot.SelectedIndex]["name"].ToString();


            string mapListSql = string.Format(
                "select id, name from maps");
            mainCmd.CommandText = mapListSql;
            mainAdp = new MySqlDataAdapter(mainCmd);
            mainAdp.Fill(robotMapList);
            cBoxMap.DataSource = robotMapList;
            cBoxMap.DisplayMember = "name";
            cBoxMap.SelectedIndex = 0;
            Robot.map_id = robotMapList.Rows[cBoxMap.SelectedIndex]["id"].ToString();
            Robot.map_name = cBoxMap.Text;

            string routeListSql = "select id, name from routes";
            mainCmd.CommandText = routeListSql;
            mainAdp = new MySqlDataAdapter(mainCmd);
            mainAdp.Fill(robotRouteList);
            cBoxRoute.DataSource = robotRouteList;
            cBoxRoute.DisplayMember = "name";
            cBoxRoute.SelectedIndex = 0;
            Robot.route_id = robotRouteList.Rows[cBoxRoute.SelectedIndex]["id"].ToString();
            Robot.route_name = cBoxRoute.Text;



        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(btnStart.Text == "开始")
            {
                browser = new ChromiumWebBrowser(Path.Combine(Application.StartupPath, "ros\\newMap.html"));
                //browser = new ChromiumWebBrowser();

                //   MessageBox.Show(Path.Combine(Application.StartupPath, "ros\\test.html"));
                browser.JavascriptObjectRepository.Register("boundAsync", new BoundAsyncROS(), isAsync: true, options: BindingOptions.DefaultBinder);
                PanelChrome.Controls.Add(browser);
                btnContinue.Enabled = true;
                btnStart.Text = "结束";
            }
            else
            {
                btnStart.Text = "开始";
                browser.Dispose();
                PanelChrome.Controls.Remove(browser);
                browser = null;
                btnContinue.Text = "暂停";
                btnContinue.Enabled = false;        

            }
            
            //if (browser != null)
            //{
            //    browser.Dock = DockStyle.Fill;
            //}

            //browser.JavascriptObjectRepository.ResolveObject += (senders, es) =>
            //{
            //    var repo = es.ObjectRepository;
            //    if (es.ObjectName == "boundAsync2")
            //    {
            //        repo.Register("boundAsync2", new BoundAsyncROS(), isAsync: true, options: BindingOptions.DefaultBinder);
            //    }
            //};
            //rosSocket = new RosSocket(new RosSharp.RosBridgeClient.Protocols.WebSocketNetProtocol(Robot.ip));
            //string id = rosSocket.Subscribe<nav_msgs.OccupancyGrid>("/map", MapSubscriptionHandler);
            //OnMessageReceived.WaitOne();
            //OnMessageReceived.Reset();
            //rosSocket.Unsubscribe(id);
            //Thread.Sleep(100);
            //Assert.IsTrue(true);

            //Subscribe<T>(string topic, SubscriptionHandler<T> subscriptionHandler, int throttle_rate = 0, int queue_length = 1, int fragment_size = int.MaxValue, string compression = "none") where T : Message;
            /*
                public void SubscriptionTest()
        {
            string id = RosSocket.Subscribe<std_msgs.String>("/subscription_test", SubscriptionHandler);
            OnMessageReceived.WaitOne();
            OnMessageReceived.Reset();
            RosSocket.Unsubscribe(id);
            Thread.Sleep(100);
            Assert.IsTrue(true);
        }

            private void SubscriptionHandler(std_msgs.String message)
        {
            OnMessageReceived.Set();
        }

        private ManualResetEvent OnMessageReceived = new ManualResetEvent(false);

             
             */


        }
        /*public string getRosIp()
        {
            return Robot.ip;
        }*/
        /**
         * 机器人紧急控制，多窗口应用
         * 全部通过rosbridge与机器人连接，通过话题发布控制机器人
         * 同个上位机不能重复连接，可通过全局标志位控制
         * */
        private void btnControl_Click(object sender, EventArgs e)
        {
            Form formControl = new FormControl();
            formControl.Show();
        }

       

        private void cBoxMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBoxMap.SelectedIndex >= 0)
            {
                Robot.map_id = robotMapList.Rows[cBoxMap.SelectedIndex]["id"].ToString();
                Robot.map_name = cBoxMap.Text;
                if(DataBase.connection.State == ConnectionState.Closed)
                {
                    DataBase.connection.Open();
                }
                string routeUpdateSql = string.Format("select id, name from routes where map_id = '{0}'", Robot.map_id);
                mainCmd.CommandText = routeUpdateSql;
                mainAdp = new MySqlDataAdapter(mainCmd);
                robotRouteList.Clear();
                mainAdp.Fill(robotRouteList);
                cBoxRoute.DataSource = robotRouteList;
                cBoxRoute.SelectedIndex = 0;
                DataBase.connection.Close();
            }     
        }

        private void cBoxRobot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBoxRobot.SelectedIndex >= 0)
            {
                Robot.ip = robotIpList.Rows[cBoxRobot.SelectedIndex]["ip"].ToString();
                Robot.id = robotIpList.Rows[cBoxRobot.SelectedIndex]["id"].ToString();
                Robot.name = robotIpList.Rows[cBoxRobot.SelectedIndex]["name"].ToString();
            }    
        }

        private void cBoxRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBoxRoute.SelectedIndex >= 0)
            {
                Robot.route_id = robotRouteList.Rows[cBoxRoute.SelectedIndex]["id"].ToString();
                Robot.route_name = cBoxRoute.Text;
            }
            
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (browser != null)
            {
                browser.Dispose();
            }
            Application.Exit();
        }

        /// <summary>
        /// 暂时用来测试执行javascript
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            var frame = browser.GetFocusedFrame();
            var script =
                @"(async function ()
                {
                        alert('手动执行javascript');
                })();";

    
     

            frame.ExecuteJavaScriptAsync(script);

            ////Execute extension method
            //frame.ListenForEvent("test-button", "click");
            //public static void ListenForEvent(this IFrame frame, string id, string eventName)
            //{
            //    if (frame == null)
            //    {
            //        throw new ArgumentException("An IFrame instance is required.", "frame");
            //    }

            //    // Adds a click event listener to a DOM element with the provided
            //    // ID. When the element is clicked the ScriptedMethodsBoundObject's
            //    // RaiseEvent function is invoked. This is one way to get
            //    // asynchronous events from the web page. Typically though the web
            //    // page would be aware of window.boundEvent.RaiseEvent and would
            //    // simply raise it as needed.
            //    //
            //    // Scripts should be minified for production builds. The script
            //    // could also be read from a file...
            //    var script =
            //        @"(async function ()
            //    {
            //        await CefSharp.BindObjectAsync('boundEvent');
            //        var counter = 0;
            //        var elem = document.getElementById('##ID##');
            //        elem.removeAttribute('disabled');
            //        elem.addEventListener('##EVENT##', function(e){
            //            if (!window.boundEvent){
            //                console.log('window.boundEvent does not exist.');
            //                return;
            //            }
            //            counter++;
            //            //NOTE RaiseEvent was converted to raiseEvent in JS (this is configurable when registering the object)
            //            window.boundEvent.raiseEvent('##EVENT##', {count: counter, id: e.target.id, tagName: e.target.tagName});
            //        });
            //        console.log(`Added ##EVENT## listener to ${elem.id}.`);
            //    })();";

            //    // For simple inline scripts you could use String.Format() but
            //    // beware of braces in the javascript code. If reading from a file
            //    // it's probably safer to include tokens that can be replaced via
            //    // regex.
            //    script = Regex.Replace(script, "##ID##", id);
            //    script = Regex.Replace(script, "##EVENT##", eventName);

            //    frame.ExecuteJavaScriptAsync(script);
            //}
        }
    }
}
