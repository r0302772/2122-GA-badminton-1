using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badminton_DAL.BaseModels;

namespace Badminton_DAL
{
    public partial class Speler : BasisKlasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == /*nameof(Voornaam)*/ "Voornaam" && string.IsNullOrWhiteSpace(Voornaam))
                {
                    return "Voornaam is een verplicht veld!";
                }
                if (columnName == /*nameof(Familienaam)*/ "Familienaam" && string.IsNullOrWhiteSpace(Familienaam))
                {
                    return "Familienaam is een verplicht veld!";
                }
                //if (columnName == /*nameof(Geslacht)*/ "Geslacht" && string.IsNullOrWhiteSpace(Geslacht))
                //{
                //    return "Geslacht is een verplicht veld!";
                //}
                if (columnName == /*nameof(Geboortedatum)*/ "Geboortedatum" && string.IsNullOrWhiteSpace(Geboortedatum.ToString()))
                {
                    return "Geboortedatum is een verplicht veld!";
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
