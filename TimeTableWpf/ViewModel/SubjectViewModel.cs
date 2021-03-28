using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TimeTableWpf.ViewModels.Base;
using TimeTableWpf.Services.Subject;
using TimeTableWpf.Models;
using TimeTableWpf.ViewModel.Base;

namespace RoomNavi_wpf.ViewModel
{
    public class SubjectViewModel : BaseViewModel
    {
        ISubjectService _subjectService;

        private string _subjectId;
        private ObservableCollection<Subject> _subjects;

        public string SubjectId
        {
            get { return _subjectId; }
            set { SetProperty(ref _subjectId, value); }
        }


        public ObservableCollection<Subject> subjects
        {
            get { return _subjects; }
            set { SetProperty(ref _subjects, value); }
        }

        public SubjectViewModel()
        {

        }
        public SubjectViewModel(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            subjects = await _subjectService.GetAllSubjectsAsync("null","token");

            IsBusy = false;
        }

        public async Task GetAllSubjectsAsyncForTest(string subjectId, string token)
        {
            subjects = await _subjectService.GetAllSubjectsAsync(subjectId, token);
        }

        public ICommand GetSubjectCommand => new RelayCommand(async () => await GetSubject());

        private async Task GetSubject()
        {
            /*
            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                MessageBoxResult result = MessageBox.Show("Not Connected to Internet", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Question);
                return;
            }
            */
            string tmpSubjectId = "null";

            if(SubjectId == null || SubjectId == "")
            {
                tmpSubjectId = "null";
            }
            else
            {
                tmpSubjectId = SubjectId;
            }

            try
            {
                subjects = await _subjectService.GetAllSubjectsAsync(tmpSubjectId, SettingsService.AuthAccessToken);
            }
            catch (Exception ex)
            {
                string strErr = "Error " + ex.ToString();


                if (strErr.IndexOf("Unauthorized") > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Please, Log in again.", "Unauthorized", MessageBoxButton.OK,MessageBoxImage.Question);
                    SettingsService.AuthAccessToken = "";
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(strErr, "Error", MessageBoxButton.OK, MessageBoxImage.Question);
                }

            }

            

            /*
            HttpClient client = new HttpClient();

            try
            {
                string token = _settingsService.AuthAccessToken;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await client.GetStringAsync(destUrl);
                string content = result.ToString();
                List<Subject> results = JsonConvert.DeserializeObject<List<Subject>>(content);

                subjects = new ObservableCollection<Subject>(results);

                client.Dispose();
            }
            catch (Exception ex)
            {
                string checkResult = "Error " + ex.ToString();
                await DialogService.ShowAlertAsync(checkResult, "Error", "Close");

                if (checkResult.IndexOf("Unauthorized") > 0)
                {
                    _settingsService.AuthAccessToken = "";
                    client.Dispose();

                    await Navigation.PopAsync();
                    return;

                }
                client.Dispose();
            }
            */
        }


    }


}
