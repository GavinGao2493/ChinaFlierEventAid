using System;
using System.Text;
using Newtonsoft.Json;
namespace ConsoleVersion
{   
    /// <summary>
    /// 存储边界上的每一个点
    /// </summary>
    public class BorderPoint
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public double LAT;
        /// <summary>
        /// 经度
        /// </summary>
        public double LNG;
    }
    /// <summary>
    /// 存储一块封闭的管制区域
    /// </summary>
    class Border
    {
        public List<BorderPoint>? Borders;
    }
    /// <summary>
    /// 存储一个管制员信息
    /// </summary>
    public class AtcInfo
    {
        /// <summary>
        /// 意义不明
        /// </summary>
        public string? Border = "";
        public List<List<BorderPoint>>? Borders;
        /// <summary>
        /// 管制席位呼号
        /// </summary>
        public string Callsign = "";
        /// <summary>
        /// 席位类型
        /// GND->0
        /// TWR->0
        /// APP->5
        /// CTR->5
        /// </summary>
        public int FIRType;
        /// <summary>
        /// 管制频率
        /// </summary>
        public string Freq = "";
        /// <summary>
        /// 中心点纬度
        /// </summary>
        public string LAT = "";
        /// <summary>
        /// 中心点经度
        /// </summary>
        public string LNG = "";
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UID = "";
    }
    /// <summary>
    /// 存储所有在线管制员信息
    /// </summary>
    public class AtcList
    {
        List<AtcInfo>? atcList = new List<AtcInfo>();
        public AtcList(string jsonString)
        {
            atcList = JsonConvert.DeserializeObject<List<AtcInfo>>(jsonString);
        }
        public List<AtcInfo>? GetAtcList()
        {
            return atcList;
        }
    }
}
