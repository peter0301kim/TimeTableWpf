using TimeTableWpf.Services.Settings;
using TimeTableWpf.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TimeTableWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ISettingsService SettingsService;
        public App()
        {
            InitializeComponent();

            DependencyInjector.UpdateDependencies(true);
            SettingsService = DependencyInjector.Resolve<ISettingsService>();

        }

    }
}
