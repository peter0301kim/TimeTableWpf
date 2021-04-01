using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TimeTableWpf.Models;

namespace TimeTableWpf.Services.TimeTable
{
    public class TimeTableService : ITimeTableService
    {

        public async Task<List<Models.TimeTable>> GetAllTimeTableAsync(string token, string timeTableApiUrl, string param)
        {
            List<Models.TimeTable> timeTables;
            try
            {
                var client = new RestClient(timeTableApiUrl);
                var request = new RestRequest(param, Method.GET);

                request.AddHeader("authorization", "Bearer " + token);
                request.AddHeader("accept", "application/json");

                IRestResponse response = await client.ExecuteAsync(request);
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
            /*




                
            */
        }
    }
