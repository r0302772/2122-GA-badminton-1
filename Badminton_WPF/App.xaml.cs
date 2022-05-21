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
            //MainMenuViewModel viewmodel = new MainMenuViewModel();
            //Views.MainMenuWindow view = new Views.MainMenuWindow() { Title = "Badminton Vlaanderen" };
            //view.DataContext = viewmodel;
            //view.Show();

            MainViewModel viewmodel = new MainViewModel();
            Views.MainView view = new Views.MainView() { Title = "Badminton Vlaanderen" };
            view.DataContext = viewmodel;
            view.Show();

            //SpelerViewModel viewmodel = new SpelerViewModel();
            //Views.SpelerView view = new Views.SpelerView() { Title = "Badminton Vlaanderen" };
            //view.DataContext = viewmodel;
            //view.Show();
        }
    }
}
