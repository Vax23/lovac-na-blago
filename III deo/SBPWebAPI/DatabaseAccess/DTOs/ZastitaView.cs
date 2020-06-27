using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class ZastitaView
    {
        public int ZastitaId { get; set; }
        public string ZastitaNaziv { get; set; }

        //public virtual IList<LegendaView> Legende { get; set; }
        //public virtual IList<LokacijaView> Lokacije { get; set; }
        //public virtual DefiniseView ImaDef { get; set; }

        public ZastitaView()
        {
            //Legende = new List<LegendaView>();
            //Lokacije = new List<LokacijaView>();
        }

        public ZastitaView(Zastita z)
        {
            ZastitaId = z.Id;
            ZastitaNaziv = z.Naziv;
        }
    }
}
