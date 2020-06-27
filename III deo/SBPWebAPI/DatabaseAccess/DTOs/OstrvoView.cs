using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class OstrvoView : LokacijaView
    {
        public OstrvoView()
        {

        }

        public OstrvoView(Lokacija l) : base(l)
        {

        }
    }
}
