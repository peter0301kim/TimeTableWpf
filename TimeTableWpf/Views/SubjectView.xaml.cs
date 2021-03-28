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

namespace TimeTableWpf.Views
{
    /// <summary>
    /// Interaction logic for SubjectView.xaml
    /// </summary>
    public partial class SubjectView : Page
    {
        SubjectViewModel viewModel;
        public SubjectView()
        {
            InitializeComponent();
            viewModel = new SubjectViewModel();
            viewModel.Navigation = this.NavigationService;
            DataContext = viewModel;
        }
    }
}
