using Badminton_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Badminton_WPF.ViewModels
{
    class MainViewModel:ICommand
    {
        public string titel = "Badminton Vlaanderen";
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //returnwaarde true->methode mag uitgevoerd worden
            //returnwaarde false -> methode mag niet uitgevoerd worden
            switch (parameter.ToString())
            {
                case "Clubs": return true;
                case "Spelers": return true;
                case "Wedstrijden": return true;

            }
            return true;
        }

        public void Execute(object parameter)
        {

            switch (parameter.ToString())
            {
                case "Admin": OpenAdminView(); break;
                //case "Bezoekers": OpenBezoekersView(); break;
               

            }
        }

        public void OpenAdminView()
        {
            LoginViewModel vm = new LoginViewModel();
            Login view = new Login() { Title = $"{titel} | Login" };
            view.DataContext = vm;
            view.Show();
        }

   
        //public void OpenBezoekersView()
        //{
        //    SpelerViewModel vm = new SpelerViewModel();
        //    SpelerView view = new SpelerView() { Title = $"{titel} | Spelers" };
        //    view.DataContext = vm;
        //    view.Show();
        //}
    }
}
