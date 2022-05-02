using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Badminton_DAL;



namespace Badminton_WPF.ViewModels
{
    public class SpelerViewModel : BasisViewModel
    {
        public SpelerViewModel()
        {
            Spelers = new ObservableCollection<Speler>(DatabaseOperations.GetSpelers());
       
        }

        private ObservableCollection<Speler> _spelers;

        private Speler _speler;

        public Speler Speler
        {
            get { return _speler; }
            set { _speler = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<Speler> Spelers
        {
            get { return _spelers; }
            set { _spelers = value; NotifyPropertyChanged(); }
        }

        private int _id;
        private string _voornaam;
        private string _familienaam;
        private string _telefoonnummer;
        private string _email;
        private DateTime _geboortedatum;
        private string _geslacht;

        public string Geslacht
        {
            get { return _geslacht; }
            set { _geslacht = value; }
        }


        public DateTime Geboortedatum
        {
            get { return _geboortedatum; }
            set { _geboortedatum = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        public string Telefoonnummer
        {
            get { return _telefoonnummer; }
            set { _telefoonnummer = value; }
        }


        public string Familienaam
        {
            get { return _familienaam; }
            set { _familienaam = value; }
        }


        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


      
        private void SpelerToevoegen()
        {
            


            Speler speler = new Speler();
            Voornaam = speler.Voornaam;
            Familienaam = speler.Familienaam;
            Geboortedatum = speler.Geboortedatum;
            Email = speler.Email;
            Telefoonnummer = speler.Telefoonnummer;


         DatabaseOperations.SpelerToevoegen(speler);
          
               List<Speler> spelers = DatabaseOperations.GetSpelers();
                Spelers = new ObservableCollection<Speler>(spelers);
            
        }

        public void SpelerZoeken()
        {
            List<Speler> spelers = DatabaseOperations.GetSpelers();
            Spelers = new ObservableCollection<Speler>(spelers);
        }
        public override bool CanExecute(object parameter)
        {

            //returnwaarde true -> methode mag uitgevoerd worden
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
                case "Toevoegen": SpelerToevoegen(); break;
               // case "Verwijderen": SpelerVerwijderen(); break;
               // case "Aanpassen": SpelerAandpassen() break;
                case "Zoeken": SpelerZoeken(); break;
            }
        }

    }

    
    
}



