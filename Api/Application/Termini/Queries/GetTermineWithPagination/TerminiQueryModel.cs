using System;

namespace SportskiCentarRS2.Application.Termini.Queries.GetTermineWithPagination
{
    public class TerminiQueryModel
    {
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
        public bool? Slobodan { get; set; }
        public int? ProstorijaId { get; set; }
    }
}
