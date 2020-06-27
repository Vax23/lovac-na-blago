using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public abstract class Lokacija
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string ZemljaNalazenja { get; set; }
        public virtual string Tip { get; set; }

        public virtual Blago VezanaZa { get; set; }
        public virtual IList<Legenda> Legende { get; set; }
        public virtual IList<Zastita> Zastite { get; set; }
        public virtual Definise ImaDef { get; set; }

        public Lokacija()
        {
            Legende = new List<Legenda>();
            Zastite = new List<Zastita>();
        }
    }

    public class Grobnica : Lokacija
    {

    }

    public class GradDuhova : Lokacija
    {

    }

    public class Pecina : Lokacija
    {

    }

    public class Ostrvo : Lokacija
    {

    }

    public class Piramida : Lokacija
    {

    }

    public class UkletiZamak : Lokacija
    {

    }
}
