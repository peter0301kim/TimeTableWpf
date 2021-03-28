using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.Subject
{
    public class SubjectService : ISubjectService
    {
        private string Url = "https://rntwebservicefortafesa20190611083115.azurewebsites.net/api/subject";

        public SubjectService()
        {

        }

        public async Task<ObservableCollection<Models.Subject>> GetAllSubjectsAsync(string token)
        {
            HttpClient client = new HttpClient();

            string destUrl = Url + "/null";

            var subjects = new ObservableCollection<Models.Subject>();

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await client.GetStringAsync(destUrl); // Call WebAPI

                string content = result.ToString();

                List<Models.Subject> results = JsonConvert.DeserializeObject<List<Models.Subject>>(content);

                subjects = new ObservableCollection<Models.Subject>(results);

                client.Dispose();
            }
            catch (Exception ex)
            {
                string strErr = ex.ToString();
                client.Dispose();

                throw new Exception(strErr);
            }

            return subjects;
        }

        public async Task<ObservableCollection<Models.Subject>> GetAllSubjectsAsync(string subjectId, string token)
        {
            HttpClient client = new HttpClient();

            string destUrl = Url + "/" + subjectId;

            var subjects = new ObservableCollection<Models.Subject>();

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await client.GetStringAsync(destUrl); // Call WebAPI

                string content = result.ToString();

                List<Models.Subject> results = JsonConvert.DeserializeObject<List<Models.Subject>>(content);

                subjects = new ObservableCollection<Models.Subject>(results);

                client.Dispose();
            }
            catch (Exception ex)
            {
                string strErr = ex.ToString();
                client.Dispose();

                throw new Exception(strErr);
            }

            return subjects;
        }
    }
}
