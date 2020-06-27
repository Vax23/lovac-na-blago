using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public abstract class Predmet
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string Tip { get; set; }
        public virtual string Materijal { get; set; }

        public virtual Blago PripadaBlagu { get; set; }

        public Predmet()
        {

        }
    }

    public class Knjiga : Predmet
    {

    }

    public class Mac : Predmet
    {

    }

    public class Krst : Predmet
    {

    }

    public class Lobanja : Predmet
    {

    }
}
