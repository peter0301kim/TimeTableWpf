using MaterialDesignThemes.Wpf;
using TimeTableWpf.Services.LogIn;
using TimeTableWpf.Services.Settings;
using TimeTableWpf.Views;
using TimeTableWpf.ViewModel;
using TimeTableWpf.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeTableWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OnLogIn();
        }

        private void BtnMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            BtnMenuOpen.Visibility = Visibility.Collapsed;
            BtnMenuClose.Visibility = Visibility.Visible;

        }

        private void BtnMenuClose_Click(object sender, RoutedEventArgs e)
        {
            BtnMenuOpen.Visibility = Visibility.Visible;
            BtnMenuClose.Visibility = Visibility.Collapsed;
        }

        private void OnLogIn()
        {
            var settingsService = DependencyInjector.Resolve<ISettingsService>();
            var loginService = DependencyInjector.Resolve<ILogInService>();
            var logInDlg = new LoginView(settingsService, loginService);
            if (logInDlg.ShowDialog().Equals(true))
            {

                // do something here
            }


        }
        private void subjectListItem_DblClick(object sender, MouseButtonEventArgs e)
        {
            this.frmMain.NavigationService.Navigate(new SubjectView());
        }

        private void timetableListItem_DblClick(object sender, MouseButtonEventArgs e)
        {
            this.frmMain.NavigationService.Navigate(new TimetableView());
        }

        private void lecturerListItem_DblClick(object sender, MouseButtonEventArgs e)
        {
            this.frmMain.NavigationService.Navigate(new LecturerTimetableView());
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
