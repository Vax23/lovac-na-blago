using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entiteti;
using DatabaseAccess.DTOs;

namespace DatabaseAccess.DTOs
{
    public class PorekloView
    {
        public int PorekloId { get; set; }

        //public virtual BlagoView VezanoZa { get; set; }

        public PorekloView()
        {

        }

        public PorekloView(Poreklo p)
        {
            PorekloId = p.Id;
        }
        
    }
}
