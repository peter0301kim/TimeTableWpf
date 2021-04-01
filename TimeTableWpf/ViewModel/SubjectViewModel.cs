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
using TimeTableWpf;
using System.Collections.Generic;

namespace RoomNavi_wpf.ViewModel
{
    public class SubjectViewModel : BaseViewModel
    {
        ISubjectService SubjectService;

        private string _subjectName;
        public string SubjectName
        {
            get { return _subjectName; }
            set { SetProperty(ref _subjectName, value); }
        }

        private ObservableCollection<Subject> _subjects;
        public ObservableCollection<Subject> Subjects
        {
            get { return _subjects; }
            set { SetProperty(ref _subjects, value); }
        }

        public SubjectViewModel()
        {
            SubjectService = DependencyInjector.Resolve<ISubjectService>();
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            //var value = await SubjectService.GetAllSubjectsAsync(SettingsService.ApiSubjectUrl, "token", "null");

            //Subjects = new ObservableCollection<Subject>(value);

            IsBusy = false;
        }

        public async Task GetAllSubjectsAsyncForTest(string subjectId, string token)
        {
            //var value = await SubjectService.GetAllSubjectsAsync(SettingsService.ApiSubjectUrl, token, subjectId);

            //Subjects = new ObservableCollection<Subject>(value);

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

            try
            {
                var value = await SubjectService.GetAllSubjectsAsync(SettingsService.AuthAccessToken, SettingsService.ApiSubjectUrl, SubjectName);


                Subjects = new ObservableCollection<Subject>(value);

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
        }
    }
}
