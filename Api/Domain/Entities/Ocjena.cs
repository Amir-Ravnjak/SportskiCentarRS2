using SportskiCentarRS2.Domain.ValueObjects;

namespace SportskiCentarRS2.Domain.Entities
{
    public class Ocjena
    {
        public int Id { get; set; }
        public Rezervacija Rezervacija { get; set; }
        public int RezervacijaId { get; set; }
        public VrijednostOcjene Vrijednost { get; set; }
    }
}
