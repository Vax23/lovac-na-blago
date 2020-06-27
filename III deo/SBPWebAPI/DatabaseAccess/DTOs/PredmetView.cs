using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class PredmetView
    {
        public int PredmetId { get; set; }
        public string PredmetNaziv { get; set; }
        public string PredmetMaterijal { get; set; }

        public BlagoView Blaga { get; set; }

        public PredmetView()
        {

        }

        public PredmetView(Predmet p)
        {
            PredmetId = p.Id;
            PredmetNaziv = p.Naziv;
            PredmetMaterijal = p.Materijal;
        }
    }
}
