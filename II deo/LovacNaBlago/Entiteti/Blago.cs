using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovacNaBlago.Entiteti
{
    public class Blago
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string Mapa { get; set; }

        public virtual IList<Predmet> Predmeti { get; set; }
        public virtual IList<Legenda> Legende { get; set; }
        public virtual IList<Lokacija> Lokacije { get; set; }
        public virtual IList<Lovac> Lovci { get; set; }
        public virtual Poreklo JePorekla { get; set; }

        public Blago()
        {
            Predmeti = new List<Predmet>();
            Legende = new List<Legenda>();
            Lokacije = new List<Lokacija>();
            Lovci = new List<Lovac>();
        }
    }
}