using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badminton_DAL.BaseModels;

namespace Badminton_DAL
{
    public partial class Club : BasisKlasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == /*nameof(Clubnaam)*/ "Clubnaam" && string.IsNullOrWhiteSpace(Clubnaam))
                {
                    return "Clubnaam is een verplicht veld!";
                }
                if (columnName == /*nameof(Adres)*/ "Adres" && string.IsNullOrWhiteSpace(Adres))
                {
                    return "Adres is een verplicht veld!";
                }
                if (columnName == /*nameof(Gemeente)*/ "Gemeente" && string.IsNullOrWhiteSpace(Gemeente))
                {
                    return "Gemeente is een verplicht veld!";
                }
                if (columnName == /*nameof(DatumOpgericht)*/ "DatumOpgericht" && string.IsNullOrWhiteSpace(DatumOpgericht.ToString()))
                {
                    return "DatumOpgericht is een verplicht veld!";
                }
                if (columnName == /*nameof(Telefoonnummer)*/ "Telefoonnummer" && string.IsNullOrWhiteSpace(Telefoonnummer))
                {
                    return "Telefoonnummer is een verplicht veld!";
                }
                if (columnName == /*nameof(Email)*/ "Email" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Email is een verplicht veld!";
                }
                return "";
            }
        }
    }
}
