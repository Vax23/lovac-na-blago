using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.Mapiranja
{
    public class PredmetMapiranja:ClassMap<DatabaseAccess.Entiteti.Predmet>
    {
        public PredmetMapiranja()
        {
            //Mapiranje tabele
            Table("PREDMET");

            //Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Naziv, "NAZIV");
            //Map(x => x.Tip, "TIP");
            Map(x => x.Materijal, "MATERIJAL");

            //Mapiranje podklasa
            DiscriminateSubClassesOnColumn("TIP");

            //Mapiranje veze 1:N Blago-Predmet
            References(x => x.PripadaBlagu).Column("ID_BLAGA").LazyLoad();
        }
    }
    
    class KnjigaMapiranja : SubclassMap<Knjiga>
    {
        KnjigaMapiranja()
        {
            DiscriminatorValue("Knjiga");
        }
    }

    class MacMapiranja : SubclassMap<Mac>
    {
        MacMapiranja()
        {
            DiscriminatorValue("Mac");
        }
    }

    class KrstMapiranja : SubclassMap<Krst>
    {
        KrstMapiranja()
        {
            DiscriminatorValue("Krst");
        }
    }

    class LobanjaMapiranja : SubclassMap<Lobanja>
    {
        LobanjaMapiranja()
        {
            DiscriminatorValue("Lobanja");
        }
    }
}
