using System.Threading.Tasks;
using System.Windows.Input;
using TimeTableWpf.ViewModels.Base;
using TimeTableWpf.ViewModel.Base;
using TimeTableWpf.Views;
using TimeTableWpf.ViewModel;
using TimeTableWpf;

namespace RoomNavi_wpf.ViewModel
{
    public class MainViewModel: BaseViewModel
    {

        public MainViewModel()
        {
        }

        //public ICommand SettingsCommand => new Command(async () => await SettingsAsync());

        /*
        private async Task SettingsAsync()
        {

        }
        */

        public ICommand LoginCommand => new RelayCommand(() => OnLoginCommand());
        private void OnLoginCommand()
        {

            Navigation.Navigate("LoginView");
        }

        public ICommand LogoutCommand => new RelayCommand(() => OnLogoutCommand());
        private void OnLogoutCommand()
        {
            SettingsService.AuthAccessToken = "";

        }

        public ICommand SubjectCommand => new RelayCommand(async () => await OnSubjectCommand());
        private async Task OnSubjectCommand()
        {
            if(SettingsService.AuthAccessToken == "")
            {
                OnLoginCommand();
            }
            else
            {
                var viewModel = DependencyInjector.Resolve<SubjectViewModel>();
                Navigation.Navigate(new SubjectView());
            }

        }

        public ICommand TimetableCommand => new RelayCommand(async () => await OnTimetableCommand());
        private async Task OnTimetableCommand()
        {
            if (SettingsService.AuthAccessToken == "")
            {
                OnLoginCommand();
            }
            else
            {
                var viewModel = DependencyInjector.Resolve<TimetableViewModel>();
                Navigation.Navigate(new TimetableView());
            }
        }

        public ICommand LecturerTimetableCommand => new RelayCommand(async () => await OnLecturerTimetableCommand());
        private async Task OnLecturerTimetableCommand()
        {
            if (SettingsService.AuthAccessToken == "")
            {
                OnLoginCommand();
            }
            else
            {
                Navigation.Navigate(new LecturerTimetableView());
            }
        }

        public ICommand CourseCommand => new RelayCommand(async () => await OnCourseCommand());
        private async Task OnCourseCommand()
        {
            /*
            string uri = "https://www.tafesa.edu.au/courses";
            await Browser.OpenAsync(uri, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
            });
            */
        }

        public ICommand LocationCommand => new RelayCommand(async () => await OnLocationCommand());
        private async Task OnLocationCommand()
        {
            /*
            string uri = "https://www.tafesa.edu.au/locations";

            await Browser.OpenAsync(uri, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
            });
            */
        }

    }







}
