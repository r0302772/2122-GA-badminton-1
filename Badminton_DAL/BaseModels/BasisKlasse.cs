using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Badminton_DAL.BaseModels
{
    public abstract class BasisKlasse : INotifyPropertyChanged,IDataErrorInfo
    {
        public abstract string this[string columnName] { get; }

        

        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Error);

        }

        public string Error
        {

            get
            {
                string foutmeldingen = "";

                foreach (var item in this.GetType().GetProperties())
                {
                    if (item.CanRead)
                    {
                        string fout = this[item.Name];
                        if (!string.IsNullOrWhiteSpace(fout))
                        {
                            foutmeldingen += fout + Environment.NewLine;
                        }
                    }
                }
                return foutmeldingen;
            }
        }


    }
}
