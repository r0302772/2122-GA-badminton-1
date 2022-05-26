using Badminton_DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Badminton_WPF.Views;
using System.Security;
using System.Security.Cryptography;

namespace Badminton_WPF.ViewModels
{
    public class LoginViewModel : BasisViewModel
    {
      
        public LoginViewModel()
        {
            
        }

        
        private SecureString _SecurePassword;
        public SecureString SecurePassword
        {
            get { return _SecurePassword; }
            set { _SecurePassword = value;
                NotifyPropertyChanged();
            }
        }
        private string _gebruikersnaam;
        public string Gebruikersnaam
        {
            get { return _gebruikersnaam; }
            set { _gebruikersnaam = value;}
        }

    public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public string titel = "Badminton Vlaanderen";
        private void Inloggen()
        {
            if (!CheckLogin())
            {
                MessageBox.Show("Foutieve login");
                return;
            }
            AdminViewModel vm = new AdminViewModel();
            AdminView view = new AdminView() { Title = $"{titel} | Admin" };
            view.DataContext = vm;
            view.Show();
            
           
        }
        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
        private bool CheckLogin()
        {
            string hashedPassword = sha256_hash(SecurePassword.ToString());
            Gebruiker gebruiker = DatabaseOperations.GetGebruikerByName(Gebruikersnaam);
            if(gebruiker!=null) return hashedPassword.Equals(gebruiker.Wachtwoord);
            return false;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Login": return true;
                  
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Login": Inloggen();break;
                 
            }
        }

        
    }
}
