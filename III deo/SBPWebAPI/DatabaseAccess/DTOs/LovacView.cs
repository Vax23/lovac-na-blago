using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class LovacView
    {
        public int LovacId { get; set; }
        public string LovacIme { get; set; }
        public DateTime LovacPocetakTrazenja { get; set; }
        public DateTime LovacKrajTrazenja { get; set; }

        public  BlagoView Blaga { get; set; }

        public LovacView()
        {

        }

        public LovacView(Lovac l)
        {
            LovacId = l.Id;
            LovacIme = l.Ime;
            LovacPocetakTrazenja = l.PocetakTrazenja;
            LovacKrajTrazenja = l.KrajTrazenja;
        }
    }
}
