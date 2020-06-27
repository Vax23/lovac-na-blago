using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.Mapiranja
{
    public class ZastitaMapiranja:ClassMap<DatabaseAccess.Entiteti.Zastita>
    {
        public ZastitaMapiranja()
        {
            //Mapiranje tabele
            Table("ZASTITA");

            //Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Naziv, "NAZIV");

            //Mapiranje veze M:N Zastita-Legenda
            HasManyToMany(x => x.Legende)
                .Table("DEFINISE")
                .ParentKeyColumn("ID_ZASTITE")
                .ChildKeyColumn("ID_LEGENDE")
                .Cascade.All();

            //Mapiranje veze M:N Zastita-Lokacija
            HasManyToMany(x => x.Lokacije)
                .Table("DEFINISE")
                .ParentKeyColumn("ID_ZASTITE")
                .ChildKeyColumn("ID_LOKACIJE")
                .Inverse()
                .Cascade.All();

            //Mapiranje 1:1 Definise-Zastita
            HasOne(x => x.ImaDef).PropertyRef(x => x.DefZastita);


            //Mapiranje podklase
            DiscriminateSubClassesOnColumn("TIP");
        }
    }

    class DuhMapiranja : SubclassMap<Duh>
    {
        public DuhMapiranja()
        {
            DiscriminatorValue("Duh");
        }
    }

    class KletvaMapiranja : SubclassMap<Kletva>
    {
        public KletvaMapiranja()
        {
            DiscriminatorValue("Kletva");
        }
    }

    class ZmajMapiranja : SubclassMap<Zmaj>
    {
        public ZmajMapiranja()
        {
            DiscriminatorValue("Zmaj");
        }
    }
}
