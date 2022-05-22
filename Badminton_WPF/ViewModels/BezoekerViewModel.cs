using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badminton_WPF.Views;
using System.Windows.Input;
namespace Badminton_WPF.ViewModels
{
    public class BezoekerViewModel:ICommand
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
               

            }
            return true;
        }

        public void Execute(object parameter)
        {

            switch (parameter.ToString())
            {
                case "Club": OpenClubView(); break;
                //case "Bezoeker": OpenBezoekerView(); break;


            }
        }

        public void OpenClubView()
        {
            BezoekerClubViewModel vm = new BezoekerClubViewModel();
            BezoekerClubView view = new BezoekerClubView() { Title = $"{titel} | Clubs" };
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
