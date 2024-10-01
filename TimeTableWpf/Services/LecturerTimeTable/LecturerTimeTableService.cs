using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TimeTableWpf.Models;
using TimeTableWpf.Services.Settings;

namespace TimeTableWpf.Services.LecturerTimeTable 
{
    public class LecturerTimeTableService : ILecturerTimeTableService
    {
        public async Task<List<Models.TimeTable>> GetAllLecturerTimeTableAsync(string token, string timeTableApiUrl, string param)
        {
            List<Models.TimeTable> timeTables;
            try
            {
                var client = new RestClient(timeTableApiUrl);
                var request = new RestRequest(param, Method.Get);

                request.AddHeader("authorization", "Bearer " + token);
                request.AddHeader("accept", "application/json");

                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.Content.ToString());
                }

                var apiReturnValue = JsonConvert.DeserializeObject<ApiReturnValue<TimeTables>>(response.Content);
                timeTables = apiReturnValue.Object.Rows;


            }
            catch (Exception)
            {
                timeTables = null;
            }
            return timeTables;
           
        }
    }
}
