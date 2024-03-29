﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    /// <summary>
    /// 存储一个机组的一条记录
    /// </summary>
    public class CheckRecords
    {
        public Aircraft aircraft;
        /// <summary>
        /// 记录进入范围的时间，默认初值为2000年1月1日00:00分
        /// </summary>
        public DateTime inBoundTime = new DateTime(2000, 1, 1);
        /// <summary>
        /// 离开进入范围的时间，默认初值为2000年1月1日00:00分
        /// </summary>
        public DateTime outBoundTime = new DateTime(2000, 1, 1);
        /// <summary>
        /// 新建一条记录并更新进入记录
        /// </summary>
        /// <param name="aircraft">机组信息</param>
        /// <param name="inBoundTime">进入扇区时间</param>
        /// <param name="outBoundTime">离开扇区时间</param>
        public CheckRecords(Aircraft aircraft)
        {
            this.aircraft = aircraft;
            inBoundTime = DateTime.Now;
            outBoundTime = DateTime.Now;
        }
        public CheckRecords(Aircraft aircraft, DateTime dateTime)
        {
            this.aircraft = aircraft;
            inBoundTime = dateTime;
            outBoundTime = dateTime;
        }
        /// <summary>
        /// 更新最新时间与最新飞行计划
        /// </summary>
        public void UpdateRecords(Aircraft aircraft, DateTime dateTime)
        {
            if (inBoundTime == new DateTime(2000, 1, 1))
                inBoundTime = dateTime;
            outBoundTime = dateTime;
            
            // 更新起飞机场与目的地机场
            if (this.aircraft.AirportD != aircraft.AirportD)
            {
                this.aircraft.AirportD = aircraft.AirportD;
                this.aircraft.AirportDIATA = aircraft.AirportDIATA;
                this.aircraft.AirportDName = aircraft.AirportDName;
            }
            if (this.aircraft.AirportA != aircraft.AirportA)
            {
                this.aircraft.AirportA = aircraft.AirportA;
                this.aircraft.AirportAIATA = aircraft.AirportAIATA;
                this.aircraft.AirportAName = aircraft.AirportAName;
            }
        }
        public void UpdateRecords(Aircraft aircraft)
        {
            if (inBoundTime == new DateTime(2000, 1, 1))
                inBoundTime = DateTime.Now;
            outBoundTime = DateTime.Now;

            // 更新起飞机场与目的地机场
            if (this.aircraft.AirportD != aircraft.AirportD)
            {
                this.aircraft.AirportD = aircraft.AirportD;
                this.aircraft.AirportDIATA = aircraft.AirportDIATA;
                this.aircraft.AirportDName = aircraft.AirportDName;
            }
            if (this.aircraft.AirportA != aircraft.AirportA)
            {
                this.aircraft.AirportA = aircraft.AirportA;
                this.aircraft.AirportAIATA = aircraft.AirportAIATA;
                this.aircraft.AirportAName = aircraft.AirportAName;
            }
        }
        /// <summary>
        /// 使用元组的方式返回机组进入和离开范围时间
        /// 元组的第一项为进入时间，第二项为离开时间
        /// </summary>
        /// <returns></returns>
        public (DateTime, DateTime) GetInboundAndOutboundTime()
        {
            return (inBoundTime, outBoundTime);
        }
    }
    /// <summary>
    /// 存储一个CheckPoint的相关机组数据
    /// </summary>
    public class CheckPoint
    {
        public string checkPointName;
        public double LAT, LNG;
        public int range, lowAlt, highAlt;
        List<CheckRecords> checkedAircraft = new List<CheckRecords>();
        /// <summary>
        /// 初始化CheckPoint
        /// </summary>
        /// <param name="checkPointName"></param>
        /// <param name="LAT"></param>
        /// <param name="LNG"></param>
        /// <param name="range"></param>
        /// <param name="lowAlt"></param>
        /// <param name="highAlt"></param>
        public CheckPoint(string checkPointName, double LAT, double LNG, int range, int lowAlt = 0, int highAlt = 48900)
        {
            this.checkPointName = checkPointName;
            this.LAT = LAT;
            this.LNG = LNG;
            this.range = range;
            this.lowAlt = lowAlt;
            this.highAlt = highAlt;
        }
        /// <summary>
        /// 利用最新范围内的机组来更新机组列表
        /// </summary>
        /// <param name="aircrafts">制定范围内的机组列表</param>
        public void UpdateCheckedAircrafts(List<Aircraft>? aircrafts)
        {
            if (aircrafts == null) return;
            foreach (var aircraft in aircrafts)
                if (GetAddedAircraftIndex(aircraft, checkedAircraft) == -1)
                    checkedAircraft.Add(new CheckRecords(aircraft));
                else
                    checkedAircraft[GetAddedAircraftIndex(aircraft, checkedAircraft)].UpdateRecords(aircraft);
        }
        public void UpdateCheckedAircrafts(List<Aircraft>? aircrafts, DateTime dateTime)
        {
            if (aircrafts == null) return;
            foreach (var aircraft in aircrafts)
                if (GetAddedAircraftIndex(aircraft, checkedAircraft) == -1)
                    checkedAircraft.Add(new CheckRecords(aircraft, dateTime));
                else
                    checkedAircraft[GetAddedAircraftIndex(aircraft, checkedAircraft)].UpdateRecords(aircraft, dateTime);
        }
        /// <summary>
        /// 取机组索引
        /// 若未找到，返回-1
        /// </summary>
        /// <param name="aircraft">机组信息</param>
        /// <param name="checkedAircraft">机组列表</param>
        /// <returns></returns>
        static int GetAddedAircraftIndex(Aircraft aircraft, List<CheckRecords> checkedAircraft)
        {
            for (int i = 0; i < checkedAircraft.Count; i++)
                if (checkedAircraft[i].aircraft.Callsign == aircraft.Callsign
                    && checkedAircraft[i].aircraft.UID == aircraft.UID)
                    return i;
            return -1;
        }
        public List<CheckRecords> GetCheckPoinrRecords()
        {
            return checkedAircraft;
        }
        /// <summary>
        /// 清除数据（初始化）
        /// </summary>
        public void Clear()
        {
            checkedAircraft = new List<CheckRecords>();
        }
    }
}
