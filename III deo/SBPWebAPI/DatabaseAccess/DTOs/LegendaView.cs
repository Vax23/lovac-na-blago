using DatabaseAccess.Entiteti;
using System.Collections.Generic;

namespace DatabaseAccess.DTOs
{
    public class LegendaView
    {
        public  int LegendaId { get; set; }
        public  string LegendaNaziv { get; set; }
        public  string LegendaPrica { get; set; }
       
        public BlagoView Blaga { get; set; }
        //public virtual DefiniseView ImaDef { get; set; }
        //public virtual IList<ZastitaView> Zastite { get; set; }
        //public virtual IList<LokacijaView> Lokacije { get; set; }
        

        public LegendaView()
        {
            //Zastite = new List<ZastitaView>();
            //Lokacije = new List<LokacijaView>();
        }

        public LegendaView(Legenda l)
        {
            LegendaId = l.Id;
            LegendaNaziv = l.Naziv;
            LegendaPrica = l.Prica;
        }
    }
}
