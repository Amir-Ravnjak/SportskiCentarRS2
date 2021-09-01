using System;
using ValueOf;

namespace SportskiCentarRS2.Domain.ValueObjects
{
    public class Kolicina : ValueOf<int,Kolicina>
    {
        protected override void Validate()
        {
            if (Value < 0)
                throw new ArgumentOutOfRangeException("Kolicina", Value, "Količina na stanju ne može biti manja od 0");
        }
    }
}
