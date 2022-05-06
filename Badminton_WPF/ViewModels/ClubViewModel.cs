using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Badminton_DAL;
using System.Windows.Controls;

namespace Badminton_WPF.ViewModels
{
    public class ClubViewModel : BasisViewModel
    {
        private Club _clubRecord;
        public Club ClubRecord
        {
            get { return _clubRecord; }
            set
            {
                _clubRecord = value;
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

        private Club _geselecteerdeClub;
        public Club GeselecteerdeClub
        {
            get { return _geselecteerdeClub; }
            set
            {
                _geselecteerdeClub = value;
                ClubRecordInstellen();
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

        public void Zoeken()
        {
            List<Club> clubs = DatabaseOperations.GetClubsByNaam(txtClubnaam);
            Clubs = new ObservableCollection<Club>(clubs);
        }

        private void Toevoegen()
        {
            if (ClubRecord.IsGeldig())
            {
                int ok = DatabaseOperations.ClubToevoegen(ClubRecord);
                if (ok > 0)
                {
                    Clubs = new ObservableCollection<Club>(DatabaseOperations.GetClubs());
                    Wissen();
                }
                else
                {
                    Foutmelding = "Club is niet toegevoegd!";
                }
            }
        }

        public void Aanpassen()
        {
            if (GeselecteerdeClub != null)
            {
                if (GeselecteerdeClub.IsGeldig())
                {
                    int ok = DatabaseOperations.ClubAanpassen(GeselecteerdeClub);
                    if (ok > 0)
                    {
                        Clubs = new ObservableCollection<Club>(DatabaseOperations.GetClubsByNaam(GeselecteerdeClub.Clubnaam));
                        Wissen();
                    }
                    else
                    {
                        Foutmelding = "Club is niet aangepast!";
                    }
                }
            }
            else
            {
                Foutmelding = "Eerst een club selecteren!";
            }
        }

        public void Verwijderen()
        {

            if (GeselecteerdeClub != null)
            {
                int ok = DatabaseOperations.ClubVerwijderen(GeselecteerdeClub);
                if (ok > 0)
                {
                    Clubs = new ObservableCollection<Club>(DatabaseOperations.GetClubs());
                    Wissen();
                }
                else
                {
                    Foutmelding = "Club is niet verwijderd!";
                }
            }
            else
            {
                Foutmelding = "Eerst een club selecteren!";
            }

        }

        private void ClubRecordInstellen()
        {
            if (GeselecteerdeClub != null)
            {
                ClubRecord = GeselecteerdeClub;
            }
            else
            {
                ClubRecord = new Club();
            }
        }

        public void Wissen()
        {
            GeselecteerdeClub = null;
            ClubRecordInstellen();
            Foutmelding = "";
        }

        public ClubViewModel()
        {
            Clubs = new ObservableCollection<Club>(DatabaseOperations.GetClubs());
            ClubRecord = new Club();
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
                case "Verwijderen": return true;
                case "Toevoegen": return true;
                case "Aanpassen": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {

            switch (parameter.ToString())
            {
                case "Toevoegen": Toevoegen(); break;
                case "Verwijderen": Verwijderen(); break;
                case "Aanpassen": Aanpassen(); break;
                case "Zoeken": Zoeken(); break;
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
    }
}
