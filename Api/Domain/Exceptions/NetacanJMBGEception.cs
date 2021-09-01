using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Domain.Exceptions
{
    public class NetacanJMBGEception:Exception
    {
        public NetacanJMBGEception() : base("Unešeni JMBG je netačan, JMBG se sastoji od tačno 13 cifara.")
        {

        }
    }
}
