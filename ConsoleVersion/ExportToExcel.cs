using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
namespace ConsoleVersion
{
    internal class ExportToExcel
    {
        public static bool AtcListToExcel(List<AtcInfo>? list)
        {
            if (list == null)   return false;
            bool result = false;
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");// 创建一个名称为Sheet1的表;
            IRow row = sheet.CreateRow(0);// 第一行写标题
            row.CreateCell(0).SetCellValue("席位名称"); // 第一列标题
            row.CreateCell(1).SetCellValue("用户编号"); // 第二列标题
            //每一行依次写入
            for (int i = 0; i < list.Count; i++)
            {
                row = sheet.CreateRow(i + 1);   //i+1:从第二行开始写入(第一行可同理写标题)，i从第一行写入
                row.CreateCell(0).SetCellValue(list[i].Callsign);//第一列的值
                row.CreateCell(1).SetCellValue(list[i].UID);//第二列的值
            }
            //文件写入的位置
            using (FileStream fs = File.OpenWrite(@"AtcList.xls"))
            {
                workbook.Write(fs);//向打开的这个xls文件中写入数据  
                result = true;
            }
            return result;
        }
    }
}
