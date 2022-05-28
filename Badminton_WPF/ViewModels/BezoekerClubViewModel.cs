using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Badminton_DAL;
using System.Windows.Controls;
using System.Windows;

namespace Badminton_WPF.ViewModels
{
    public class BezoekerClubViewModel : BasisViewModel
    {
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
        private string _txtClubnaam;
        public string txtClubnaam
        {
            get { return _txtClubnaam; }
            set
            {
                _txtClubnaam = value;
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
        public BezoekerClubViewModel()
        {
            Clubs = new ObservableCollection<Club>(DatabaseOperations.GetClubs());
            
        }
        public void Zoeken()
        {
            List<Club> clubs = DatabaseOperations.GetClubsByNaam(txtClubnaam);
            Clubs = new ObservableCollection<Club>(clubs);
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
            //returnwaarde true->methode mag uitgevoerd worden
            //returnwaarde false -> methode mag niet uitgevoerd worden
            switch (parameter.ToString())
            {
                case "Zoeken": return true;
                case "ToonDetails":return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {

            switch (parameter.ToString())
            {

                case "Zoeken": Zoeken(); break;
                case "ToonDetails": ToonDetails(); break;
            }
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


        public void ToonDetails()
        {
            if (GeselecteerdeClub == null)
            {
                Foutmelding = "Eerst een club selecteren!";
                return;
            }
            List<Werknemer> werknemers = DatabaseOperations.GetWerknemerByClubId(GeselecteerdeClub.Id);
            List<Speler> spelers = DatabaseOperations.GetSpelerByClubId(GeselecteerdeClub.Id);
            string details = "";
            details += $"Clubnaam:{GeselecteerdeClub.Clubnaam}\n" +
                $"Adres: {GeselecteerdeClub.Adres} {GeselecteerdeClub.Gemeente}\n" +
                $"Opgericht:{GeselecteerdeClub.DatumOpgericht}\n" +
                $"Telefoon: {GeselecteerdeClub.Telefoonnummer}\n" +
                $"Email: {GeselecteerdeClub.Email}\n" +
             $"Aantal spelers: {spelers.Count}\n";

            details += "Voorzitter:\n";
            foreach (var werknemer in werknemers)
            {

                if (werknemer.Functie.Naam.ToLower() == "voorzitter")
                {
                    details += $" {werknemer.Voornaam} {werknemer.Familienaam}\n";
                }



            }

            details += "Contactpersoon:\n";
            foreach (var werknemer in werknemers)
            {

                if (werknemer.Functie.Naam.ToLower() == "contactpersoon")
                {
                    details += $" {werknemer.Voornaam} {werknemer.Familienaam}\n";
                }


            }

            MessageBox.Show(details,$"{GeselecteerdeClub.Clubnaam}");
        }
    }
}
