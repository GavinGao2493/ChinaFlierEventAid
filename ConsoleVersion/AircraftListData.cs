using Newtonsoft.Json;
using System;
using System.Text;
namespace ConsoleVersion
{
    /// <summary>
    /// 存储单个机组信息
    /// </summary>
    class Aircraft()
    {
        /// <summary>
        /// 到达机场ICAO码
        /// </summary>
        public string AirportA = "";
        /// <summary>
        /// 到达机场IATA码
        /// </summary>
        public string AirportAIATA = "";
        /// <summary>
        /// 到达机场名称
        /// </summary>
        public string AirportAName = "";
        /// <summary>
        /// 起飞机场ICAO码
        /// </summary>
        public string AirportD = "";
        /// <summary>
        /// 起飞机场IATA码
        /// </summary>
        public string AirportDIATA = "";
        /// <summary>
        /// 起飞机场名称
        /// </summary>
        public string AirportDName = "";
        /// <summary>
        /// 当前高度，单位为feet
        /// </summary>
        public string Altitude = "";
        /// <summary>
        /// 呼号
        /// </summary>
        public string Callsign = "";
        /// <summary>
        /// 航空器国家
        /// </summary>
        public string Country = "";
        /// <summary>
        /// 续航？意义不明
        /// </summary>
        public int Duration;
        /// <summary>
        /// 飞行航路
        /// </summary>
        public string FPlan = "";
        /// <summary>
        /// 航路距离，单位为m
        /// </summary>
        public double FPlanDistance;
        /// <summary>
        /// 航向
        /// </summary>
        public double HDG;
        /// <summary>
        /// IATA呼号
        /// </summary>
        public string IATACallsign = "";
        /// <summary>
        /// 内部使用的航班编号
        /// </summary>
        public int ID;
        /// <summary>
        /// 纬度
        /// </summary>
        public string LAT = "";
        /// <summary>
        /// 经度
        /// </summary>
        public string LNG = "";
        /// <summary>
        /// 机型
        /// </summary>
        public string Model
        {
            get{ return modifiedModel; }
            set
            {
                if (value.Length == 7)
                    modifiedModel = value.Substring(3);
                else
                    modifiedModel = value;
            }
        }
        /// <summary>
        /// 处理后的机型
        /// </summary>
        private string modifiedModel = "";
        /// <summary>
        /// 是否在线
        /// </summary>
        public int Online;
        /// <summary>
        /// 默认为Noraml，意义不明
        /// </summary>
        public string Origin = "";
        /// <summary>
        /// 图片文件名
        /// </summary>
        public string Photo = "";
        /// <summary>
        /// 图片说明
        /// </summary>
        public string PhotoInfo = "";
        /// <summary>
        /// 航迹预测线端点纬度
        /// </summary>
        public double PreLAT;
        /// <summary>
        /// 航迹预测线端点经度
        /// </summary>
        public double PreLNG;
        /// <summary>
        /// 剩余航路距离，单位为m
        /// </summary>
        public double RemainDistance;
        /// <summary>
        /// 速度，单位为knot
        /// </summary>
        public string Speed = "";
        /// <summary>
        /// 应答机
        /// </summary>
        public int Squawk;
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UID = "";
        /// <summary>
        /// 垂直速度，单位为feet/s
        /// </summary>
        public double VSpeed;
    }
    /// <summary>
    /// 存储全部机组信息（从airline_list中读取）
    /// </summary>
    class AircraftList
    {
        List<Aircraft>? aircrafts = new List<Aircraft>();
        public AircraftList(string jsonString)
        {
            aircrafts = JsonConvert.DeserializeObject<List<Aircraft>>(jsonString);
        }
        public List<Aircraft>? GetAircraftsList()
        {
            return aircrafts;
        }
    }
}
