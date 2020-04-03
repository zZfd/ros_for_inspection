using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace 服务端
{
    class message
    {
        //10000-警报socket
        //10001-识别-接收图片socket
        //10002-识别-发送图片、接收结果socket
        //10003-机器人远程监控-接收图片（帧）socket
        //10004-机器人远程监控-控制命令socket

        public static String robotIP = "192.168.43.67";//null;


        public static String localPic = "D:\\xjy\\xjyPic\\";

        public static String serverIP = "127.0.0.1";//null;


        public static String MysqlStr = "database=newbianjingprogram;server=localhost;user id=root;Password=zfd980323.;Charset=utf8;Allow Zero Datetime=True";
        public static MySqlConnection myCon =  new MySqlConnection(MysqlStr);

        public static String ManagerName = "zfd";//管理员姓名
        public static String ManagerID = "2";//管理员ID
        public static int isSuper = 0;//是否具有超级权限

        public static int inspectorID;
        public static String inspectorName = null;

        public static int groupID;
        public static int inspectequipmentID;
        public static String routeName = null;

        public static int missionID;
        public static String missionItem = null;


        public static int routeID;
        public static int routeDeID;
        public static string routeComName = null;
        public static object routeMessage = null;

        public static int devID;
        public static object devMessage = null;

        public static int comID;
        public static object comMessage = null;

        public static int proID;
        public static object proMessage = null;

        public static object tree1Message = null;
        public static object tree2Message = null;

        //添加节点后，用以下两个参数重新定位树1的选中节点
        public static object addNodePa = null;
        public static int addIndex;

        //移除节点后，用以下两个参数重新定位树2的选中节点
        public static object remNodePa = null;
        public static int remIndex;
    }
}
