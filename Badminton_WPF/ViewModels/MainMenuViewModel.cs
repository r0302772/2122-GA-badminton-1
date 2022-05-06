using Badminton_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Badminton_WPF.ViewModels
{
    public class MainMenuViewModel : ICommand
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
                case "Clubs": OpenClubsView(); break;
                case "Spelers": OpenSpelersView(); break;
                case "Wedstrijden": OpenWedstrijdenView(); break;
                    
            }
        }

        public void OpenClubsView()
        {
            ClubViewModel vm = new ClubViewModel();
            ClubView view = new ClubView() {Title = $"{titel} | Clubs" };
            view.DataContext = vm;
            view.Show();
        }

        public void OpenWedstrijdenView()
        {

        }

        public void OpenSpelersView()
        {
            SpelerViewModel vm = new SpelerViewModel();
            SpelerView view = new SpelerView() { Title = $"{titel} | Spelers" };
            view.DataContext = vm;
            view.Show();
        }


    }
}
