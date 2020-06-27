using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Legenda
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string Prica { get; set; }

        public virtual Blago VezanaZa { get; set; }
        public virtual Definise ImaDef { get; set; }
        public virtual IList<Zastita> Zastite { get; set; }
        public virtual IList<Lokacija> Lokacije { get; set; }

        public Legenda()
        {
            Zastite = new List<Zastita>();
            Lokacije = new List<Lokacija>();
        }
    }
}