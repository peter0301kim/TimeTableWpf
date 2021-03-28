using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TimeTableWpf.ViewModels.Base;
using TimeTableWpf.ViewModel.Base;
using TimeTableWpf.Services.LogIn;

namespace TimeTableWpf.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private const string Url = "https://identityservice20190424115844.azurewebsites.net/api/RntAppUser/LogIn";
        private const string Url_DbTime = "https://rntwebservicefortafesa20190611083115.azurewebsites.net/api/DBTIME";

        private string _userId;
        private string _password;

        ILogInService _loginService;
        public Window thisWnd;

        public LoginViewModel(ILogInService loginService)
        {
            this._loginService = loginService;

        }

        public LoginViewModel()
        {
            
        }

        public string UserId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public override Task InitializeAsync(object navigationData)
        {
            /*
            if (navigationData is LogoutParameter)
            {
                var logoutParameter = (LogoutParameter)navigationData;

                if (logoutParameter.Logout)
                {
                    Logout();
                }
            }
            */
            return base.InitializeAsync(navigationData);
        }

        public ICommand LogInCommand => new RelayCommand(async () => await OnLogIn());

        private async Task OnLogIn()
        {
            /*
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                MessageBoxResult result = MessageBox.Show("Not Connected to Internet", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Question);
                return;
                // Connection to internet is available
            }
            */

            //Execute 2 database service parallelly
            
            Task task1 = LoginService();
            Task task2 = GetDbTime(); // I get db time when login 1. to give user good performance because the first db access is too slow, 2. when db insert, the time must be correspond with db time.

            await task1;
            await task2;
        }

        public async Task LoginService()
        {
            try
            {
                SettingsService.AuthAccessToken = await _loginService.LoginAsync(UserId, Password);

            }
            catch (Exception ex)
            {
                string checkResult = ex.ToString();
                MessageBoxResult result = MessageBox.Show(checkResult, "Error", MessageBoxButton.OK, MessageBoxImage.Question);
            }

            this.thisWnd.DialogResult = true;
            this.thisWnd.Close();
        }
        private async Task LoginService2()
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                string sContentType = "application/json";

                JObject inputData = new JObject();
                inputData.Add("UserName", UserId);
                inputData.Add("Password", Password);
                HttpResponseMessage response = await httpClient.PostAsync(
                    Url,
                    new StringContent(inputData.ToString(), Encoding.UTF8, sContentType));

                string content = await response.Content.ReadAsStringAsync();
                var dic_token = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                string token = dic_token["token"];

                SettingsService.AuthAccessToken = token;

                httpClient.Dispose();
                //goto Main
            }
            catch (Exception ex)
            {
                string checkResult = ex.ToString();
                MessageBoxResult result = MessageBox.Show(checkResult, "Error", MessageBoxButton.OK, MessageBoxImage.Question);

                httpClient.Dispose();
            }
        }
        private async Task GetDbTime()
        {
            /*
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                MessageBoxResult result = MessageBox.Show("Not Connected to Internet", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Question);

                return;
                // Connection to internet is available
            }
            */

            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(Url_DbTime);
                string content = result.ToString();

                client.Dispose();
            }
            catch (Exception ex)
            {
                string checkResult = ex.ToString();
                MessageBoxResult result = MessageBox.Show(checkResult, "Error", MessageBoxButton.OK, MessageBoxImage.Question);
                client.Dispose();
            }
        }

        public ICommand CancelCommand => new RelayCommand(async () => await OnCancel());

        private async Task OnCancel()
        {
            this.thisWnd.DialogResult = false;
            this.thisWnd.Close();
        }


        
        /*
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        */
    }
}
