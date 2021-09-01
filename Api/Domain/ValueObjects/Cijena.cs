using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace SportskiCentarRS2.Domain.ValueObjects
{
    public class Cijena : ValueOf<double,Cijena>
    {
        protected override void Validate()
        {
            if (Value <= 0)
                throw new ArgumentOutOfRangeException("Cijena", Value, "Cijena termina mora biti veća od 0KM.");
        }
    }
}
