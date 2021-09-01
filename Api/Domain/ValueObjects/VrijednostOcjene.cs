using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace SportskiCentarRS2.Domain.ValueObjects
{
    public class VrijednostOcjene : ValueOf<int,VrijednostOcjene>
    {
        protected override void Validate()
        {
            if (Value < 0 || Value > 5)
                throw new ArgumentOutOfRangeException("Ocjena", Value, "Ocjena može imati vrijednost od 0 do 5");
        }
    }
}
