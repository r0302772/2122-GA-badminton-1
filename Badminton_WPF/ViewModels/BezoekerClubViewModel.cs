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

            }
            return true;
        }

        public override void Execute(object parameter)
        {

            switch (parameter.ToString())
            {

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
