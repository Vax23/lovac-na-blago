using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovacNaBlago.Entiteti
{
    public abstract class Zastita
    {

        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string Tip { get; set; }

        public virtual IList<Legenda> Legende { get; set; }
        public virtual IList<Lokacija> Lokacije { get; set; }
        public virtual Definise ImaDef { get; set; }

        public Zastita()
        {
            Legende = new List<Legenda>();
            Lokacije = new List<Lokacija>();
        }
    }

    public class Duh:Zastita
    {

    }

    public class Kletva:Zastita
    {

    }

    public class Zmaj:Zastita
    {

    }
}
