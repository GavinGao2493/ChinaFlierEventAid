using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
namespace ConsoleVersion
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string urlAircraftList = "https://map.chinaflier.com/airline_list";
            string urlAtcList = "https://map.chinaflier.com/atc_list";

            try
            {
                string contentAircraftList = await GetWebContent(urlAircraftList);
                string contentAtcList = await GetWebContent(urlAtcList);

                //Console.WriteLine(content);
                AircraftList aircraftList = new AircraftList(contentAircraftList);
                AtcList atcList = new AtcList(contentAtcList);

                List<string> AirportDs = new List<string> { "ZJHK", "ZJSY" };
                List<string> AirportAs = new List<string> { "ZSNB", "ZSHC" };

                ExportToExcel.AtcListToExcel(atcList.GetAtcList(), AirportDs, AirportAs);
                ExportToExcel.AircraftListToExcel(aircraftList.GetAircraftsList());

                List<Aircraft>? selectedAircrafts = aircraftList.GetInGivenAreaAircraft(23.383, 113.302, 0, 45100, 100);
                CheckPoint checkPoint1 = new CheckPoint("CheckPoint1");
                checkPoint1.UpdateCheckedAircraft(selectedAircrafts);
                ExportToExcel.CheckPointToExcel(checkPoint1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
            }
        }
        static async Task<string> GetWebContent(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception($"HTTP 请求失败: {ex.Message}");
                }
            }
        }
    }
}