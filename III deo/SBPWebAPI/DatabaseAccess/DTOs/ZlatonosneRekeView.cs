using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class ZlatonosneRekeView:ObicnaNalazistaZlataView
    {
        public virtual string ONZImeReke { get; set; }

        public ZlatonosneRekeView()
        {

        }

        public ZlatonosneRekeView(ZlatonosneReke zr):base(zr)
        {
            ONZImeReke = zr.ImeReke;
        }
    }
}
