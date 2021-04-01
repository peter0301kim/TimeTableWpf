using Newtonsoft.Json;
using TimeTableWpf.Services.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TimeTableWpf.ViewModels.Base;
using TimeTableWpf.Models;
using TimeTableWpf.ViewModel.Base;
using TimeTableWpf.Views;
using TimeTableWpf.Services.TimeTable;

namespace TimeTableWpf.ViewModel
{
    public class TimeTableViewModel : BaseViewModel
    {
        ITimeTableService TimeTableService;

        private string _campus;
        private string _classroom;
        private List<string> _dayofweek;
        private string _selectedDayOfWeek;
        private ObservableCollection<TimeTable> _timetables;

        //private string Url = "https://rntwebservice20190404104209.azurewebsites.net/api/Timetable";

        private string Url = "https://rntwebservicefortafesa20190611083115.azurewebsites.net/api/Timetable";

        public TimeTableViewModel()
        {
            TimeTableService = DependencyInjector.Resolve<ITimeTableService>();

            SetDayOfWeek();
        }

        public void SetDayOfWeek()
        {
            var weekList = new List<string>();
            weekList.Add("Mon");
            weekList.Add("Tue");
            weekList.Add("Wed");
            weekList.Add("Thu");
            weekList.Add("Fri");
            weekList.Add("Sat");
            weekList.Add("Sun");

            Dayofweek = weekList;
        }

        public ObservableCollection<TimeTable> TimeTables
        {
            get { return _timetables; }
            set { SetProperty(ref _timetables, value); }
        }

        public string Campus
        {
            get { return _campus; }
            set { SetProperty(ref _campus, value); }
        }

        public string Classroom
        {
            get { return _classroom; }
            set { SetProperty(ref _classroom, value); }
        }

        public List<string> Dayofweek
        {
            get { return _dayofweek; }
            set { SetProperty(ref _dayofweek, value); }
        }

        public string SelectedDayOfWeek
        {
            get { return _selectedDayOfWeek; }
            set { SetProperty(ref _selectedDayOfWeek, value); }
        }

        public ICommand GetTimeTableCommand => new RelayCommand(async () => await GetTimetable());

        private async Task GetTimetable()
        {
            if(Campus == "" || Campus == null)
            {
                MessageBoxResult result = MessageBox.Show("Please enter campus", "Not Valid", MessageBoxButton.OK, MessageBoxImage.Question);

                return;
            }

            if (Classroom == "" || Classroom == null)
            {
                MessageBoxResult result = MessageBox.Show("Please enter classroom", "Not Valid", MessageBoxButton.OK, MessageBoxImage.Question);
                return;
            }

            if (SelectedDayOfWeek == "" || SelectedDayOfWeek == null)
            {
                MessageBoxResult result = MessageBox.Show("Please choose a day of week", "Not Valid", MessageBoxButton.OK, MessageBoxImage.Question);
                return;
            }
            /*
            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                MessageBoxResult result = MessageBox.Show("Not Connected to Internet", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Question);
                return;
                // Connection to internet is available
            }
            */
            string param = $"/{Campus}/{Classroom}/{SelectedDayOfWeek}";

            try
            {
                var value = await TimeTableService.GetAllTimeTableAsync(SettingsService.AuthAccessToken, SettingsService.ApiTimeTableUrl, param);

                TimeTables = new ObservableCollection<TimeTable>(value);

            }
            catch (Exception ex)
            {
                string strErr = "Error " + ex.ToString();


                if (strErr.IndexOf("Unauthorized") > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Please, Log in again.", "Unauthorized", MessageBoxButton.OK, MessageBoxImage.Question);
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
                List<Timetable> timeTables = JsonConvert.DeserializeObject<List<Timetable>>(content);

                timetables = new ObservableCollection<Timetable>(timeTables);

                client.Dispose();

            }
            catch (Exception ex)
            {
                string checkResult = "Error " + ex.ToString();

                if (checkResult.IndexOf("Unauthorized") > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Unauthorized", "Error", MessageBoxButton.OK, MessageBoxImage.Question);
                    _settingsService.AuthAccessToken = "";
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(checkResult, "Error", MessageBoxButton.OK, MessageBoxImage.Question);
                }
                client.Dispose();
            }
            */

        }


        public ICommand ShowLecturerCommand => new RelayCommand<TimeTable>(async (item) => await OnShowLecturerCommand(item));
        private async Task OnShowLecturerCommand(TimeTable timetable)
        {
            string msg = "Campus" + timetable.LecturerId;


            var viewModel = DependencyInjector.Resolve<LecturerViewModel>();
            viewModel.LecturerId = timetable.LecturerId;

            LecturerView lPage = new LecturerView();
            //lPage.showdi
            Navigation.Navigate(new LecturerView());
        }


    }
}
