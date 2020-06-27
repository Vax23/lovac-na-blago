using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.Mapiranja
{
    public class LegendaMapiranja:ClassMap<DatabaseAccess.Entiteti.Legenda>
    {
        public LegendaMapiranja()
        {
            //Mapiranje tabele
            Table("LEGENDA");

            //Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Prica, "PRICA");

            //Mapiranje veze 1:N Blago-Legenda
            References(x => x.VezanaZa).Column("ID_BLAGA").LazyLoad();

            //Mapiranje 1:1
            HasOne(x => x.ImaDef).PropertyRef(x => x.DefLegenda);

            //Mapiranje veze M:N Legenda-Zastita
            HasManyToMany(x => x.Zastite)
                .Table("DEFINISE")
                .ParentKeyColumn("ID_LEGENDE")
                .ChildKeyColumn("ID_ZASTITE")
                .Inverse()
                .Cascade.All();

            //Mapiranje veze M:N Legenda-Lokacija
            HasManyToMany(x => x.Lokacije)
                .Table("DEFINISE")
                .ParentKeyColumn("ID_LEGENDE")
                .ChildKeyColumn("ID_LOKACIJE")
                .Inverse()
                .Cascade.All();
            
        }
    }
}
