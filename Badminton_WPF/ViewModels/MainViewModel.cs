using Badminton_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Badminton_WPF.ViewModels
{
    public class MainViewModel:ICommand
    {
        public string titel = "Badminton Vlaanderen";
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //returnwaarde true->methode mag uitgevoerd worden
            //returnwaarde false -> methode mag niet uitgevoerd worden
            switch (parameter.ToString())
            {
                case "Admin": return true;
                case "Bezoeker": return true;
         

            }
            return true;
        }

        public void Execute(object parameter)
        {

            switch (parameter.ToString())
            {
                case "Admin": OpenAdminView(); break;
                case "Bezoeker": OpenBezoekerView(); break;
                
               

            }
        }

        public void OpenAdminView()
        {
            LoginViewModel vm = new LoginViewModel();
            Login view = new Login() { Title = $"{titel} | Login" };
            view.DataContext = vm;
            view.Show();
        }


        public void OpenBezoekerView()
        {
            BezoekerViewModel vm = new BezoekerViewModel();
            BezoekerView view = new BezoekerView() { Title = $"{titel} | Bezoeker" };
            view.DataContext = vm;
            view.Show();
        }
    }
}
