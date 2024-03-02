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
        public string AirportD = "";
        public string AirportDIATA = "";
        public string AirportDName = "";
        public string Alititude = "";
        public string Callsign = "";
        public string Country = "";
        public int Duration;
        public string FPlan = "";
        /// <summary>
        /// 航路距离，单位为m
        /// </summary>
        public double FPlanDistance;
        public double HDG;
        public string IATACallsign = "";
        public int ID;
        public string LAT = "";
        public string LNG = "";
        public string Model = "";
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
        public string PhotoInfo = "";
        public double PreLAT;
        public double PreLNG;
        public double RemainDistance;
        public string Speed = "";
        public int Squawk;
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

    }
}
