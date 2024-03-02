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
        public string Airport = "";
    }
    /// <summary>
    /// 存储全部机组信息（从airline_list中读取）
    /// </summary>
    class AircraftList
    {

    }
}
