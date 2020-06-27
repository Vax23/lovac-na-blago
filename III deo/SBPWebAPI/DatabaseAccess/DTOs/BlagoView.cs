using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.DTOs;

namespace DatabaseAccess.DTOs
{
    public class BlagoView
    {
        public int BlagoId { get; set; }
        public string BlagoNaziv { get; set; }
        public string BlagoMapa { get; set; }

        
        public virtual IList<PredmetView> Predmeti { get; set; }
        public virtual IList<LegendaView> Legende { get; set; }
        public virtual IList<LokacijaView> Lokacije { get; set; }
        public virtual IList<LovacView> Lovci { get; set; }
        public virtual PorekloView Porekla { get; set; }

        public BlagoView()
        {
            Predmeti = new List<PredmetView>();
            Legende = new List<LegendaView>();
            Lokacije = new List<LokacijaView>();
            Lovci = new List<LovacView>();
        }

        public BlagoView(Blago b)
        {
            BlagoId = b.Id;
            BlagoNaziv = b.Naziv;
            BlagoMapa = b.Mapa;
        }
    }
}
