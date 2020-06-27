using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class GrobnicaView : LokacijaView
    {
        public GrobnicaView()
        {

        }

        public GrobnicaView(Lokacija l) : base(l)
        {

        }
    }
}
