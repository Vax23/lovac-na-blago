using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class BlagoNepoznatogPoreklaView:PorekloView
    {
        public BlagoNepoznatogPoreklaView()
        {

        }

        public BlagoNepoznatogPoreklaView(Poreklo p) : base(p)
        {

        }
    }
}
