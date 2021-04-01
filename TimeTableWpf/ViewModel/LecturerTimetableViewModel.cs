using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TimeTableWpf.ViewModels.Base;
using TimeTableWpf.Models;
using TimeTableWpf.ViewModel.Base;
using TimeTableWpf.Services.LecturerTimeTable;
using TimeTableWpf;

namespace RoomNavi_wpf.ViewModel
{
    public class LecturerTimetableViewModel : BaseViewModel
    {
        ILecturerTimeTableService LecturerTimeTableService;

        private string _lecturerName;

        private bool _isMon;
        private bool _isTue;
        private bool _isWed;
        private bool _isThu;
        private bool _isFri;

        private ObservableCollection<TimeTable> _timetables;

        private string Url = "https://rntwebservicefortafesa20190611083115.azurewebsites.net/api/LecturerTimetable";

        public LecturerTimetableViewModel()
        {
            LecturerTimeTableService = DependencyInjector.Resolve<ILecturerTimeTableService>();

            IsMon = true;
        }

        public ObservableCollection<TimeTable> TimeTables
        {
            get { return _timetables; }
            set { SetProperty(ref _timetables, value); }
        }

        public string LecturerName
        {
            get { return _lecturerName; }
            set { SetProperty(ref _lecturerName, value); }
        }

        public bool IsMon
        {
            get { return _isMon; }
            set
            {
                if (!value && !IsTue && !IsWed && !IsThu && !IsFri)
                {
                    _isMon = true;
                    SetProperty(ref _isMon, value);
                    return;
                }
                _isMon = value;
                SetProperty(ref _isMon, value);
            }
        }

        public bool IsTue
        {
            get { return _isTue; }
            set
            {
                if (!value && !IsMon && !IsWed && !IsThu && !IsFri)
                {
                    _isTue = true;
                    SetProperty(ref _isTue, value);
                    return;
                }
                _isTue = value;
                SetProperty(ref _isTue, value);
            }
        }

        public bool IsWed
        {
            get { return _isWed; }
            set
            {
                if (!value && !IsMon && !IsTue && !IsThu && !IsFri)
                {
                    _isWed = true;
                    SetProperty(ref _isWed, value);
                    return;
                }
                _isWed = value;
                SetProperty(ref _isWed, value);
            }
        }

        public bool IsThu
        {
            get { return _isThu; }
            set
            {
                if (!value && !IsMon && !IsTue && !IsWed && !IsFri)
                {
                    _isThu = true;
                    SetProperty(ref _isThu, value);
                    return;
                }
                _isThu = value;
                SetProperty(ref _isThu, value);
            }
        }

        public bool IsFri
        {
            get { return _isFri; }
            set
            {
                if (!value && !IsMon && !IsTue && !IsWed && !IsThu)
                {
                    _isFri = true;
                    SetProperty(ref _isFri, value);
                    return;
                }
                _isFri = value;
                SetProperty(ref _isFri, value);
            }
        }

        public ICommand GetLecturerTimeTableCommand => new RelayCommand(async () => await GetLecturerTimeTable());

        private async Task GetLecturerTimeTable()
        {

            if(LecturerName == "" || LecturerName == null)
            {
                MessageBoxResult result = MessageBox.Show("Please enter lecturer's name",
                                          "Info",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Question);

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

            string dayOfWeeks = "";


            if (IsMon) { dayOfWeeks += "1,"; }
            if (IsTue) { dayOfWeeks += "2,"; }
            if (IsWed) { dayOfWeeks += "3,"; }
            if (IsThu) { dayOfWeeks += "4,"; }
            if (IsFri) { dayOfWeeks += "5,"; }

            dayOfWeeks = dayOfWeeks.Remove(dayOfWeeks.Length - 1);

            string param = $"/{LecturerName}/{dayOfWeeks}";

            try
            {
                var value = await LecturerTimeTableService.GetAllLecturerTimeTableAsync(SettingsService.AuthAccessToken, SettingsService.ApiLecturerTimeTableUrl, param);

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
        }

    }
}
