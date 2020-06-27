using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Lovac
    {
        public virtual int Id { get; protected set; }
        public virtual string Ime { get; set; }
        public virtual DateTime PocetakTrazenja { get; set; }
        public virtual DateTime KrajTrazenja { get; set; }

        public virtual Blago TragaZa { get; set; }

        public Lovac()
        {

        }
    }
}
