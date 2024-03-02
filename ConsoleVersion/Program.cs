using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
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