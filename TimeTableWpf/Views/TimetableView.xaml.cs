using RoomNavi_wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeTableWpf.ViewModel;

namespace TimeTableWpf.Views
{
    /// <summary>
    /// Interaction logic for TimetableView.xaml
    /// </summary>
    public partial class TimetableView : Page
    {
        TimetableViewModel viewModel;
        public TimetableView()
        {
            InitializeComponent();
            viewModel = new TimetableViewModel();
            viewModel.Navigation = this.NavigationService;
            DataContext = viewModel;
        }
    }
}
