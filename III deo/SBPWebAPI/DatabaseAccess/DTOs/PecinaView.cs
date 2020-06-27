using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class PecinaView : LokacijaView
    {
        public PecinaView()
        {

        }

        public PecinaView(Lokacija l) : base(l)
        {

        }
    }
}
