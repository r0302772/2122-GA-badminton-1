using Badminton_DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Badminton_WPF.ViewModels
{
    public class LoginViewModel : BasisViewModel
    {
        public LoginViewModel()
        {
            
        }

        private Gebruiker _gebruiker;

        public Gebruiker Gebruiker
        {
            get { return _gebruiker; }
            set
            {
                _gebruiker = value;
                NotifyPropertyChanged(nameof(Gebruiker));
                NotifyPropertyChanged(nameof(CheckLogin));
            }
        }

        private ObservableCollection<Gebruiker> _gebruikers;
        public ObservableCollection<Gebruiker> Gebruikers
        {
            get { return _gebruikers; }
            set
            {
                _gebruikers = value;
                NotifyPropertyChanged();
            }
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        private void Inloggen()
        {

        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Inloggen": return true;
                  
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Inloggen": Inloggen();break;
                 
            }
        }

        public void CheckLogin()
        {

            var gebruiker = Gebruikers.Where(x => x.Gebruikernaam == this.Gebruiker.Gebruikernaam).SingleOrDefault();
            if (Gebruiker != null)
            {
                MessageBox.Show("Inloggen mislukt, inloggegevens incorrect!");
            }
            else if (this.Gebruiker.Wachtwoord == Gebruiker.Wachtwoord && this.Gebruiker.Gebruikernaam == Gebruiker.Gebruikernaam)
            {
                MessageBox.Show("Inloggen geslaagd!" + Gebruiker.Gebruikernaam);
            }
            else
            {
                MessageBox.Show("Inloggen mislukt controlleer je login gegevens!");
            }   
        }

        
    }
}
