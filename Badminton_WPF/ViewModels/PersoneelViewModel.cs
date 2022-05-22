using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badminton_DAL;
using System.Collections.ObjectModel;

namespace Badminton_WPF.ViewModels
{
    public class PersoneelViewModel : BasisViewModel
    {
        #region Properties
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
            Werknemers = new ObservableCollection<Werknemer>(DatabaseOperations.GetWerknemer());
            Functies = new ObservableCollection<Functie>(DatabaseOperations.GetFuncties());
            Clubs = new ObservableCollection<Club>(DatabaseOperations.GetClubs());
            WerknemerRecord = new Werknemer();
            WerknemerRecord.IsGeldig();
        }

        public void WerknemerRecordInstellen()
        {
            if (GeselecteerdeWerknemer != null)
            {
                WerknemerRecord = GeselecteerdeWerknemer;

                //Geslacht = DatabaseOperations.GetGeslachtById(int.Parse(GeselecteerdeSpeler.GeslachtID));
                //SpelerRecord.GeslachtID = GeselecteerdeGeslacht.Id;
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
            //returnwaarde true->methode mag uitgevoerd worden
            //returnwaarde false -> methode mag niet uitgevoerd worden
            //switch (parameter.ToString())
            //{
            //    case "Zoeken": return true;
            //    case "Verwijderen": return true;
            //    case "Toevoegen": return true;
            //    case "Aanpassen": return true;
            //}
            return true;
        }

        public override void Execute(object parameter)
        {

           

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
