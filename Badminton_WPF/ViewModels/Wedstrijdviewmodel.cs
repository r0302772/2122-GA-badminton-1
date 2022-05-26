using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Badminton_DAL;
using Badminton_WPF.Views;

namespace Badminton_WPF.ViewModels
{
    public class Wedstrijdviewmodel : BasisViewModel
    {
        #region members
        
        private ObservableCollection<Wedstrijd> _wedstrijden;
        private ObservableCollection<CategorieSpelerWedstrijd> _categorieSpelerWedstrijden;
        private ObservableCollection<Speler> _spelers;
        private ObservableCollection<Categorie> _categories;
        private Speler _spelerRecordSearch;
        private CategorieSpelerWedstrijd _categorieSpelerWedstrijd;
        private string _foutmelding;
        
        #endregion
        #region getters and setters
        public CategorieSpelerWedstrijd CategorieSpelerWedstrijd
        {
            get { return _categorieSpelerWedstrijd;  }
            set
            {
                _categorieSpelerWedstrijd = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Wedstrijd> Wedstrijden
        {
            get { return _wedstrijden; }
            set { _wedstrijden=value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<CategorieSpelerWedstrijd> CategorieSpelerWedstrijden
        {
            get { return _categorieSpelerWedstrijden;}
            set { _categorieSpelerWedstrijden=value;
            NotifyPropertyChanged();}
        }

        public ObservableCollection<Speler> Spelers
        {
            get { return _spelers; }
            set { _spelers=value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Categorie> Categories
        {
            get { return _categories; }
            set { _categories=value;
                NotifyPropertyChanged();
            }
        }
       
        public string Foutmelding
        {
            get { return _foutmelding; }
            set { _foutmelding=value;
                NotifyPropertyChanged();
            }
        }
        public Speler SpelerRecordSearch
        {
            get { return _spelerRecordSearch; }
            set { _spelerRecordSearch = value;
            NotifyPropertyChanged();}
        }
        #endregion
        //constructor
        public Wedstrijdviewmodel()
        {
            Spelers = new ObservableCollection<Speler>(DatabaseOperations.GetSpelers());
            CategorieSpelerWedstrijden = new ObservableCollection<CategorieSpelerWedstrijd>(DatabaseOperations.GetCategorieSpelerWedstrijden());
            Wedstrijden = new ObservableCollection<Wedstrijd>(DatabaseOperations.GetWedstrijden());
            Categories = new ObservableCollection<Categorie>(DatabaseOperations.GetCategories());
            SpelerRecordSearch = new Speler();

        }
        #region overrides
        public override bool CanExecute(object parameter)
        {

            switch (parameter.ToString())
            {
                case "Zoeken": return true;
                case "OpenToevoegenWedstrijd": return true;
                case "OpenAanpassenWedstrijd": return true;
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
                case "Zoeken": ZoekWedstrijdBySpeler(SpelerRecordSearch); break;
                case "OpenToevoegenwerknemer": OpenToevoegenWedstrijd(); break;
                case "OpenAanpassenWerknemerScherm": OpenAanpassenWedstijd(); break;
                case "Toevoegen": Toevoegen(); break;
                case "Verwijderen": Verwijderen(); break;
                case "Aanpassen": Aanpassen(); break;
            }
        }
        public override string this[string columnName] => "";
        #endregion
        #region methods
        private void ZoekWedstrijdBySpeler(Speler geslecteerdeSpeler)
        {
            throw new NotImplementedException();
        }

        private void OpenToevoegenWedstrijd()
        {
            Wedstrijdviewmodel viewmodel = this;
            WedstrijdToevoegenView view = new WedstrijdToevoegenView() { Title = "Wedstrijd toevoegen" };
            view.DataContext = viewmodel;
            view.Show();
        }

        private void OpenAanpassenWedstijd()
        {
            throw new NotImplementedException();
        }

        private void Aanpassen()
        {
            throw new NotImplementedException();
        }

        private void Verwijderen()
        {
            throw new NotImplementedException();
        }

        private void Toevoegen()
        {
           
        }

        private void Wissen()
        {
            Foutmelding = "";
            
        }
    }
    #endregion
}
