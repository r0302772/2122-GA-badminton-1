using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Badminton_WPF.ViewModels;
using Badminton_WPF.Views;

namespace Badminton_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SpelerView spelerView = new SpelerView();
            SpelerViewModel spelerViewModel = new SpelerViewModel();
            spelerView.DataContext = spelerViewModel;
            spelerView.Show();
        }
    }
}
