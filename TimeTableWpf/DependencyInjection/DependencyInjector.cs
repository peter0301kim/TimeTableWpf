using TimeTableWpf.Services.LogIn;
using TimeTableWpf.Services.Settings;
using TimeTableWpf.Services.Subject;
using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using RoomNavi_wpf.ViewModel;
using TimeTableWpf.Services.Lecturer;
using TimeTableWpf.Services.LecturerTimeTable;
using TimeTableWpf.Services.TimeTable;

namespace TimeTableWpf
{
    public static class DependencyInjector
    {
        private static TinyIoCContainer _container;

        static DependencyInjector()
        {
            _container = new TinyIoCContainer();

            _container.Register<ISettingsService, SettingsService>();
        }

        public static void UpdateDependencies(bool useMockServices)
        {

            if (useMockServices)
            {
                _container.Register<ILogInService, LogInMockService>();
                _container.Register<ILecturerService, LecturerMockService>();
                _container.Register<ILecturerTimeTableService, LecturerTimeTableMockService>();
                _container.Register<ISubjectService, SubjectMockService>();
                _container.Register<ITimeTableService, TimeTableMockService>();

            }
            else
            {
                _container.Register<ILogInService, LogInService>();
                _container.Register<ILecturerService, LecturerService>();
                _container.Register<ILecturerTimeTableService, LecturerTimeTableService>();
                _container.Register<ISubjectService, SubjectService>();
                _container.Register<ITimeTableService, TimeTableService>();
            }
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
