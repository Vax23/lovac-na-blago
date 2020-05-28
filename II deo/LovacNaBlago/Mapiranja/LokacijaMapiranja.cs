using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LovacNaBlago.Entiteti;

namespace LovacNaBlago.Mapiranja
{
    public class LokacijaMapiranja:ClassMap<LovacNaBlago.Entiteti.Lokacija>
    {
        public LokacijaMapiranja()
        {
            //Mapiranje tabele
            Table("LOKACIJA");

            //Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.ZemljaNalazenja, "ZEMLJA_NALAZENJA");
            //Map(x => x.Tip, "TIP");

            //Mapiranje veze 1:N Blago-Lokacija
            References(x => x.VezanaZa).Column("ID_BLAGA").LazyLoad();

            //Mapiranje veze M:N Lokacija-Legenda
            HasManyToMany(x => x.Legende)
                .Table("DEFINISE")
                .ParentKeyColumn("ID_LOKACIJE")
                .ChildKeyColumn("ID_LEGENDE")
                .Cascade.All();

            //Mapiranje veze M:N Lokacija-Zastita
            HasManyToMany(x => x.Zastite)
                .Table("DEFINISE")
                .ParentKeyColumn("ID_LOKACIJE")
                .ChildKeyColumn("ID_ZASTITE")
                .Cascade.All();

            //Mapiranje 1:1 Lokacija-Definise
            HasOne(x => x.ImaDef).PropertyRef(x => x.DefLokacija);

            //Mapiranje podklasa
            DiscriminateSubClassesOnColumn("TIP");
        }
    }

    class GrobnicaMapiranja : SubclassMap<Grobnica>
    {
        public GrobnicaMapiranja()
        {
            DiscriminatorValue("Grobnica");
        }
    }

    class GradDuhovaMapiranja : SubclassMap<GradDuhova>
    {
        public GradDuhovaMapiranja()
        {
            DiscriminatorValue("Grad duhova");
        }
    }

    class PecinaMapiranja : SubclassMap<Pecina>
    {
        public PecinaMapiranja()
        {
            DiscriminatorValue("Pecina");
        }
    }

    class OstrvoMapiranja : SubclassMap<Ostrvo>
    {
        public OstrvoMapiranja()
        {
            DiscriminatorValue("Ostrvo");
        }
    }

    class PiramidaMapiranja : SubclassMap<Piramida>
    {
        public PiramidaMapiranja()
        {
            DiscriminatorValue("Piramida");
        }
    }

    class UkletiZamakMapiranja : SubclassMap<UkletiZamak>
    {
        public UkletiZamakMapiranja()
        {
            DiscriminatorValue("Ukleti zamak");
        }
    }
}
