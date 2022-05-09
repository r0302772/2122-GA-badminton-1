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
    public class SpelerViewModel : BasisViewModel
    {
        private Speler _spelerRecord;
        public Speler SpelerRecord
        {
            get { return _spelerRecord; }
            set
            {
                _spelerRecord = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Speler> _spelers;
        public ObservableCollection<Speler> Spelers
        {
            get { return _spelers; }
            set
            {
                _spelers = value;
                NotifyPropertyChanged();
            }
        }

        private Speler _geselecteerdeSpeler;
        public Speler GeselecteerdeSpeler
        {
            get { return _geselecteerdeSpeler; }
            set
            {
                _geselecteerdeSpeler = value;
                SpelerRecordInstellen();
                NotifyPropertyChanged();
            }
        }

        private string _txtVolledigenaam;
        public string txtVolledigenaam
        {
            get { return _txtVolledigenaam; }
            set
            {
                _txtVolledigenaam = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Geslacht> _geslachten;
        public ObservableCollection<Geslacht> Geslachten
        {
            get { return _geslachten; }
            set
            {
                _geslachten = value;
                NotifyPropertyChanged();
            }
        }

        private Geslacht _geselecteerdeGeslacht;
        public Geslacht GeselecteerdeGeslacht
        {
            get { return _geselecteerdeGeslacht; }
            set
            {
                _geselecteerdeGeslacht = value;
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
                NotifyPropertyChanged();
            }
        }

        public SpelerViewModel()
        {
            //Spelers = new ObservableCollection<Speler>(DatabaseOperations.GetSpelers());
            Geslachten = new ObservableCollection<Geslacht>(DatabaseOperations.GetGeslachten());
            Clubs = new ObservableCollection<Club>(DatabaseOperations.GetClubs());
            SpelerRecord = new Speler();

        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        #region overbodige properties? staan in comment
        //private int _id;
        //private string _voornaam;
        //private string _familienaam;
        //private string _telefoonnummer;
        //private string _email;
        //private DateTime _geboortedatum;
        //private string _geslacht;

        //public string Geslacht
        //{
        //    get { return _geslacht; }
        //    set { _geslacht = value; }
        //}

        //public DateTime Geboortedatum
        //{
        //    get { return _geboortedatum; }
        //    set { _geboortedatum = value; }
        //}

        //public string Email
        //{
        //    get { return _email; }
        //    set { _email = value; }
        //}

        //public string Telefoonnummer
        //{
        //    get { return _telefoonnummer; }
        //    set { _telefoonnummer = value; }
        //}

        //public string Familienaam
        //{
        //    get { return _familienaam; }
        //    set { _familienaam = value; }
        //}

        //public string Voornaam
        //{
        //    get { return _voornaam; }
        //    set { _voornaam = value; }
        //}

        //public int Id
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}

        #endregion

        public void ZoekenViaClub()
        {
            List<Speler> spelers = DatabaseOperations.GetSpelerByClubId(GeselecteerdeClub.Id);
            Spelers = new ObservableCollection<Speler>(spelers);
        }

        public void Zoeken()
        {
            List<Speler> spelers = DatabaseOperations.GetSpelersByNaam(txtVolledigenaam);
            Spelers = new ObservableCollection<Speler>(spelers);
        }

        private void Toevoegen()
        {
            if (GeselecteerdeGeslacht.Id != null)
            {

                SpelerRecord.GeslachtID = GeselecteerdeGeslacht.Id;

                if (SpelerRecord.IsGeldig())
                {


                    int ok = DatabaseOperations.SpelerToevoegen(SpelerRecord);
                    if (ok > 0)
                    {
                        Spelers = new ObservableCollection<Speler>(DatabaseOperations.GetSpelers());
                        Wissen();
                    }
                    else
                    {
                        Foutmelding = "Speler is niet toegevoegd!";
                    }
                }
            }
        }

        public void Aanpassen()
        {
            if (GeselecteerdeSpeler != null)
            {
                if (GeselecteerdeSpeler.IsGeldig())
                {
                    int ok = DatabaseOperations.SpelerAanpassen(GeselecteerdeSpeler);
                    if (ok > 0)
                    {
                        Spelers = new ObservableCollection<Speler>(DatabaseOperations.GetSpelersByNaam(GeselecteerdeSpeler.Familienaam));
                        Wissen();
                    }
                    else
                    {
                        Foutmelding = "Speler is niet aangepast!";
                    }
                }
            }
            else
            {
                Foutmelding = "Eerst een speler selecteren!";
            }
        }

        public void Verwijderen()
        {

            if (GeselecteerdeSpeler != null)
            {
                int ok = DatabaseOperations.SpelerVerwijderen(GeselecteerdeSpeler);
                if (ok > 0)
                {
                    Spelers = new ObservableCollection<Speler>(DatabaseOperations.GetSpelers());
                    Wissen();
                }
                else
                {
                    Foutmelding = "Speler is niet verwijderd!";
                }
            }
            else
            {
                Foutmelding = "Eerst een speler selecteren!";
            }

        }

        private void SpelerRecordInstellen()
        {
            if (GeselecteerdeSpeler != null)
            {
                SpelerRecord = GeselecteerdeSpeler;
                //Geslacht = DatabaseOperations.GetGeslachtById(int.Parse(GeselecteerdeSpeler.GeslachtID));
                //SpelerRecord.GeslachtID = GeselecteerdeGeslacht.Id;
            }
            else
            {
                SpelerRecord = new Speler();
            }
        }

        public void Wissen()
        {
            GeselecteerdeSpeler = null;
            SpelerRecordInstellen();
            Foutmelding = "";
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



