using System;
using System.Windows;
using TimeTableWpf.Services.LogIn;
using TimeTableWpf.Services.Settings;

namespace TimeTableWpf.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        ISettingsService SettingsService;
        ILogInService LoginService;
        public LoginView(ISettingsService settingsService, ILogInService loginService)
        {
            InitializeComponent();
            this.SettingsService = settingsService;
            this.LoginService = loginService;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClearValue(SizeToContentProperty);
            RootLayout.ClearValue(WidthProperty);
            RootLayout.ClearValue(HeightProperty);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private async void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsService.AuthAccessToken = await LoginService.LoginAsync(txtUserId.Text, txtPassword.Password);

            }
            catch (Exception ex)
            {
                string checkResult = ex.ToString();
                MessageBoxResult result = MessageBox.Show(checkResult, "Error", MessageBoxButton.OK, MessageBoxImage.Question);
            }

            DialogResult = true;
            Close();
        }
    }
}
