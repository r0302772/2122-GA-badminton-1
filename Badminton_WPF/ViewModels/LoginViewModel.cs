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

        
        private string _SecurePassword;
        public string SecurePassword
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
            if (Gebruikersnaam==null || SecurePassword ==null)
            {
                MessageBox.Show("Gebruikersnaam en wachtwoord zijn verplicht!","Foutmelding",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
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

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
        private bool CheckLogin()
        {
            
            string source = SecurePassword;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hash = GetHash(sha256Hash, source);

                if (hash != DatabaseOperations.GetGebruikerByName(Gebruikersnaam).Wachtwoord) return false;
                return true;
            }
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
