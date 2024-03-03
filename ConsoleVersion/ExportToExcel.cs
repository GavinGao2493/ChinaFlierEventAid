using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
namespace ConsoleVersion
{
    internal class ExportToExcel
    {
        /// <summary>
        /// 导出所有在线管制员列表
        /// </summary>
        /// <param name="atcList"></param>
        /// <returns></returns>
        public static bool AtcListToExcel(List<AtcInfo>? atcList)
        {
            if (atcList == null)   return false;
            
            bool result = false;
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");// 创建一个名称为Sheet1的表;
            IRow row = sheet.CreateRow(0);// 第一行写标题
            row.CreateCell(0).SetCellValue("席位名称"); // 第一列标题
            row.CreateCell(1).SetCellValue("用户编号"); // 第二列标题
            //每一行依次写入
            for (int i = 0; i < atcList.Count; i++)
            {
                row = sheet.CreateRow(i + 1);   //i+1:从第二行开始写入(第一行可同理写标题)，i从第一行写入
                row.CreateCell(0).SetCellValue(atcList[i].Callsign);//第一列的值
                row.CreateCell(1).SetCellValue(atcList[i].UID);//第二列的值
            }
            //文件写入的位置
            using (FileStream fs = File.OpenWrite(@"AtcList.xls"))
            {
                workbook.Write(fs);//向打开的这个xls文件中写入数据  
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 设置了起飞落地机场信息的导出
        /// </summary>
        /// <param name="atcList"></param>
        /// <param name="AirportD">起飞机场</param>
        /// <param name="AirportA">落地机场</param>
        /// <returns></returns>
        public static bool AtcListToExcel(List<AtcInfo>? atcList, List<string> AirportDs, List<string> AirportAs)
        {
            if (atcList == null) return false;

            bool result = false;
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");// 创建一个名称为Sheet1的表;
            IRow row = sheet.CreateRow(0);// 第一行写标题

            // 设置适配于策划案的列宽
            for (int i = 0; i < 12; i++)
                sheet.SetColumnWidth(i, (int)(118 / 8.43 * 256));

            // 下面间隔添加是因为后续合并单元格
            row.CreateCell(0).SetCellValue("场面席位"); // 第一列标题
            row.CreateCell(2).SetCellValue("终端席位"); // 第三列标题
            row.CreateCell(4).SetCellValue("高空席位"); // 第五列标题
            row.CreateCell(6).SetCellValue("终端席位"); // 第七列标题
            row.CreateCell(8).SetCellValue("场面席位"); // 第九列标题

            // 下面开始合并单元格
            CellRangeAddress mergedRegion = new CellRangeAddress(0, 0, 0, 1);
            sheet.AddMergedRegion(mergedRegion);
            mergedRegion = new CellRangeAddress(0, 0, 2, 3);
            sheet.AddMergedRegion(mergedRegion);
            mergedRegion = new CellRangeAddress(0, 0, 4, 5);
            sheet.AddMergedRegion(mergedRegion);
            mergedRegion = new CellRangeAddress(0, 0, 6, 7);
            sheet.AddMergedRegion(mergedRegion);
            mergedRegion = new CellRangeAddress(0, 0, 8, 9);
            sheet.AddMergedRegion(mergedRegion);

            // 初始化各类型席位数目
            int rowTwrD = 0;    int rowTmaD = 0;
            int rowTwrA = 0;    int rowTmaA = 0;
            int rowCtr = 0;     int rowUnclassfied = 0;
            bool unclassfiedFlag = false;

            // 依次写入数据
            for (int i = 0; i < atcList.Count; i++)
            {
                if (atcList[i].Callsign.Contains("DEL") || atcList[i].Callsign.Contains("DLV")
                        || atcList[i].Callsign.Contains("APN") || atcList[i].Callsign.Contains("RAMP")
                        || atcList[i].Callsign.Contains("GND") || atcList[i].Callsign.Contains("TWR"))
                    if (IsCallsignContainingAirport(atcList[i].Callsign, AirportDs))
                    {
                        row = sheet.GetRow(++rowTwrD);
                        if (row == null)
                            row = sheet.CreateRow(rowTwrD);
                        row.CreateCell(0).SetCellValue(atcList[i].Callsign);
                        row.CreateCell(1).SetCellValue(atcList[i].UID);
                    }
                    else if (IsCallsignContainingAirport(atcList[i].Callsign, AirportAs))
                    {
                        row = sheet.GetRow(++rowTwrA);
                        if (row == null)
                            row = sheet.CreateRow(rowTwrA);
                        row.CreateCell(8).SetCellValue(atcList[i].Callsign);
                        row.CreateCell(9).SetCellValue(atcList[i].UID);
                    }
                    else
                    {
                        if (!unclassfiedFlag)
                        {
                            unclassfiedFlag = true;
                            row = sheet.GetRow(0);
                            row.CreateCell(10).SetCellValue("无法自动分类席位"); // 第十一列标题
                            mergedRegion = new CellRangeAddress(0, 0, 10, 11);
                            sheet.AddMergedRegion(mergedRegion);
                        }
                        row = sheet.GetRow(++rowUnclassfied);
                        if (row == null)
                            row = sheet.CreateRow(rowUnclassfied);
                        row.CreateCell(10).SetCellValue(atcList[i].Callsign);
                        row.CreateCell(11).SetCellValue(atcList[i].UID);
                    }
                else if (atcList[i].Callsign.Contains("APP"))
                    if (IsCallsignContainingAirport(atcList[i].Callsign, AirportDs))
                    {
                        row = sheet.GetRow(++rowTmaD);
                        if (row == null)
                            row = sheet.CreateRow(rowTmaD);
                        row.CreateCell(2).SetCellValue(atcList[i].Callsign);
                        row.CreateCell(3).SetCellValue(atcList[i].UID);
                    }
                    else if (IsCallsignContainingAirport(atcList[i].Callsign, AirportAs))
                    {
                        row = sheet.GetRow(++rowTmaA);
                        if (row == null)
                            row = sheet.CreateRow(rowTmaA);
                        row.CreateCell(6).SetCellValue(atcList[i].Callsign);
                        row.CreateCell(7).SetCellValue(atcList[i].UID);
                    }
                    else
                    {
                        if (!unclassfiedFlag)
                        {
                            unclassfiedFlag = true;
                            row = sheet.GetRow(0);
                            row.CreateCell(10).SetCellValue("无法自动分类席位"); // 第十一列标题
                            mergedRegion = new CellRangeAddress(0, 0, 10, 11);
                            sheet.AddMergedRegion(mergedRegion);
                        }
                        row = sheet.GetRow(++rowUnclassfied);
                        if (row == null)
                            row = sheet.CreateRow(rowUnclassfied);
                        row.CreateCell(10).SetCellValue(atcList[i].Callsign);
                        row.CreateCell(11).SetCellValue(atcList[i].UID);
                    }
                else if (atcList[i].Callsign.Contains("CTR"))
                {
                    row = sheet.GetRow(++rowCtr);
                    if (row == null)
                        row = sheet.CreateRow(rowCtr);
                    row.CreateCell(4).SetCellValue(atcList[i].Callsign);
                    row.CreateCell(5).SetCellValue(atcList[i].UID);
                }
                else
                {
                    if (!unclassfiedFlag)
                    {
                        unclassfiedFlag = true;
                        row = sheet.GetRow(0);
                        row.CreateCell(10).SetCellValue("无法自动分类席位"); // 第十一列标题
                        mergedRegion = new CellRangeAddress(0, 0, 10, 11);
                        sheet.AddMergedRegion(mergedRegion);
                    }
                    row = sheet.GetRow(++rowUnclassfied);
                    if (row == null)
                        row = sheet.CreateRow(rowUnclassfied);
                    row.CreateCell(10).SetCellValue(atcList[i].Callsign);
                    row.CreateCell(11).SetCellValue(atcList[i].UID);
                }
            }
            //文件写入的位置
            using (FileStream fs = File.OpenWrite(@"AtcList.xls"))
            {
                workbook.Write(fs);//向打开的这个xls文件中写入数据  
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 导出所有在线机组列表
        /// </summary>
        /// <param name="aircraftList"></param>
        /// <returns></returns>
        public static bool AircraftListToExcel(List<Aircraft>? aircraftList)
        {
            if (aircraftList == null) return false;

            bool result = false;
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");  // 创建一个名称为Sheet1的表;
            IRow row = sheet.CreateRow(0);  // 第一行写标题
            row.CreateCell(0).SetCellValue("机组呼号"); // 第一列标题
            row.CreateCell(1).SetCellValue("用户编号"); // 第二列标题
            row.CreateCell(2).SetCellValue("起飞机场"); // 第三列标题
            row.CreateCell(3).SetCellValue("落地机场"); // 第四列标题
            row.CreateCell(4).SetCellValue("机型");     // 第五列标题

            //每一行依次写入
            for (int i = 0; i < aircraftList.Count; i++)
            {
                row = sheet.CreateRow(i + 1);   // i+1:从第二行开始写入(第一行可同理写标题)，i从第一行写入
                row.CreateCell(0).SetCellValue(aircraftList[i].Callsign);   // 第一列的值
                row.CreateCell(1).SetCellValue(aircraftList[i].UID);        // 第二列的值
                row.CreateCell(2).SetCellValue(aircraftList[i].AirportD);   // 第三列的值
                row.CreateCell(3).SetCellValue(aircraftList[i].AirportA);   // 第四列的值
                row.CreateCell(4).SetCellValue(aircraftList[i].Model);      // 第五列的值
            }
            // 文件写入的位置
            using (FileStream fs = File.OpenWrite(@"AircraftList.xls"))
            {
                workbook.Write(fs); // 向打开的这个xls文件中写入数据  
                result = true;
            }
            return result;
        }
        public static bool CheckPointToExcel(CheckPoint? checkPoint)
        {
            if (checkPoint ==  null)    return false;

            List<CheckRecords> aircraftList = checkPoint.GetCheckPoinrRecords();
            bool result = false;
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");  // 创建一个名称为Sheet1的表;
            IRow row = sheet.CreateRow(0);  // 第一行写标题
            row.CreateCell(0).SetCellValue("机组呼号"); // 第一列标题
            row.CreateCell(1).SetCellValue("用户编号"); // 第二列标题
            row.CreateCell(2).SetCellValue("起飞机场"); // 第三列标题
            row.CreateCell(3).SetCellValue("落地机场"); // 第四列标题
            row.CreateCell(4).SetCellValue("进入时间"); // 第五列标题
            row.CreateCell(5).SetCellValue("离开时间"); // 第六列标题

            //每一行依次写入
            for (int i = 0; i < aircraftList.Count; i++)
            {
                row = sheet.CreateRow(i + 1);   // i+1:从第二行开始写入(第一行可同理写标题)，i从第一行写入
                row.CreateCell(0).SetCellValue(aircraftList[i].aircraft.Callsign);   // 第一列的值
                row.CreateCell(1).SetCellValue(aircraftList[i].aircraft.UID);        // 第二列的值
                row.CreateCell(2).SetCellValue(aircraftList[i].aircraft.AirportD);   // 第三列的值
                row.CreateCell(3).SetCellValue(aircraftList[i].aircraft.AirportA);   // 第四列的值
                (DateTime inboundTime, DateTime outbounTime) = aircraftList[i].GetInboundAndOutboundTime();
                row.CreateCell(4).SetCellValue(Convert.ToString(inboundTime));    // 第五列的值
                row.CreateCell(5).SetCellValue(Convert.ToString(outbounTime));    // 第六列的值
            }
            // 文件写入的位置
            using (FileStream fs = File.OpenWrite(checkPoint.checkPointName + ".xls"))
            {
                workbook.Write(fs); // 向打开的这个xls文件中写入数据  
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 判断呼号内是否包含机场ICAO码
        /// </summary>
        /// <param name="callsign">管制席位呼号</param>
        /// <param name="airports">包含机场名的列表</param>
        /// <returns></returns>
        static bool IsCallsignContainingAirport(string callsign, List<string> airports)
        {
            foreach (string airport in airports)
                if (callsign.Contains(airport))
                    return true;
            return false;
        }
    }
}
