using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public abstract class ObicnaNalazistaZlata
    {
        public virtual int Id { get; protected set; }
        public virtual string Ime { get; set; }
        public virtual string ZemljaNalazenja { get; set; }
        public virtual string ImeNalazaca { get; set; }
        public virtual DateTime DatumOtkrivanja { get; set; }
        public virtual string Tip { get; set; }

        public ObicnaNalazistaZlata()
        {

        }
    }

    public class ZlatneZile : ObicnaNalazistaZlata
    {

    }

    public class ZlatonosneReke : ObicnaNalazistaZlata
    {
        public virtual string ImeReke { get; set; }

        public ZlatonosneReke()
        {

        }
    }
}
