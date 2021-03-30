using TimeTableWpf.Services.Settings;
using TimeTableWpf.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

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


            string dcFile = GlobalSettings.Instance.DataConnectionSettingsPathFile;
            var dataConnectionSettings = JsonConvert.DeserializeObject<DataConnectionSettings>(System.IO.File.ReadAllText(dcFile));

            DependencyInjector.UpdateDependencies(dataConnectionSettings);

            SettingsService = DependencyInjector.Resolve<ISettingsService>();
        }

    }
}
