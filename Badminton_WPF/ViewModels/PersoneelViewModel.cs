using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badminton_DAL;
using System.Collections.ObjectModel;
using Badminton_WPF.Views;
using System.Windows;

namespace Badminton_WPF.ViewModels
{
    public class PersoneelViewModel : BasisViewModel
    {
        public string titel = "Badminton Vlaanderen";
        #region Properties
        private Functie _functie;
        public Functie functie
        {
            get { return _functie; }
            set { _functie = value;
                NotifyPropertyChanged();
            }
        }

        private Werknemer _werknemerRecord;

        public Werknemer WerknemerRecord
        {
            get { return _werknemerRecord; }
            set
            {
                _werknemerRecord = value;
                NotifyPropertyChanged();
            }
        }
        private ObservableCollection<Werknemer> _werknemers;
        public ObservableCollection<Werknemer> Werknemers
        {
            get { return _werknemers; }
            set
            {
                _werknemers = value;
                NotifyPropertyChanged();
            }
        }


        private Werknemer _geselecteerdeWerknemer;
        public Werknemer GeselecteerdeWerknemer
        {
            get { return _geselecteerdeWerknemer; }
            set
            {
                _geselecteerdeWerknemer = value;
                WerknemerRecordInstellen();
                NotifyPropertyChanged();
            }
        }

        private Club _geselecteerdeClub;

        public Club GeselecteerdeClub
        {
            get { return _geselecteerdeClub; }
            set
            {
                _geselecteerdeClub = value;
                NotifyPropertyChanged();
            }
        }


        private ObservableCollection<Functie> _functies;
        public ObservableCollection<Functie> Functies
        {
            get { return _functies; }
            set
            {
                _functies = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Club> _clubs;
        public ObservableCollection<Club> Clubs
        {
            get { return _clubs; }
            set
            {
                _clubs = value;
                NotifyPropertyChanged();
            }
        }


        #endregion


        public PersoneelViewModel()
        {

            Werknemers = new ObservableCollection<Werknemer>(DatabaseOperations.GetWerknemers());
            Functies = new ObservableCollection<Functie>(DatabaseOperations.GetFuncties());
            Clubs = new ObservableCollection<Club>(DatabaseOperations.GetClubs());
            WerknemerRecord = new Werknemer();
            //WerknemerRecord.IsGeldig();
        }

        public void WerknemerRecordInstellen()
        {
            if (GeselecteerdeWerknemer != null)
            {
                WerknemerRecord = GeselecteerdeWerknemer;
            }

        }
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }
        public override bool CanExecute(object parameter)
        {

            switch (parameter.ToString())
            {
                case "Zoeken": return true;
                case "OpenToevoegenwerknemer": return true;
                case "OpenAanpassenWerknemerScherm": return true;
                case "Toevoegen": return true;
                case "Aanpassen": return true;
                case "Verwijderen": return true;

            }
            return false;
        }

        public override void Execute(object parameter)
        {

            switch (parameter.ToString())
            {
                case "Zoeken": ZoekWerknemerByClub(GeselecteerdeClub); break;
                case "OpenToevoegenwerknemer": OpenToevoegenWerknemerScherm(); break;
                case "OpenAanpassenWerknemerScherm":OpenAanpassenWerknemerScherm(); break;
                case "Toevoegen": Toevoegen(); break;
                case "Verwijderen": Verwijderen(); break;
                case "Aanpassen": Aanpassen(); break;
            }

        }
        
        public void Toevoegen()
        {

            if (WerknemerRecord.IsGeldig())
            {


                int ok = DatabaseOperations.WerknemerToevoegen(WerknemerRecord);
                if (ok > 0)
                {
                    Werknemers = new ObservableCollection<Werknemer>(DatabaseOperations.GetWerknemers());
                    Wissen();
                    MessageBox.Show("Werknemer succesvol toegevoegd aan club", "melding", MessageBoxButton.OK, MessageBoxImage.Information);
                    personeelToevoegenView.Close();
                }
                else
                {
                    Foutmelding = "Werknemer is niet toegevoegd!";
                }
            }

        }

        

        public void Aanpassen()
        {
            if (WerknemerRecord != null)
            {
                if (WerknemerRecord.IsGeldig())
                {
                    int ok = DatabaseOperations.WerknemerAanpassen(WerknemerRecord);
                    if (ok > 0)
                    {
                        Werknemers = new ObservableCollection<Werknemer>(DatabaseOperations.GetWerknemers());
                       personeelAanpassenView.Close();
                    }
                    else
                    {
                        Foutmelding = "Werknemer is niet aangepast!";
                    }
                }
            }
            else
            {
                Foutmelding = "Eerst een Werknemer selecteren!";
            }
        }


        public void Verwijderen()
        {

            if (WerknemerRecord != null)
            {
                int ok = DatabaseOperations.WerknemerVerwijderen(WerknemerRecord);
                if (ok > 0)
                {
                    Werknemers = new ObservableCollection<Werknemer>(DatabaseOperations.GetWerknemers());
                    Wissen();
                }
                else
                {
                    Foutmelding = "Werknemer is niet verwijderd!";
                }
            }
            else
            {
                Foutmelding = "Eerst een werknemer selecteren!";
            }

        }
        public void Wissen()
        {
            GeselecteerdeWerknemer = null;
            WerknemerRecordInstellen();
            Foutmelding = "";
        }

        public void ZoekWerknemerByClub(Club club)
        {

            Werknemers = new ObservableCollection<Werknemer>(DatabaseOperations.GetWerkenemerByClub(club));
            Clubs = new ObservableCollection<Club>(DatabaseOperations.GetClubs());
            Functies = new ObservableCollection<Functie>(DatabaseOperations.GetFuncties());

        }
        

        PersoneelAanpassen personeelAanpassenView  = new PersoneelAanpassen();
        public void OpenAanpassenWerknemerScherm()
        {
            if (WerknemerRecord != null)
            {
                personeelAanpassenView = new PersoneelAanpassen() { Title =$"{titel} | Werknemer aanpassen"};
                

                personeelAanpassenView.DataContext = this;
                personeelAanpassenView.Show();
            }
            else
            {
                Foutmelding = "Gelieven een Werknemer te selecteren!";
            }
           
        }

        PersoneelToevoegenView personeelToevoegenView = new PersoneelToevoegenView();
        public void OpenToevoegenWerknemerScherm()
        {
            personeelToevoegenView = new PersoneelToevoegenView() { Title = $"{titel} | Werknemer toevoegen" };

            personeelToevoegenView.DataContext = this;
            personeelToevoegenView.Show();
        }

        private string _foutmelding;
        public string Foutmelding
        {
            get { return _foutmelding; }
            set
            {
                _foutmelding = value;
                NotifyPropertyChanged();
            }
        }
    }
}
