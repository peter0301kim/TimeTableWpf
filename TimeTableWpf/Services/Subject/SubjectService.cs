using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.Subject
{
    public class SubjectService : ISubjectService
    {
        public SubjectService()
        {

        }

        public async Task<List<Models.Subject>> GetAllSubjectsAsync(string destUrl, string token)
        {
            destUrl += "/null";

            List<Models.Subject> subjects = new List<Models.Subject>();
            try
            {
                var client = new RestClient(destUrl);
                var request = new RestRequest(Method.GET);

                //request.Resource = "{version}/token";

                request.AddHeader("accept", "application/json");
                //request.AddParameter("version", _version, ParameterType.UrlSegment);
                //request.AddParameter("id", subjectId);

                IRestResponse response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.Content.ToString());
                }

                string returnValue = response.Content;

                subjects = JsonConvert.DeserializeObject<List<Models.Subject>>(response.Content);

            }
            catch (Exception e)
            {
                subjects = null;
            }

            return subjects;
        }

        public async Task<List<Models.Subject>> GetAllSubjectsAsync(string destUrl, string token, string subjectId)
        {
            if (subjectId != "null")
            {
                destUrl += $"/{subjectId}";
            }

            List<Models.Subject> subjects = new List<Models.Subject>();
            try
            {
                var client = new RestClient(destUrl);
                var request = new RestRequest(Method.GET);

                //request.Resource = "{version}/token";

                request.AddHeader("accept", "application/json");
                //request.AddParameter("version", _version, ParameterType.UrlSegment);
                request.AddParameter("id", subjectId);

                IRestResponse response = await client.ExecuteAsync(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.Content.ToString());
                }

                string returnValue = response.Content;

                subjects = JsonConvert.DeserializeObject<List<Models.Subject>>(response.Content);

            }
            catch (Exception e)
            {
                subjects= null;
            }

            return subjects;
        }
    }
}
