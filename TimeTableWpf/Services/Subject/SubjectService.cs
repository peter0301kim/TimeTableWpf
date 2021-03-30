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
using TimeTableWpf.Models;

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

            List<Models.Subject> lstSubjects = new List<Models.Subject>();
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

                var apiReturnValue = JsonConvert.DeserializeObject<ApiReturnValue<Subjects>>(response.Content);

                lstSubjects = apiReturnValue.Object.Rows;

            }
            catch (Exception e)
            {
                lstSubjects = null;
            }

            return lstSubjects;
        }

        public async Task<List<Models.Subject>> GetAllSubjectsAsync(string destUrl, string token, string subjectName)
        {
            int pageSize = 100;
            int pageNumber = 1;

            if (string.IsNullOrEmpty(subjectName))
            {
                subjectName = "null";
            }

            destUrl += $"/{subjectName}/{pageSize}/{pageNumber}";

            List<Models.Subject> lstSubjects = new List<Models.Subject>();
            try
            {
                var client = new RestClient(destUrl);
                var request = new RestRequest(Method.GET);

                //request.Resource = "{version}/token";

                request.AddHeader("accept", "application/json");
                //request.AddParameter("subjectName", subjectId);
                //request.AddParameter("pageSize", 100);
                //request.AddParameter("pageNumber", 1);

                IRestResponse response = await client.ExecuteAsync(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.Content.ToString());
                }

                string returnValue = response.Content;

                var apiReturnValue = JsonConvert.DeserializeObject<ApiReturnValue<Subjects>>(response.Content);

                lstSubjects = apiReturnValue.Object.Rows;

            }
            catch (Exception e)
            {
                lstSubjects = null;
            }

            return lstSubjects;
        }
    }
}
