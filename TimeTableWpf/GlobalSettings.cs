using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TimeTableWpf
{
    class GlobalSettings
    {
        public const string AzureTag = "Azure";
        public const string MockTag = "Mock";
        public const string DefaultEndpoint = "http://YOUR_IP_OR_DNS_NAME"; // i.e.: "http://YOUR_IP" or "http://YOUR_DNS_NAME"

        private string _baseIdentityEndpoint;
        private string _baseGatewayShoppingEndpoint;
        private string _baseGatewayMarketingEndpoint;
        public string CurrentDirectory { get; set; }
        public string DataConnectionSettingsPathFile { get; set; }
        public string ApiBaseUrl { get; set; }
        public string LecturerEndPoint { get; set; }
        public string LecturerTimeTableEndPoint { get; set; }
        public string SubjectEndPoint { get; set; }
        public string TimeTableEndPoint { get; set; }
        public GlobalSettings()
        {
            AuthToken = "INSERT AUTHENTICATION TOKEN";

            BaseIdentityEndpoint = DefaultEndpoint;
            BaseGatewayShoppingEndpoint = DefaultEndpoint;
            BaseGatewayMarketingEndpoint = DefaultEndpoint;

            CurrentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            DataConnectionSettingsPathFile = Path.Combine(CurrentDirectory, "DataConnectionSettings.json");

            ApiBaseUrl = "https://localhost:44311";
            LecturerEndPoint = "/api/Lecturer";
            LecturerTimeTableEndPoint = "/api/LecturerTimeTable";
            SubjectEndPoint = "/api/Subject";
            TimeTableEndPoint = "/api/TimeTable";
        }

        public static GlobalSettings Instance { get; } = new GlobalSettings();

        public string BaseIdentityEndpoint
        {
            get { return _baseIdentityEndpoint; }
            set
            {
                _baseIdentityEndpoint = value;
                UpdateEndpoint(_baseIdentityEndpoint);
            }
        }

        public string BaseGatewayShoppingEndpoint
        {
            get { return _baseGatewayShoppingEndpoint; }
            set
            {
                _baseGatewayShoppingEndpoint = value;
                UpdateGatewayShoppingEndpoint(_baseGatewayShoppingEndpoint);
            }
        }

        public string BaseGatewayMarketingEndpoint
        {
            get { return _baseGatewayMarketingEndpoint; }
            set
            {
                _baseGatewayMarketingEndpoint = value;
                UpdateGatewayMarketingEndpoint(_baseGatewayMarketingEndpoint);
            }
        }

        public string ClientId { get { return "xamarin"; } }

        public string ClientSecret { get { return "secret"; } }

        public string AuthToken { get; set; }

        public string RegisterWebsite { get; set; }

        public string AuthorizeEndpoint { get; set; }

        public string UserInfoEndpoint { get; set; }

        public string TokenEndpoint { get; set; }

        public string LogoutEndpoint { get; set; }

        public string Callback { get; set; }

        public string LogoutCallback { get; set; }

        public string GatewayShoppingEndpoint { get; set; }

        public string GatewayMarketingEndpoint { get; set; }

        private void UpdateEndpoint(string endpoint)
        {
            RegisterWebsite = $"{endpoint}/Account/Register";
            LogoutCallback = $"{endpoint}/Account/Redirecting";

            var connectBaseEndpoint = $"{endpoint}/connect";
            AuthorizeEndpoint = $"{connectBaseEndpoint}/authorize";
            UserInfoEndpoint = $"{connectBaseEndpoint}/userinfo";
            TokenEndpoint = $"{connectBaseEndpoint}/token";
            LogoutEndpoint = $"{connectBaseEndpoint}/endsession";

            var baseUri = ExtractBaseUri(endpoint);
            Callback = $"{baseUri}/xamarincallback";
        }

        private void UpdateGatewayShoppingEndpoint(string endpoint)
        {
            GatewayShoppingEndpoint = $"{endpoint}";
        }

        private void UpdateGatewayMarketingEndpoint(string endpoint)
        {
            GatewayMarketingEndpoint = $"{endpoint}";
        }

        private string ExtractBaseUri(string endpoint)
        {
            var uri = new Uri(endpoint);
            var baseUri = uri.GetLeftPart(System.UriPartial.Authority);

            return baseUri;
        }
    }

    public enum ConnectDataMode
    {
        Mock,
        WebAPI
    }
}
