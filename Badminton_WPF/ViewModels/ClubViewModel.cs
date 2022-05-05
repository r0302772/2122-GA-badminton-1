using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_WPF.ViewModels
{
    public class ClubViewModel:BasisViewModel
    {
        public ClubViewModel()
        {

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
                //case "Zoeken": return true;
                //case "Verwijderen": return true;
                //case "Toevoegen": return true;
                //case "Aanpassen": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {

            switch (parameter.ToString())
            {
                //case "Toevoegen": Toevoegen(); break;
                //case "Verwijderen": Verwijderen(); break;
                //case "Aanpassen": Aanpassen(); break;
                //case "Zoeken": Zoeken(); break;
            }
        }
    }
}
