using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelligent_robot_patrol
{
    class Project
    {
        //巡检识别信息
        public static string currentDevID = null;
        public static string currentComID = null;
        public static string currentProID = null;
        public static string currentProType = null;

        public static string QRcodePos = null;//二维码位置，根据仪器类型，仪表盘是rp0的Y，液位计是rp2的X。倒过来的，因为识别那边到这读取了

        //public static ArrayList resultArray = new ArrayList();//保存识别结果
        /*public static int resultNums = 1;//结果个数
        public static String resultID = null;//结果ID
        public static String RECresult = null;//识别结果
        public static String isSuccess = null;//识别是否成功
        public static String isNormal = null;//项目结果是否正常

        public static String ErrorComName = null;//故障部件
        public static String ErrorComID = null;//故障部件ID
        public static String ErrorDevName = null;//故障设备
        public static String ErrorDevID = null;//故障设备ID
        public static String ErrorResult = null;//故障结果
        public static String ErrorProjectID = null;//故障项目ID
        public static String ErrorProjectName = null;//故障项目
        public static int notOKProCount;//未完成的检测项目个数*/
    }
}
