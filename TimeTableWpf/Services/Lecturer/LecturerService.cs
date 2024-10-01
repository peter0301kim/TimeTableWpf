using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.Lecturer
{
    public class LecturerService : ILecturerService
    {
        public async Task<List<Models.Lecturer>> GetAllLecturerAsync(string timeTableApiUrl, string token)
        {
            List<Models.Lecturer> lecturers;
            try
            {
                var client = new RestClient(timeTableApiUrl);
                var request = new RestRequest(timeTableApiUrl,Method.Get);

                request.AddHeader("authorization", "Bearer " + token);
                request.AddHeader("accept", "application/json");

                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.Content.ToString());
                }
                string responseContent = response.Content;
                lecturers = JsonConvert.DeserializeObject<List<Models.Lecturer>>(responseContent);

            }
            catch (Exception)
            {
                lecturers = null;
            }
            return lecturers;
        }
        /*
        
         
            HttpClient client = new HttpClient();

            try
            {
                string token = SettingsService.AuthAccessToken;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await client.GetStringAsync(strUrl);
                string content = result.ToString();
                //Lecturer lecturer = JsonConvert.DeserializeObject<Lecturer>(content);

                List<Lecturer> results = JsonConvert.DeserializeObject<List<Lecturer>>(content);

                lecturerId = results[0].LecturerId;
                givenName = results[0].GivenName;
                lastName = results[0].LastName;
                emailAddress = results[0].EmailAddress;
                
                //lecturers = new ObservableCollection<Lecturer>(results);

                client.Dispose();
            }
            catch (Exception ex)
            {
                string checkResult = "Error " + ex.ToString();
                client.Dispose();
            }
         
         */
    }
}
