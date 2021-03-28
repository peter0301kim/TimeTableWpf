using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimeTableWpf.ViewModels.Base;
using TimeTableWpf.Models;
using TimeTableWpf.Services.Lecturer;
using TimeTableWpf.ViewModel.Base;

namespace TimeTableWpf.ViewModel
{
    public class LecturerViewModel : BaseViewModel
    {
        // private string Url = "https://rntwebservice20190404104209.azurewebsites.net/api/lecturer";

        private string Url = "https://rntwebservicefortafesa20190611083115.azurewebsites.net/api/lecturer";

        Lecturer _lecturer = null;

        ILecturerService LecturerService;


        private ObservableCollection<Lecturer> _lecturers;
        public ObservableCollection<Lecturer> Lecturers
        {
            get { return _lecturers; }
            set { SetProperty(ref _lecturers, value); }
        }

        public LecturerViewModel()
        {
            _lecturer = new Lecturer();

            Task.Run(async () => { await GetLecturer(); });
        }

        private string _lecturerId;

        public string LecturerId
        {
            get { return _lecturerId; }
            set { SetProperty(ref _lecturerId, value); }
        }
        private string _givenName;

        public string GivenName
        {
            get { return _givenName; }
            set { SetProperty(ref _givenName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }

        }

        private string _emailAddress;
        public string EmailAddress
        {
            get { return EmailAddress; }
            set { SetProperty(ref _emailAddress, value); }
        }



        private async Task GetLecturer()
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

            string strUrl = Url + "/" + LecturerId;

            
            HttpClient client = new HttpClient();

            try
            {
                string token = SettingsService.AuthAccessToken;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await client.GetStringAsync(strUrl);
                string content = result.ToString();
                //Lecturer lecturer = JsonConvert.DeserializeObject<Lecturer>(content);

                List<Lecturer> results = JsonConvert.DeserializeObject<List<Lecturer>>(content);

                LecturerId = results[0].LecturerId;
                GivenName = results[0].GivenName;
                LastName = results[0].LastName;
                EmailAddress = results[0].EmailAddress;
                
                //lecturers = new ObservableCollection<Lecturer>(results);

                client.Dispose();
            }
            catch (Exception ex)
            {
                string checkResult = "Error " + ex.ToString();
                client.Dispose();
            }
           
        }

        public ICommand CloseCommand => new RelayCommand(async () => await OnClose());

        private async Task OnClose()
        {
        }
    }
}
