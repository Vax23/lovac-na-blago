using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class LokacijaView
    {
        public int LokacijaId { get; set; }
        public string LokacijaNaziv { get; set; }
        
        public string LokacijaZemlja { get; set; }

        public BlagoView Blaga { get; set; }

        //public virtual IList<LegendaView> Legende { get; set; }
        //public virtual IList<ZastitaView> Zastite { get; set; }
        //public virtual DefiniseView ImaDef { get; set; }
        public LokacijaView()
        {

            //Legende = new List<LegendaView>();
            //Zastite = new List<ZastitaView>();

        }

        public LokacijaView(Lokacija l)
        {
            LokacijaId = l.Id;
            LokacijaNaziv = l.Naziv;
            LokacijaZemlja = l.ZemljaNalazenja;
        }
    }
}
