using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class BlagoNestalihCivilizacijaView : PorekloView
    {
        public virtual string BNCTipCivilizacije { get; set; }

        public BlagoNestalihCivilizacijaView()
        {

        }

        public BlagoNestalihCivilizacijaView(BlagoNestalihCivilizacija b) : base(b)
        {
            BNCTipCivilizacije = b.TipCivilizacije;
        }
    }
}
