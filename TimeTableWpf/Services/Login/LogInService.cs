using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.LogIn
{
    public class LogInService : ILogInService
    {
        private const string Url = "https://identityservice20190424115844.azurewebsites.net/api/RntAppUser/LogIn";

        public async Task<string> LoginAsync(string userId, string password)
        {
            HttpClient client = new HttpClient();

            string AuthAccessToken = "";

            try
            {
                string sContentType = "application/json";

                JObject inputData = new JObject();
                inputData.Add("UserName", userId);
                inputData.Add("Password", password);
                HttpResponseMessage response = await client.PostAsync(
                    Url,
                    new StringContent(inputData.ToString(), Encoding.UTF8, sContentType));

                string content = await response.Content.ReadAsStringAsync();

                var dic_token = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                string token = dic_token["token"];

                AuthAccessToken = token;

                client.Dispose();
            }
            catch (Exception ex)
            {
                string strErr = ex.ToString();
                client.Dispose();

                throw new Exception(strErr);
            }

            return AuthAccessToken;
        }
    }
}
