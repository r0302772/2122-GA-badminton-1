using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_DAL
{
    public partial class Geslacht
    {
        public override bool Equals(object obj)
        {
            return obj is Geslacht geslacht &&
                   Id == geslacht.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
