using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class DefiniseView
    {
        public  int DefiniseId { get; set; }

        public  LegendaView Legende { get; set; }
        public  LokacijaView Lokacije { get; set; }
        public  ZastitaView Zastite { get; set; }

        public DefiniseView()
        {

        }

        public DefiniseView(Definise d)
        {
            DefiniseId = d.Id;
        }
    }
}
