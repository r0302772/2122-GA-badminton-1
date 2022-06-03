using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Badminton_DAL;
using Badminton_WPF.Views;

namespace Badminton_WPF.ViewModels
{
    public class Wedstrijdviewmodel : BasisViewModel
    {
        #region members

        private WedstrijdAanpassenView _aanpassenView;
        private WedstrijdToevoegenView _toevoegenView;
        private ObservableCollection<Wedstrijd> _wedstrijden;
        private ObservableCollection<CategorieSpelerWedstrijd> _categorieSpelerWedstrijden;
        private ObservableCollection<Speler> _spelers;
        private ObservableCollection<Categorie> _categories;
        private Speler _spelerRecordSearch;
        private CategorieSpelerWedstrijd _categorieSpelerWedstrijd;
        private Wedstrijd _wedstrijd;
        private string _foutmelding;
        private Visibility _textBoxVisibility;
        private Categorie _categorie;


        #endregion
        #region getters and setters

        public WedstrijdToevoegenView ToevoegenView
        {
            get { return _toevoegenView; }
            set { _toevoegenView = value; }
        }
        public WedstrijdAanpassenView AanpassenView
        {
            get { return _aanpassenView; }
            set { _aanpassenView = value; }
        }
        public Categorie Categorie
        {
            get
            {
                return _categorie;
            }
            set
            {
                
                _categorie = value;
                NotifyPropertyChanged();
                if (_categorie != null && _categorie.Naam.ToLower() == "enkel")
                {
                    TextBoxVisibility = Visibility.Hidden;
                    CategorieSpelerWedstrijd.SpelerAway2 = null;
                    CategorieSpelerWedstrijd.SpelerHome2 = null;
                }
                else
                {
                    TextBoxVisibility = Visibility.Visible;
                }
            }
        }
        public Visibility TextBoxVisibility
        {
            get { return _textBoxVisibility; }
            set
            {
                _textBoxVisibility = value;
                NotifyPropertyChanged();
            }
        }
        
        public Wedstrijd Wedstrijd
        {
            get { return _wedstrijd; }
            set { _wedstrijd = value; NotifyPropertyChanged(); }
        }
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
            CategorieSpelerWedstrijd = new CategorieSpelerWedstrijd();
            SpelerRecordSearch = new Speler();
            Wedstrijd = new Wedstrijd();
            TextBoxVisibility = Visibility.Visible;


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
                case "Zoeken": ZoekWedstrijdBySpeler(); break;
                case "OpenToevoegenWedstrijd": OpenToevoegenWedstrijd(); break;
                case "OpenAanpassenWedstrijd": OpenAanpassenWedstijd(); break;
                case "Toevoegen": Toevoegen(); break;
                case "Verwijderen": Verwijderen(); break;
                case "Aanpassen": Aanpassen(); break;
            }
        }
        public override string this[string columnName] => "";
        #endregion
        #region methods
        private void ZoekWedstrijdBySpeler()
        {
            CategorieSpelerWedstrijden = new ObservableCollection<CategorieSpelerWedstrijd>(DatabaseOperations.GetCategorieSpelerWedstrijdBySpelerId(SpelerRecordSearch.Id));
        }

        private void OpenToevoegenWedstrijd()
        {
            Wedstrijdviewmodel viewmodel = this;
            viewmodel.CategorieSpelerWedstrijd = new CategorieSpelerWedstrijd();
            ToevoegenView = new WedstrijdToevoegenView() { Title = "Wedstrijd toevoegen" };
            ToevoegenView.DataContext = viewmodel;
            ToevoegenView.Show();
        }

        private void OpenAanpassenWedstijd()
        {
            if (CategorieSpelerWedstrijd != null)
            {
                Wedstrijdviewmodel viewmodel = this;
                AanpassenView = new WedstrijdAanpassenView() { Title = "Wedstrijd aanpassen" };
                AanpassenView.DataContext = viewmodel;
                AanpassenView.Show();
            }
        }

        private void Aanpassen()
        {
            
                int ok = DatabaseOperations.CategorieSpelerWedstrijdAanpassen(CategorieSpelerWedstrijd);
                if (ok > 0)
                {
                    CategorieSpelerWedstrijden =
                        new ObservableCollection<CategorieSpelerWedstrijd>(DatabaseOperations
                            .GetCategorieSpelerWedstrijden());
                    AanpassenView.Close();
                }
                else
                {
                    Foutmelding = "Wedstrijd is niet aangepast!";
                }

        }

        private void Verwijderen()
        {
            if (CategorieSpelerWedstrijd != null)
            {
                int ok = DatabaseOperations.CategorieSpelerWedstrijdVerwijderen(CategorieSpelerWedstrijd);
                if (ok > 0)
                {
                    CategorieSpelerWedstrijden = new ObservableCollection<CategorieSpelerWedstrijd>(DatabaseOperations.GetCategorieSpelerWedstrijden());
                    Wissen();

                }
                else
                {
                    Foutmelding = "Wedstrijd is niet verwijderd!";
                }
            }
            else
            {
                Foutmelding = "Eerst een Wedstrijd selecteren!";
            }
        }

        private void Toevoegen()
        {

            int wedstrijdKey = DatabaseOperations.WedstrijdToevoegen(Wedstrijd);
            //CategorieSpelerWedstrijd.Wedstrijd = Wedstrijd;
            CategorieSpelerWedstrijd.WedstrijdId = wedstrijdKey;
            DatabaseOperations.CategorieSpelerWedstrijdToevoegen(CategorieSpelerWedstrijd);
            CategorieSpelerWedstrijden =
                new ObservableCollection<CategorieSpelerWedstrijd>(DatabaseOperations
                    .GetCategorieSpelerWedstrijden());
            ToevoegenView.Close();

        }

        private void Wissen()
        {
            Foutmelding = "";
            
        }
    }
    #endregion
}
